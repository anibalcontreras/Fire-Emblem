using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.DamageOutOfCombat;

public class BewitchingTomeBeforeCombatEffect : IDamageBeforeCombatEffect
{
    private readonly double _percentage;
    
    private EffectTarget _target { get; }
    
    public BewitchingTomeBeforeCombatEffect(double percentage, EffectTarget target)
    {
        _percentage = percentage;
        _target = target;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        int damage = (int)(targetUnit.GetCurrentStat(StatType.Atk) * _percentage);
        targetUnit.ApplyDamageBeforeCombat(damage);
        EffectCollection targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}