using Fire_Emblem;
using Fire_Emblem.Effect;
using Fire_Emblem.Stats;
using Fire_Emblem.UnitManagment;

public class MutualBonusEffect : IEffect, IBonusEffect
{
    private StatType _stat;
    private int _amount;

    public MutualBonusEffect(StatType stat, int amount)
    {
        _stat = stat;
        _amount = amount;
    }

    public void ApplyEffect(GameView view, Unit activator, Unit opponent)
    {
        ApplyBonus(view, activator, opponent);
    }

    public void ApplyBonus(GameView view, Unit activator, Unit opponent)
    {
        activator.ApplyStatEffect(_stat, _amount);
        opponent.ApplyStatEffect(_stat, _amount);
        view.AnnounceBonusStat(activator.Name, $"{_stat}+{_amount}");
        view.AnnounceBonusStat(opponent.Name, $"{_stat}+{_amount}");
    }

    public void RevertEffect(GameView view, Unit activator, Unit opponent)
    {
        activator.ApplyStatEffect(_stat, -_amount);
        opponent.ApplyStatEffect(_stat, -_amount);
    }

    public void RevertBonus(GameView view, Unit activator, Unit opponent)
    {
        RevertEffect(view, activator, opponent);
    }

    public IEffect Clone()
    {
        return new MutualBonusEffect(_stat, _amount);
    }
}