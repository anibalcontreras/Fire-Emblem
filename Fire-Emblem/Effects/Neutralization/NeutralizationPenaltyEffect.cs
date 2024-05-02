using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Neutralization;

public class NeutralizationPenaltyEffect: IEffect
{
    public EffectTarget Target { get; }
    public StatType? StatType => null;
    public int? Amount => null;
    public NeutralizationPenaltyEffect(EffectTarget target)
    {
        Target = target;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        targetUnit.NeutralizePenalty();
        targetUnit.AddActiveEffect(this);
    }
}