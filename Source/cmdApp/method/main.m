% Copyright (c) 2024 by Central South University.  
% coding: utf-8                                                     
% Programme written by Yang Yaokun                        
% For more information, contact by email: revenir32@outlook.com 
% Please read the README.md before use. 
% ------------------------------------------

clc
clearvars

% 创建 ChannelTask 对象
ct = ChannelTask();

% 添加两个信号区间：
% 第1个区间：采样时间 2 秒，频率成分 [1, 32]
% 第2个区间：采样时间 2 秒，频率成分 [1, 2, 4, 8, 16, 32]

ct.AddInterval(2, [1 2 4 8 16 32]);

% 绘制总信号的时域与频域图（包含所有区间）
ct.PlotSpectrum();

% 以下为调试代码，可以用来查看内部结构（当前被注释）
% ct.SignalStack{1}
% ct.SignalStack{2}
% % ct.SignalStack{3}
% length(ct.signal)