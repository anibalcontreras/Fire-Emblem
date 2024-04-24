using Fire_Emblem.TeamManagment;
using Fire_Emblem.UnitManagment;

namespace Fire_Emblem;

public class Combat
{
    public Team ActiveTeam { get; private set; }
    public Team OpponentTeam { get; private set; }
    public Unit Attacker { get; private set; }
    public Unit Defender { get; private set; }
    public CombatState State { get; private set; }
    

    public Combat(Team activeTeam, Team opponentTeam, Unit attacker, Unit defender)
    {
        ActiveTeam = activeTeam;
        OpponentTeam = opponentTeam;
        Attacker = attacker;
        Defender = defender;
    }

    public void UpdateState(CombatState newState)
    {
        State = newState;
    }
    
    public bool CanAttackerPerformFollowUp()
    {
        return Attacker.CurrentSpd - Defender.CurrentSpd >= 5;
    }

    public bool CanDefenderPerformFollowUp()
    {
        return Defender.CurrentSpd - Attacker.CurrentSpd >= 5;
    }
}
