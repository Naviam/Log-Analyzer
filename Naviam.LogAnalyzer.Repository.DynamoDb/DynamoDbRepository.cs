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
                .ForMember(x => x.Map, m => m.MapFrom(q =>string.IsNullOrEmpty(q.Map)? null : Json.Decode(q.Map, typeof(IEnumerable<MapInfo>))));
            Mapper.CreateMap<Account, Model.Account>();
            Mapper.CreateMap<Model.Account, Account>();
            Mapper.CreateMap<Filter, Model.Filter>()
                .ForMember(x => x.Criteria, m => m.MapFrom(q => Json.Encode(q.Criteria)));
            Mapper.CreateMap<Model.Filter, Filter>()
                .ForMember(x => x.Criteria, m => m.MapFrom(q => Json.Decode(q.Criteria, typeof(IEnumerable<Criterion>))));
        }

        public void PrepareTestData(int accountsNumber)
        {
            for (var k = 0; k < accountsNumber; k++)
            {
                Context.Save<Model.Account>(
                    new Model.Account
                        {
                            CreationDate = DateTime.UtcNow,
                            Email = string.Format(@"email@{0}.com", k),
                            Name = string.Format(@"testAccount{0}", k),
                            Password = "blabla"
                        });
                for (var i = 0; i < 3; i++)
                {
                    var dataSource =
                        Mapper.Map<DataSource, Model.DataSource>(
                            new DataSource()
                                {
                                    DataSourceType = DataSourceTypes.SelfEndpoint,
                                    Id = GetNewKey(),
                                    Map =
                                        new List<MapInfo>()
                                            {
                                                new MapInfo()
                                                    { PropertyName = "prop1", PropertyType = PropertyTypes.String },
                                                new MapInfo()
                                                    { PropertyName = "prop2", PropertyType = PropertyTypes.Number }
                                            },
                                    Name = string.Format(@"testDS{0}", i),
                                });
                    dataSource.AccountId = string.Format(@"email@{0}.com", k);
                    this.Context.Save(dataSource);
                    for (var x = 0; x < 3; x++)
                    {
                        var filter = Mapper.Map<Filter, Model.Filter>(
                            new Filter()
                            {
                                Id = GetNewKey(),
                                CompareOperetion = CompareOperations.And,
                                Name = string.Format(@"testFilter{0}", x),
                                Criteria = new List<Criterion>()
                                    {
                                        new Criterion()
                                            {
                                                ColumnName = "Column1",
                                                IsExclude = false,
                                                Operation = Operations.Equal,
                                                StringValue = "zaaazzz"
                                            },
                                        new Criterion()
                                            {
                                                ColumnName = "Column2",
                                                IsExclude = true,
                                                Operation = Operations.Like,
                                                StringValue = "%aaa%"
                                            }
                                    }
                            }
                            );
                        filter.DataSourceId = dataSource.Id;
                        this.Context.Save(filter);
                    }
                }
            }
            
        }

    }
}
