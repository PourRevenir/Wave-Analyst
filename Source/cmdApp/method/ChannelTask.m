classdef ChannelTask < handle
    % ChannelTask 类（继承自句柄类 handle，支持对象引用传递）
    % 用于管理多个信号区间（SignalInterval），合成总信号，并可绘制时域与频域图像

    properties (Access = public)
        SignalStack              cell      % 元胞数组，存储多个 SignalInterval 信号区间（最多存放5个）
        signal            (1, :) double = []  % 合并后的总信号，一维双精度行向量
        nInterval         (1, 1) double = 0   % 当前管理的信号区间个数
        samplingTime      (1, :) double = []  % 每个信号区间的采样持续时间，为一个向量
        samplingFrequency (1, 1) double = 8   % 合成信号的总采样频率，初始默认为 8 Hz
        figureHandle                        % 用于绘图的图形窗口句柄（当前未使用）
    end

    methods (Access = public)
        % ===== 构造函数 =====
        function ct = ChannelTask()
            % ChannelTask 构造函数，初始化 SignalStack 为一个包含5个空元胞的数组
            ct.SignalStack = cell(1, 5);
        end
		
		

        % ===== 添加一个新的信号区间 =====
        function ct = AddInterval(ct, sampling_time, frequency_list)
            % 输入：
            %   sampling_time：该区间的信号采样时间（秒）
            %   frequency_list：该区间信号包含的频率成分，如 [1, 32]
            %
            % 功能：
            %   创建一个新的 SignalInterval 对象，合成其信号并合并入总信号中

            ct.nInterval = ct.nInterval + 1;  % 区间计数 +1

            % 创建一个 SignalInterval（实际内部会构造 PseudoRandomSignal） --调用SignalInterval
            si = SignalInterval(frequency_list, 4, sampling_time);
			
			
            ct.SignalStack(ct.nInterval) = {si};  % 放入元胞数组中

            % 将当前区间的采样时间加入总时间向量
            ct.samplingTime = cat(2, ct.samplingTime, si.samplingTime);

            % 计算新的采样频率：取当前总频率与新信号频率的最小公倍数
            sampling_Frequency = lcm(ct.samplingFrequency, si.samplingFrequency);
            ct.signal = [];  % 清空原有总信号

            % 对每个已有的信号区间，按照新的采样频率重新采样，并拼接成总信号
            for i = 1:ct.nInterval
                si = ct.SignalStack{i};
                si.Sampling(sampling_Frequency/si.samplingFrequency);
                ct.signal = cat(2, ct.signal, si.signal);
            end
            ct.samplingFrequency = sampling_Frequency;  % 更新总采样频率
        end
		
		
		
		

        % ===== 删除最后一个信号区间 =====
        function ct = RemoveInterval(ct)
            % 功能：当有多个区间时，移除最后一个添加的信号区间

            if ct.nInterval > 1
                % 移除最后一个信号的数据
                ct.signal(end-length(ct.SignalStack{ct.nInterval}.signal)+1:end) = [];
                % 删除最后一个 SignalInterval 对象
                delete(ct.SignalStack{ct.nInterval});
                % 移除对应的采样时间
                ct.samplingTime(ct.nInterval) = [];
                % 区间总数 -1
                ct.nInterval = ct.nInterval - 1;
            end
        end
		
		
		

        % ===== 绘制信号的时域图与频域图 =====
        function ct = PlotSpectrum(ct)
            % 构造总时间轴，用于绘制时域信号
            time = linspace(0, sum(ct.samplingTime), ct.samplingFrequency*sum(ct.samplingTime));
            figure('Color', 'w')  % 新建白色背景的绘图窗口

            % ===== 第一行：时域信号（总）=====
            subplot(3, ct.nInterval, 1:ct.nInterval)
            plot(time, ct.signal, 'k' ,'LineWidth', .8)  % 绘制总信号（黑色实线）
            grid on
            ax = gca;

            ax.FontSize      = 10;
            ax.XLim          = [0, sum(ct.samplingTime)];
            ax.YLim          = [-1.2, 1.2];
            ax.XLabel.String = 't/s';     % 横轴：时间（秒）
            ax.YLabel.String = 'Amplitude/A'; % 纵轴：幅值
            ax.Title.String  = 'Time domain signal'; % 标题

            % ===== 第二行：每个信号区间的频谱图（带主频率红点标记）=====
            for i = 1:ct.nInterval
                si = ct.SignalStack{i};
           
                subplot(3, ct.nInterval, ct.nInterval+i)
                semilogx(si.frequency, si.amplitude, 'k' , ...
                    'LineWidth', .8)
                hold on
                grid on
                semilogx(si.dominantFrequency, si.dominantAmplitude, 'ro', ...
                    'MarkerSize', 5)  % 用红圈标记主频率
                ax = gca; 

                ax.FontSize = 10;
                ax.XLabel.String = 'Frequency/Hz';
                if (i == 1)
                    ax.YLabel.String = 'Amplitude/A';
                end
                ax.Title.String = ['Signal ', num2str(i)];  % 图标题
                hold off

                % ===== 第三行：所有信号频谱的叠加对比（不同颜色）=====
                subplot(3, ct.nInterval, ct.nInterval*2+1:ct.nInterval*3)
                colorchar = ['r', 'g', 'b', 'c', 'm', 'y', 'k'];
                semilogx(si.frequency, si.amplitude, colorchar(i), ...
                    'LineWidth', .8, ...
                    'DisplayName', ['Signal ', num2str(i)])  % 不同颜色区分各信号

                hold on
                grid on
                semilogx(si.dominantFrequency, si.dominantAmplitude, 'o', ...
                    'MarkerSize', 5, ...
                    'MarkerEdgeColor', 'k', ...
                    'HandleVisibility', 'off')  % 主频率标记（无图例）
                ax = gca;

                ax.FontSize = 10;
                ax.XLabel.String = 'Frequency/Hz';
                ax.YLabel.String = 'Amplitude/A';
                ax.Title.String = 'Specturm';  % 注意拼写应为 Spectrum
            end

            legend('Location', 'northwest');  % 添加图例，位置在左上
        end
    end
end