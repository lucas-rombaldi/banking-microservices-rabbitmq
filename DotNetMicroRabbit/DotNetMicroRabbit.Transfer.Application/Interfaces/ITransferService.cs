using DotNetMicroRabbit.Transfer.Domain.Models;
using System.Collections.Generic;

namespace DotNetMicroRabbit.Transfer.Application.Interfaces
{
    public interface ITransferService
    {
        IEnumerable<TransferLog> GetTransferLogs();
    }
}
