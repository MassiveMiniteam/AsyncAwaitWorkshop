using System;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace ExampleLogin
{
    public class LoginPanel : MonoBehaviour
    {
        [SerializeField] private TMP_InputField usernameField;
        [SerializeField] private TMP_InputField passwordField;

        private readonly IOnlineSystem _onlineSystem = new OnlineSystem();
        private readonly IExternalAuthentication _externalAuthentication = new ExternalAuthentication();
    
        public async void LoginPressed()
        {
            var username = usernameField.text;
            var password = passwordField.text;

            await LoginAsync(username, password);
        }

        private CancellationTokenSource cts = new();
        
        private async Task LoginAsync(string username, string password)
        {
            try
            {
                Debug.Log($"Starting Login: Username [{username}] Password [{password}]");
                
                var success = await _onlineSystem.LoginAsync(username, password, default, cts.Token);
                
                Debug.Log($"Completed Login: {(success ? "Success" : "Failed")}");
                new GameObject("Hello World");
            }
            catch (OperationCanceledException)
            {
                
            }
        }

        private void OnDestroy()
        {
            cts.Cancel();
        }

        private void LoginSync(string username, string password)
        {
            var token = _externalAuthentication.RequestToken();
            var success = _onlineSystem.Login(username, password, token);
        }

        private void LoginWithCallback(string username, string password)
        {
            Debug.Log($"Starting Login: Username [{username}] Password [{password}]");

            _externalAuthentication.RequestToken(delegate(int token)
            {
                Debug.Log("Received Token");

                _onlineSystem.Login(username, password, token,
                    delegate(bool success) { Debug.Log($"Completed Login: {(success ? "Success" : "Failed")}"); });
            });
        }
    }
}
