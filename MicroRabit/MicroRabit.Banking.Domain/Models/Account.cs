using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabit.Banking.Domain.Models
{
   public class Account
    {
        int AccountId { get; set; }
        string AccountType { get; set; }
        decimal AccountBalance { get; set; }
    }
}
