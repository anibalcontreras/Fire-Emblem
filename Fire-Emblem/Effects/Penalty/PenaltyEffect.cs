using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;

public class PenaltyEffect : IEffect, IPenaltyEffect
{
    public EffectTarget Target { get; }
    private StatType _statToDecrease;
    private int _amount;
    public StatType StatType => _statToDecrease;
    public int? Amount => _amount;
    
    public PenaltyEffect(StatType statToDecrease, int amount, EffectTarget target)
    {
        _statToDecrease = statToDecrease;
        _amount = amount;
        Target = target;
    }
    
    public virtual void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        targetUnit.ApplyStatPenaltyEffect(_statToDecrease, _amount);
        targetUnit.AddActiveEffect(this);
    }
}