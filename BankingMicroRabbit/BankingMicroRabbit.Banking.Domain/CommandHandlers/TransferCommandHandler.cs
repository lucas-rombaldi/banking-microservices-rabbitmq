using BankingMicroRabbit.Banking.Domain.Commands;
using BankingMicroRabbit.Banking.Domain.Events;
using BankingMicroRabbit.Domain.Core.Bus;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BankingMicroRabbit.Banking.Domain.CommandHandlers
{
    public class TransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
    {
        private readonly IEventBus _bus;
        public TransferCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new TransferCreatedEvent(request.From, request.To, request.Amount));
            return Task.FromResult(true);
        }
    }
}
