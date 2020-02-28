using DotNetMicroRabbit.Transfer.Data.Context;
using DotNetMicroRabbit.Transfer.Domain.Interfaces;
using DotNetMicroRabbit.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetMicroRabbit.Transfer.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private readonly TransferDbContext _ctx;

        public TransferRepository(TransferDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _ctx.TransferLogs;
        }

        public void Add(TransferLog transferLog)
        {
            _ctx.Add(transferLog);
            _ctx.SaveChanges();
        }
    }
}
