using System.Text.Json.Serialization;
using Fire_Emblem.Weapon;
namespace Fire_Emblem.UnitManagment;

public class UnitFromJson
{
    public string Name { get; set; }
    public string Gender { get; set; }
    public string DeathQuote { get; set; }
    
    [JsonPropertyName("HP")]
    public string HPString { get; set; }
    
    [JsonPropertyName("Atk")]
    public string AtkString { get; set; }
    
    [JsonPropertyName("Spd")]
    public string SpdString { get; set; }
    
    [JsonPropertyName("Def")]
    public string DefString { get; set; }
    
    [JsonPropertyName("Res")]
    public string ResString { get; set; }

    [JsonConverter(typeof(WeaponConverter))]
    public Weapon.Weapon Weapon { get; set; } // Ahora la propiedad es del tipo Weapon

    public Unit ConvertToUnit()
    {
        return new Unit
        {
            Name = this.Name,
            Gender = this.Gender,
            DeathQuote = this.DeathQuote,
            BaseHp = int.Parse(HPString),
            BaseAtk = int.Parse(AtkString),
            BaseSpd = int.Parse(SpdString),
            BaseDef = int.Parse(DefString),
            BaseRes = int.Parse(ResString),
            Weapon = this.Weapon
        };
    }
}