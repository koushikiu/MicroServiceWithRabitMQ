using MicroRabit.Banking.Application.Models;
using MicroRabit.Banking.Data.Repository;
using MicroRabit.Banking.Domain.Commands;
using MicroRabit.Banking.Domain.Models;
using MicroRabit.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabit.Banking.Application.services
{
   public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _bus;
        public AccountService(IAccountRepository accountRepository, IEventBus bus)
        {
            _accountRepository = accountRepository;
            _bus = bus;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public void Transfer(AccountTransfer accountTrensfer)
        {
            var createTransferCommand = new CreateTransferCommand(accountTrensfer.FromAccount, accountTrensfer.ToAccount, accountTrensfer.TransferAmmount);
            _bus.SendCommand(createTransferCommand);
        }
    }
}
public interface IAccountService
{
    IEnumerable<Account> GetAccounts();
    void Transfer(AccountTransfer accountTrensfer);
}
