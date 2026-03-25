using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_Sensor
{
    internal class Sensor
    {
        private double? currentValue;
        public string SensorName { get; set; }

        public event Action<double, Sensor> ValueChanged;
        public event Action<double, Sensor> AlarmOccured;
        public event Func<double, bool> Valadating;        



        public Sensor(string sensorName)
        {
            this.SensorName = sensorName;
        }

        public double? CurrentValue
        {
            get
            {
                return this.currentValue;
            }
            set
            {
                bool changed = this.currentValue != value;      
                this.currentValue = value;                     
                if (changed && this.currentValue.HasValue && this.ValueChanged != null)     
                {                                                                           
                    ValueChanged(this.currentValue.Value, this);
                }
          
                if (Valadating != null && this.currentValue.HasValue)
                {
                    bool valid = Valadating(this.currentValue.Value);
                    if (!valid && AlarmOccured != null)
                    {
                        AlarmOccured(this.currentValue.Value, this);
                    }
                }
            }
        }
    }
}
