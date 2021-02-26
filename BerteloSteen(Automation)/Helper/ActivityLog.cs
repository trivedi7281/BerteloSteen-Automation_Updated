using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using System;

namespace DARS.Automation_.Helper
{
    public class ActivityLog
    {
        #region Field

        private static ILog _logger;
        private static ConsoleAppender _consoleAppender;
        private static FileAppender _fileAppender;
        private static RollingFileAppender _rollingFileAppender;
        private static string _layout = "%date{dd-MMM-yyyy-HH:mm:ss} [%class] [%level] [%method]- %message%newline";

        #endregion

        #region Property


        public static string Layout
        {
            set { _layout = value; }
        }

   


        private static PatternLayout GetPatternLayout()
        {
            var patterLayout = new PatternLayout()
            {
                ConversionPattern = _layout

            };
            patterLayout.ActivateOptions();
            return patterLayout;

        }

        private static ConsoleAppender GetConsoleAppender()
        {
            var consoleAppender = new ConsoleAppender()
            {
                Name = "ConsoleAppender",
                Layout = GetPatternLayout(),
                Threshold = Level.Error
            };
            consoleAppender.ActivateOptions();
            return consoleAppender;

        }

        private static FileAppender GetFileAppender()
        {
            var fileAppender = new FileAppender()
            {
                Name = "fileAppender",
                Layout = GetPatternLayout(),
                Threshold = Level.All,
                AppendToFile = true,
                File = "FileLogger.log",
            };
            fileAppender.ActivateOptions();
            return fileAppender;
        }

        private static RollingFileAppender GetRollingFileAppender()
        {
            var rollingAppender = new RollingFileAppender()
            {
                Name = "Rolling File Appender",
                Layout = GetPatternLayout(),
                Threshold = Level.All,
                AppendToFile = true,
                File = "RollingFile.log",
                MaximumFileSize = "1MB",
                MaxSizeRollBackups = 15
            };
            rollingAppender.ActivateOptions();
            return rollingAppender;
        }

        #endregion

        #region

        public static ILog GetLogger(Type type)
        {
            if (_consoleAppender == null)
                _consoleAppender = GetConsoleAppender();

            if (_fileAppender == null)
                _fileAppender = GetFileAppender();

            if (_rollingFileAppender == null)
                _rollingFileAppender = GetRollingFileAppender();

            if(_logger != null)
            {
                return _logger;
            }

            BasicConfigurator.Configure(_consoleAppender, _fileAppender, _rollingFileAppender);
            _logger = LogManager.GetLogger(type);
            return _logger;
        }


        #endregion

    }
}
