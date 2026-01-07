% Copyright (c) 2024 by Central South University.  
% coding: utf-8                                                     
% Programme written by Revenir                            
% For more information, contact by email: yangyaokun@csu.edu.cn.  
% Please read the README.md before use. 
% ------------------------------------------

clc
clearvars

prs1 = PseudoRandomSignal(2, 'prs_an', 2, 2);
% prs2 = PseudoRandomSignal([2 0 1 0 1 0 1 0 1 0 1 0 -1 0 -1 0 -1 0 -1 0 -1], 'pattern', 1, 2);
% prs2.arrayFrequency = [1 9];

si1 = SignalInterval(prs1, 1, 1, 1);
% si2 = SignalInterval(prs2, 1, 16, 1);

ct = ChannelTask(si1);
% ct.AddInterval2Channel(si1);

ct.PlotCompositeSpectrum;
