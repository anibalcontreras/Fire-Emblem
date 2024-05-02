using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Neutralization;

public class NeutralizationBonusEffect: IEffect
{
    public EffectTarget Target { get; }
    public StatType? StatType => null;
    public int? Amount => null;
    public NeutralizationBonusEffect(EffectTarget target)
    {
        Target = target;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        targetUnit.NeutralizeBonus();
        targetUnit.AddActiveEffect(this);
    }
}