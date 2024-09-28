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
    
    public void ManageGame(TeamCollection teams, List<Combat> combats)
    {
        int currentPlayer = 0;
        int round = 1;
        while (CheckIfBothTeamsHaveLivingUnits(teams))
        {
            Combat combat = _combatController.ConductCombat(teams, round++, currentPlayer);
            RemoveDefeatedUnits(teams.GetTeams());
            combats.Add(combat);
            currentPlayer = (currentPlayer + 1) % 2;
        }
        AnnounceWinner(teams);
    }
    
    private bool CheckIfBothTeamsHaveLivingUnits(TeamCollection teams)
    {
        List<Team> teamList = teams.GetTeams();
        return teamList[0].HasLivingUnits() && teamList[1].HasLivingUnits();
    }
    
    private void RemoveDefeatedUnits(List<Team> teams)
    {
        foreach (Team team in teams) team.RemoveDefeatedUnits();
    }
    
    private void AnnounceWinner(TeamCollection teams)
    {
        List<Team> teamList = teams.GetTeams();
        bool teamOneHasLivingUnits = teamList[0].HasLivingUnits();
        bool teamTwoHasLivingUnits = teamList[1].HasLivingUnits();

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