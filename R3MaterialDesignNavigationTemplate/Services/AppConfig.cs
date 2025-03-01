using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace R3MaterialDesignNavigationTemplate.Services
{
    public class AppConfig
    {
        [JsonInclude]
        [JsonPropertyName("frame_rate")]
        public int FrameRate { get; private set; } = 60;

        public static string Path => System.IO.Path.ChangeExtension(System.Reflection.Assembly.GetExecutingAssembly().Location, ".conf");
        public void Save()
        {
            System.IO.File.WriteAllText(Path, JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true }));
        }
        public static AppConfig Load()
        {
            if (!System.IO.File.Exists(Path))
            {
                return new AppConfig(); 
            }
            using var sr = new System.IO.FileStream(Path, System.IO.FileMode.Open);
            return JsonSerializer.Deserialize<AppConfig>(sr)!;
        }
    }
}
