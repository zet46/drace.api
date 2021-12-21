using System;
using System.Collections.Generic;

#nullable disable

namespace api.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public double DraceAmount { get; set; }
        public double XDraceAmount { get; set; }
        public string ContractAddress { get; set; }

        public virtual Contract ContractAddressNavigation { get; set; }
    }
}
