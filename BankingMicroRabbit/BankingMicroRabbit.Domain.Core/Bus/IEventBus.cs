using BankingMicroRabbit.Domain.Core.Commands;
using BankingMicroRabbit.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BankingMicroRabbit.Domain.Core.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;

        void Publish<T>(T @event) where T : Event;

        void Subscribe<T, THandler>()
            where T : Event
            where THandler : IEventHandler;
    }
}
