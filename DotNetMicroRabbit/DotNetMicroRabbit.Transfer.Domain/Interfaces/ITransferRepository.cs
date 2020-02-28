using DotNetMicroRabbit.Transfer.Domain.Models;
using System.Collections.Generic;

namespace DotNetMicroRabbit.Transfer.Domain.Interfaces
{
    public interface ITransferRepository
    {
        IEnumerable<TransferLog> GetTransferLogs();
        void Add(TransferLog transferLog);
    }
}
