using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeunteHUE
{
    public class HeatingCoolingMock : TemperatureMockBase
    {
        private bool _heating = true;

        public HeatingCoolingMock()
            : base(20.0)
        {
        }

        protected override double CalculateNextTemperature()
        {
            double temp = CurrentTemperature;

            if (_heating)
            {
                temp += 0.7;
                if (temp >= 40.0)
                    _heating = false;
            }
            else
            {
                temp -= 0.7;
                if (temp <= 20.0)
                    _heating = true;
            }

            return temp;
        }
    }

}
