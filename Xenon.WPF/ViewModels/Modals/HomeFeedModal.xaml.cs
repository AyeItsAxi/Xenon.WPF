using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;
using Newtonsoft.Json;
using Wpf.Ui.Controls;
using Xenon.WPF.Common.Weather;

namespace Xenon.WPF.ViewModels.Modals
{
    /// <summary>
    /// Interaction logic for HomeFeedModal.xaml
    /// </summary>
    public partial class HomeFeedModal : UiPage
    {
        public static Weather? weather;
        public HomeFeedModal()
        {
            InitializeComponent();
            Initialize();
            // TODO: Weather data by ipapi ip address passed into openweathermap
        }

        public async void Initialize()
        {
            //dont care if its obsolete it works
            WebClient wc = new();
            string latlong = wc.DownloadString($"https://ipapi.co/{GetIPV4Address()}/latlong");
            string lat = latlong.Split(',')[0];
            string @long = latlong.Split(',')[1];
            string jsresp = wc.DownloadString($"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={@long}&appid=6e196828dad7235411a78ecadc8a792a");
            jsresp = jsresp.Replace("[", "");
            jsresp = jsresp.Replace("]", "");
            weather = JsonConvert.DeserializeObject<Weather>(jsresp);
            await Task.Delay(500);
            var reader = XmlReader.Create("https://www.tempe.gov/Home/Components/RssFeeds/RssFeed/View?ctID=6&cateIDs=15");
            var feed = SyndicationFeed.Load(reader);
            Common.Static.asd = feed.Items.ToList();
            SetContent();
            StartStatusBarTimer();
        }
        
        private void StartStatusBarTimer()
        {
            System.Timers.Timer statusTime = new()
            {
                Interval = 2000
            };
            statusTime.Elapsed += new(StatusTimeElapsed);
            statusTime.Enabled = true;
        }

        private void StatusTimeElapsed(object sender, ElapsedEventArgs e)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(UpdateTime, DispatcherPriority.SystemIdle);
        }

        private void UpdateTime()
        {
            DateLabel.Content = $"{DateTime.Now:dddd, MMMM dd, yyyy} - {DateTime.Now:h:mm tt}";
        }

        public void SetContent()
        {
            CityLabel.Content = weather.name;
            DateLabel.Content = $"{DateTime.Now:dddd, MMMM dd, yyyy} - {DateTime.Now:h:mm tt}";
            WeatherConditionLabel.Content = $"- {weather.weather.main}";
            TemperatureCurrent.Content = $"{ConvertKelvinToFahrenheit(weather.main.temp)}";
            TemperatureLow.Text = $"{ConvertKelvinToFahrenheit(weather.main.temp_min)}";
            TemperatureHigh.Text = $"{ConvertKelvinToFahrenheit(weather.main.temp_max)}";
            for (int i = 0; i < Common.Static.asd.Count; i++)
            {
                listBox.Items.Add(Common.Static.asd[i].Title.Text);
            }
        }

        public string GetIPV4Address()
        {
            WebClient wc = new WebClient();
            return wc.DownloadString("https://api.ipify.org/");
        }
        
        public string ConvertKelvinToFahrenheit(string kelvin)
        {
            return $"{Math.Round((Convert.ToDouble(kelvin) - 273.15) * 9 / 5 + 32)}°";
        }
    }
}
