namespace Fire_Emblem.Combats.Loaders;

using System.Text.Json;
using Units;
using Skills;
using System.Collections.ObjectModel;

public class DataLoader
{
    public ReadOnlyCollection<Unit> Units { get; private set; }
    public ReadOnlyCollection<Skill> Skills { get; private set; }
    private readonly string _unitsJsonFilePath = "characters.json";
    private readonly string _skillsJsonFilePath = "skills.json";
    
    
    public DataLoader()
    {
        Units = LoadUnits(_unitsJsonFilePath).AsReadOnly();
        Skills = LoadSkills(_skillsJsonFilePath).AsReadOnly();
    }
    
    private List<T> LoadFromJson<T>(string filePath, JsonSerializerOptions options)
    {
        string jsonContent = File.ReadAllText(filePath);
        return new List<T>(JsonSerializer.Deserialize<T[]>(jsonContent, options));
    }
    
    private List<Unit> LoadUnits(string filePath)
    {
        string jsonContent = File.ReadAllText(filePath);
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var unitFromJsonList = JsonSerializer.Deserialize<List<UnitFromJson>>(jsonContent, options);
        return CreateUnitsList(unitFromJsonList);
    }

    private static List<Unit> CreateUnitsList(List<UnitFromJson> unitFromJsonList)
    {
        List<Unit> units = new List<Unit>();
        foreach (UnitFromJson unitFromJson in unitFromJsonList)
            units.Add(unitFromJson.ConvertToUnit());
        return units;
    }

    private List<Skill> LoadSkills(string filePath)
    {
        JsonSerializerOptions options = new JsonSerializerOptions();
        return LoadFromJson<Skill>(filePath, options);
    }
}