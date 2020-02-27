using DotNetMicroRabbit.Banking.Domain.Commands;
using DotNetMicroRabbit.Banking.Domain.Events;
using DotNetMicroRabbit.Domain.Core.Bus;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetMicroRabbit.Banking.Domain.CommandHandlers
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
