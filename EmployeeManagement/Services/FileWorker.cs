using System.Text.Json;

namespace EmployeeManagement.Services
{
    internal class FileWorker<T>
    {
        private readonly string _filePath;
        private readonly string _fileName;

        public FileWorker() : this(@"C:\temp\")
        { }
        public FileWorker(string filePath) : this(filePath, "entities.json")
        { }
        public FileWorker(string filePath, string fileName)
        {
            _filePath = filePath;
            _fileName = fileName;
        }

        public void SaveEntityToLocalDrive(List<T> currentEntityList)
        {
            FileInfo fileInfo = new FileInfo(Path.Combine(_filePath, _fileName));
            using FileStream fs = fileInfo.OpenWrite();
            JsonSerializer.Serialize(fs, currentEntityList);
        }

        public List<T> ReadFileFromLocalDisk()
        {
            EnsureDirectoryExists(_filePath); // Check and create directory if needed

            FileInfo fileInfo = new FileInfo(Path.Combine(_filePath, _fileName));

            if (!fileInfo.Exists)
            {
                CreateFile(fileInfo.FullName); // Create file if it doesn't exist
                return new List<T>(); // Return empty list since the file is not found
            }

            using StreamReader sr = fileInfo.OpenText();
            var prepareString = sr.ReadToEnd();

            return JsonSerializer.Deserialize<List<T>>(prepareString);
        }

        private void EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch
                {
                    throw;
                }
            }
        }

        private void CreateFile(string fileName)
        {
            int bufferSize = 2 << 11; // 4096 bytes, it's the default buffer size in FileStream.
            using var fs = new FileStream(fileName,
                                          FileMode.Create,
                                          FileAccess.Write,
                                          FileShare.None,
                                          bufferSize,
                                          FileOptions.Asynchronous);
        }
    }
}
