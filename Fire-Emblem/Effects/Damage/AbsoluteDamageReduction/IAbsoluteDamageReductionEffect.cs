using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.AbsoluteDamageReduction;

public interface IAbsoluteDamageReductionEffect
{
    public void ApplyEffect(Unit activator, Unit opponent);
}