using Autofac;
using GenericBlogAPI.Core.Helpers;

namespace GenericBlogAPI.Core.DI
{
    public class HelpersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UrlHelper>().As<IUrlHelper>();
            builder.RegisterType<HtmlHelper>().As<IHtmlHelper>();
        }
    }
}