classdef PseudoRandomSignal < handle
    % PseudoRandomSignal 类（句柄类）
    % 用于生成一种基于多个频率成分的伪随机二值（±1）信号序列

    properties (GetAccess = public, SetAccess = private)
        frequencyList % 输入的频率成分列表，例如 [1, 2, 4]
        nSequence     % 生成的信号序列的总长度（矩阵列数）
    end

    properties (Access = private)
        sequence % 最终生成的伪随机信号序列，元素为 ±1
    end

    methods (Access = public)
        % ===== 构造函数 =====
        function prs = PseudoRandomSignal(frequencyList)
            arguments
                frequencyList (1, :) double = 1  % 默认频率为 1 Hz
            end
            prs.frequencyList = frequencyList;  % 保存频率列表
            prs.MakeSequence();  % 调用方法生成信号序列
        end

        % ===== 重采样方法（生成更长的信号）=====
        function signal = Sampling(prs, n_interpolation, sampling_time)
            arguments
                prs             (1,1) PseudoRandomSignal
                n_interpolation (1,1) double = 1  % 插值倍数
                sampling_time   (1,1) double = 1  % 采样时间倍数
            end

            
            % 通过重复原始序列的元素，生成更长信号
            signal = repmat(repelem(prs.sequence, n_interpolation), ...
                                    1, sampling_time);
        end
    end






    methods (Access = private)
        % ===== 核心：生成伪随机信号序列 =====
        function prs = MakeSequence(prs)
            nFrequency         = length(prs.frequencyList);  % 频率个数
            n_cols_half_matrix = prs.frequencyList(1);       % 初始周期设为第一个频率的周期数
            for i = 2:nFrequency
                % 计算所有频率的最小公倍数，作为基本周期长度
                n_cols_half_matrix = lcm(n_cols_half_matrix, prs.frequencyList(i));
            end
            n_cols_matrix  = n_cols_half_matrix*2;  % 总矩阵宽度（双倍周期？）
            sequenceMatrix = zeros(nFrequency, n_cols_matrix);  % 初始化频率×时间的矩阵
            prs.sequence   = zeros(1, n_cols_matrix);  % 最终信号序列
            prs.nSequence  = n_cols_matrix;  % 信号长度

            % 对每个频率，构造一个周期内的方波模式
            for i = 1:nFrequency
                half_period          = ones(1, n_cols_half_matrix/prs.frequencyList(i));
                pattern              = cat(2, half_period, -half_period);  % 前半为1，后半为-1
                sequenceMatrix(i, :) = repmat(pattern, 1, prs.frequencyList(i));  % 按频率重复
            end

            % 将所有频率的波形叠加后取符号，生成最终 ±1 序列
            prs.sequence = sign(sum(sequenceMatrix, 1));
        end
    end
end