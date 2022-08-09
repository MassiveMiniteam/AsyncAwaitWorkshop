using System.Threading.Tasks;

namespace ExampleSaveData
{
    public interface ISaveSystem
    {
        public Task SaveDataToPathAsync(string path, string data);
        public Task<string> LoadDataFromPathAsync(string path);
    }
}