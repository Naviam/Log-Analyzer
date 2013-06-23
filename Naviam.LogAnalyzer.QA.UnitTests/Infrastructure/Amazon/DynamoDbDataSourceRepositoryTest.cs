namespace Naviam.DataAnalyzer.QA.UnitTests.Infrastructure.Amazon
{
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    using Naviam.DataAnalyzer.Model.DataSource;
    using Naviam.DataAnalyzer.Repository.DynamoDb;

    [TestFixture]
    public class DynamoDbDataSourceRepositoryTest
    {
        private DataSourceRepository repository;

        private string accountId;

        /// <summary>
        /// Test initialization.
        /// </summary>
        [SetUp]
        public void Init()
        {
            repository = new DataSourceRepository();
            accountId = "TestAccount";
        }

        [Test]
        public void DynamoDbDataSourceRepositoryScenario()
        {
            var id = DynamoDbRepository.GetNewKey();
            
            //check add record
            var ds = new DataSource()
            {
                DataSourceType = DataSourceTypes.SelfEndpoint,
                Id = id,
                Map = new List<MapInfo>()
                    {
                        new MapInfo(){PropertyName = "prop1", PropertyType = PropertyTypes.String}, 
                        new MapInfo(){PropertyName = "prop2", PropertyType = PropertyTypes.Number}
                    },
                Name = "testDataSource"
            };
            repository.AddDataSource(ds, accountId);

            // check get by id and accaunt
            var res = repository.GetDataSource(id, accountId);
            Assert.AreEqual(res.Id, id);

            // check update
            ds.Name = "testDataSourceUpdated";
            ds.Map = new List<MapInfo>()
                         {
                             new MapInfo() { PropertyName = "prop1Updated", PropertyType = PropertyTypes.String },
                             new MapInfo() { PropertyName = "prop2Updated", PropertyType = PropertyTypes.Number }
                         };
            ds.DataSourceType = DataSourceTypes.Unknown;
            repository.UpdateDataSource(ds, accountId);
            var updatedRes = repository.GetDataSource(id, accountId);
            Assert.AreEqual(updatedRes.Name, "testDataSourceUpdated");
            Assert.AreEqual(updatedRes.Map.ToList()[0].PropertyName, "prop1Updated");
            Assert.AreEqual(updatedRes.DataSourceType, DataSourceTypes.Unknown);

            // chek get by account
            repository.GetDataSources(accountId);
            Assert.IsNotNull(repository.GetDataSources(accountId).FirstOrDefault(x => x.Id == id));
            
            // delete record
            repository.DeleteDataSource(id, accountId);
            
            // check datasource deleted
            repository.GetDataSources(accountId);
            Assert.IsNull(repository.GetDataSources(accountId).FirstOrDefault(x => x.Id == id));
        }

        [TearDown]
        public void Cleanup()
        {
            foreach (var res in repository.GetDataSources(accountId))
            {
                repository.DeleteDataSource(res.Id, accountId);
            }
        }
    }
}
