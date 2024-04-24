using Fire_Emblem.Stats;
using Fire_Emblem.TeamManagment;
using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Effect;

public class BonusEffect : IEffect, IBonusEffect
{
    private StatType _statToIncrease;
    private int _amount;

    public BonusEffect(StatType statToIncrease, int amount)
    {
        _statToIncrease = statToIncrease;
        _amount = amount;
    }
    
    public virtual void ApplyEffect(GameView view, Unit activator, Unit opponent)
    {
        ApplyBonus(view, activator, opponent);
    }
    
    public virtual void ApplyBonus(GameView view, Unit activator, Unit opponent)
    {
        activator.ApplyStatEffect(_statToIncrease, _amount);
        view.AnnounceBonusStat(activator.Name, this.ToString());
    }
    public virtual IEffect Clone()
    {
        return new BonusEffect(_statToIncrease, _amount);
    }
    
    public override string ToString()
    {
        return $"{_statToIncrease}+{_amount}";
    }
}