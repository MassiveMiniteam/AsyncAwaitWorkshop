using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleLogin
{
    public interface IExternalAuthentication
    {
        public int RequestToken();
        public void RequestToken(Action<int> callback);

        #region --- Secret 1 ---

        public Task<int> RequestTokenAsync();

        #endregion
    
        #region --- Secret 2 ---

        public Task<int> RequestTokenAsync(CancellationToken ct);

        #endregion
    }
}