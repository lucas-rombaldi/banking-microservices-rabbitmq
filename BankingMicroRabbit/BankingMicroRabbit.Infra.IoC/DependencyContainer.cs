using BankingMicroRabbit.Banking.Application.Interfaces;
using BankingMicroRabbit.Banking.Application.Services;
using BankingMicroRabbit.Banking.Data.Context;
using BankingMicroRabbit.Banking.Data.Repository;
using BankingMicroRabbit.Banking.Domain.CommandHandlers;
using BankingMicroRabbit.Banking.Domain.Commands;
using BankingMicroRabbit.Banking.Domain.Interfaces;
using BankingMicroRabbit.Domain.Core.Bus;
using BankingMicroRabbit.Infra.Bus;
using BankingMicroRabbit.Transfer.Application.Interfaces;
using BankingMicroRabbit.Transfer.Application.Services;
using BankingMicroRabbit.Transfer.Data.Context;
using BankingMicroRabbit.Transfer.Data.Repository;
using BankingMicroRabbit.Transfer.Domain.EventHandlers;
using BankingMicroRabbit.Transfer.Domain.Events;
using BankingMicroRabbit.Transfer.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BankingMicroRabbit.Infra.IoC
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
