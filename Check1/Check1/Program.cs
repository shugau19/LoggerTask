using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using LoggerPack;

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
 
           var app = Host.CreateDefaultBuilder(args);
            string Dsn =  "https://73b188f2b09743319fa80b493c831941@o409423.ingest.sentry.io/5281866" ;
            var obj = new Class1();
            obj.UseGloabalLogger(app,Dsn);

            return app
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    
                    webBuilder.UseStartup<Startup>();
                });

        }
            
    }
}
