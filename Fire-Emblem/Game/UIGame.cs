using Fire_Emblem_GUI;
using Fire_Emblem.Exception;
using Fire_Emblem.Teams;
using Fire_Emblem.Units;
using Fire_Emblem.Views;

namespace Fire_Emblem;

public class UIGame
{
    private readonly IView _view;
    private readonly TeamBuilder _teamBuilder;
    
    public UIGame(IView view)
    {
        _view = view;
        TeamBuilder teamBuilder = new TeamBuilder();
        _teamBuilder = teamBuilder;
    }
    
    public void Play()
    {
        string formattedTeams = GetFormattedTeams();
        TeamCollection teamsCollection = BuildTeamsFromScratch(formattedTeams);
        try
        {
            ValidateTeams(teamsCollection);
            IUnit[] adaptedTeam1 = AdaptTeam(teamsCollection.GetTeams()[0]);
            IUnit[] adaptedTeam2 = AdaptTeam(teamsCollection.GetTeams()[1]);
            _view.UpdateTeams(adaptedTeam1, adaptedTeam2);
            UpdateBattleStats(adaptedTeam1, adaptedTeam2);
        }
        catch (InvalidTeamException)
        {
            _view.ShowInvalidTeamMessage();
        }
    }

    private string GetFormattedTeams()
    {
        string team1Data = _view.GetTeam1();
        string team2Data = _view.GetTeam2();
        string formattedTeam1 = "Player 1 Team\n" + team1Data + "\n";
        string formattedTeam2 = "Player 2 Team\n" + team2Data;
        return formattedTeam1 + formattedTeam2;
    }
    
    private TeamCollection BuildTeamsFromScratch(string fileContent)
    {
        List<Team> teamsList = _teamBuilder.BuildTeams(fileContent);
        TeamCollection teams = CreateTeamCollection(teamsList);
        return teams;
    }
    
    private TeamCollection CreateTeamCollection(List<Team> teamsList)
    {
        TeamCollection teams = new TeamCollection();
        foreach (Team team in teamsList)
            teams.AddTeam(team);
        return teams;
    }

    private void ValidateTeams(TeamCollection teamsCollection)
    {
        foreach (Team team in teamsCollection.GetTeams())
        {
            team.ValidateTeam();
        }
    }

    private IUnit[] AdaptTeam(Team team)
    {
        List<Unit> units = team.Units;
        return units.Select(unit => new UnitAdapter(unit)).ToArray();
    }
    
    private void UpdateBattleStats(IUnit[] adaptedTeam1, IUnit[] adaptedTeam2)
    {
        int idSelectedUnitTeam1 = _view.SelectUnitFirstTeam();
        IUnit adaptedUnitTeam1 = adaptedTeam1[idSelectedUnitTeam1];
        int idSelectedUnitTeam2 = _view.SelectUnitSecondTeam();
        IUnit adaptedUnitTeam2 = adaptedTeam2[idSelectedUnitTeam2];
        _view.UpdateUnitsStatsDuringBattle(adaptedUnitTeam1, adaptedUnitTeam2);
    }
}