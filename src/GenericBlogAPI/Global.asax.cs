using System;
using System.Web;
using System.Web.Http;
using Autofac.Integration.WebApi;
using GenericBlogAPI.DI;

namespace GenericBlogAPI
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            try
            {
                var config = GlobalConfiguration.Configuration;
                config.DependencyResolver = new AutofacWebApiDependencyResolver(DIContainer.Container);
            }
            catch (Exception exception)
            {
                const string errorMessage = "Failed to load base classes.";
                throw new Exception(errorMessage);
            }
        }
    }
}