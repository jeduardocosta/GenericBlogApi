using Autofac;
using GenericBlogAPI.Core.DI;
using GenericBlogAPI.Parsers;
using GenericBlogAPI.Services;

namespace GenericBlogAPI.DI
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