classdef ChannelTask < handle
    properties (Access = public)
        listInterval cell
    end

    properties (GetAccess = public, SetAccess = private)
        multiSignal       (1, :) double {mustBeInteger} = []
        nSignalInterval   (1, 1) double {mustBeInteger} = 0
        multiSamplingTime (1, 1) double  = 0
        samplingFrequency (1, 1) double {mustBeInteger} = 1
    end

    events
        SweepFrequencyRunner
    end

    methods (Access = public)
        function ct = ChannelTask(signal)
            arguments
                signal (1, 1)  
            end
            ct.samplingFrequency = signal.samplingFrequency;
            if isa(signal, 'SignalInterval')
                ct = ct.AddInterval2Channel(signal);
            elseif isa(signal, 'PseudoRandomSignal')
                ct = ct.AddSignal2Channel(signal);
            else
                assert(false, 'The signal must be a SignalInterval or PseudoRandomSignal.');
            end
        end

        function ct = AddInterval2Channel(ct, si)
            arguments
                ct  (1, 1) ChannelTask
                si  (1, 1) SignalInterval
            end

            ct.nSignalInterval   = ct.nSignalInterval + 1;
            if ct.nSignalInterval == 1
                ct.listInterval      = {si};
            else
                ct.listInterval      = [ct.listInterval, {si}];
            end
            ct.multiSignal       = cat(2, ct.multiSignal, si.signalArray);
            ct.multiSamplingTime = ct.multiSamplingTime + si.samplingTime;

        end

        function ct = AddSignal2Channel(ct, prs)
            arguments
                ct  (1, 1) ChannelTask
                prs (1, 1) PseudoRandomSignal
            end
            assert(ct.samplingFrequency == prs.samplingFrequency, ...
                   'The sampling frequency of the added pseudo random signal must be consistent with the existing signal intervals in the channel task.');

            si = SignalInterval(prs);
            ct = ct.AddInterval2Channel(si);

        end
    end

    methods (Access = public)
        function ct = PlotCompositeSpectrum(ct)
            arguments
                ct              (1, 1) ChannelTask   
            end

            time = linspace(0, ct.multiSamplingTime, length(ct.multiSignal));
            figure('Color', 'w')

            subplot(3, ct.nSignalInterval, 1:ct.nSignalInterval)
            plot(time, ct.multiSignal, 'k' ,'LineWidth', .8)
            grid on
            ax = gca;

            ax.FontSize      = 10;
            ax.XLim          = [0, ct.multiSamplingTime];
            ax.YLim          = [-1.2, 1.2];
            ax.XLabel.String = 't/s';
            ax.YLabel.String = 'Amplitude/A';
            ax.Title.String  = 'Time domain signal';

            for i = 1:ct.nSignalInterval
                si = ct.listInterval{i};
           
                subplot(3, ct.nSignalInterval, ct.nSignalInterval+i)
                semilogx(si.frequency, si.amplitude, 'k' , ...
                    'LineWidth', .8)
                hold on
                grid on
                semilogx(si.dominantFrequency, si.dominantAmplitude, 'ro', ...
                    'MarkerSize', 5)
                ax = gca; 

                ax.FontSize = 10;
                ax.XLabel.String = 'Frequency/Hz';
                if (i == 1)
                    ax.YLabel.String = 'Amplitude/A';
                end
                ax.Title.String = ['Signal ', num2str(i)];
                hold off

                subplot(3, ct.nSignalInterval, ct.nSignalInterval*2+1:ct.nSignalInterval*3)
                colorchar = ['r', 'g', 'b', 'c', 'm', 'y', 'k'];
                semilogx(si.frequency, si.amplitude, colorchar(i), ...
                    'LineWidth', .8, ...
                    'DisplayName', ['Signal ', num2str(i)])

                hold on
                grid on
                semilogx(si.dominantFrequency, si.dominantAmplitude, 'o', ...
                    'MarkerSize', 5, ...
                    'MarkerEdgeColor', 'k', ...
                    'HandleVisibility', 'off')
                ax = gca;

                ax.FontSize = 10;
                ax.XLabel.String = 'Frequency/Hz';
                ax.YLabel.String = 'Amplitude/A';
                ax.Title.String = 'Specturm';
            end

            legend('Location', 'northwest');
     
        end
   
    end
end