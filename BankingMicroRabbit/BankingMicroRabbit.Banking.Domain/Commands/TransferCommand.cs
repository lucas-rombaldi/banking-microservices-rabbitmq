﻿using BankingMicroRabbit.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingMicroRabbit.Banking.Domain.Commands
{
    public abstract class TransferCommand : Command
    {
        public int From { get; protected set; }
        public int To { get; protected set; }
        public decimal Amount { get; protected set; }
    }
}
