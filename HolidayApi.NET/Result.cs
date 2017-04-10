using System.Collections.Generic;
using Newtonsoft.Json;

namespace HolidayApi
{
    public class Result
    {
        [JsonProperty(PropertyName = "status")]
        public int Status;

        [JsonProperty(PropertyName = "holidays")]
        public Dictionary<string, HolidayData[]> Holidays;
    
        [JsonProperty(PropertyName = "error")]
        public string Error;
    }
}
