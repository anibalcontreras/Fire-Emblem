using Fire_Emblem.TeamManagment;
using Fire_Emblem.UnitManagment;

namespace Fire_Emblem;

public class CombatManager
{
    private GameView _gameView;
    private Combat _combat;

    public CombatManager(GameView gameView)
    {
        _gameView = gameView;
    }

    public void ConductCombat(List<Team> teams, int round, int currentPlayer)
    {
        Team activeTeam = teams[currentPlayer];
        Team opponentTeam = teams[(currentPlayer + 1) % 2];
        Unit attacker = _gameView.SelectUnit(activeTeam, currentPlayer + 1);
        Unit defender = _gameView.SelectUnit(opponentTeam, (currentPlayer + 1) % 2 + 1);

        Combat combat = new Combat(activeTeam, opponentTeam, attacker, defender, _gameView);
        _gameView.AnnounceRoundStart(round, attacker, currentPlayer);
        combat.ProcessCombat();
    }
}
