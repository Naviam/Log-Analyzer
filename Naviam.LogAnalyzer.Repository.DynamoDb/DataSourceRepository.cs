namespace Naviam.DataAnalyzer.Repository.DynamoDb
{
    using System.Collections.Generic;
    using System.Linq;

    using Amazon.DynamoDBv2.DocumentModel;

    using AutoMapper;

    using Naviam.DataAnalyzer.Model.DataSource;
    using DynamoDb = Naviam.DataAnalyzer.Repository.DynamoDb.Model;

    public class DataSourceRepository : DynamoDbRepository, IDataSourceRepository
    {
        public DataSourceRepository()
        {
            Mapper.CreateMap<DataSource, DynamoDb.DataSource>();
            Mapper.CreateMap<DynamoDb.DataSource, DataSource>();
        }

        public DataSource GetDataSource(string id, string accountId)
        {
            var ds = this.Context.Query<DynamoDb.DataSource>(accountId, QueryOperator.Equal, id).ToList();
            if (ds.Count > 0)
            {
                return Mapper.Map<DynamoDb.DataSource, DataSource>(ds[0]);
            }
            return null;
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
            var ds = this.Context.Load<DynamoDb.DataSource>(accountId, dataSource.Id);
            ds.DataSourceType = (int)dataSource.DataSourceType;
            ds.Name = dataSource.Name;
            this.Context.Save(ds);
            return dataSource;
        }

        public void DeleteDataSource(string id, string accountId)
        {
            this.Context.Delete<DynamoDb.DataSource>(accountId, id);
        }
    }
}
