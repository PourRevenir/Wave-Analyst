classdef SignalInterval < handle
    properties (GetAccess = public, SetAccess = public)
        signal
        samplingFrequency
        samplingTime
    end

    properties (Access = private)
        frequency
        amplitude
        featureFrequency
        featureAmplitude
    end

    methods (Access = public)
        function si = SignalInterval(prs, n_interpolation, sampling_time)
            arguments
                prs             (1, 1) PseudoRandomSignal
                n_interpolation (1, 1) double {mustBePositive, mustBeInteger} = 3
                sampling_time   (1, 1) double {mustBePositive, mustBeInteger} = 2
            end
            si.signal            = prs.Sampling(n_interpolation, sampling_time);
            si.samplingFrequency = prs.nSequence * n_interpolation;
            si.samplingTime      = sampling_time;
        end

        function si = AddSignal(si)

        end

    end

    methods (Access = private)
        function si = Spectrum(si)
        
        end

        function si = FeatureSpectrum(si, nFrequency)

        end

        function si = Sampling(si)

        end

        function si = PhaseShift(si)

        end

        function si = MultiFrequency(si)

        end
    end
end