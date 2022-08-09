using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleLogin
{
    public class OnlineSystem : IOnlineSystem
    {
        public bool Login(string username, string password)
        {
            Task.Run(() => SleepThreadFor(2000)).Wait();
            return true;
        }
    
        public bool Login(string username, string password, int token)
        {
            Task.Delay(2000).Wait();
            return true;
        }

        public async void Login(string username, string password, int token, Action<bool> callback)
        {
            await Task.Delay(2000);
            callback?.Invoke(true);
        }

        public async Task<bool> LoginAsync(string username, string password, int token, CancellationToken ct)
        {
            await Task.Delay(2000, ct);
            return true;
        }

        public async void Login(string username, string password, Action<bool> callback)
        {
            await Task.Delay(2000);
            callback?.Invoke(true);
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            await Task.Delay(2000);
            return true;
        }

        public async Task<bool> LoginAsync(string username, string password, int token)
        {
            await Task.Delay(2000);
            return true;
        }
        private static void SleepThreadFor(int ms)
        {
            Thread.Sleep(ms);
        }
    }
}