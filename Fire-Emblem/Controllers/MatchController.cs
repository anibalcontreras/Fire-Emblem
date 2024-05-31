using Fire_Emblem.Combats.Teams;
using Fire_Emblem.Combats.Views;

namespace Fire_Emblem.Combats.Controllers;

public class MatchController
{
    private readonly ConsoleGameView _consoleGameView;
    private readonly CombatController _combatController;
    public MatchController(ConsoleGameView consoleGameView)
    {
        _consoleGameView = consoleGameView;
        _combatController = new CombatController(_consoleGameView);
    }
    
    public void ManageGame(List<Team> teams, List<Combat> combats)
    {
        int currentPlayer = 0;
        int round = 1;

        while (CheckIfBothTeamsHaveLivingUnits(teams))
        {
            
            Combat combat = _combatController.ConductCombat(teams, round++, currentPlayer);
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
            _consoleGameView.AnnounceWinner(1);
        else if (!team1HasLivingUnits && team2HasLivingUnits)
            _consoleGameView.AnnounceWinner(2);
    }
}
