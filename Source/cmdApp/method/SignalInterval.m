classdef SignalInterval < handle
    % SignalInterval 类
    % 表示一个信号区间，包括信号数据、采样参数、频谱分析结果等

    properties (GetAccess = public, SetAccess = public)
       signal            (1, :) double = [-1 1]  % 该区间的信号数据
       samplingTime      (1, 1) double = 1       % 该信号的采样时间（秒）
       samplingFrequency (1, 1) double = 2       % 该信号的采样频率
       frequency         (1, :) double           % FFT 后的频率轴
       amplitude         (1, :) double           % FFT 后的幅值
       dominantFrequency (1, :) double         % 主频率成分（幅值最大者）
       dominantAmplitude (1, :) double         % 主频率对应的幅值
    end

    properties (Access = private)
        frequencyList    (1, :) double = 1      % 频率成分列表
        nSignal          (1, 1) double = 2      % 信号长度
    end
	
	

    methods (Access = public)
        % ===== 构造函数：根据频率列表生成信号区间 =====
        function si = SignalInterval(frequency_list, n_interpolation, sampling_time)
            % 内部创建 PseudoRandomSignal 对象并生成信号  --PseudoRandomSignal 
            prs = PseudoRandomSignal(frequency_list);
            si.signal            = prs.Sampling(n_interpolation, sampling_time);
            si.frequencyList     = frequency_list;
            si.samplingTime      = sampling_time;
            si.samplingFrequency = n_interpolation * prs.nSequence;
            si.nSignal           = length(si.signal);
            delete(prs);  % 用完即释放

            % 计算该信号的频谱信息
            si.Spectrum();
            si.MarkSpectrum();
        end



        % ===== 重采样（插值）方法 =====
        function si = Sampling(si, n_interpolation)
            arguments
                si                    SignalInterval
                n_interpolation (1,1) double = 1
            end
            % 提高信号的采样密度（通过重复信号点）
            si.samplingFrequency = n_interpolation * si.samplingFrequency; 
            si.signal            = repelem(si.signal, n_interpolation);
            si.nSignal           = length(si.signal);
            si.Spectrum();       % 重新计算频谱
            si.MarkSpectrum();   % 重新标记主频率
        end
    end



    methods (Access = private)
        % ===== 计算频谱（FFT）=====
        function si = Spectrum(si)
            n = si.nSignal /2;
            a = fft(si.signal); % 快速傅里叶变换
            si.frequency = (0:n-1)/si.samplingTime;  % 频率轴
            si.amplitude = abs(a(1:n))/n;  % 幅值（归一化）
        end

        % ===== 标记主频率（幅值最大的几个频率）=====
        function si = MarkSpectrum(si)
            [~, index] = sort(si.amplitude,'descend');  % 按幅值降序排序
            index = index(1:length(si.frequencyList));  % 取前 N 个（N = 输入频率个数）
            si.dominantFrequency = si.frequency(index);
            si.dominantAmplitude = si.amplitude(index);
        end
		
		
		
    end
end