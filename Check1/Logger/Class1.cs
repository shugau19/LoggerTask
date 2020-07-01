using System;
using Sentry;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Logger
{
    public class Class1
    {
        public static ILogger logger { get; set; }

        public Class1(String dsn, string logFilePath)
        {
            LogManager.Configuration = new LoggingConfiguration();

            var logfile = new FileTarget("logfile") { Name="log", FileName = logFilePath };
            //var logconsole = new ConsoleTarget("logconsole");

            // Rules for mapping loggers to targets            
            //LogManager.Configuration.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            LogManager.Configuration.AddRule(LogLevel.Error, LogLevel.Fatal, logfile);

            LogManager.Configuration
               .AddSentry(o =>
               {

                   o.Dsn = new Dsn(dsn);
                   // Optionally specify a separate format for message
                   o.Layout = "${message}";
                   // Optionally specify a separate format for breadcrumbs
                   o.BreadcrumbLayout = "${logger}: ${message}";

                   // Debug and higher are stored as breadcrumbs (default is Info)
                   o.MinimumBreadcrumbLevel = NLog.LogLevel.Debug;
                   // Error and higher is sent as event (default is Error)
                   o.MinimumEventLevel = NLog.LogLevel.Info;

                   // Send the logger name as a tag
                   o.AddTag("logger", "${logger}");

                   // All Sentry Options are accessible here.
               });

            logger = LogManager.GetCurrentClassLogger();
        }

        public static void Write(LogLevel logLevel, Exception ex, string message)
        {
            if (logLevel == LogLevel.Error)
                logger.Error(ex, message);
        }
    }
}
