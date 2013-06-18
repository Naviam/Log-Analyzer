namespace Naviam.DataAnalyzer.QA.UnitTests.Infrastructure.Amazon
{
    using System;
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
                Name = "testDataSource"
            };
            repository.AddDataSource(ds, accountId);

            // check get by id and accaunt
            Assert.AreEqual(repository.GetDataSource(id, accountId).Id, id);

            // check update
            ds.Name = "testDataSourceUpdated";
            repository.UpdateDataSource(ds, accountId);
            Assert.AreEqual(repository.GetDataSource(id, accountId).Name, "testDataSourceUpdated");

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
