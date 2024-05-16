using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.PercentageDamageReduction;

public class GuardBearingPercentageReductionEffect : IEffect, IPercentageDamageReductionEffect
{
    private readonly double _initialPercentage;
    private readonly EffectTarget _target;

    public GuardBearingPercentageReductionEffect(double percentage, EffectTarget target)
    {
        _initialPercentage = percentage;
        _target = target;
    }

    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        double percentageToApply;

        if (!targetUnit.HasBeenAttackerBefore || !targetUnit.HasBeenDefenderBefore)
        {
            percentageToApply = _initialPercentage;
        }
        else
        {
            percentageToApply = 0.3;
        }

        targetUnit.ApplyPercentageDamageReductionEffect(percentageToApply);
        targetUnit.AddActiveEffect(this);
    }
}