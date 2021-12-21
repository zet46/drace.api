using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api.Dto
{
    public class RacingDto
    {
        public RacingDto(List<RacingItemDto> racingItems)
        {
            Items = racingItems;
        }
        public double SumDrace => Items.Sum(x => x.DraceReward);
        public double SumXDrace => Items.Sum(x => x.XdraceReward);
        public double SumTime => Items.Sum(x => x.Mins);
        public int Count => Items.Count();
        public double AvgDrace => Count > 0 ? SumDrace / Count : 0;
        public double AvgXDrace => Count > 0 ? SumXDrace / Count : 0;
        public double AvgTime => Count > 0 ? SumTime / Count : 0;
        public List<RacingItemDto> Items { get; set; }
    }
    public class RacingItemDto
    {
        public int CarId { get; set; }
        [JsonIgnore]
        public long StartTime { get; set; }
        [JsonProperty("startTime")]
        public DateTimeOffset StartTimeDate => DateTimeOffset.FromUnixTimeSeconds(StartTime);
        [JsonIgnore]
        public long EndTime { get; set; }
        [JsonProperty("endTime")]
        public DateTimeOffset EndTimeDate => DateTimeOffset.FromUnixTimeSeconds(EndTime);
        public double Mins => (EndTime - StartTime) / 60.0;
        public int Score { get; set; }
        public double DraceReward { get; set; }
        public double XdraceReward { get; set; }
    }
    public class RacingResultDto
    {
        public List<Item> Items { get; set; }
    }
    public class Item
    {
        public int CarId { get; set; }
        public long StartTime { get; set; }
        public long EndTime { get; set; }
        public int Score { get; set; }
        public double DraceReward { get; set; }
        public double XdraceReward { get; set; }
    }
}
