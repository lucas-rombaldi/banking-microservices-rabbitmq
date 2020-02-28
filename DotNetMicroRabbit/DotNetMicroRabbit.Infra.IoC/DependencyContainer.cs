using DotNetMicroRabbit.Banking.Application.Interfaces;
using DotNetMicroRabbit.Banking.Application.Services;
using DotNetMicroRabbit.Banking.Data.Context;
using DotNetMicroRabbit.Banking.Data.Repository;
using DotNetMicroRabbit.Banking.Domain.CommandHandlers;
using DotNetMicroRabbit.Banking.Domain.Commands;
using DotNetMicroRabbit.Banking.Domain.Interfaces;
using DotNetMicroRabbit.Domain.Core.Bus;
using DotNetMicroRabbit.Infra.Bus;
using DotNetMicroRabbit.Transfer.Application.Interfaces;
using DotNetMicroRabbit.Transfer.Application.Services;
using DotNetMicroRabbit.Transfer.Data.Context;
using DotNetMicroRabbit.Transfer.Data.Repository;
using DotNetMicroRabbit.Transfer.Domain.EventHandlers;
using DotNetMicroRabbit.Transfer.Domain.Events;
using DotNetMicroRabbit.Transfer.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetMicroRabbit.Infra.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });

            //Subscriptions
            services.AddTransient<TransferEventHandler>();

            //Domain Events
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

            //Domain Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            //Application Services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService>();

            //Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();
            services.AddTransient<BankingDbContext>();
            services.AddTransient<TransferDbContext>();
        }
    }
}
