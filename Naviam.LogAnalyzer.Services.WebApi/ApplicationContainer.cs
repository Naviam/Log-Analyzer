namespace Naviam.DataAnalyzer.Services.WebApi
{
    using Naviam.DataAnalyzer.Model.DataSource;
    using Naviam.DataAnalyzer.Repository.DynamoDb;
    using Naviam.DataAnalyzer.Services.Concrete;
    using Naviam.DataAnalyzer.Services.Contracts.DataSource;
    using SimpleInjector;

    public class ApplicationContainer
    {
        public static Container Prepare()
        {
            var container = new Container();
            container.Register<IDataSourceService, DataSourceService>();
            container.Register<IDataSourceRepository, DataSourceRepository>();
            return container;
        }
    }
}