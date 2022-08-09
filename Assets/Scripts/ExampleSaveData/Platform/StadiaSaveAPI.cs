using System;
using UnityEngine;

namespace ExampleSaveData.Platform
{
    public static class StadiaSaveAPI
    {
        public static void Save(string path, string data, Action<bool> callback)
        {
            SaveInternal(path, data, callback);
        }
        public static void Load(string path, Action<string> callback)
        {
            LoadInternal(path, callback);
        }

        #region --- Internal ---

        private static async void SaveInternal(string path, string data, Action<bool> callback)
        {
            await System.Threading.Tasks.Task.Delay(2000);
            PlayerPrefs.SetString(path, data);
            callback?.Invoke(true);
        }

        private static async void LoadInternal(string path, Action<string> callback)
        {
            await System.Threading.Tasks.Task.Delay(2000);
            var result = PlayerPrefs.GetString(path);
            callback?.Invoke(result);
        }
    
        #endregion
    }
}