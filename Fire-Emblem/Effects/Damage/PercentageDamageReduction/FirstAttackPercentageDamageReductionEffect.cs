using Fire_Emblem.Effects.Bonus;
using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.PercentageDamageReduction;

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
        targetUnit.ApplyFirstAttackPercentageDamageReduction(_percentage);
        targetUnit.AddActiveEffect(this);
    }
}