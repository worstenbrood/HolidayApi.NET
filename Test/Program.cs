using System;
using HolidayApi;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var holidayApi = new Holiday("422957bb-ed30-4e95-a09d-f24e950cf2e4");
            foreach (var holiday in holidayApi.Fetch("BE", 2016))
            {
                Console.WriteLine("{0}: {1}", holiday.Date, holiday.Name);
            }
        }
    }
}
