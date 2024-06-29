using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Controllers;

public class FollowUpController
{
    private readonly int _spdNumberDifference = 5;
    public bool CanAttackerPerformFollowUp(Unit attacker, Unit defender)
    {
        if (attacker.HasDenialFollowUp && !attacker.HasDenialOfDenialFollowUp)
            return false;
        int attackerCurrentStat = attacker.GetCurrentStat(StatType.Spd);
        int defenderCurrentStat = defender.GetCurrentStat(StatType.Spd);
        return attackerCurrentStat - defenderCurrentStat >= _spdNumberDifference;
    }
    
    public bool CanDefenderPerformFollowUp(Unit attacker, Unit defender)
    {
        if (defender.HasDenialFollowUp && !defender.HasDenialOfDenialFollowUp)
            return false;
        int defenderCurrentStat = defender.GetCurrentStat(StatType.Spd);
        int attackerCurrentStat = attacker.GetCurrentStat(StatType.Spd);
        return defenderCurrentStat - attackerCurrentStat >= _spdNumberDifference;
    }
}