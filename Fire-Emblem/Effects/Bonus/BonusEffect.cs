using Fire_Emblem.Stats;
using Fire_Emblem.Teams;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;

public class BonusEffect : IEffect
{
    private readonly StatType _statToIncrease;
    private readonly int _amount;
    public EffectTarget Target { get; private set; }
    
    public BonusEffect(StatType statToIncrease, int amount, EffectTarget target)
    {
        _statToIncrease = statToIncrease;
        _amount = amount;
        Target = target;
    }
    public void ApplyEffect(GameView view, Unit activator, Unit opponent)
    {
        
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        targetUnit.ApplyStatBonusAndPenaltyEffect(_statToIncrease, _amount);
        view.AnnounceBonusStat(targetUnit.Name, this.ToString());
    }
    
    public override string ToString()
    {
        return $"{_statToIncrease}+{_amount}";
    }
}