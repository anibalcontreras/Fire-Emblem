using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.ExtraDamage;

public class ExtraDamagePerStatTypeEffect : IExtraDamageEffect
{
    private readonly double _percentage;
    private readonly StatType _statType;
    private EffectTarget _target { get; }
        
    public ExtraDamagePerStatTypeEffect(double percentage, StatType statType, EffectTarget target)
    {
        _percentage = percentage;
        _statType = statType;
        _target = target;
    }
        
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        int extraDamage = (int)(opponent.GetCurrentStat(_statType) * _percentage);
        targetUnit.ApplyExtraDamageEffect(extraDamage);
        EffectCollection targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}