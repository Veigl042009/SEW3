using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_Sensor
{
    internal class Sensor
    {
        private double? currentValue; // nullable double, da der Sensor möglicherweise keinen Wert hat (z.B. wenn er gerade nicht misst)
        public string SensorName { get; set; }  

        public event Action<double, Sensor> ValueChanged; // Event, das ausgelöst wird, wenn sich der Wert ändert. Action Delegate mit einem double Parameter (neuer Wert)
        public event Action<double, Sensor> AlarmOccured;
        public event Func<double, bool> Validating; // Rückgabewert: true --> alles ok, false --> irgendwas stimmt nicht, z.B. ungültiger Wert oder Sensor defekt
        
        
        
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
                bool changed = this.currentValue != value; // prüfen, ob sich der Wert geändert hat
                this.currentValue = value;
                if (changed && this.currentValue.HasValue && this.ValueChanged != null) // wenn ein Eventhandler angemeldet ist, dann null
                {
                    ValueChanged(this.currentValue.Value, this); // Event mit dem neuen Wert auslösen
                }

                if(Validating != null && this.currentValue.HasValue)
                {
                    bool valid = Validating(this.currentValue.Value);// Validierung durchführen
                    if (!valid && AlarmOccured != null) // wenn ungültig und Eventhandler für Alarm angemeldet ist
                    {
                        AlarmOccured(this.currentValue.Value, this); // Alarm auslösen
                    }
                }
            }
        }
    }
}
