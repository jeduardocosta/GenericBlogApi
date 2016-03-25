using Autofac;
using GenericBlogAPI.Core.Parsers;

namespace GenericBlogAPI.Core.DI
{
    public class ParserModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BlogFeedContentParser>().As<IBlogFeedContentParser>();
            builder.RegisterType<JsonParser>().As<IJsonParser>();
            builder.RegisterType<DatetimeParser>().As<IDatetimeParser>();
        }
    }
}
