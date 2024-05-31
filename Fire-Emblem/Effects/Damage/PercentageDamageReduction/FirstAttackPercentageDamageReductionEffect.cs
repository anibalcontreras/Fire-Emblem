using Fire_Emblem.Combats.Units;
using Fire_Emblem.Combats.Stats;

namespace Fire_Emblem.Combats.Effects.Damage.PercentageDamageReduction;

public class FirstAttackPercentageDamageReductionEffect : IEffect
{
    private readonly EffectTarget Target;
    private readonly double _percentage;

    public FirstAttackPercentageDamageReductionEffect(double percentage, EffectTarget target)
    {
        Target = target;
        _percentage = percentage;
    }

    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        targetUnit.ApplyFirstAttackPercentageDamageReductionEffect(_percentage);
        targetUnit.AddActiveEffect(this);
    }
}