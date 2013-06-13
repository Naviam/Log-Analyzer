namespace Naviam.DataAnalyzer.Repository.DynamoDb
{
    using System;
    using System.Collections.Generic;

    using Naviam.DataAnalyzer.Model.DataSource;

    public class DataSourceRepository : IDataSourceRepository
    {
        public DataSource GetDataSource(string id)
        {
            throw new NotImplementedException();
        }

        public List<DataSource> GetDataSources(int accountId)
        {
            throw new NotImplementedException();
        }

        public string AddDataSource(DataSource dataSource, int accountId)
        {
            throw new NotImplementedException();
        }

        public DataSource UpdateDataSource(DataSource dataSource)
        {
            throw new NotImplementedException();
        }

        public void DeleteDataSource(string id)
        {
            throw new NotImplementedException();
        }
    }
}
