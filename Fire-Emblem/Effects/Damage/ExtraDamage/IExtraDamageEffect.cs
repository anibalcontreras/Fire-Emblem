using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.ExtraDamage;

public interface IExtraDamageEffect
{
    public void ApplyEffect(Unit activator, Unit opponent);
}