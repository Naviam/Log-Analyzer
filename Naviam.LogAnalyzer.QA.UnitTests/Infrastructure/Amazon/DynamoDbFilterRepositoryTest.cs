namespace Naviam.DataAnalyzer.QA.UnitTests.Infrastructure.Amazon
{
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    using Naviam.DataAnalyzer.Model.DataSource;
    using Naviam.DataAnalyzer.Model.Filter;
    using Naviam.DataAnalyzer.Repository.DynamoDb;

    [TestFixture]
    public class DynamoDbFilterRepositoryTest
    {
        private FilterRepository repository;

        private string dataSourceId;

        [SetUp]
        public void Init()
        {
            repository = new FilterRepository();
            dataSourceId = "testDataSourceId";
        }

        [Test]
        public void DynamoDbFilterRepositoryScenario()
        {
            var id = DynamoDbRepository.GetNewKey();

            //check add record
            var flt = new Filter()
            {
                Id = id,
                CompareOperetion = CompareOperations.And,
                Name = "testFilter",
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
            };
            repository.AddFilter(flt, dataSourceId);

            // check get by 
            var res = repository.GetFilter(id, dataSourceId);
            Assert.AreEqual(res.Id, id);

            // check update
            flt.Name = "testFilter";
            flt.Criteria = new List<Criterion>()
                {
                    new Criterion()
                        { ColumnName = "Column3", IsExclude = true, Operation = Operations.Like, StringValue = "%aaa%" }
                };
            repository.UpdateFilter(flt, dataSourceId);
            var updatedRes = repository.GetFilter(id, dataSourceId);
            Assert.AreEqual(updatedRes.Name, "testFilter");
            Assert.AreEqual(updatedRes.Criteria.ToList()[0].ColumnName, "Column3");

            // chek get
            Assert.IsNotNull(repository.GetFilters(dataSourceId).FirstOrDefault(x => x.Id == id));

            // check delete 
            repository.DeleteFilter(id, dataSourceId);
            Assert.IsNull(repository.GetFilters(dataSourceId).FirstOrDefault(x => x.Id == id));
        }

        [TearDown]
        public void Cleanup()
        {
            repository.DeleteFilters(dataSourceId);
        }
    }
}
