using Fire_Emblem.Controllers;
using Fire_Emblem.Teams;
using Fire_Emblem.Views;

namespace Fire_Emblem;

public class GameInitializer
{
    private readonly ConsoleGameView _consoleGameView;
    private readonly GameController _gameController;
    private readonly CombatController _combatController;
    private readonly FileManager _fileManager;
    private readonly TeamBuilder _teamBuilder;

    public GameInitializer(ConsoleGameView consoleGameView, GameController gameController, 
        CombatController combatController, FileManager fileManager, TeamBuilder teamBuilder)
    {
        _consoleGameView = consoleGameView;
        _gameController = gameController;
        _combatController = combatController;
        _fileManager = fileManager;
        _teamBuilder = teamBuilder;
    }

    public void InitializeGame(CombatCollection combats)
    {
        TeamCollection teams = BuildTeamsFromScratch();
        if (teams.AreTeamsValid())
            _gameController.ManageGame(teams.GetTeams(), combats.GetCombats());
        else
            _consoleGameView.AnnounceMessageForInvalidTeam();
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
        {
            teams.AddTeam(team);
        }
        return teams;
    }
}
