// See https://aka.ms/new-console-template for more information
using _17_Sensor;
using System.Xml;



Sensor temp1 = new Sensor("Temperatursensor 1");
temp1.ValueChanged += TemperatureChanged;
temp1.CurrentValue = 23.5;
temp1.Validating += ValidatingTemperature;
temp1.AlarmOccured += TemperatureAlarmOccured;

void TemperatureAlarmOccured(double value, Sensor sender)
{
    if(value < 28)
    {
        Console.WriteLine("Lüfter aus");
    }
    if(value > 34)
    {
        Console.WriteLine("Lüfter ein");
    }
}

bool ValidatingTemperature(double value)
{
    if (value < 28 || value > 34)
    {
        return false;
    }
    else
    {
        return true;
    }
       
}

void TemperatureChanged(double obj, Sensor sender)
{




    Console.WriteLine($"Neue Temperatur {obj} auf Sensor: {sender.SensorName} ");
}

Console.WriteLine(temp1.CurrentValue);
temp1.CurrentValue = 27.5;
temp1.CurrentValue = 29.5;
temp1.CurrentValue = 35.0;
temp1.CurrentValue = 33.0;

