using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;

public class BonusEffect : IBonusEffect
{
    private readonly StatType _statToIncrease;
    private readonly int _amount;
    private readonly EffectTarget _target;
    public BonusEffect(StatType statToIncrease, int amount, EffectTarget target)
    {
        _statToIncrease = statToIncrease;
        _amount = amount;
        _target = target;
    }
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        targetUnit.ApplyStatBonus(_statToIncrease, _amount);
        EffectCollection targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}