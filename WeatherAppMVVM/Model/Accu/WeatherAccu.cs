using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppMVVM.Model
{
    [AddINotifyPropertyChangedInterface]
    public class Headline
    {
        public DateTime EffectiveDate { get; set; }
        public int EffectiveEpochDate { get; set; }
        public int Severity { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
        public DateTime EndDate { get; set; }
        public int EndEpochDate { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }

    [AddINotifyPropertyChangedInterface]
    public class Minimum : Range
    {
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    [AddINotifyPropertyChangedInterface]
    public class Maximum : Range
    {
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Temperature
    {
        public Minimum Minimum { get; set; }
        public Maximum Maximum { get; set; }
    }

    [AddINotifyPropertyChangedInterface]
    public class Day
    {
        public int Icon { get; set; }
        public string IconPhrase { get; set; }
        public bool HasPrecipitation { get; set; }
        public string PrecipitationType { get; set; }
        public string PrecipitationIntensity { get; set; }
    }

    [AddINotifyPropertyChangedInterface]
    public class Night
    {
        public int Icon { get; set; }
        public string IconPhrase { get; set; }
        public bool HasPrecipitation { get; set; }
        public string PrecipitationType { get; set; }
        public string PrecipitationIntensity { get; set; }
    }

    [AddINotifyPropertyChangedInterface]
    public class DailyForecast
    {
        public DateTime Date { get; set; }
        public int EpochDate { get; set; }
        public Temperature Temperature { get; set; }
        public Day Day { get; set; }
        public Night Night { get; set; }
        public IList<string> Sources { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }

    [AddINotifyPropertyChangedInterface]
    public class Range
    {
        public double Value { get; set; }
    }



    [AddINotifyPropertyChangedInterface]
    public class WeatherAccu
    {
        public Headline Headline { get; set; }
        public List<DailyForecast> DailyForecasts { get; set; }

        public WeatherAccu()
        {
                DailyForecasts = new List<DailyForecast>();
                for (int i = 0; i < 3; i++)
                {
                    DailyForecast dailyForecast = new DailyForecast
                    {
                        Date = DateTime.Now.AddDays(-i),
                        Temperature = new Temperature
                        {
                            Maximum = new Range
                            {
                                Value = 21 + i
                            } as Maximum,
                            Minimum = new Range
                            {
                                Value = 5 - i
                            } as Minimum
                        }
                    };
                    DailyForecasts.Add(dailyForecast);
                }            
        }

    }


}
