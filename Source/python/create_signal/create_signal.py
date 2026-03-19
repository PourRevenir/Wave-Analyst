import numpy as np
import pandas as pd
import os

def generate_signals(num_samples=1000, sampling_rate=1000):
    """
    生成各种典型的离散时间域信号
    
    参数:
        num_samples: 采样点数
        sampling_rate: 采样率 (Hz)
    
    返回:
        包含所有信号的字典
    """
    # 时间轴
    t = np.arange(num_samples) / sampling_rate
    
    signals = {}
    
    # 1. 单位脉冲序列 (Unit Impulse/Delta Function)
    # δ[n] = 1 when n=0, else 0
    unit_impulse = np.zeros(num_samples)
    unit_impulse[num_samples // 2] = 1  # 在中间放置一个脉冲
    signals['unit_impulse'] = unit_impulse
    
    # 2. 单位阶跃序列 (Unit Step Function)
    # u[n] = 1 for n >= 0, else 0
    unit_step = np.zeros(num_samples)
    unit_step[num_samples // 2:] = 1
    signals['unit_step'] = unit_step
    
    # 3. 矩形脉冲 (Rectangular Pulse)
    # 在中心位置有一个持续一定宽度的矩形脉冲
    rect_pulse = np.zeros(num_samples)
    pulse_width = int(num_samples * 0.1)  # 脉冲宽度为总长度的10%
    start_idx = num_samples // 2 - pulse_width // 2
    end_idx = start_idx + pulse_width
    rect_pulse[start_idx:end_idx] = 1
    signals['rectangular_pulse'] = rect_pulse
    
    # 4. 正弦波 (Sine Wave)
    frequency = 5  # 5 Hz
    sine_wave = np.sin(2 * np.pi * frequency * t)
    signals['sine_wave'] = sine_wave
    
    # 5. 余弦波 (Cosine Wave)
    cosine_wave = np.cos(2 * np.pi * frequency * t)
    signals['cosine_wave'] = cosine_wave
    
    # 6. 方波 (Square Wave)
    square_wave = np.sign(np.sin(2 * np.pi * frequency * t))
    square_wave[square_wave == 0] = 1  # 处理零值
    signals['square_wave'] = square_wave
    
    # 7. 三角波 (Triangular Wave)
    triangle_wave = 2 * np.abs(2 * (t * frequency - np.floor(t * frequency + 0.5))) - 1
    signals['triangular_wave'] = triangle_wave
    
    # 8. 锯齿波 (Sawtooth Wave)
    sawtooth_wave = 2 * (t * frequency - np.floor(t * frequency)) - 1
    signals['sawtooth_wave'] = sawtooth_wave
    
    # 9. 指数衰减信号 (Exponential Decay)
    decay_constant = 0.02
    exponential_decay = np.exp(-decay_constant * np.arange(num_samples))
    signals['exponential_decay'] = exponential_decay
    
    # 10. 复指数信号 (Complex Exponential)
    complex_exp_real = np.real(np.exp(1j * 2 * np.pi * frequency * t))
    complex_exp_imag = np.imag(np.exp(1j * 2 * np.pi * frequency * t))
    signals['complex_exponential_real'] = complex_exp_real
    signals['complex_exponential_imag'] = complex_exp_imag
    
    # 11. 高斯脉冲 (Gaussian Pulse)
    gaussian_center = num_samples // 2
    gaussian_std = num_samples / 20
    gaussian_pulse = np.exp(-((np.arange(num_samples) - gaussian_center) ** 2) / (2 * gaussian_std ** 2))
    signals['gaussian_pulse'] = gaussian_pulse
    
    # 12. sinc函数 (Sinc Function)
    sinc_signal = np.sinc(2 * (t - 0.5))  # 归一化的sinc函数
    signals['sinc_function'] = sinc_signal
    
    # 13. 线性调频信号 (Chirp Signal)
    chirp_signal = np.sin(2 * np.pi * (frequency * t + 2 * t ** 2))
    signals['chirp_signal'] = chirp_signal
    
    # 14. 随机噪声 (Random Noise)
    white_noise = np.random.randn(num_samples)
    signals['white_noise'] = white_noise
    
    # 15. 周期性冲激串 (Periodic Impulse Train)
    impulse_train = np.zeros(num_samples)
    period = num_samples // 10  # 每10个样本一个脉冲
    impulse_train[::period] = 1
    signals['impulse_train'] = impulse_train
    
    return t, signals


def save_to_csv(time_array, signals_dict, output_dir='signal_outputs'):
    """
    将信号保存到CSV文件
    
    参数:
        time_array: 时间数组
        signals_dict: 信号字典
        output_dir: 输出目录
    """
    # 创建输出目录
    if not os.path.exists(output_dir):
        os.makedirs(output_dir)
    
    print(f"正在保存信号到 '{output_dir}' 目录...")
    
    # 为每个信号创建一个单独的CSV文件
    for signal_name, signal_data in signals_dict.items():
        filename = os.path.join(output_dir, f'{signal_name}.csv')
        
        # 创建DataFrame
        df = pd.DataFrame({
            'time': time_array,
            'amplitude': signal_data
        })
        
        # 保存到CSV
        df.to_csv(filename, index=False)
        print(f"  已保存: {filename} ({len(signal_data)} 个数据点)")
    
    # 同时创建一个汇总文件，包含所有信号
    summary_filename = os.path.join(output_dir, 'all_signals_summary.csv')
    summary_df = pd.DataFrame({'time': time_array})
    
    for signal_name, signal_data in signals_dict.items():
        summary_df[signal_name] = signal_data
    
    summary_df.to_csv(summary_filename, index=False)
    print(f"\n  已保存汇总文件: {summary_filename}")
    
    return output_dir


def create_comparison_plot_data(time_array, signals_dict):
    """
    创建用于比较的信号数据（可选功能）
    """
    comparison_data = []
    
    for signal_name, signal_data in signals_dict.items():
        # 计算信号的基本统计特性
        stats = {
            'signal_name': signal_name,
            'mean': np.mean(signal_data),
            'std': np.std(signal_data),
            'max': np.max(signal_data),
            'min': np.min(signal_data),
            'energy': np.sum(signal_data ** 2),
            'rms': np.sqrt(np.mean(signal_data ** 2))
        }
        comparison_data.append(stats)
    
    return pd.DataFrame(comparison_data)


def main():
    """主函数"""
    print("=" * 60)
    print("离散时间域信号生成器")
    print("=" * 60)
    
    # 设置参数
    num_samples = 1000
    sampling_rate = 1000  # Hz
    duration = num_samples / sampling_rate  # 秒
    
    print(f"\n参数设置:")
    print(f"  采样点数: {num_samples}")
    print(f"  采样率: {sampling_rate} Hz")
    print(f"  持续时间: {duration:.2f} 秒")
    print(f"  时间分辨率: {1/sampling_rate*1000:.2f} ms")
    
    # 生成信号
    print("\n正在生成信号...")
    time_array, signals_dict = generate_signals(num_samples, sampling_rate)
    
    print(f"\n生成的信号类型 ({len(signals_dict)} 种):")
    for i, name in enumerate(signals_dict.keys(), 1):
        print(f"  {i:2d}. {name}")
    
    # 保存到CSV
    output_directory = save_to_csv(time_array, signals_dict)
    
    # 创建统计比较数据
    print("\n信号统计特性:")
    stats_df = create_comparison_plot_data(time_array, signals_dict)
    print(stats_df.to_string(index=False))
    
    # 保存统计信息到CSV
    stats_df.to_csv(os.path.join(output_directory, 'signal_statistics.csv'), index=False)
    print(f"\n统计信息已保存到: {os.path.join(output_directory, 'signal_statistics.csv')}")
    
    print("\n" + "=" * 60)
    print("完成! 所有信号已成功保存到CSV文件")
    print("=" * 60)
    
    return output_directory, signals_dict


if __name__ == "__main__":
    output_dir, generated_signals = main()