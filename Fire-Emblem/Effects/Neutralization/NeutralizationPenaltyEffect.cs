using Fire_Emblem.Combats.Stats;
using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Effects.Neutralization;

public class NeutralizationPenaltyEffect: IEffect
{
    public EffectTarget Target { get; }
    public StatType StatType { get; private set; }
    public int? Amount => null;
    public NeutralizationPenaltyEffect(EffectTarget target, StatType statType)
    {
        Target = target;
        StatType = statType;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        targetUnit.NeutralizePenalty(StatType);
        targetUnit.AddActiveEffect(this);
    }
}