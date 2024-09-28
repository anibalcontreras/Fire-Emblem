using System.Text.Json;
using System.Text.Json.Serialization;
using Fire_Emblem.Exception;

namespace Fire_Emblem.Weapons;

public class WeaponConverter : JsonConverter<Weapon>
{
    public override Weapon Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string weaponType = reader.GetString();

        return weaponType switch
        {
            "Sword" => new Sword(),
            "Lance" => new Lance(),
            "Bow" => new Bow(),
            "Magic" => new Magic(),
            "Axe" => new Axe(),
            _ => throw new WeaponTypeNotSupportedException()
        };
    }
    
    public override void Write(Utf8JsonWriter writer, Weapon value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}