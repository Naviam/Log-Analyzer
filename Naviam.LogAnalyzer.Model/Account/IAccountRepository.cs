namespace Naviam.DataAnalyzer.Model.Account
{
    using System.Collections.Generic;

    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();

        Account GetAccount(string accountId);

        string AddAccount(Account account);

        Account UpdateAccount(Account account);

        void DeleteAccount(string accountId);
    }
}