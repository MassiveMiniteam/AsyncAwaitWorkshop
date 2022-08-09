using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleLogin
{
    public interface IOnlineSystem
    {
        bool Login(string username, string password);
    
        #region --- Secret 1 ---

        void Login(string username, string password, Action<bool> callback);

        #endregion
    
        #region --- Secret 2 ---

        Task<bool> LoginAsync(string username, string password);

        #endregion

        #region --- Secret 3 ---

        Task<bool> LoginAsync(string username, string password, int token);
    
        bool Login(string username, string password, int token);
    
        void Login(string username, string password, int token, Action<bool> callback);
    
        #endregion

        #region --- Secret 4 ---

        Task<bool> LoginAsync(string username, string password, int token, CancellationToken ct);
    
        #endregion
    }
}