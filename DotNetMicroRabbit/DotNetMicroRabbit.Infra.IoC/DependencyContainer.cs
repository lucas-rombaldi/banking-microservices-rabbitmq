using DotNetMicroRabbit.Banking.Application.Interfaces;
using DotNetMicroRabbit.Banking.Application.Services;
using DotNetMicroRabbit.Banking.Data.Context;
using DotNetMicroRabbit.Banking.Data.Repository;
using DotNetMicroRabbit.Banking.Domain.CommandHandlers;
using DotNetMicroRabbit.Banking.Domain.Commands;
using DotNetMicroRabbit.Banking.Domain.Interfaces;
using DotNetMicroRabbit.Domain.Core.Bus;
using DotNetMicroRabbit.Infra.Bus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetMicroRabbit.Infra.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Domain Bus
            services.AddTransient<IEventBus, RabbitMQBus>();

            //Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            //Application Services
            services.AddTransient<IAccountService, AccountService>();

            //Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<BankingDbContext>();
        }
    }
}
