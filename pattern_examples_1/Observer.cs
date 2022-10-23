using System;
using System.Collections.Generic;

namespace PracticeTime3
{
    // Weather Observerable : Weather => AnalizeStation 
    public sealed class WeatherDataArgs
    {
        public readonly int _temperature;
        public readonly int _windSpeed;
        public WeatherDataArgs(int temperature, int windSpeed)
        {
            _temperature = temperature;
            _windSpeed = windSpeed;
        }
    }
    public interface IObserver
    {
        void UpdateData(WeatherDataArgs _weatherArgs);
    }
    public interface IObservable
    {
        void AddObserver(IObserver _observer);
        void RemoveObserver(IObserver _observer);
        void NotifyObservers();
    }
    public sealed class Weather : IObservable
    {
        private List<IObserver> _observers;
        private WeatherDataArgs _weatherData;
        public WeatherDataArgs WeatherData
        {
            get => _weatherData;
            set
            {
                _weatherData = value;
                NotifyObservers();
            }
        }
        public Weather(WeatherDataArgs _weatherData)
        {
            _observers = new List<IObserver>();
            this._weatherData = _weatherData;
        }
        public void NotifyObservers()
        {
            foreach(IObserver _obs in _observers)
            {
                _obs.UpdateData(_weatherData);
            }
        }
        public void AddObserver(IObserver _observer)
        {
            _observers.Add(_observer);
        }
        public void RemoveObserver(IObserver _observer)
        {
            _observers.Remove(_observer);
        }
    }

    public class AnalizeStation : IObserver
    {
        private delegate void OneInputOperaion<in T>(T _weatherData);
        private event OneInputOperaion<WeatherDataArgs> WeatherChanged;

        public AnalizeStation()
        {
            InitializeEvents();
        }
        private void InitializeEvents()
        {
            WeatherChanged += PrintWeatherData;
        }
        public void UpdateData(WeatherDataArgs _weatherArgs)
        {
            WeatherChanged.Invoke(_weatherArgs);
        }
        private void PrintWeatherData(WeatherDataArgs _weatherArgs)
        {
            Console.WriteLine(_weatherArgs._temperature);
            Console.WriteLine(_weatherArgs._windSpeed);
        }
    }

}
