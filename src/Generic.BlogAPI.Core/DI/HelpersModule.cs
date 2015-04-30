using Autofac;
using Generic.BlogAPI.Core.Helpers;

namespace Generic.BlogAPI.Core.DI
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