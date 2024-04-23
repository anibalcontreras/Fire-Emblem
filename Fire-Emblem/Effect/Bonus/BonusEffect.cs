using Fire_Emblem.Stats;
using Fire_Emblem.TeamManagment;
using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Effect;

public class BonusEffect : IEffect
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
        activator.IncreaseStat(_statToIncrease, _amount);
        view.AnnounceBonusStat(activator.Name, this.ToString());
    }
    
    public virtual void RevertEffect(GameView view, Unit unit, Unit rival)
    {
        unit.IncreaseStat(_statToIncrease, -_amount);
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