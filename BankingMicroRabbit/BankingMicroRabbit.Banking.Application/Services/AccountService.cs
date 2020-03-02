using BankingMicroRabbit.Banking.Application.Interfaces;
using BankingMicroRabbit.Banking.Application.Models;
using BankingMicroRabbit.Banking.Domain.Commands;
using BankingMicroRabbit.Banking.Domain.Interfaces;
using BankingMicroRabbit.Banking.Domain.Models;
using BankingMicroRabbit.Domain.Core.Bus;
using System.Collections.Generic;

namespace BankingMicroRabbit.Banking.Application.Services
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

        public void Transfer(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(
                accountTransfer.FromAccount,
                accountTransfer.ToAccount,
                accountTransfer.TransferAmount
                );

            _bus.SendCommand<CreateTransferCommand>(createTransferCommand);
        }
    }
}
