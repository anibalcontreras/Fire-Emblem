using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem;

public class Combat
{
    private readonly int _spdNumberDifference = 5;
    public Unit Attacker { get; }
    public Unit Defender { get;  }
    
    public Combat(Unit attacker, Unit defender)
    {
        Attacker = attacker;
        Defender = defender;
    }
    
    public bool CanAttackerPerformFollowUp()
    {
        int attackerCurrentStat = Attacker.GetCurrentStat(StatType.Spd);
        int defenderCurrentStat = Defender.GetCurrentStat(StatType.Spd);
        return attackerCurrentStat - defenderCurrentStat >= _spdNumberDifference;
    }

    public bool CanDefenderPerformFollowUp()
    {
        int defenderCurrentStat = Defender.GetCurrentStat(StatType.Spd);
        int attackerCurrentStat = Attacker.GetCurrentStat(StatType.Spd);
        return defenderCurrentStat - attackerCurrentStat >= _spdNumberDifference;
    }
}
