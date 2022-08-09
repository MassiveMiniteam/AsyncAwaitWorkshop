using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleLogin
{
    public interface IOnlineSystem
    {
        bool Login(string username, string password);
        
        void Login(string username, string password, Action<bool> callback);

        Task<bool> LoginAsync(string username, string password);

        Task<bool> LoginAsync(string username, string password, int token);
    
        bool Login(string username, string password, int token);
    
        void Login(string username, string password, int token, Action<bool> callback);
    
        Task<bool> LoginAsync(string username, string password, int token, CancellationToken ct);
    
    }
}