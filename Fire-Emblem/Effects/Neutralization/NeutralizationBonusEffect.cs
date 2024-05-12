using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Neutralization;

public class NeutralizationBonusEffect : IEffect
{
    public EffectTarget Target { get; private set; }
    public StatType StatType { get; private set; }
    public int? Amount => null;

    public NeutralizationBonusEffect(EffectTarget target, StatType statType)
    {
        Target = target;
        StatType = statType;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        targetUnit.NeutralizeBonus(StatType);
        targetUnit.AddActiveEffect(this);
    }
}
