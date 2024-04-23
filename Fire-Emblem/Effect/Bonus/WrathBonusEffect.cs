using Fire_Emblem;
using Fire_Emblem.Effect;
using Fire_Emblem.Stats;
using Fire_Emblem.UnitManagment;

public class WrathBonusEffect : IEffect, IBonusEffect
{
    private readonly int _maxBonus;

    public WrathBonusEffect(int maxBonus)
    {
        _maxBonus = maxBonus;
    }

    public void ApplyEffect(GameView view, Unit activator, Unit opponent)
    {
        int hpLost = activator.HP - activator.CurrentHP;
        int bonus = Math.Min(hpLost, _maxBonus);
        
        activator.AtkBonus = bonus; // Consider using properties to handle state
        activator.SpdBonus = bonus; // Consider using properties to handle state
        
        ApplyBonus(view, activator, opponent);
    }

    public void ApplyBonus(GameView view, Unit activator, Unit opponent)
    {
        view.AnnounceBonusStat(activator.Name, $"{AtkBoostString(activator.AtkBonus)}");
        activator.IncreaseStat(StatType.Atk, activator.AtkBonus);
        view.AnnounceBonusStat(activator.Name, $"{SpdBoostString(activator.SpdBonus)}");
        activator.IncreaseStat(StatType.Spd, activator.SpdBonus);
    }

    public void RevertEffect(GameView view, Unit activator, Unit opponent)
    {
        RevertBonus(view, activator, opponent);
    }

    public void RevertBonus(GameView view, Unit activator, Unit opponent)
    {
        activator.IncreaseStat(StatType.Atk, -activator.AtkBonus);
        activator.IncreaseStat(StatType.Spd, -activator.SpdBonus);
    }

    public IEffect Clone()
    {
        return new WrathBonusEffect(_maxBonus);
    }

    private string AtkBoostString(int boost)
    {
        return $"Atk+{boost}";
    }
    
    private string SpdBoostString(int boost)
    {
        return $"Spd+{boost}";
    }
}



