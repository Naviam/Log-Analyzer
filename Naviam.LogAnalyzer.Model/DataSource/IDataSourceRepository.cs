namespace Naviam.DataAnalyzer.Model.DataSource
{
    using System;
    using System.Collections.Generic;

    public interface IDataSourceRepository
    {
        DataSource GetDataSource(string id);

        List<DataSource> GetDataSources(int accountId);

        string AddDataSource(DataSource dataSource, int accountId);

        DataSource UpdateDataSource(DataSource dataSource);

        void DeleteDataSource(string id);
    }
}
