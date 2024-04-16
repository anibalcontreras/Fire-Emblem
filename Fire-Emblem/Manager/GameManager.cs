using Fire_Emblem.TeamManagment;

namespace Fire_Emblem;

public class GameManager
{
    private readonly GameView _gameView;
    private readonly CombatManager _combatManager;
    public GameManager(GameView gameView)
    {
        _gameView = gameView;
        _combatManager = new CombatManager(_gameView);
    }
    
    public void ManageGame(List<Team> teams)
    {
        int currentPlayer = 0;
        int round = 1;

        while (CheckIfBothTeamsHaveLivingUnits(teams))
        {
            _combatManager.ConductCombat(teams, round++, currentPlayer);
            RemoveDefeatedUnits(teams);
            currentPlayer = (currentPlayer + 1) % 2;
        }
        AnnounceWinner(teams);
    }
    
    private void RemoveDefeatedUnits(List<Team> teams)
    {
        foreach (Team team in teams) team.RemoveDefeatedUnits();
    }
    
    private bool CheckIfBothTeamsHaveLivingUnits(List<Team> teams)
    {
        return teams[0].HasLivingUnits() && teams[1].HasLivingUnits();
    }
    
    private void AnnounceWinner(List<Team> teams)
    {
        bool team1HasLivingUnits = teams[0].HasLivingUnits();
        bool team2HasLivingUnits = teams[1].HasLivingUnits();

        if (team1HasLivingUnits && !team2HasLivingUnits)
            _gameView.AnnounceWinner(1);
        else if (!team1HasLivingUnits && team2HasLivingUnits)
            _gameView.AnnounceWinner(2);
    }
}
