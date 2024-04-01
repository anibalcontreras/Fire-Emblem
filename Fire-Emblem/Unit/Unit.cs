using System.Text.Json;
using System.Text.Json.Serialization;

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

    
    public int CalculateDamage(Unit opponent)
    {
        int defenseValue = this.Weapon is Magic ? Convert.ToInt32(opponent.Res) : Convert.ToInt32(opponent.Def);
        
        double damage = (Convert.ToDouble(this.Atk) * Convert.ToDouble(this.Weapon.GetWTB(opponent.Weapon))) - defenseValue;

        // Apply the damage to the currentHP of the opponent
        opponent.CurrentHP -= (int)Math.Max(0, Math.Truncate(damage));

        // Esto hay que cambiarlo, porque se tiene que devolver el daño que se hizo
        return (int)Math.Max(0, Math.Truncate(damage));
    }
    
}