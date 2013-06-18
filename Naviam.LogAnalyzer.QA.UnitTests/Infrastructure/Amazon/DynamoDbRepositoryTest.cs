namespace Naviam.DataAnalyzer.QA.UnitTests.Infrastructure.Amazon
{
    using NUnit.Framework;

    using Naviam.DataAnalyzer.Repository.DynamoDb;

    [TestFixture]
    class DynamoDbRepositoryTest
    {
        /// <summary>
        /// Test initialization.
        /// </summary>
        [SetUp]
        public void Init()
        {
        }

        [Test]
        public void DataSourceCanCreate()
        {
            var repository = new DynamoDbRepository();
            Assert.IsNotNull(repository);
        }

        [TearDown]
        public void Cleanup()
        {
        }
    }
}
