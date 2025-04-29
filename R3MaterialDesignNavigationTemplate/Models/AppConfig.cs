using R3JsonExtensions;
using R3MaterialDesignNavigationTemplate.Extensions;
using R3MaterialDesignNavigationTemplate.ViewModels;
using System.Collections;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace R3MaterialDesignNavigationTemplate.Models;

public class AppConfig : IHasJsonObject
{
    public static string Path => System.IO.Path.ChangeExtension(System.Reflection.Assembly.GetExecutingAssembly().Location, ".conf");

    public void SaveToFile()
    {
        System.IO.File.WriteAllText(Path, JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true }));
    }

    public JsonObject? JsonObject { get; set; }
    public static AppConfig Load()
    {
        if (!System.IO.File.Exists(Path))
        {
            return new AppConfig();
        }
        var json = System.IO.File.ReadAllText(Path);
        var conf = JsonSerializer.Deserialize<AppConfig>(json)!;
        conf.JsonObject = JsonNode.Parse(json)!.AsObject();
        return conf;
    }
}
