namespace Naviam.DataAnalyzer.QA.UnitTests.Infrastructure.Amazon
{
    using NUnit.Framework;

    using Naviam.DataAnalyzer.Infrastructure.Amazon;

    class DynamoDbClientTest
    {
        /// <summary>
        /// Test initialization.
        /// </summary>
        [SetUp]
        public void Init()
        {
        }

        [Test]
        public void DynamoDbClientCanGetTablesList()
        {
            using (var client = new DynamoDbClient())
            {
                // client.CreateTable("Filter", "DataSourceId", "Id", 10, 5);
                var request = client.GetTableList();
                Assert.IsNotNull(request);
            }
        }

        [TearDown]
        public void Cleanup()
        {
        }
    }
}
