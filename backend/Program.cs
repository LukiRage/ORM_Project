using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql;
using static ORM_Projekt.DB_import_export;
using static ORM_Projekt.DataBaseModels;
using System.Net;
using System.Text;
using System.Xml.Linq;
using System.ServiceModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ORM_Projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                        .UseUrls("http://localhost:8000");
                });
    }
}