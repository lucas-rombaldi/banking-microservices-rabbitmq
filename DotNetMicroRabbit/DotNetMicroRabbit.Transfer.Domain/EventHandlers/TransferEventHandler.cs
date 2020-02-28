using DotNetMicroRabbit.Domain.Core.Bus;
using DotNetMicroRabbit.Transfer.Domain.Events;
using DotNetMicroRabbit.Transfer.Domain.Interfaces;
using DotNetMicroRabbit.Transfer.Domain.Models;
using System;
using System.Threading.Tasks;

namespace DotNetMicroRabbit.Transfer.Domain.EventHandlers
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
