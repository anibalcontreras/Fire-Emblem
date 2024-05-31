using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Effects.Damage.ExtraDamage;

public interface IFirstAttackExtraDamageEffect
{
    public void ApplyEffect(Unit activator, Unit opponent);
}