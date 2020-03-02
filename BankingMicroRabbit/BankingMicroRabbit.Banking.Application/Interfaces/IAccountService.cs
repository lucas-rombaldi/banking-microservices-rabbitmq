using BankingMicroRabbit.Banking.Application.Models;
using BankingMicroRabbit.Banking.Domain.Models;
using System.Collections.Generic;

namespace BankingMicroRabbit.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
        void Transfer(AccountTransfer accountTransfer);
    }
}
