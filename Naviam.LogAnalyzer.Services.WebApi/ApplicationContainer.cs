namespace Naviam.DataAnalyzer.Services.WebApi
{
    using Naviam.DataAnalyzer.Services.Concrete;
    using Naviam.DataAnalyzer.Services.Contracts.DataSource;
    using SimpleInjector;

    public class ApplicationContainer
    {
        public static Container Prepare()
        {
            var container = new Container();
            container.Register<IDataSourceService, DataSourceService>();
            return container;
        }
    }
}