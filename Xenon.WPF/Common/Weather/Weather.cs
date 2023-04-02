using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xenon.WPF.Common.Weather
{
    public class Weather
    {
        public WeatherCoord coord { get; set; }
        public WeatherWeather weather { get; set; }
        public string @base { get; set; }
        public WeatherMain main { get; set; }
        public string visibility { get; set; }
        public WeatherWind wind { get; set; }
        public WeatherClouds clouds { get; set; }
        public string dt { get; set; }
        public WeatherSys sys { get; set; }
        public string timezone { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string cod { get; set; }
    }
}
