using System;
using Microsoft.Extensions.Hosting;
using Sentry;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Config;
using NLog.Extensions.Logging;

namespace LoggerPack
{
    public class Class1
    {
        public void UseGloabalLogger(IHostBuilder app, String dsn)
        {
            LogManager.Configuration = new LoggingConfiguration();

            app.ConfigureLogging((hostingContext, logging) =>
            {
                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                logging.AddDebug();
                logging.AddNLog();
            });


         /*   LogManager.Configuration
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
                }); */
        }
    }
}
