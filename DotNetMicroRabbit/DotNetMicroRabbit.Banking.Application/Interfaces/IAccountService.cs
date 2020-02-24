using DotNetMicroRabbit.Banking.Domain.Models;
using System.Collections.Generic;

namespace DotNetMicroRabbit.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
    }
}
