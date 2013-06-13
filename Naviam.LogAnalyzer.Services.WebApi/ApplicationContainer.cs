namespace Naviam.DataAnalyzer.Services.WebApi
{
    using Naviam.DataAnalyzer.Services.Contracts.DataSource;
    using SimpleInjector;

    public class ApplicationContainer
    {
        public static Container Prepare()
        {
            var container = new Container();
            container.Register<IDataSourceService, DataSourceRepository>();
            return container;
        }
    }
}