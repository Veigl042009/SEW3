using System;
using System.Threading.Tasks;
using _15_Sensor;

namespace NeunteHUE;

public partial class MainPage : ContentPage
{
    private Sensor sensor = new Sensor("TemperaturSensor");

    public MainPage()
    {
        InitializeComponent();

        sensor.ValueChanged += Sensor_ValueChanged;
        sensor.Valadating += Sensor_Validating;
        sensor.AlarmOccured += Sensor_AlarmOccured;
    }

    private void Sensor_ValueChanged(double value, Sensor s)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            TemperatureLabel.Text = $"{value:F1} °C";
            StatusLabel.Text = "Wert geändert";
        });
    }

    private bool Sensor_Validating(double value)
    {
        return value >= 0 && value <= 30;
    }

    private void Sensor_AlarmOccured(double value, Sensor s)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            StatusLabel.Text = $"ALARM: {value:F1} °C";
        });
    }

    private async void StartSimulation(object sender, EventArgs e)
    {
        var mock = new CoolingHeatingMock();
        mock.Start();

        for (int i = 0; i < 100; i++)
        {
            var temperature = mock.CurrentTemperature;
            sensor.CurrentValue = temperature;

            await Task.Delay(1000);
        }

        mock.Stop();
    }
}