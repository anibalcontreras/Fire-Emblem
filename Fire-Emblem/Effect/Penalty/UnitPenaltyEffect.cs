using Fire_Emblem.Stats;
using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Effect;

public class UnitPenaltyEffect : IEffect
{
    private StatType _statToDecrease;
    private int _amount;
    
    public UnitPenaltyEffect(StatType statToDecrease, int amount)
    {
        _statToDecrease = statToDecrease;
        _amount = amount;
    }
    
    public virtual void ApplyEffect(GameView view, Unit activator, Unit opponent)
    {
        activator.ApplyStatEffect(_statToDecrease, -_amount);
        view.AnnouncePenaltyStat(activator.Name, this.ToString());
    }
    
    public virtual IEffect Clone()
    {
        return new UnitPenaltyEffect(_statToDecrease, _amount);
    }
    
    public override string ToString()
    {
        return $"{_statToDecrease}-{_amount}";
    }
}