classdef SignalInterval < handle
    properties (GetAccess = public, SetAccess = public)
        signal           
        samplingFrequency 
        samplingTime
        arrayFrequency
    end

    properties (Access = private)
        signal4cal
        sampling_time4cal
        frequency
        amplitude
        markFrequency
        markAmplitude
    end

    methods (Access = public)
        function si = SignalInterval(interval_time)
            arguments
                interval_time (1, 1) double {mustBePositive, mustBeReal} = 1
            end 
            si.samplingTime = interval_time;
        end

        function si = AddSignal(si)
            
        end

    end

    methods (Access = private)
        function si = Spectrum(si)
        
            n = length(si.signal)/2;
            a = fft(si.signal.* hanning(2*n));
            si.frequency = (0:n-1)/si.samplingTime;
            si.amplitude = abs(a(1:n))/n;
        end

        function si = MarkSpectrum(si, nFrequency)
            [~, index] = sort(si.amplitude,'descend');
            index = index(1:nFrequency);
            si.markFrequency = si.frequency(index);
            si.markAmplitude = si.amplitude(index);
        end

        function si = Sampling(si)

        end

        function si = PhaseShift(si)

        end

        function si = MultiFrequency(si)

        end
    end
end