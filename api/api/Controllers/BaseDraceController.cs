using api.Dto;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;

namespace api.Controllers
{
    [ApiController]
    public class BaseDraceController : ControllerBase
    {
        protected readonly DraceDBContext _dbContext;
        protected readonly AppSettingDto _appSetting;
        protected readonly IMapper _mapper;

        public BaseDraceController(IServiceProvider serviceProvider)
        {
            _dbContext = serviceProvider.GetService(typeof(DraceDBContext)) as DraceDBContext;
            _appSetting = serviceProvider.GetService(typeof(AppSettingDto)) as AppSettingDto;
            _mapper = serviceProvider.GetService(typeof(IMapper)) as IMapper;
        }
        protected void WriteLog(string addr, double totalDrace, double totalXdrace)
        {
            var ipAddress = Request.HttpContext.Connection.RemoteIpAddress;
            _dbContext.Logs.Add(new Log
            {
                IpAddress = ipAddress.ToString(),
                Date = DateTimeOffset.UtcNow,
                ContractAddress = addr,
                TotalDrace = totalDrace,
                TotalXDrace = totalXdrace
            });
            _dbContext.SaveChanges();
        }
    }
}
