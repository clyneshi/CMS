using CMS.DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Windows.Forms;
using Microsoft.Extensions.Hosting;
using CMS.BL.Utils;
using CMS.WinformUI.Utils;
using CMS.DAL.Utils;

namespace CMS.WinformUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            var services = host.Services;

            try
            {
                var context = services.GetRequiredService<CMSContext>();
                CMSDBInitializer.Initialize(context);
            }
            catch (Exception)
            {
                // TODO: log
                throw;
            }

            var loginForm = services.GetRequiredService<Login>(); 
            Application.Run(loginForm);
        }

        public static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.AddJsonFile("appsettings.json", optional: false);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddCMSDbContext(hostContext.Configuration);
                    services.AddServices();
                    services.AddForms();
                });
    }
}
