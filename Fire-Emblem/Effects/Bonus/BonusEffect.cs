using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;

public class BonusEffect : IEffect, IBonusEffect
{
    private readonly StatType _statToIncrease;
    private readonly int _amount;
    public EffectTarget Target { get; private set; }
    public StatType StatType => _statToIncrease;
    public int? Amount => _amount;
    
    public BonusEffect(StatType statToIncrease, int amount, EffectTarget target)
    {
        _statToIncrease = statToIncrease;
        _amount = amount;
        Target = target;
    }
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        targetUnit.ApplyStatBonusEffect(_statToIncrease, _amount);
        targetUnit.AddActiveEffect(this);
    }
}