using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WeatherAppMVVM.ViewModel
{
    public class UVConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            float uv;
            string uvString = (string)value;
            if(float.TryParse(uvString, out uv))
            {
                if (uv < 3)
                    return "Low";
                if (uv < 7)
                    return "Middle";
            }
            return "High";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "0.0";
        }
    }
}
