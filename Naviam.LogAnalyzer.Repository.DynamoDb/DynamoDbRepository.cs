namespace Naviam.DataAnalyzer.Repository.DynamoDb
{
    using System;
    using System.Collections.Generic;
    using System.Web.Helpers;

    using Amazon.DynamoDBv2;
    using Amazon.DynamoDBv2.DataModel;

    using AutoMapper;

    using Naviam.DataAnalyzer.Model.Account;
    using Naviam.DataAnalyzer.Model.DataSource;
    using Naviam.DataAnalyzer.Model.Filter;

    public class DynamoDbRepository
    {
        readonly AmazonDynamoDBConfig config = new AmazonDynamoDBConfig();

        protected readonly AmazonDynamoDBClient Client;

        protected readonly DynamoDBContext Context;

        public DynamoDbRepository()
        {
            Mapping();
            this.Client = new AmazonDynamoDBClient(config);
            this.Context = new DynamoDBContext(this.Client);
        }

        public static string GetNewKey()
        {
            return Guid.NewGuid().ToString("N");
        }

        private static void Mapping()
        {
            Mapper.CreateMap<DataSource, Model.DataSource>()
                  .ForMember(x => x.Map, m => m.MapFrom(q => Json.Encode(q.Map)));
            Mapper.CreateMap<Model.DataSource, DataSource>()
                  .ForMember(x => x.Map, m => m.MapFrom(q => Json.Decode(q.Map, typeof(IEnumerable<MapInfo>))));
            Mapper.CreateMap<Account, Model.Account>();
            Mapper.CreateMap<Model.Account, Account>();
            Mapper.CreateMap<Filter, Model.Filter>()
                .ForMember(x => x.Criteria, m => m.MapFrom(q => Json.Encode(q.Criteria)));
            Mapper.CreateMap<Model.Filter, Filter>()
                .ForMember(x => x.Criteria, m => m.MapFrom(q => Json.Decode(q.Criteria, typeof(IEnumerable<Criterion>))));
        }
    }
}
