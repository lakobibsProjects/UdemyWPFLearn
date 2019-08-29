using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppMVVM.Model
{
    [AddINotifyPropertyChangedInterface]
    public class Area
    {
        public string ID { get; set; }
        public string LocalizedName { get; set; }
    }

    [AddINotifyPropertyChangedInterface]
    public class AccuCity
    {
        public string Key { get; set; }
        public string LocalizedName { get; set; }
        public Area Country { get; set; }
        public Area AdministrativeArea { get; set; }
    }

}
