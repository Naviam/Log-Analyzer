namespace Naviam.DataAnalyzer.Model.Account
{
    public interface IAccountRepository
    {
        Account GetAccountWithInternalData(string email);

        Account GetAccount(string email);

        string AddAccount(Account account);

        Account UpdateAccount(Account account);

        void DeleteAccount(string email, bool deleteCascade = false);
    }
}