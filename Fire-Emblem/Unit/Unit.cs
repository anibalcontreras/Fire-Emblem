using System.Text.Json.Serialization;
using Fire_Emblem.SkillManagment;
using Fire_Emblem.Stats;

namespace Fire_Emblem.UnitManagment;

using Fire_Emblem.Weapon;

public class Unit
{
    public string Name { get; set; }
    public string Gender { get; set; }
    public string DeathQuote { get; set; }
    [JsonIgnore]
    public int HP { get; set; }
    [JsonIgnore]
    public int Atk { get; set; }
    [JsonIgnore]
    public int Spd { get; set; }
    [JsonIgnore]
    public int Def { get; set; }
    [JsonIgnore]
    public int Res { get; set; }
    
    [JsonPropertyName("HP")]
    public string HPString
    {
        set => HP = int.TryParse(value, out int result) ? result : 0;
    }
    
    [JsonPropertyName("Atk")]
    public string AtkString
    {
        set => Atk = int.TryParse(value, out int result) ? result : 0;
    }
    
    [JsonPropertyName("Spd")]
    public string SpdString
    {
        set => Spd = int.TryParse(value, out int result) ? result : 0;
    }
    
    [JsonPropertyName("Def")]
    public string DefString
    {
        set => Def = int.TryParse(value, out int result) ? result : 0;
    }
    
    [JsonPropertyName("Res")]
    public string ResString
    {
        set => Res = int.TryParse(value, out int result) ? result : 0;
    }
    
    [JsonConverter(typeof(WeaponConverter))]
    public Weapon Weapon { get; set; }
    
    private int _currentHP;
    
    public int CurrentHP
    {
        get { return _currentHP; }
        set { _currentHP = Math.Max(0, value); } // Asegura que CurrentHP no sea negativo
    }
    
    public void InitializeCurrentHP()
    {
        _currentHP = HP;
    }
    
    private List<Skill> _skills = new List<Skill>();

    public IEnumerable<Skill> Skills
        => _skills.AsReadOnly();

    public void AddSkill(Skill skill)
        => _skills.Add(skill);
        
    public void RemoveSkill(Skill skill)
        => _skills.Remove(skill);
    
    public int CalculateDamage(Unit opponent)
    {
        int defenseValue = Weapon is Magic ? Convert.ToInt32(opponent.Res) : Convert.ToInt32(opponent.Def);
        
        double damage = (Convert.ToDouble(Atk) * Convert.ToDouble(Weapon.GetWTB(opponent.Weapon))) - defenseValue;
        
        opponent.CurrentHP -= (int)Math.Max(0, Math.Truncate(damage));
        
        return (int)Math.Max(0, Math.Truncate(damage));
    }
    
    public void IncreaseStat(StatType statType, int increaseAmount)
    {
        switch (statType)
        {
            case StatType.HP:
                HP += increaseAmount;
                // TODO: Ver si tiene que ser para el currentHP.
                // _currentHP = Math.Min(_currentHP + increaseAmount, HP);
                break;
            case StatType.Atk:
                Atk += increaseAmount;
                break;
            case StatType.Spd:
                Spd += increaseAmount;
                break;
            case StatType.Def:
                Def += increaseAmount;
                break;
            case StatType.Res:
                Res += increaseAmount;
                break;
            default:
                throw new ArgumentException($"Stat '{statType}' is not recognized.");
        }
    }
    public int AtkBonus { get; set; } = 0;
    public int SpdBonus { get; set; } = 0;
    
}