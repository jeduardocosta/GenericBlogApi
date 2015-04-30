using Autofac;
using Generic.BlogAPI.Core.Clients;
using Generic.BlogAPI.Core.Readers;

namespace Generic.BlogAPI.Core.DI
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