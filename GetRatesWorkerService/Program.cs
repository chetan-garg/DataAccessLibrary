using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Unibet.DataAccessLibrary;
using Unibet.DataHandler;
using IL = Unibet.InterfaceLibrary;
using GetRatesWorker;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GetRatesWorkerService
{
    public class Program
    {
        public static Castle.Windsor.WindsorContainer container = new Castle.Windsor.WindsorContainer();

        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("");

            Console.WriteLine(configuration.GetConnectionString("Storage"));
            container.Register(Component.For<IL.IDataHandler>().ImplementedBy<DataHandler>());
            container.Register(Component.For<IL.IDataMapper>().ImplementedBy<DataMapper>());
            container.Register(Component.For<IL.IDataAccessLayer>().ImplementedBy<DataAccessLayer>());
            container.Register(Component.For<IL.IGetRatesWorker>().ImplementedBy<GetRatesWorker.GetRatesWorker>());
            container.Register(Component.For<IL.IRatesConverter>().ImplementedBy<RatesConverter>());
            container.Register(Component.For<IL.ISqlServerDb>().ImplementedBy<SqlServerDb>());


            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}
