using System.Text.Json;
namespace FinalTask.Interface
{
    public class FileSystemSaveLoadService<T> : ISaveLoadService<T>
    {
        private string _path;

        public FileSystemSaveLoadService(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Path is required");

            _path = path;

            Directory.CreateDirectory(_path);
        }

        public T LoadData(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("File name cannot be empty", nameof(fileName));
            
            var fullFilePath = Path.Combine(_path, $"{fileName}.txt");

            if (!File.Exists(fullFilePath))
                throw new FileNotFoundException($"File not found: {fullFilePath}");

            string jsonData;

            try
            {
                using (var readStream = File.OpenText(fullFilePath))
                {
                    jsonData = readStream.ReadToEnd();
                }

                var deserializeData = JsonSerializer.Deserialize<T>(jsonData);

                return deserializeData;
            }
            catch (IOException ex)
            {
                throw new InvalidOperationException(
                    $"Failed to load data: {ex.Message}", ex);
            }
        }

        public void SaveData(T data, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("File name cannot be empty", nameof(fileName));

            string serializedData = JsonSerializer.Serialize(data);
            
            var fullFilePath = Path.Combine(_path, $"{fileName}.txt");

            try
            { 
                using (var writeStream = File.CreateText(fullFilePath))
                {
                    writeStream.Write(serializedData);
                }
            }
            catch (IOException ex)
            {
                throw new InvalidOperationException(
                    $"Failed to save data: {ex.Message}", ex);
            }
        }

        public bool PlayerHasProfile(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("File name cannot be empty", nameof(fileName));

            var fullFilePath = Path.Combine(_path, $"{fileName}.txt");

            return File.Exists(fullFilePath);
        }
    }
}
