using System;
using System.Threading.Tasks;
using UnityEngine;

namespace ExampleSaveData.Platform
{
    public static class PlatformSaveAPI
    {
        public static async void Save(string path, string data, Action<bool> callback)
        {
            await Task.Delay(2000);
            PlayerPrefs.SetString(path, data);
            callback?.Invoke(true);
        }
        
        public static async void Load(string path, Action<string> callback)
        {
            await Task.Delay(2000);
            var result = PlayerPrefs.GetString(path);
            callback?.Invoke(result);
        }
    }
}