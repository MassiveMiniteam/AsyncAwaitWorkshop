using System;
using System.Threading;
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
    
        private readonly CancellationTokenSource _cts = new();
        
        public void LoginPressed()
        {
            var username = usernameField.text;
            var password = passwordField.text;

            LoginAsyncWithCancellation(username, password);
        }

        private async void LoginAsyncWithCancellation(string username, string password)
        {
            try
            {
                Debug.Log($"Starting Login: Username [{username}] Password [{password}]");
                
                var success = await _onlineSystem.LoginAsync(username, password, 123, _cts.Token);
                
                Debug.Log($"Completed Login: {(success ? "Success" : "Failed")}");
                
                new GameObject("Hello World");
            }
            catch (OperationCanceledException)
            {
            }
        }

        private void OnDestroy()
        {
            _cts.Cancel();
        }

        private async void LoginAsync(string username, string password)
        {
            var token = await _externalAuthentication.RequestTokenAsync();
            var success = await _onlineSystem.LoginAsync(username, password, token);
        }

        private void LoginSync(string username, string password)
        {
            var token = _externalAuthentication.RequestToken();
            var success = _onlineSystem.Login(username, password, token);
        }

        private void LoginWithCallback(string username, string password)
        {
            Debug.Log($"Starting Login: Username [{username}] Password [{password}]");

            _externalAuthentication.RequestToken(token =>
            {
                Debug.Log("Received Token");

                _onlineSystem.Login(username, password, token,
                    delegate(bool success) { Debug.Log($"Completed Login: {(success ? "Success" : "Failed")}"); });
            });
        }
    }
}
