using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Naviam.DataAnalyzer.Services.WebApi.App_Start;

namespace Naviam.DataAnalyzer.Services.WebApi
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfiguration.Configure();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            GlobalConfiguration.Configuration.DependencyResolver = new ScopeContainer(ApplicationContainer.Prepare());
        }
    }
}