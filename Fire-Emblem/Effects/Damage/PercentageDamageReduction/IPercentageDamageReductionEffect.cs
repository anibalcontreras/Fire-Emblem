using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.PercentageDamageReduction;

public interface IPercentageDamageReductionEffect : IEffect
{
    public void ApplyEffect(Unit activator, Unit opponent);
}