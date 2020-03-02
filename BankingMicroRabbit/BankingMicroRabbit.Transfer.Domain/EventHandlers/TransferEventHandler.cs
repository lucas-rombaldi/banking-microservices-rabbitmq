using BankingMicroRabbit.Domain.Core.Bus;
using BankingMicroRabbit.Transfer.Domain.Events;
using BankingMicroRabbit.Transfer.Domain.Interfaces;
using BankingMicroRabbit.Transfer.Domain.Models;
using System;
using System.Threading.Tasks;

namespace BankingMicroRabbit.Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository _transferRepository;
        public TransferEventHandler(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }

        public Task Handle(TransferCreatedEvent @event)
        {
            _transferRepository.Add(new TransferLog()
            {
                FromAccount = @event.From,
                ToAccount = @event.To,
                Amount = @event.Amount,
            });

            return Task.CompletedTask;
        }
    }
}
