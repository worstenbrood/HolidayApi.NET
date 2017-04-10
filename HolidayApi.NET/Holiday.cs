using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace HolidayApi
{
    public class Holiday
    {
        public const string Url = "https://holidayapi.com/v1/holidays?key={0}";

        private string _baseUrl;

        public Holiday(string key)
        {
            _baseUrl = string.Format(Url, key);
        }

        private IEnumerable<HolidayData> FetchData(string data)
        {
            var request = WebRequest.Create(string.Format("{0}&{1}", _baseUrl, data));

            using (var response = request.GetResponse())
            {
                using (var stream = new StreamReader(response.GetResponseStream()))
                {
                    var result = JsonConvert.DeserializeObject<Result>(stream.ReadToEnd());

                    if (result.Status != 200)
                        throw new Exception(result.Error);
                    
                    return result.Holidays.Values.SelectMany(v => v);
                }
            }
        }

        public IEnumerable<HolidayData> Fetch(string country = "BE", int year = 0, bool ispublic = true)
        {
            var parameters = string.Format("&country={0}&year={1}&public={2}", country, year, ispublic);
            return FetchData(parameters);
        }
    }
}
