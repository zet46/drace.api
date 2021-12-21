using api.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    public class RacingController : BaseDraceController
    {
        public RacingController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpGet("drace/{addr}/racings")]
        public async Task<RacingDto> GetRacingsAsync(string addr)
        {
            using (var httpClient = new HttpClient())
            {
                var url = _appSetting.DraceApiUrl;
                httpClient.BaseAddress = new Uri(url);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (var response = await httpClient.GetAsync($"{addr}/rewards?limit={_appSetting.DefaultPageSize}"))
                {
                    var resultJson = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<RacingResultDto>(resultJson);
                    var racingItems = _mapper.Map<List<RacingItemDto>>(result.Items);
                    var dto = new RacingDto(racingItems);
                    WriteLog(addr, dto.SumDrace, dto.SumXDrace);
                    return dto;
                }
            }
        }
    }
}
