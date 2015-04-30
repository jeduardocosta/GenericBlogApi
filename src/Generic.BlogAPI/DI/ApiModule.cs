using Autofac;
using Generic.BlogAPI.Core.DI;
using Generic.BlogAPI.Parsers;
using Generic.BlogAPI.Services;

namespace Generic.BlogAPI.DI
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RequestParametersParser>().As<IRequestParametersParser>();
            builder.RegisterType<BlogGetActionService>().As<IBlogGetActionService>();

            builder.RegisterModule(new CoreModule());
        }
    }
}