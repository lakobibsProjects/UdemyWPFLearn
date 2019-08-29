using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherAppMVVM.Model;

namespace WeatherAppMVVM.ViewModel
{
    class WeatherAccuAPI
    {
        public const string API_KEY = "3y93ua2O4e3AkUPKqNymMbmLdG2Y6mQd";
        public const string BASE_URL = "http://dataservice.accuweather.com/forecasts/v1/daily/5day/{0}?apikey={1}&metric=true";
        public const string BASE_URL_AUTOCOMPLITE = "http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public static async Task<WeatherAccu> GetWeatherInformationAsync(string locationKey)
        {
            WeatherAccu result = new WeatherAccu();

            string url = string.Format(BASE_URL, locationKey, API_KEY);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<WeatherAccu>(json);
            }

            return result;
        }
        public static async Task<List<AccuCity>> GetAutocompliteAsync(string query)
        {
            List<AccuCity> cities = new List<AccuCity>();

            string url = string.Format(BASE_URL_AUTOCOMPLITE, API_KEY, query);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                cities = JsonConvert.DeserializeObject<List<AccuCity>>(json);
            }

            return cities;
        }

    }
}
