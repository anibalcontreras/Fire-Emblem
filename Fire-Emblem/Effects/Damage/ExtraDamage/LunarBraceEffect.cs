using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.ExtraDamage;

public class LunarBraceEffect : IExtraDamageEffect
{
    private readonly double _percentage;
    private readonly StatType _statType;
    private EffectTarget Target { get; }
        
    public LunarBraceEffect(double percentage, StatType statType, EffectTarget target)
    {
        _percentage = percentage;
        _statType = statType;
        Target = target;
    }
        
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        int extraDamage = (int)(opponent.GetCurrentStat(_statType) * _percentage);
        targetUnit.ApplyExtraDamageEffect(extraDamage);
        targetUnit.AddActiveEffect(this);
    }
}