﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MicroRabit.Banking.Domain.Models
{

    public class Account
    {
       public int AccountId { get; set; }
       public string AccountType { get; set; }
       public decimal AccountBalance { get; set; }
    }
}
