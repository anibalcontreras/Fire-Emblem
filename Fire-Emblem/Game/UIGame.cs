using Fire_Emblem_GUI;
using Fire_Emblem.Controllers;
using Fire_Emblem.Exception;
using Fire_Emblem.Teams;
using Fire_Emblem.Units;
using Fire_Emblem.Views;

namespace Fire_Emblem;

public class UIGame
{
    private readonly IView _view;
    private readonly GameInitializer _gameInitializer;
    private readonly CombatCollection _combats;
    private readonly TeamBuilder _teamBuilder;
    private readonly GameController _gameController;
    
    public UIGame(IView view)
    {
        _view = view;
        GameController gameController = new GameController(_view);
        CombatController combatController = new CombatController(_view);
        FileManager fileManager = new FileManager(_view);
        TeamBuilder teamBuilder = new TeamBuilder();
        _gameInitializer = new GameInitializer(_view, gameController, combatController, fileManager, teamBuilder);
        _combats = new CombatCollection();
        _teamBuilder = teamBuilder;
        _gameController = gameController;
    }
    
    public void Play()
    {
        
        string team1Data = _view.GetTeam1();
        string team2Data = _view.GetTeam2();
        string formattedTeam1 = "Player 1 Team\n" + team1Data + "\n";
        string formattedTeam2 = "Player 2 Team\n" + team2Data;
        string formattedTeams = formattedTeam1 + formattedTeam2;
        TeamCollection teamsCollection = BuildTeamsFromScratch(formattedTeams);
        try
        {
            foreach (Team team in teamsCollection.GetTeams()) team.ValidateTeam();
            IUnit[] adaptedTeam1 = teamsCollection.GetTeams()[0].Units.Select(unit => new UnitAdapter(unit)).ToArray();
            IUnit[] adaptedTeam2 = teamsCollection.GetTeams()[1].Units.Select(unit => new UnitAdapter(unit)).ToArray();
            _view.UpdateTeams(adaptedTeam1, adaptedTeam2);
            int idSelectedUnitTeam1 = _view.SelectUnitFirstTeam();
            IUnit adaptedUnitTeam1 = adaptedTeam1[idSelectedUnitTeam1];
            int idSelectedUnitTeam2 = _view.SelectUnitSecondTeam();
            IUnit adaptedUnitTeam2 = adaptedTeam2[idSelectedUnitTeam2];
            _view.UpdateUnitsStatsDuringBattle(adaptedUnitTeam1, adaptedUnitTeam2);
        }
        catch (InvalidTeamException)
        {
            _view.ShowInvalidTeamMessage();
        }
      
    }
    
    private TeamCollection BuildTeamsFromScratch(string fileContent)
    {
        List<Team> teamsList = _teamBuilder.BuildTeams(fileContent);
        TeamCollection teams = CreateTeamCollection(teamsList);
        return teams;
    }
    
    private static TeamCollection CreateTeamCollection(List<Team> teamsList)
    {
        TeamCollection teams = new TeamCollection();
        foreach (Team team in teamsList)
        {
            teams.AddTeam(team);
        }
        return teams;
    }

}