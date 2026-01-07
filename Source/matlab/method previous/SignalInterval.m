classdef SignalInterval < handle
    properties (GetAccess = public, SetAccess = private)
        signalArray       (1, :) double {mustBeInteger} = []
        arrayFrequency    (1, :) double  = []
        samplingFrequency (1, 1) double {mustBeInteger} = 1
        samplingTime      (1, 1) double  = 1
        frequency         (1, :) double {mustBeReal} = []
        amplitude         (1, :) double {mustBeReal} = []
        dominantFrequency (1, :) double {mustBeReal} = []
        dominantAmplitude (1, :) double {mustBeReal} = []
    end

    methods (Access = public)
        function si = SignalInterval(prs, frequency_double, sampling_insert, sampling_time)
            arguments
                prs              (1, 1) PseudoRandomSignal
                frequency_double (1, 1) double  = 1
                sampling_insert  (1, 1) double  = 1
                sampling_time    (1, 1) double  = 1

            end

            si.signalArray       = prs.signalArray;
            si.arrayFrequency    = prs.arrayFrequency;
            si.samplingFrequency = prs.samplingFrequency;
            si.samplingTime      = prs.samplingTime;

            if frequency_double > 1
                si = si.DoubleFrequency(frequency_double);
            elseif frequency_double < 1 && frequency_double > 0
                si = si.HalfFrequency(1/frequency_double);
            end

            if sampling_insert >= 1
                si = si.SamplingSignal(sampling_insert, sampling_time);
            end

        end
        
        function si = SamplingSignal(si, n_interpolation, sampling_time)
            arguments
                si (1,1) SignalInterval
                n_interpolation (1,1) double {mustBeInteger} = 1
                sampling_time   (1,1) double  = 1
            end

            si.samplingFrequency = n_interpolation * si.samplingFrequency; 
            si.signalArray       = repelem(si.signalArray, n_interpolation);
            si.SpectrumInterval();
            si.samplingTime      = si.samplingTime * sampling_time;

            if sampling_time > 1
                si.signalArray       = repmat(si.signalArray, 1, sampling_time);
            elseif sampling_time < 1
                si.signalArray       = si.signalArray(1:round(length(si.signalArray)*sampling_time));
            end
            
        end

        function si = DoubleFrequency(si, n_double)
             arguments
                si (1,1) SignalInterval
                n_double (1,1) double {mustBeInteger} = 1
            end

            si.arrayFrequency    = si.arrayFrequency * n_double;
            si.samplingFrequency = si.samplingFrequency * n_double;
            si.signalArray       = repmat(si.signalArray, 1, n_double);
            % si.frequency         = si.frequency * n_double;
            % si.dominantFrequency = si.dominantFrequency * n_double;
            si.SpectrumInterval();

        end

        function si = HalfFrequency(si, n_half)
             arguments
                si (1,1) SignalInterval
                n_half (1,1) double {mustBeInteger} = 1
            end

            si.arrayFrequency    = si.arrayFrequency/n_half;
            si.samplingTime      = si.samplingTime * n_half;
            si.signalArray       = repelem(si.signalArray, n_half);
            si.frequency         = si.frequency / n_half;
            si.dominantFrequency = si.dominantFrequency / n_half;

        end      

    end

    methods (Access = private)
        function si = SpectrumInterval(si)
            arguments
                si (1,1) SignalInterval
            end

            si.SpectrumFFT;
            si.DominantFrequency;

        end

        function SpectrumFFT(si)
            n = length(si.signalArray)/2;
            a = fft(si.signalArray);
            si.frequency = (0:n-1)/si.samplingTime;
            si.amplitude = abs(a(1:n))/n;
        end 

        function DominantFrequency(si)
            [~, index] = sort(si.amplitude,'descend');
            si.dominantFrequency = si.frequency(index(1:length(si.arrayFrequency)));
            si.dominantAmplitude = si.amplitude(index(1:length(si.arrayFrequency)));
        end
    end
end