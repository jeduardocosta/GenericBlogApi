using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;

namespace Generic.BlogAPI.DI
{
    public class DIContainer
    {
        private static IContainer _container;

        public static IContainer Container
        {
            get
            {
                if (_container == null) 
                    Setup();

                return _container;
            }
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        private static void Setup()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterModule(new ApiModule());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            _container = builder.Build();
        }
    }
}