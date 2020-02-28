using DotNetMicroRabbit.Domain.Core.Bus;
using DotNetMicroRabbit.Transfer.Application.Interfaces;
using DotNetMicroRabbit.Transfer.Domain.Interfaces;
using DotNetMicroRabbit.Transfer.Domain.Models;
using System.Collections.Generic;

namespace DotNetMicroRabbit.Transfer.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _transferRepository;
        private readonly IEventBus _bus;

        public TransferService(ITransferRepository transferRepository, IEventBus bus)
        {
            _transferRepository = transferRepository;
            _bus = bus;
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _transferRepository.GetTransferLogs();
        }
    }
}
