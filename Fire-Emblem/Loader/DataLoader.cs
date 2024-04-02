using Fire_Emblem.Weapon;

namespace Fire_Emblem.Loader;

using System.Text.Json;
using Fire_Emblem.UnitManagment;
using Fire_Emblem.SkillManagment;
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
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.Converters.Add(new WeaponConverter());
        return LoadFromJson<Unit>(filePath, options);
    }

    private List<Skill> LoadSkills(string filePath)
    {
        JsonSerializerOptions options = new JsonSerializerOptions();
        return LoadFromJson<Skill>(filePath, options);
    }

}