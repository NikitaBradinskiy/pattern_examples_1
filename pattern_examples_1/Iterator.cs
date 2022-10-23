using System;
using System.Collections;
using System.Collections.Generic;

namespace PracticeTime3
{
    public enum DeviceStyle
    {
        Work,
        Study,
        Gamers,
    }

    public abstract class Device
    {
        public static int _id { get; private set; }
        public int ID = _id;
        private DeviceStyle _deviceStyle;
        public DeviceStyle _DeviceStyle => _deviceStyle;
        public Device(DeviceStyle deviceStyle)
        {
            _deviceStyle = deviceStyle;
            _id++;
        }
    }
    public sealed class Keyboard : Device
    {
        public Keyboard(DeviceStyle deviceStyle) : base (deviceStyle)
        {
        }
    }
    public class Store : IEnumerable<Device>
    {
        public List<Device> _devices;
        public Store(List<Device> devices)
        {
            _devices = devices;
        }

        public IEnumerator<Device> GetEnumerator()
        {
            return _devices.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    public class Customer
    {
        private Store _store;
        private DeviceStyle _style;

        public Customer(Store store, DeviceStyle style)
        {
            _store = store;
            _style = style;
        }
        public List<Device> GetPreferncesResult()
        {
            IEnumerator<Device> _deviceEnumerator = PreferencesCollection(_style);
            List<Device> _preferences = new List<Device>();
            if(_deviceEnumerator != null)
            {
                while (_deviceEnumerator.MoveNext())
                {
                    _preferences.Add(_deviceEnumerator.Current);
                }
            }
            return _preferences;
        }
        private IEnumerator<Device> PreferencesCollection(DeviceStyle prefernce)
        {
             foreach(Device device in _store)
             {
                if (device._DeviceStyle == prefernce)
                    yield return device;
             }
        }
    }

   
}
