using System;
using System.Collections.Generic;

#nullable disable

namespace api.Models
{
    public partial class Log
    {
        public int Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public string IpAddress { get; set; }
        public string ContractAddress { get; set; }
        public double TotalDrace { get; set; }
        public double TotalXDrace { get; set; }
    }
}
