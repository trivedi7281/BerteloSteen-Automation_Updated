using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DARS.Automation_.Utilities
{ 
[TestFixture]
public class TestLogger
    {
        //1. to create the layout of the logger.
        //2. Use this layout in the appender.
        //3. Inititalize the Configuration.
        //4. Get the Instance of the Logger.
        [TestCase]
        public void Log4Net() { 
        
            var patterLayout = new PatternLayout();
            patterLayout.ConversionPattern = "%date{dd-MMM-yyyy-HH:mm:ss} [%class] [%level] [%method]- %message%newline";
            patterLayout.ActivateOptions();

            var consoleAppender = new ConsoleAppender()
            {
                Name = "ConsoleAppender",
                Layout = patterLayout,
                Threshold = Level.All
            };


            var fileAppender = new FileAppender()
            {
                Name = "fileAppender",
                Layout = patterLayout,
                Threshold = Level.All,
                AppendToFile = true,
                File = "FileLogger.log",
            };

            consoleAppender.ActivateOptions();
            fileAppender.ActivateOptions();

            BasicConfigurator.Configure(consoleAppender , fileAppender);

            ILog logger = LogManager.GetLogger(typeof(TestLogger));

            logger.Debug("This is Debug Information");
            logger.Info("This is Info Information");
            logger.Warn("This is Warn Information");
            logger.Error("This is Error Information");
            logger.Fatal("This is Fatal Information");


           

        }
    }
}
