using System;
using Newtonsoft.Json;

namespace HolidayApi
{
    public class HolidayData
    {
        [JsonProperty(PropertyName = "name")]
        public string Name;

        [JsonProperty(PropertyName = "date")]
        public DateTime Date;

        [JsonProperty(PropertyName = "observer")]
        public DateTime Observer;

        [JsonProperty(PropertyName = "public")]
        public bool Public;
    }
}
