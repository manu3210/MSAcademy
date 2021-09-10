using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CarRentals
{
    public class ManageJson<T>
    {
        private readonly string _path;

        public ManageJson(string path)
        {
            _path = path;
        }

        JsonSerializerOptions options = new()
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };

        public List<T> ReadJson()
        {
            var List = new List<T>();
            var json = ReadFile();

            if (!string.IsNullOrEmpty(json))
            {
                List = JsonSerializer.Deserialize<List<T>>(json, options);
            }

            return List;
        }

        public string ReadFile()
        {
            if (File.Exists(_path))
            {
                using (var reader = new StreamReader(_path))
                {
                    return reader.ReadToEnd();
                }
            }
            else
            {
                return null;
            }
        }

        public void SaveChanges(List<T> List)
        {
            string json = JsonSerializer.Serialize(List, options);

            using (var writer = new StreamWriter(_path))
            {
                writer.Write(json);
            }
        }
    }
}
