using Fire_Emblem;
using Fire_Emblem.Effects;
using Fire_Emblem.Stats;
using Fire_Emblem.Units;

public class WrathBonusEffect : IEffect, IBonusEffect
{
    private readonly int _maxBonus;

    public WrathBonusEffect(int maxBonus)
    {
        _maxBonus = maxBonus;
    }

    public void ApplyEffect(GameView view, Unit activator, Unit opponent)
    {
        int hpLost = activator.BaseHp - activator.CurrentHP;
        int bonus = Math.Min(hpLost, _maxBonus);
        
        activator.AtkBonus = bonus;
        activator.SpdBonus = bonus;
        
        ApplyBonus(view, activator, opponent);
    }

    public void ApplyBonus(GameView view, Unit activator, Unit opponent)
    {
        view.AnnounceBonusStat(activator.Name, $"{AtkBoostString(activator.AtkBonus)}");
        activator.ApplyStatBonusAndPenaltyEffect(StatType.Atk, activator.AtkBonus);
        view.AnnounceBonusStat(activator.Name, $"{SpdBoostString(activator.SpdBonus)}");
        activator.ApplyStatBonusAndPenaltyEffect(StatType.Spd, activator.SpdBonus);
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



