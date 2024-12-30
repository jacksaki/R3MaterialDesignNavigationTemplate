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
        [JsonPropertyName("theme")]
#pragma warning disable CS8618 // null 非許容のフィールドには、コンストラクターの終了時に null 以外の値が入っていなければなりません。'required' 修飾子を追加するか、Null 許容として宣言することを検討してください。
        public ThemeConfig Theme { get; set; }
#pragma warning restore CS8618 // null 非許容のフィールドには、コンストラクターの終了時に null 以外の値が入っていなければなりません。'required' 修飾子を追加するか、Null 許容として宣言することを検討してください。
        public static string Path => System.IO.Path.ChangeExtension(System.Reflection.Assembly.GetExecutingAssembly().Location, ".conf");
        public void Save()
        {
            System.IO.File.WriteAllText(Path, JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true }));
        }
        public static AppConfig Load()
        {
            if (!System.IO.File.Exists(Path))
            {
                return new AppConfig()
                {
                    Theme = ThemeConfig.CreateDefault()
                };
            }
            using(var sr=new System.IO.FileStream(Path,System.IO.FileMode.Open))
            {
                var conf = JsonSerializer.Deserialize<AppConfig>(sr)!;
                if (conf.Theme == null)
                {
                    conf.Theme = ThemeConfig.CreateDefault();
                }
                return conf;
            }
        }
    }
}
