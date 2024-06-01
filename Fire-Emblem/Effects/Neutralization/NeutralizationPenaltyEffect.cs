using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Neutralization;

public class NeutralizationPenaltyEffect: IEffect
{
    private EffectTarget _target { get; }
    public StatType StatType { get; }
    
    public NeutralizationPenaltyEffect(EffectTarget target, StatType statType)
    {
        _target = target;
        StatType = statType;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        targetUnit.NeutralizePenalty(StatType);
        targetUnit.AddActiveEffect(this);
    }
}