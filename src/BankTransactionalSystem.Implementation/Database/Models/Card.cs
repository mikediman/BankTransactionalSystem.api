﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionalSystem.Implementation.Database.Models
{
    public class Card
    {
        public Guid CardId { get; set; }
        public string CardNumber { get; set; }
        public string Balance { get; set; }
    }
}
