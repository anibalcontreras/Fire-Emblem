using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Bonus.AlterBaseStat;

public class AlterBaseStatEffect : IEffect
{
    private readonly StatType _statToIncrease;
    private readonly int _amount;
    private EffectTarget Target { get; }
    public AlterBaseStatEffect(StatType statToIncrease, int amount, EffectTarget target)
    {
        _statToIncrease = statToIncrease;
        _amount = amount;
        Target = target;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        targetUnit.ApplyStatBonusEffect(_statToIncrease, _amount);
        targetUnit.SetActivatedAlterStatBase();
        targetUnit.AddActiveEffect(this);
    }
}
    