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
    public class RESULT
    {
        public string Name { get; set; }

        public string L { get; set; }
        
    }

    [AddINotifyPropertyChangedInterface]
    public class UndergroundCity
    {        
        public List<RESULT> RESULTS{ get; set; } 

    }

}
