using Fire_Emblem.Stats;
using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Effect;

public class PenaltyEffect : IEffect
{
    private StatType _statToDecrease;
    private int _amount;
    
    public PenaltyEffect(StatType statToDecrease, int amount)
    {
        _statToDecrease = statToDecrease;
        _amount = amount;
    }
    
    public virtual void ApplyEffect(GameView view, Unit unit)
    {
        unit.IncreaseStat(_statToDecrease, -_amount);
        view.AnnouncePenaltyStat(unit.Name, this.ToString());
    }
    
    public virtual void RevertEffect(GameView view, Unit unit)
    {
        unit.IncreaseStat(_statToDecrease, +_amount);
    }
    
    public virtual IEffect Clone()
    {
        return new PenaltyEffect(_statToDecrease, _amount);
    }
    
    public override string ToString()
    {
        return $"{_statToDecrease}-{_amount}";
    }
    
}