namespace Naviam.DataAnalyzer.Model.DataSource
{
    using System;
    using System.Collections.Generic;

    public interface IDataSourceRepository
    {
        DataSource GetDataSource(Guid id);

        List<DataSource> GetDataSources(int userId);

        Guid AddDataSource(DataSource dataSource);

        DataSource UpdateDataSource(DataSource dataSource);

        void DeleteDataSource(Guid id);
    }
}
