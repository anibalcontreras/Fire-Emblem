
using Fire_Emblem.Stats;
using Fire_Emblem.TeamManagment;
using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Effect;

public class WrathBonusEffect : IEffect
{
    
    public void ApplyEffect(GameView view, Unit unit)
    {
        int lostHp = unit.HP - unit.CurrentHP;
        int boost = Math.Min(lostHp, 30); // Limitar el boost a un máximo de 30

        if (boost == 0) return;
        unit.IncreaseStat(StatType.Atk, boost);
        view.AnnounceBonusStat(unit.Name, AtkBoostString(boost));
        unit.IncreaseStat(StatType.Spd, boost);
        view.AnnounceBonusStat(unit.Name, SpdBoostString(boost));
    }
    
    public void RevertEffect(GameView view, Unit unit)
    {
        int lostHp = unit.HP - unit.CurrentHP;
        int boost = Math.Min(lostHp, 30);
        
        if (boost == 0) return;
        unit.IncreaseStat(StatType.Atk, -boost); // Revertir el efecto después del combate
        unit.IncreaseStat(StatType.Spd, -boost);
    }
    
    private string AtkBoostString(int boost)
    {
        return $"Atk+{boost}";
    }
    
    private string SpdBoostString(int boost)
    {
        return $"Spd+{boost}";
    }
    
    public IEffect Clone()
    {
        return new WrathBonusEffect();
    }
}
