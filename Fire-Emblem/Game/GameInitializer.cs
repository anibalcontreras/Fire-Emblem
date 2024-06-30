using Fire_Emblem.Controllers;
using Fire_Emblem.Exception;
using Fire_Emblem.Teams;
using Fire_Emblem.Views;

namespace Fire_Emblem;

public class GameInitializer
{
    private readonly IView _view;
    private readonly GameController _gameController;
    private readonly CombatController _combatController;
    private readonly FileManager _fileManager;
    private readonly TeamBuilder _teamBuilder;

    public GameInitializer(IView view, GameController gameController, 
        CombatController combatController, FileManager fileManager, TeamBuilder teamBuilder)
    {
        _view = view;
        _gameController = gameController;
        _combatController = combatController;
        _fileManager = fileManager;
        _teamBuilder = teamBuilder;
    }

    public void InitializeGame(CombatCollection combats)
    {
        TeamCollection teamsCollection = BuildTeamsFromScratch();
        try
        {
            foreach (Team team in teamsCollection.GetTeams()) team.ValidateTeam();
            _gameController.ManageGame(teamsCollection, combats.GetCombats());
        }
        catch (InvalidTeamException)
        {
            _gameController.AnnounceInvalidTeam();
        }
    }

    private TeamCollection BuildTeamsFromScratch()
    {
        string[] files = _fileManager.GetFileOptions();
        string selectedFile = _fileManager.SelectFile(files);
        string fileContent = _fileManager.ReadFileContent(selectedFile);
        List<Team> teamsList = _teamBuilder.BuildTeams(fileContent);
        TeamCollection teams = CreateTeamCollection(teamsList);
        return teams;
    }
    
    private static TeamCollection CreateTeamCollection(List<Team> teamsList)
    {
        TeamCollection teams = new TeamCollection();
        foreach (Team team in teamsList)
            teams.AddTeam(team);
        return teams;
    }
}
