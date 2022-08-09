using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleLogin
{
    public class ExternalAuthentication : IExternalAuthentication
    {
        public int RequestToken()
        {
            Task.Delay(2000).Wait();
            return 123;
        }

        public async void RequestToken(Action<int> callback)
        {
            await Task.Delay(2000);
            callback?.Invoke(123);
        }

        public async Task<int> RequestTokenAsync()
        {
            await Task.Delay(2000);
            return 123;
        }

        public async Task<int> RequestTokenAsync(CancellationToken ct)
        {
            await Task.Delay(2000, ct);
            return 123;
        }
    }
}