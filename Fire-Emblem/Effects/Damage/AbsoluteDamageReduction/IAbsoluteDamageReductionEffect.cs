using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Effects.Damage.AbsoluteDamageReduction;

public interface IAbsoluteDamageReductionEffect
{
    public void ApplyEffect(Unit activator, Unit opponent);
}