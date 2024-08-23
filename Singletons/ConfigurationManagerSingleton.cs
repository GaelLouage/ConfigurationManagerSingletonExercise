using System.Collections.Concurrent;
using System.Data.SqlTypes;

namespace SingletonPatternExercise.Singletons
{
    public sealed class ConfigurationManagerSingleton
    {
        private static ConfigurationManagerSingleton? instance = null;
        private static readonly object padlock = new object();
        /*using ConcurrentDictionary<string, object> instead of Dictionary<string,
         * object> to ensure thread safety when accessing or modifying the settings.*/
        private static ConcurrentDictionary<string, object> settings = new ConcurrentDictionary<string, object>();
        // using double check
        public static ConfigurationManagerSingleton Instance
        {
            get
            {
                if (instance is null)
                {
                    lock (padlock)
                    {
                        if (instance is null)
                        {
                            instance = new ConfigurationManagerSingleton();
                        }
                    }
                }
                return instance;
            }
        }
        public  T Get<T>(string key)
        {
            if(settings.TryGetValue(key, out var value))
            {
                return (T)value;
            }
            throw new KeyNotFoundException($"The setting '{key}' was not found.");
        }
        public  (bool IsAdded, string Message) AddSettings(string key, object value)
        {
            if (settings.ContainsKey(key) is false)
            {
                settings.TryAdd(key, value);
                return (true,$"Value {value} added with key {key}.");
            }
            return (false,$"Failed to add to settings.");
        }

        public  (bool IsRemoved, string Message) RemoveSettings(string key)
        {
            if (settings.TryRemove(key, out _))
            {
                return (true, $"Removed key '{key}'.");
            }
            return (false, $"Failed to remove key '{key}'.");
        }
    }
}
