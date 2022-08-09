using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleLogin
{
    public interface IExternalAuthentication
    {
        public int RequestToken();
        
        public void RequestToken(Action<int> callback);

        public Task<int> RequestTokenAsync();

        public Task<int> RequestTokenAsync(CancellationToken ct);

    }
}