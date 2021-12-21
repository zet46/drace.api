using api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api.Controllers
{
    [ApiController]
    public class ContractController : BaseDraceController
    {
        public ContractController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpGet("drace/contracts")]
        public IEnumerable<Contract> GetContracts()
        {
            var ipAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            return _dbContext.Contracts.Where(x => ipAddress == "::1" || x.AllowIpAddress == ipAddress);
        }
    }
}
