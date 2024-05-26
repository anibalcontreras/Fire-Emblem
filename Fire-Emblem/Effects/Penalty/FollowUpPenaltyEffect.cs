using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;

public class FollowUpPenaltyEffect : IEffect
{
    private readonly int _penaltyAmount;
    private EffectTarget Target { get; }
    
    public FollowUpPenaltyEffect(StatType statToDecrease, int penaltyAmount, EffectTarget target)
    {
        _penaltyAmount = penaltyAmount;
        Target = target;
    }
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        // targetUnit.ApplyFollowUpStatPenaltyEffect(_penaltyAmount);
        targetUnit.AddActiveEffect(this);
    }
}