using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.PercentageDamageReduction;

public class ExtraChivalryPercentageDamageReductionEffect : IPercentageDamageReductionEffect
{
    private readonly EffectTarget _target;
    private readonly double _damageReductionPercentage = 0.5;
    
    public ExtraChivalryPercentageDamageReductionEffect(EffectTarget target)
    {
        _target = target;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        double damageReductionPercentage = CalculateDamageReductionPercentage(opponent);
        targetUnit.ApplyPercentageDamageReduction(damageReductionPercentage);
        EffectsList targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }

    private double CalculateDamageReductionPercentage(Unit opponent)
    {
        double opponentHpFraction = (double)opponent.CurrentHP / opponent.BaseHp;
        double truncatedHpFraction = Math.Truncate(opponentHpFraction * 100) / 100;
        double damageReductionPercentage = truncatedHpFraction * _damageReductionPercentage;
        return Math.Truncate(damageReductionPercentage * 100) / 100;
    }
}