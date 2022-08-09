using System.Threading.Tasks;
using ExampleSaveData.Platform;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ExampleSaveData
{
    public class SaveSystemStadia : ISaveSystem
    {
        public async Task SaveDataToPathAsync(string path, string data)
        {
            var taskCompletion = new TaskCompletionSource<object>();
            
            StadiaSaveAPI.Save(path, data, delegate(bool b)
            {
                taskCompletion.SetResult(null);
            });
            
            await taskCompletion.Task;
        }
        
        public Task<string> LoadDataFromPathAsync(string path)
        {
            var taskCompletion = new TaskCompletionSource<string>();
            
            StadiaSaveAPI.Load(path, (data) => 
            {
                taskCompletion.SetResult(data);
            });
            
            return taskCompletion.Task;
        }
    }
    
    public class SavePanel : MonoBehaviour
    {
        [SerializeField] private TMP_InputField pathField;
        [SerializeField] private TMP_InputField dataField;

        private readonly ISaveSystem _saveSystem = new SaveSystemStadia();

        public async void SavePressed()
        {
            SetButtonsInteractable(false);
        
            var path = pathField.text;
            var data = dataField.text;
        
            Debug.Log($"Started Saving [{data}] to [{path}]");
            
            await _saveSystem.SaveDataToPathAsync(path, data);
            
            Debug.Log($"Completed Saving [{data}] to [{path}]");
        
            SetButtonsInteractable(true);
        }

        public async void LoadPressed()
        {
            SetButtonsInteractable(false);
        
            var path = pathField.text;
        
            Debug.Log($"Started Loading from [{path}]");
            
            var data = await _saveSystem.LoadDataFromPathAsync(path);
            
            Debug.Log($"Completed Loading [{data}] from [{path}]");
        
            SetButtonsInteractable(true);
        }

        #region --- Misc ---

        private void SetButtonsInteractable(bool interactable)
        {
            foreach (var button in GetComponentsInChildren<Button>())
            {
                button.interactable = interactable;
            }
        }
    
        #endregion
    }
}