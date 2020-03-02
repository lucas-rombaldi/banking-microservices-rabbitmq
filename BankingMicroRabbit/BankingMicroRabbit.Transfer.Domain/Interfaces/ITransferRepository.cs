using BankingMicroRabbit.Transfer.Domain.Models;
using System.Collections.Generic;

namespace BankingMicroRabbit.Transfer.Domain.Interfaces
{
    public interface ITransferRepository
    {
        IEnumerable<TransferLog> GetTransferLogs();
        void Add(TransferLog transferLog);
    }
}
