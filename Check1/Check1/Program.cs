using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Logger;

namespace Check1
{
    public class Program
    {
        public static void Main(string[] args)
        {

            new Class1("https://424ffff1c3324bf1b6b7f307021e97aa@o282435.ingest.sentry.io/5280921", "D:/log.txt");

            CreateHostBuilder(args).Build().Run();

        }


        public static IHostBuilder CreateHostBuilder(string[] args)
        {
 
           var app = Host.CreateDefaultBuilder(args);
            //string Dsn =  "https://73b188f2b09743319fa80b493c831941@o409423.ingest.sentry.io/5281866" ;

            return app
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        }
            
    }
}
