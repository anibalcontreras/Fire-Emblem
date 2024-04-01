using Fire_Emblem.Weapon;

namespace Fire_Emblem.Controller;

using System.Text.Json;
using Fire_Emblem.UnitManagment;
using Fire_Emblem.SkillManagment;
using System.Collections.ObjectModel; // Para usar ReadOnlyCollection

public class InitGameController
{
    private List<Unit> _units;
    private List<Skill> _skills;
    private const string _unitsJsonFilePath = "characters.json";
    private const string _skillsJsonFilePath = "skills.json";

    public InitGameController()
    {
        _units = new List<Unit>();
        _skills = new List<Skill>();
        LoadUnitsFromJson(_unitsJsonFilePath);
        LoadSkillsFromJson(_skillsJsonFilePath);
    }
    
    public ReadOnlyCollection<Unit> Units => _units.AsReadOnly(); // Proporciona acceso de solo lectura a la lista de unidades
    public ReadOnlyCollection<Skill> Skills => _skills.AsReadOnly(); // Proporciona acceso de solo lectura a la lista de habilidades
    
    private void LoadUnitsFromJson(string filePath)
    {
        try
        {
            string jsonContent = File.ReadAllText(filePath);
            Console.WriteLine(jsonContent);
            var options = new JsonSerializerOptions();
            options.Converters.Add(new WeaponConverter());
            Unit[] unitsInfo = JsonSerializer.Deserialize<Unit[]>(jsonContent, options);
            Console.WriteLine(unitsInfo);
            _units.AddRange(unitsInfo);
            // Cambiar esto está pésimo // TODO
            foreach (var unit in _units)
            {
                unit.InitializeCurrentHP();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading units from JSON: {ex.Message}");
        }
    }
    
    private void LoadSkillsFromJson(string filePath)
    {
        try
        {
            string jsonContent = File.ReadAllText(filePath);
            Skill[] skillsInfo = JsonSerializer.Deserialize<Skill[]>(jsonContent);
            _skills.AddRange(skillsInfo);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading skills from JSON: {ex.Message}");
        }
    }
}