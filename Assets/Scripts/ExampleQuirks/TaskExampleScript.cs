using System.Threading.Tasks;
using ExampleLogin;
using UnityEngine;

namespace ExampleQuirks
{
    public class TaskExampleScript : MonoBehaviour
    {
        private async void Start()
        {
            //This will throw an exception because FindObjectOfType can only be executed from the main thread.
            await Task.Run(DoWork);
        }

        private Task DoWork()
        {
            var panel = FindObjectOfType<LoginPanel>();
            Debug.Log(panel);
            return Task.CompletedTask;
        }
    }
}
