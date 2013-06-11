namespace Naviam.DataAnalyzer.Repository.Fake.Repositories
{
    using System;
    using System.Collections.Generic;

    using Naviam.DataAnalyzer.Model.DataSource;

    public class DataSourceRepository : IDataSourceRepository
    {
        public DataSource GetDataSource(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<DataSource> GetDataSources(int userId)
        {
            throw new NotImplementedException();
        }

        public Guid AddDataSource(DataSource dataSource)
        {
            throw new NotImplementedException();
        }

        public DataSource UpdateDataSource(DataSource dataSource)
        {
            throw new NotImplementedException();
        }

        public void DeleteDataSource(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
