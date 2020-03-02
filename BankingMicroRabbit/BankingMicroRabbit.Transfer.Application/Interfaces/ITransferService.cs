using BankingMicroRabbit.Transfer.Domain.Models;
using System.Collections.Generic;

namespace BankingMicroRabbit.Transfer.Application.Interfaces
{
    public interface ITransferService
    {
        IEnumerable<TransferLog> GetTransferLogs();
    }
}
