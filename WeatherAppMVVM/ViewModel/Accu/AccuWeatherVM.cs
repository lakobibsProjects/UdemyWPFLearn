using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAppMVVM.Model;

namespace WeatherAppMVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class AccuWeatherVM
    {
        public WeatherAccu Weather { get; set; }
        private string query;
        private AccuCity selectedResult;
        public ObservableCollection<AccuCity> Cities { get; set; }
        public AccuCity SelectedResult
        {
            get { return selectedResult; }
            set
            {
                selectedResult = value;
                GetWeather();
            }
        }
        public string Query
        {
            get { return query; }
            set
            {
                query = value;
                GetCitiesAsync();
            }
        }

        public AccuWeatherVM()
        {
            Weather = new WeatherAccu();
            Cities = new ObservableCollection<AccuCity>();
            SelectedResult = new AccuCity();
        }

        private async Task GetCitiesAsync()
        {
            var cities = await WeatherAccuAPI.GetAutocompliteAsync(Query);

            Cities.Clear();
            foreach (var city in cities)
            {
                Cities.Add(city);
            }
        }
        private async void GetWeather()
        {
            if (SelectedResult != null && SelectedResult.Key != null)
            {
                var weather = await WeatherAccuAPI.GetWeatherInformationAsync(SelectedResult.Key);

                foreach (var w in weather.DailyForecasts)
                {
                    int i = 0;
                    Weather.Headline = weather.Headline;
                    Weather.DailyForecasts[i].Date = w.Date;
                    Weather.DailyForecasts[i].Temperature.Maximum = w.Temperature.Maximum;
                    Weather.DailyForecasts[i].Temperature.Minimum = w.Temperature.Minimum;                    
                    i++;
                }

            }

        }
    }
}
