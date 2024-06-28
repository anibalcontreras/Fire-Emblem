using Fire_Emblem.Teams;
using Fire_Emblem.Views;

namespace Fire_Emblem.Controllers;

public class GameController
{
    private readonly IView _view;
    private readonly CombatController _combatController;
    public GameController(IView view)
    {
        _view = view;
        _combatController = new CombatController(_view);
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
    
    private bool CheckIfBothTeamsHaveLivingUnits(List<Team> teams)
    {
        return teams[0].HasLivingUnits() && teams[1].HasLivingUnits();
    }
    
    private void RemoveDefeatedUnits(List<Team> teams)
    {
        foreach (Team team in teams) team.RemoveDefeatedUnits();
    }
    
    
    private void AnnounceWinner(List<Team> teams)
    {
        bool teamOneHasLivingUnits = teams[0].HasLivingUnits();
        bool teamTwoHasLivingUnits = teams[1].HasLivingUnits();

        if (teamOneHasLivingUnits && !teamTwoHasLivingUnits)
            _view.AnnounceWinner(1);
        else if (!teamOneHasLivingUnits && teamTwoHasLivingUnits)
            _view.AnnounceWinner(2);
    }
    
    public void AnnounceInvalidTeam()
    {
        _view.AnnounceMessageForInvalidTeam();
    }
}
