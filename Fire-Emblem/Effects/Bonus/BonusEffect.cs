using Fire_Emblem.Stats;
using Fire_Emblem.Teams;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;

public class BonusEffect : IEffect, IBonusEffect
{
    private readonly StatType _statToIncrease;
    private readonly int _amount;

    public BonusEffect(StatType statToIncrease, int amount)
    {
        _statToIncrease = statToIncrease;
        _amount = amount;
    }
    
    public void ApplyEffect(GameView view, Unit activator, Unit opponent)
    {
        ApplyBonus(view, activator, opponent);
    }
    
    public void ApplyBonus(GameView view, Unit activator, Unit opponent)
    {
        activator.ApplyStatBonusAndPenaltyEffect(_statToIncrease, _amount);
        view.AnnounceBonusStat(activator.Name, this.ToString());
    }
    public override string ToString()
    {
        return $"{_statToIncrease}+{_amount}";
    }
}