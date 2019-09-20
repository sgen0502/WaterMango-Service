using System.Composition.Hosting;
using System.Reflection;

namespace WaterMango_Service.Utils
{
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