using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using LoggerPackage;

namespace Check1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            string[] Dsn = { "https://73b188f2b09743319fa80b493c831941@o409423.ingest.sentry.io/5281866" };
            Class1.CreateHostBuilder(Dsn);

            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    
                    webBuilder.UseStartup<Startup>();
                });

        }
            
    }
}
