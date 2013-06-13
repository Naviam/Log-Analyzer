namespace Naviam.DataAnalyzer.Services.WebApi
{
    using Naviam.DataAnalyzer.Model.DataSource;
    using Naviam.DataAnalyzer.Repository.DynamoDb;

    using SimpleInjector;

    public class ApplicationContainer
    {
        public static Container Prepare()
        {
            var container = new Container();
            container.Register<IDataSourceRepository, DataSourceRepository>();
            return container;
        }
    }
}