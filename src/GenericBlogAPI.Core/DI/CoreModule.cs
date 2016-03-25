using Autofac;
using GenericBlogAPI.Core.Clients;
using GenericBlogAPI.Core.Readers;

namespace GenericBlogAPI.Core.DI
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BlogFeedReader>().As<IBlogFeedReader>();
            builder.RegisterType<WebClient>().As<IWebClient>();

            builder.RegisterModule(new HelpersModule());
            builder.RegisterModule(new ParserModule());
        }
    }
}