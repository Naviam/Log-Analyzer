namespace Naviam.DataAnalyzer.Repository.DynamoDb
{
    using System.Collections.Generic;

    using Naviam.DataAnalyzer.Model.Account;

    public class AccountRepository : DynamoDbRepository, IAccountRepository 
    {
        public IEnumerable<Account> GetAccounts()
        {
            throw new System.NotImplementedException();
        }

        public Account GetAccount(string accountId)
        {
            throw new System.NotImplementedException();
        }

        public string AddAccount(Account account)
        {
            throw new System.NotImplementedException();
        }

        public Account UpdateAccount(Account account)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAccount(string accountId)
        {
            throw new System.NotImplementedException();
        }
    }
}
