using AppCore.Interface;
using AppCore.Services;
using Dominio.Contratos;
using Dominio.Entidades;
using Dominio.Interfaces;
using Dominio.PedritoSchoolContext;
using Infraestructura.Inter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedritoSchools
{
    internal static class Program
    {

        public static IConfiguration Configuration;
        /// <summary>
                                                           ///  The main entry point for the application.
                                                           /// </summary>
        [STAThread]
        static void Main()
        {
            Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();

            //var builder = new HostBuilder().ConfigureServices((hostContext, services) =>
            //{
            //    services.AddDbContext<DepreciationDBContext>(options =>
            //    {
            //        options.UseSqlServer(Configuration.GetConnectionString("Default"));
            //    });
            //});

            //var host = builder.Build();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            services.AddDbContext<PedritoSchoolContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });
            services.AddScoped<IPedritoSchoolContext, PedritoSchoolContext>();

            services.AddScoped<IEstudianteRepository, IFEstudiante>();
            services.AddScoped<IPedritoService, PedritoService>();

           


            services.AddScoped<Form1>();

            using (var serviceScope = services.BuildServiceProvider())
            {
                var main = serviceScope.GetRequiredService<Form1>();
                Application.Run(main);
            }

        }
    }
}
