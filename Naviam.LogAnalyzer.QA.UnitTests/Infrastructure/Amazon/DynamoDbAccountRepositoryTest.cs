namespace Naviam.DataAnalyzer.QA.UnitTests.Infrastructure.Amazon
{
    using System;

    using NUnit.Framework;

    using Naviam.DataAnalyzer.Model.Account;
    using Naviam.DataAnalyzer.Repository.DynamoDb;

    [TestFixture]
    public class DynamoDbAccountRepositoryTest
    {
        private AccountRepository repository;
        private string accountId;

        /// <summary>
        /// Test initialization.
        /// </summary>
        [SetUp]
        public void Init()
        {
            repository = new AccountRepository();
            accountId = "TestAccount@test.mail";
        }

        [Test]
        public void DynamoDbAccountRepositoryScenario()
        {
            //check add record
            var account = new Account()
            {
                CreationDate = DateTime.UtcNow,
                Email = accountId,
                Name = "testAccount",
                Password = "blabla"
            };
            repository.AddAccount(account);

            // check get
            var res = repository.GetAccount(accountId);
            Assert.AreEqual(res.Email, accountId);

            // check update
            account.Name = "testAccountUpdated";
            repository.UpdateAccount(account);
            var updatedRes = repository.GetAccount(accountId);
            Assert.AreEqual(updatedRes.Name, "testAccountUpdated");

            // delete record
            repository.DeleteAccount(accountId);

            // check datasource deleted
            Assert.IsNull(repository.GetAccount(accountId));

        }
        
        //[Test]
        //public void Test2()
        //{
        //    var res= repository.GetAccount("email@0.com");
        //}
        
        [TearDown]
        public void Cleanup()
        {
            repository.DeleteAccount(accountId);
        }
    }
}
