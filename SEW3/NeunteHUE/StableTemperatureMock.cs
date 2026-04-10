using System;

public class StableTemperatureMock : TemperatureMockBase
{
    private readonly Random _random = new();

    public StableTemperatureMock()
        : base(19.0)
    {
    }

    protected override double CalculateNextTemperature()
    {
        double variation = (_random.NextDouble() - 0.5) * 1.0;
        return Math.Clamp(19.0 + variation, 18.0, 20.0);
    }
}

public class CoolingHeatingMock : TemperatureMockBase
{
    private bool _cooling = true;

    public CoolingHeatingMock()
        : base(15.0)
    {
    }

    protected override double CalculateNextTemperature()
    {
        double temp = CurrentTemperature;

        if (_cooling)
        {
            temp -= 0.5;
            if (temp <= -5.0)
                _cooling = false;
        }
        else
        {
            temp += 0.5;
            if (temp >= 15.0)
                _cooling = true;
        }

        return temp;
    }
}

