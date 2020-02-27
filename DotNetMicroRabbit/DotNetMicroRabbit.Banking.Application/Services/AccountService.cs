using DotNetMicroRabbit.Banking.Application.Interfaces;
using DotNetMicroRabbit.Banking.Application.Models;
using DotNetMicroRabbit.Banking.Domain.Commands;
using DotNetMicroRabbit.Banking.Domain.Interfaces;
using DotNetMicroRabbit.Banking.Domain.Models;
using DotNetMicroRabbit.Domain.Core.Bus;
using System.Collections.Generic;

namespace DotNetMicroRabbit.Banking.Application.Services
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
