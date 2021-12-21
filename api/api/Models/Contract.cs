using System;
using System.Collections.Generic;

#nullable disable

namespace api.Models
{
    public partial class Contract
    {
        public Contract()
        {
            Deposits = new HashSet<Deposit>();
            Payments = new HashSet<Payment>();
        }

        public string ContractAddress { get; set; }
        public string Description { get; set; }
        public string Account { get; set; }
        public string RacerName { get; set; }
        public string RacerTelegram { get; set; }
        public double? Kpi { get; set; }
        public double? UnderKpiPaidPercent { get; set; }
        public double? PaidPercent { get; set; }
        public string AllowIpAddress { get; set; }

        public virtual ICollection<Deposit> Deposits { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
