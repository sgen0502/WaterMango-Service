using System;
using System.Collections.Generic;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WaterMango_Service.Communication.InMemoryDb;
using WaterMango_Service.Communication.InMemoryDb.Helper;

namespace WaterMango_Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DependencyContainer.BuildDependency();

            var host = CreateWebHostBuilder(args).Build();
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }

    public class DependencyContainer
    {
        private static CompositionHost _container;
        private static DependencyContainer _instance;
        private DependencyContainer()
        {
            var assemblies = new[] { typeof(Program).GetTypeInfo().Assembly }; 
            var configuration = new ContainerConfiguration() 
                .WithAssembly(typeof(Program).GetTypeInfo().Assembly);

            _container = configuration.CreateContainer();
        }

        public static void BuildDependency()
        {
            if (_instance == null) _instance = new DependencyContainer();
        }

        public static T GetExportedValue<T>() => _container.GetExport<T>();
    }
    
}
