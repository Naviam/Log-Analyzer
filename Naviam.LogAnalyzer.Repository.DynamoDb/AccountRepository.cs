namespace Naviam.DataAnalyzer.Repository.DynamoDb
{
    using System;
    using System.Linq;

    using AutoMapper;

    using Naviam.DataAnalyzer.Model.Account;
    using Naviam.DataAnalyzer.Model.DataSource;
    using Naviam.DataAnalyzer.Model.Filter;

    using DynamoDb = Naviam.DataAnalyzer.Repository.DynamoDb.Model;

    public class AccountRepository : DynamoDbRepository, IAccountRepository
    {
        public Account GetAccount(string email)
        {
            return Mapper.Map<DynamoDb.Account, Account>(this.Context.Load<DynamoDb.Account>(email));
        }

        public Account GetAccountWithInternalData(string email)
        {
            var account = Mapper.Map<DynamoDb.Account, Account>(this.Context.Load<DynamoDb.Account>(email));
            if (account != null)
            {
                account.DataSources =
                    this.Context.Query<DynamoDb.DataSource>(email)
                        .Select(Mapper.Map<DynamoDb.DataSource, DataSource>)
                        .ToList();
                if (account.DataSources != null)
                {
                    foreach (var var in account.DataSources)
                    {
                        var.Filters =
                            this.Context.Query<DynamoDb.Filter>(var.Id)
                        .Select(Mapper.Map<DynamoDb.Filter, Filter>)
                        .ToList();
                    }
                }
            }
            return account;
        }

        public string AddAccount(Account account)
        {
            if (string.IsNullOrEmpty(account.Email))
            {
                // TODO: make own exceptions
                throw new Exception("email should not be null!");
            }
            var acc = Mapper.Map<Account, DynamoDb.Account>(account);
            this.Context.Save(acc);
            return account.Email;
        }

        public Account UpdateAccount(Account account)
        {
            var acc = Mapper.Map<Account, DynamoDb.Account>(account);
            this.Context.Save(acc);
            return account;
        }

        public void DeleteAccount(string email, bool deleteCascade = false)
        {
            this.Context.Delete<DynamoDb.Account>(email);

            if (deleteCascade)
            {
                this.Context.Delete<DynamoDb.DataSource>(email);
            }
        }
    }
}
