using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.PercentageDamageReduction;

public interface IPercentageDamageReductionEffect
{
    public void ApplyEffect(Unit activator, Unit opponent);
}