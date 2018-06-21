using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Owin;


[assembly: OwinStartup(typeof(UserRegisterationService.Startup))]

namespace UserRegisterationService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ServiceBus.Init();
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            app.UseWebApi(config);
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
