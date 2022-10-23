using System;

namespace PracticeTime3
{
    public class Singleton<T> where T: new()
    {
        private static T _instance;
        private static object syncRoot = new object();
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        return new T();
                    }
                }
                return _instance;
            }
        }
        protected Singleton() { }    
    }
    public class Manager : Singleton<Manager>
    {
        public bool isPlayerDestroyed()
        {
            return true;
        }
    }
    public class DataService : Singleton<DataService>
    {
        public void SendData() => Console.WriteLine("Sending data");
    }
    public class ManagerAssistent 
    {
         void Play()
        {
            var isDestroyed =  Manager.Instance.isPlayerDestroyed();
        }
    }
}
