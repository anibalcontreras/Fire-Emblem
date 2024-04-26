namespace Fire_Emblem.Loaders;

using Weapons;
using System.Text.Json;
using Units;
using Skills;
using System.Collections.ObjectModel;

public class DataLoader
{
    public ReadOnlyCollection<Unit> Units { get; private set; }
    public ReadOnlyCollection<Skill> Skills { get; private set; }
    
    
    public DataLoader(string unitsJsonFilePath = "characters.json", string skillsJsonFilePath = "skills.json")
    {
        Units = LoadUnits(unitsJsonFilePath).AsReadOnly();
        Skills = LoadSkills(skillsJsonFilePath).AsReadOnly();
    }
    
    private List<T> LoadFromJson<T>(string filePath, JsonSerializerOptions options)
    {
        try
        {
            string jsonContent = File.ReadAllText(filePath);
            return new List<T>(JsonSerializer.Deserialize<T[]>(jsonContent, options));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading data from JSON: {ex.Message}");
            return new List<T>();
        }
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

    private static List<Unit> CreateUnitsList(List<UnitFromJson>? unitFromJsonList)
    {
        List<Unit> units = new List<Unit>();
        foreach (var unitFromJson in unitFromJsonList)
            units.Add(unitFromJson.ConvertToUnit());
        return units;
    }

    private List<Skill> LoadSkills(string filePath)
    {
        JsonSerializerOptions options = new JsonSerializerOptions();
        return LoadFromJson<Skill>(filePath, options);
    }
}