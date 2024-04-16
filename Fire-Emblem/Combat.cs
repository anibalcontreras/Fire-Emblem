using Fire_Emblem.TeamManagment;
using Fire_Emblem.UnitManagment;

namespace Fire_Emblem;

public class Combat
{
    public Team ActiveTeam { get; private set; }
    public Team OpponentTeam { get; private set; }
    public Unit Attacker { get; private set; }
    public Unit Defender { get; private set; }
    
    public CombatState State { get;  private set; }

    public Combat(Team activeTeam, Team opponentTeam, Unit attacker, Unit defender)
    {
        ActiveTeam = activeTeam;
        OpponentTeam = opponentTeam;
        Attacker = attacker;
        Defender = defender;
        State = CombatState.StartOfCombat;
    }

    public void SetState(CombatState newState)
        => State = newState;
    
}