using Fire_Emblem.Combats.Stats;
using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Effects.Neutralization;

public class NeutralizationBonusEffect : IEffect
{
    private EffectTarget _target { get; }
    public StatType StatType { get;  }

    public NeutralizationBonusEffect(EffectTarget target, StatType statType)
    {
        _target = target;
        StatType = statType;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        targetUnit.NeutralizeBonus(StatType);
        targetUnit.AddActiveEffect(this);
    }
}
