using MicroRabit.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabit.Banking.Domain.Interfaces
{
   public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();
    }
}
