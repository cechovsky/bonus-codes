using System.Net.Http.Formatting;
using System.Web.Http;
using BonusCodes.Common;
using LightInject;

namespace BonusCodes
{

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            Container.GetContainer().RegisterApiControllers();        
            Container.GetContainer().EnableWebApi(config);
            
            // Web API configuration and services
            config.MapHttpAttributeRoutes();
            config.DependencyResolver = new DependencyResolver();

            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());

            // Web API routes
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
