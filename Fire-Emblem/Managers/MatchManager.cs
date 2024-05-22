using Fire_Emblem.Teams;
using Fire_Emblem.Views;

namespace Fire_Emblem.Managers;

public class MatchManager
{
    private readonly GameView _gameView;
    private readonly CombatManager _combatManager;
    public MatchManager(GameView gameView)
    {
        _gameView = gameView;
        _combatManager = new CombatManager(_gameView);
    }
    
    public void ManageGame(List<Team> teams, List<Combat> combats)
    {
        int currentPlayer = 0;
        int round = 1;

        while (CheckIfBothTeamsHaveLivingUnits(teams))
        {
            
            Combat combat = _combatManager.ConductCombat(teams, round++, currentPlayer);
            RemoveDefeatedUnits(teams);
            combats.Add(combat);
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
