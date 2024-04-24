using Fire_Emblem.Stats;
using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Effect;

public class RivalPenaltyEffect : IEffect
{
    private StatType _statToDecrease;
    private int _amount;
    
    public RivalPenaltyEffect(StatType statToDecrease, int amount)
    {
        _statToDecrease = statToDecrease;
        _amount = amount;
    }
    
    public virtual void ApplyEffect(GameView view, Unit activator, Unit opponent)
    {
        opponent.ApplyStatEffect(_statToDecrease, -_amount);
        view.AnnouncePenaltyStat(opponent.Name, this.ToString());
    }
    
    public virtual void RevertEffect(GameView view, Unit unit, Unit rival)
    {
        rival.ApplyStatEffect(_statToDecrease, +_amount);
    }
    
    public virtual IEffect Clone()
    {
        return new RivalPenaltyEffect(_statToDecrease, _amount);
    }
    
    public override string ToString()
    {
        return $"{_statToDecrease}-{_amount}";
    }
}