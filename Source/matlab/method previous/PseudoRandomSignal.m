classdef PseudoRandomSignal < handle
    properties (Access = public)
        samplingFrequency (1, 1) double {mustBeInteger} = 1
        samplingTime      (1, 1) double {mustBeInteger}
        signalArray       (1, :) double {mustBeReal}    = 0
        arrayFrequency    (1, :) double {mustBeInteger} = 1
    end
    
    properties (Access = private)
        nFrequency        (1, 1) double {mustBeInteger} = 1
        sequenceMatrix           double {mustBeInteger}
        sequenceArray     (1, :) double {mustBeInteger} 
        sequenceLength    (1, 1) double {mustBeInteger} = 1
    end

    methods (Access = public)
        function prs = PseudoRandomSignal(array_frequency, method, n_interpolation, sampling_time)
            arguments
                array_frequency (1, :) double {mustBeInteger}
                method                 string = 'default'
                n_interpolation (1, 1) double {mustBeInteger} = 1
                sampling_time   (1, 1) double {mustBeInteger} = 1
            end

            switch method
                case 'prs_an'
                    prs = prs.anArray(array_frequency);
                    prs = prs.PseudoRandomSequence();
                case 'prs_odd'
                    prs = prs.OddHarmonicArray(array_frequency);
                    prs = prs.PseudoRandomSequence();
                case 'pattern'
                    prs = prs.patternSequence(array_frequency);
                otherwise
                    prs.arrayFrequency = array_frequency;
                    prs.nFrequency     = length(prs.arrayFrequency);
                    prs = prs.PseudoRandomSequence();                
            end
            prs = prs.SamplingSignal(n_interpolation, sampling_time);
        end

        function prs = SamplingSignal(prs, n_interpolation, sampling_time)
            arguments
                prs (1,1) PseudoRandomSignal
                n_interpolation (1,1) double {mustBeInteger} = 1
                sampling_time   (1,1) double {mustBeInteger} = 1
            end
            prs.samplingFrequency = n_interpolation*prs.sequenceLength;
            prs.samplingTime      = sampling_time;
            prs.signalArray       = repmat(repelem(prs.sequenceArray, n_interpolation), ...
                                    1, sampling_time);
        end
    end
 
    methods (Access = private)
        function prs = anArray(prs, array_frequency)
            if isscalar(array_frequency)
                array_frequency = cat(2, array_frequency, 2);
            end
            prs.arrayFrequency = array_frequency(2).^((1:array_frequency(1))-1);
            prs.nFrequency     = length(prs.arrayFrequency); 
        end

        function prs = OddHarmonicArray(prs, array_frequency)
            assert(isscalar(array_frequency), 'Number of frequency must be a scalar.');
            prs.arrayFrequency = (1:array_frequency)*2-1;
            prs.nFrequency     = length(prs.arrayFrequency);
        end

        function prs = patternSequence(prs, array_frequency) 
            prs.arrayFrequency = array_frequency(1);
            prs.nFrequency     = 1;

            pattern = array_frequency(2:end);
            prs.sequenceLength = array_frequency(1) * length(pattern);
            prs.sequenceMatrix = repmat(pattern, 1, prs.arrayFrequency);
            prs.sequenceArray  = prs.sequenceMatrix;
        end

        function prs = PseudoRandomSequence(prs)
            prs = prs.CreateMatrix();

            for i = 1:prs.nFrequency
                half_period              = ones(1, 0.5*prs.sequenceLength/prs.arrayFrequency(i));
                pattern                  = cat(2, half_period, -half_period);
                prs.sequenceMatrix(i, :) = repmat(pattern, 1, prs.arrayFrequency(i));
            end

            prs = prs.SignalMatrix2Sequence();          
        end

        function prs = CreateMatrix(prs)
            n_cols_half_matrix = prs.arrayFrequency(1);

            for i = 2:length(prs.arrayFrequency)
                n_cols_half_matrix = lcm(n_cols_half_matrix, prs.arrayFrequency(i));
            end

            prs.sequenceLength = n_cols_half_matrix*2;
            prs.sequenceMatrix = zeros(prs.nFrequency, prs.sequenceLength);
            prs.sequenceArray  = zeros(1, prs.sequenceLength);
        end

        function prs = SignalMatrix2Sequence(prs)
            prs.sequenceArray = sign(sum(prs.sequenceMatrix, 1));
        end
    end

end