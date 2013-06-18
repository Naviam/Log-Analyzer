namespace Naviam.DataAnalyzer.Repository.Fake.Repositories
{
    using System;
    using System.Collections.Generic;

    using Naviam.DataAnalyzer.Model.DataSource;

    public class DataSourceRepository : IDataSourceRepository
    {
        public DataSource GetDataSource(string id, string accountId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DataSource> GetDataSources(string accountId)
        {
            throw new NotImplementedException();
        }

        public string AddDataSource(DataSource dataSource, string accountId)
        {
            throw new NotImplementedException();
        }

        public DataSource UpdateDataSource(DataSource dataSource, string accountId)
        {
            throw new NotImplementedException();
        }

        public void DeleteDataSource(string id, string accountId)
        {
            throw new NotImplementedException();
        }
    }
}
