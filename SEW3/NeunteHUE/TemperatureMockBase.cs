using System;
using System.Threading;
using System.Threading.Tasks;

public abstract class TemperatureMockBase : IDisposable
{
    private readonly TimeSpan _interval;
    private CancellationTokenSource? _cts;
    private Task? _backgroundTask;
    private readonly object _lock = new();

    protected double _currentTemperature;

    public double CurrentTemperature
    {
        get
        {
            lock (_lock)
            {
                return _currentTemperature;
            }
        }
        protected set
        {
            lock (_lock)
            {
                _currentTemperature = value;
            }
        }
    }

    protected TemperatureMockBase(
        double initialTemperature,
        TimeSpan? interval = null)
    {
        _currentTemperature = initialTemperature;
        _interval = interval ?? TimeSpan.FromSeconds(1);
    }

    public void Start()
    {
        if (_backgroundTask != null)
            return;

        _cts = new CancellationTokenSource();
        _backgroundTask = Task.Run(() => RunAsync(_cts.Token));
    }

    public void Stop()
    {
        _cts?.Cancel();
        _backgroundTask = null;
    }

    private async Task RunAsync(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            CurrentTemperature = CalculateNextTemperature();
            await Task.Delay(_interval, token);
        }
    }

    protected abstract double CalculateNextTemperature();

    public void Dispose()
    {
        Stop();
        _cts?.Dispose();
    }
}
