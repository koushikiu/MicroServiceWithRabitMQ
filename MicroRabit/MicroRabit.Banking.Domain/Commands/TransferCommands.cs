using MicroRabit.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabit.Banking.Domain.Commands
{
   public abstract class TransferCommands: Command
    {
        public int From { get; protected set; }
        public int To { get; protected set; }
        public decimal Amount { get; protected set; }

    }
}
