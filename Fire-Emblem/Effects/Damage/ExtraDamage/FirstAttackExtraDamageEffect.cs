using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.ExtraDamage;

public class FirstAttackExtraDamageEffect : IEffect
{ 
    private readonly double _percentageReductionDamage = 0.25;
    private EffectTarget _target { get; }
    
    public FirstAttackExtraDamageEffect(EffectTarget target)
    {
        _target = target;
    }

    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        int amount = CalculateExtraDamage(activator, opponent);
        targetUnit.ApplyFirstAttackExtraDamageEffect(amount);
        EffectsList targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }

    private int CalculateExtraDamage(Unit activator, Unit opponent)
    {
        int atk = activator.GetFirstAttackStat(StatType.Atk);
        int res = opponent.GetFirstAttackStat(StatType.Res);
        return (int)(_percentageReductionDamage * (atk - res));
    }
}