using System;
using System.IO;
using System.Threading;
using WinFormsApp.Log;

//Logger.SetLogDirectory(@"D:\AppLogs\"); // 修改日志目录
//Logger.SetMinLogLevel(LogLevel.WARN);   // 只记录WARN及以上级别的日志
//Logger.SetRotationSettings(20, 10);     // 单个文件最大20MB，保留10个备份

namespace WinFormsApp.Log
{
    /// <summary>
    /// 日志级别枚举
    /// </summary>
    public enum LogLevel
    {
        DEBUG,   // 调试信息
        INFO,    // 常规信息
        WARN,    // 警告
        ERROR,   // 错误
        FATAL    // 严重错误
    }

    /// <summary>
    /// 日志记录工具类
    /// </summary>
    public static class Logger
    {
        // 静态变量，确保线程安全
        private static readonly object _lock = new object();
        private static string _logDirectory = @"C:\Users\Administrator\Desktop\work\Wave-Analyst\Source\WinFormsApp\Log\logs";
        private static LogLevel _minLogLevel = LogLevel.DEBUG;
        private static int _maxFileSizeMB = 10; // 单个日志文件最大10MB
        private static int _maxBackupFiles = 5; // 最多保留5个备份文件

        #region 核心记录方法（各种入参情况）

        /// <summary>
        /// 记录日志（最基本形式）
        /// </summary>
        /// <param name="level">日志级别</param>
        /// <param name="message">日志消息</param>
        public static void Log(LogLevel level, string message)
        {
            if (level < _minLogLevel) return; // 低于最小级别的日志不记录

            string logEntry = FormatLogEntry(level, message);
            WriteToFile(logEntry);
        }

        /// <summary>
        /// 记录带有异常信息的日志
        /// </summary>
        public static void Log(LogLevel level, string message, Exception ex)
        {
            if (level < _minLogLevel) return;

            string detailedMessage = $"{message}{Environment.NewLine}" +
                                   $"异常类型: {ex.GetType().Name}{Environment.NewLine}" +
                                   $"异常消息: {ex.Message}{Environment.NewLine}" +
                                   $"堆栈跟踪: {ex.StackTrace}";

            string logEntry = FormatLogEntry(level, detailedMessage);
            WriteToFile(logEntry);
        }

        /// <summary>
        /// 记录带格式化字符串的日志
        /// </summary>
        public static void Log(LogLevel level, string format, params object[] args)
        {
            if (level < _minLogLevel) return;

            string formattedMessage = string.Format(format, args);
            string logEntry = FormatLogEntry(level, formattedMessage);
            WriteToFile(logEntry);
        }

        #endregion

        #region 便捷方法（快速记录不同级别）

        public static void Debug(string message) => Log(LogLevel.DEBUG, message);
        public static void Debug(string format, params object[] args) => Log(LogLevel.DEBUG, format, args);
        public static void Debug(string message, Exception ex) => Log(LogLevel.DEBUG, message, ex);

        public static void Info(string message) => Log(LogLevel.INFO, message);
        public static void Info(string format, params object[] args) => Log(LogLevel.INFO, format, args);

        public static void Warn(string message) => Log(LogLevel.WARN, message);
        public static void Warn(string message, Exception ex) => Log(LogLevel.WARN, message, ex);
        public static void Warn(string format, params object[] args) => Log(LogLevel.WARN, format, args);

        public static void Error(string message) => Log(LogLevel.ERROR, message);
        public static void Error(string message, Exception ex) => Log(LogLevel.ERROR, message, ex);
        public static void Error(Exception ex) => Log(LogLevel.ERROR, "发生异常", ex);
        public static void Error(string format, params object[] args) => Log(LogLevel.ERROR, format, args);

        public static void Fatal(string message) => Log(LogLevel.FATAL, message);
        public static void Fatal(string message, Exception ex) => Log(LogLevel.FATAL, message, ex);

        #endregion

        #region 私有方法

        /// <summary>
        /// 格式化日志条目
        /// </summary>
        private static string FormatLogEntry(LogLevel level, string message)
        {
            return $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} " +
                   $"[{level.ToString().PadRight(5)}] " +
                   $"[Thread:{Thread.CurrentThread.ManagedThreadId:D3}] " +
                   $"{message}{Environment.NewLine}";
        }

        /// <summary>
        /// 写入文件（包含文件轮转）
        /// </summary>
        private static void WriteToFile(string logEntry)
        {
            lock (_lock) // 确保多线程安全
            {
                try
                {
                    // 确保日志目录存在
                    if (!Directory.Exists(_logDirectory))
                    {
                        Directory.CreateDirectory(_logDirectory);
                    }

                    // 生成当前日志文件名（按日期）
                    string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                    string logFilePath = Path.Combine(_logDirectory, $"app_{currentDate}.log");

                    // 检查文件大小，如果过大则轮转
                    CheckAndRotateFile(logFilePath);

                    // 写入日志
                    File.AppendAllText(logFilePath, logEntry);
                }
                catch (Exception ex)
                {
                    // 如果日志写入本身失败，尝试写入后备位置
                    try
                    {
                        string fallbackPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                                                          "app_fallback.log");
                        File.AppendAllText(fallbackPath,
                                          $"{DateTime.Now}: 日志系统错误 - {ex.Message}{Environment.NewLine}");
                    }
                    catch
                    {
                        // 如果后备位置也失败，则放弃
                    }
                }
            }
        }

        /// <summary>
        /// 检查并轮转日志文件
        /// </summary>
        private static void CheckAndRotateFile(string filePath)
        {
            if (!File.Exists(filePath)) return;

            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Length >= _maxFileSizeMB * 1024 * 1024) // 转换为字节
            {
                // 轮转文件：app_2024-01-01.log -> app_2024-01-01.log.1
                for (int i = _maxBackupFiles - 1; i >= 0; i--)
                {
                    string source = i == 0 ? filePath : $"{filePath}.{i}";
                    string target = $"{filePath}.{i + 1}";

                    if (File.Exists(source))
                    {
                        if (File.Exists(target)) File.Delete(target);
                        File.Move(source, target);
                    }
                }
            }
        }

        #endregion

        #region 配置方法

        /// <summary>
        /// 设置日志目录
        /// </summary>
        public static void SetLogDirectory(string directory)
        {
            lock (_lock)
            {
                _logDirectory = directory;
            }
        }

        /// <summary>
        /// 设置最小日志级别
        /// </summary>
        public static void SetMinLogLevel(LogLevel level)
        {
            lock (_lock)
            {
                _minLogLevel = level;
            }
        }

        /// <summary>
        /// 设置文件轮转参数
        /// </summary>
        public static void SetRotationSettings(int maxFileSizeMB, int maxBackupFiles)
        {
            lock (_lock)
            {
                _maxFileSizeMB = Math.Max(1, maxFileSizeMB);
                _maxBackupFiles = Math.Max(1, maxBackupFiles);
            }
        }

        #endregion
    }
}