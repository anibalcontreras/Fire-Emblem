using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;

public class SpdDynamicBonusEffect : IBonusEffect
{
    private EffectTarget _target { get; }
    private StatType _statType { get; }
    private double _percentage = 0.2;
    
    public SpdDynamicBonusEffect(EffectTarget target, StatType statType)
    {
        _target = target;
        _statType = statType;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        
        int bonusAmount = (int)(_percentage * targetUnit.GetBaseStat(StatType.Spd));
        targetUnit.ApplyStatBonus(_statType, bonusAmount);
        targetUnit.AddActiveEffect(this);
    }
}