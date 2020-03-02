using BankingMicroRabbit.Domain.Core.Bus;
using BankingMicroRabbit.Transfer.Application.Interfaces;
using BankingMicroRabbit.Transfer.Domain.Interfaces;
using BankingMicroRabbit.Transfer.Domain.Models;
using System.Collections.Generic;

namespace BankingMicroRabbit.Transfer.Application.Services
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
