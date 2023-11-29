using ItemRazorV1Real.Models;
using System.Text.Json;

namespace ItemRazorV1Real.Service
{
    public class JsonFileService<T>
    {
        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", typeof(T).Name + "s.json"); }
        }

        public JsonFileService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public void SaveJsonObjects(List<T> objs)
        {
            using (FileStream jsonFileWriter = File.Create(JsonFileName))
            {
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
                {
                    SkipValidation = false,
                    Indented = true
                });
                JsonSerializer.Serialize<T[]>(jsonWriter, objs.ToArray());
            }
        }

        public IEnumerable<T> GetJsonObjects()
        {
            using (StreamReader jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<T[]>(jsonFileReader.ReadToEnd());
            }
        }




    }
}
