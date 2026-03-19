classdef ChannelTask < handle
    properties (Access = public)
        SignalStack              cell
        nInterval         (1, 1) double = 0
        samplingTime      (1, :) double = []
        samplingFrequency (1, 1) double = 8
        figureHandle           
    end

    methods (Access = public)
        function ct = ChannelTask()
            ct.AddInterval();
        end

        function ct = AddInterval(ct, frequency_list, sampling_time)
            ct.nInterval = ct.nInterval + 1;

            si = SignalInterval();
            ct.SignalStack(ct.nInterval) = {si};

            ct.samplingTime = cat(2, ct.samplingTime, si.samplingTime);
            ct.samplingFrequency = lcm(ct.samplingFrequency, si.samplingFrequency);
            for i = 1:ct.nInterval
                si_temp = ct.SignalStack{i};
                if si_temp.samplingFrequency ~= ct.samplingFrequency
                    si_temp.Sampling(ct.samplingFrequency/si_temp.samplingFrequency);
                end
            end
        end

        function ct = RemoveInterval(ct)
            if ct.nInterval > 1
                delete(ct.SignalStack{ct.nInterval});
                ct.samplingTime(ct.nInterval) = [];
                ct.nInterval = ct.nInterval - 1;
            end
        end

        function ct = PlotSpectrum(ct)
            ct.figureHandle = figure('Name', 'Channel Task', 'NumberTitle', 'off');
            figure(ct.figureHandle);

            signal = ct.SignalStack{1}.signal;

            for i = 1:ct.nInterval
                si = ct.SignalStack{i};
                ax1 = subplot(3, ct.nInterval, ct.nInterval + i);
                semilogx(ax1, si.frequency, si.amplitude, 'k', ...
                    'LineWidth', .8)
                hold on
                grid on
                semilogx(ax1, si.dominantFrequency, si.dominantAmplitude, 'ro', ...
                    'MarkerSize', 5)
                title(['Interval ', num2str(i)]);
                ax1.FontSize = 10;
                ax1.XLabel.String = 'Frequency/Hz';
                if (i == 1)
                    ax.YLabel.String = 'Amplitude/A';
                end
                ax1.Title.String = ['Signal ', num2str(i)];
                hold off

                ax2 = subplot(3, ct.nInterval, ct.nInterval*2+1:ct.nInterval*3);
                colorchar = ['r', 'g', 'b', 'c', 'm', 'y', 'k'];
                semilogx(ax2, si.frequency, si.amplitude, colorchar(i), ...
                    'LineWidth', .8, ...
                    'DisplayName', ['Signal ', num2str(i)])

                hold on
                grid on
                semilogx(si.dominantFrequency, si.dominantAmplitude, 'o', ...
                    'MarkerSize', 5, ...
                    'MarkerEdgeColor', 'k', ...
                    'HandleVisibility', 'off')
                ax.FontSize = 10;
                ax.XLabel.String = 'Frequency/Hz';
                ax.YLabel.String = 'Amplitude/A';
                ax.Title.String = 'Specturm';
                legend('Location', 'northwest');
                hold off

                if i > 1
                    signal = cat(2, signal, si.signal);
                end
            end


        end
    end
end