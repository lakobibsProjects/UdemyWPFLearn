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
    public class WeatherVM
    {
        public WeatherUnderground Weather { get; set; }
        private string query;
        private RESULT selectedResult;
        public ObservableCollection<RESULT> Cities { get; set;}
        public RESULT SelectedResult
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
        public RefreshCommand RefreshCommand { get; set; }
               

        public WeatherVM()
        {
            Weather = new WeatherUnderground();
            Cities = new ObservableCollection<RESULT>();
            SelectedResult = new RESULT();
            RefreshCommand = new RefreshCommand(this);
        }

        private async Task GetCitiesAsync()
        {
            var cities = await WeatherUndergroundAPI.GetAutocompliteAsync(Query);

            Cities.Clear();
            foreach (var city in cities)
            {
                Cities.Add(city);
            }            
        }

        public async void GetWeather()
        {
            if (SelectedResult.L != null)
            { 
            var weather = await WeatherUndergroundAPI.GetWeatherInformationAsync(SelectedResult.L);
            Weather.current_observation.weather = weather.current_observation.weather;
            Weather.current_observation.UV = weather.current_observation.UV;
            Weather.current_observation.wind_string = weather.current_observation.wind_string;
            Weather.current_observation.precip_today_string = weather.current_observation.precip_today_string;
            Weather.current_observation.temperature_string = weather.current_observation.temperature_string;
            Weather.current_observation.display_location.city = weather.current_observation.display_location.city;
            }
        
        }
    }
}
