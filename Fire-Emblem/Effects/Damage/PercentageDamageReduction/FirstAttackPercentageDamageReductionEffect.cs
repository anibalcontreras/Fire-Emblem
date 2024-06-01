using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.PercentageDamageReduction;

public class FirstAttackPercentageDamageReductionEffect : IEffect
{
    private readonly EffectTarget _target;
    private readonly double _percentage;

    public FirstAttackPercentageDamageReductionEffect(double percentage, EffectTarget target)
    {
        _target = target;
        _percentage = percentage;
    }

    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        targetUnit.ApplyFirstAttackPercentageDamageReduction(_percentage);
        targetUnit.AddActiveEffect(this);
    }
}