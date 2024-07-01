using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.ExtraDamage;

public class ScendscaleEffect : IExtraDamageEffect
{
    private readonly double _percentage;
    private readonly StatType _statType;
    private readonly EffectTarget _target;
        
    public ScendscaleEffect(double percentage, StatType statType, EffectTarget target)
    {
        _percentage = percentage;
        _statType = statType;
        _target = target;
    }
        
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        int extraDamage = (int)(activator.GetCurrentStat(_statType) * _percentage);
        targetUnit.ApplyExtraDamageEffect(extraDamage);
        EffectCollection targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}