namespace Naviam.DataAnalyzer.Model.DataSource
{
    using System.Collections.Generic;

    public interface IDataSourceRepository
    {
        DataSource GetDataSource(string id, string accountId);

        IEnumerable<DataSource> GetDataSources(string accountId);

        string AddDataSource(DataSource dataSource, string accountId);

        DataSource UpdateDataSource(DataSource dataSource, string accountId);

        void DeleteDataSource(string id, string accountId);
    }
}
