using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabit.Banking.Domain.Commands
{
    public class CreateTransferCommand : TransferCommands
    {
       public CreateTransferCommand (int from, int to, decimal ammount)
        {
            From = from;
            To = to;
            Amount = ammount;
        }
    }
}
