namespace Naviam.DataAnalyzer.Repository.DynamoDb
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Helpers;

    using AutoMapper;

    using Naviam.DataAnalyzer.Model.DataSource;
    using DynamoDb = Naviam.DataAnalyzer.Repository.DynamoDb.Model;

    public class DataSourceRepository : DynamoDbRepository, IDataSourceRepository
    {
        public DataSource GetDataSource(string id, string accountId)
        {
            var result = this.Context.Load<DynamoDb.DataSource>(accountId, id, null);
            return Mapper.Map<DynamoDb.DataSource, DataSource>(result);
        }

        public IEnumerable<DataSource> GetDataSources(string accountId)
        {
            var res = this.Context.Query<DynamoDb.DataSource>(accountId).ToList();
            var val = res.Select(Mapper.Map<DynamoDb.DataSource, DataSource>).ToList();
            return val;
        }

        public string AddDataSource(DataSource dataSource, string accountId)
        {
            if (string.IsNullOrEmpty(dataSource.Id))
            {
                dataSource.Id = GetNewKey();
            }
            var ds = Mapper.Map<DataSource, DynamoDb.DataSource>(dataSource);
            ds.AccountId = accountId;
            this.Context.Save(ds);
            return dataSource.Id;
        }

        public DataSource UpdateDataSource(DataSource dataSource, string accountId)
        {
            var ds = Mapper.Map<DataSource, DynamoDb.DataSource>(dataSource);
            ds.AccountId = accountId;
            this.Context.Save(ds);
            return dataSource;
        }

        public void DeleteDataSource(string id, string accountId)
        {
            this.Context.Delete<DynamoDb.DataSource>(accountId, id);
        }
    }
}
