using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.AlterBaseStat;

public class AlterBaseStatEffect : IEffect
{
    private readonly StatType _statToIncrease;
    private readonly int _amount;
    private EffectTarget _target { get; }
    public AlterBaseStatEffect(StatType statToIncrease, int amount, EffectTarget target)
    {
        _statToIncrease = statToIncrease;
        _amount = amount;
        _target = target;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        targetUnit.ApplyStatBonus(_statToIncrease, _amount);
        targetUnit.SetActivatedAlterStatBase();
        EffectCollection targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}
    