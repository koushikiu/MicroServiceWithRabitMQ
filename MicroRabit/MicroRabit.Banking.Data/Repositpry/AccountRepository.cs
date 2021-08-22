using MicroRabit.Banking.Data.Context;
using MicroRabit.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabit.Banking.Data.Repositpry
{
    public class AccountRepository : IAccountRepository
    {
        BankingDbContext _bankingDbContext;

        public AccountRepository(BankingDbContext bankingDbContext)
        {
            _bankingDbContext = bankingDbContext;
        }

        public IEnumerable<Account> GetAccounts()
        {
             return _bankingDbContext.Accounts;
        }
    }
}
public interface IAccountRepository
{
    IEnumerable<Account> GetAccounts();
}
