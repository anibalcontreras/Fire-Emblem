using Fire_Emblem_View;
using Fire_Emblem.Controllers;
using Fire_Emblem.Teams;
using Fire_Emblem.Views;

namespace Fire_Emblem;


public class Game
{
    private readonly View _view;
    private readonly ConsoleGameView _consoleGameView;
    private readonly string _teamsFolder;
    private MatchController _matchController;
    private CombatController _combatController;
    private List<Combat> _combats;
    
    public Game(View view, string teamsFolder)
    {
        _view = view;
        _teamsFolder = teamsFolder;
        _consoleGameView = new ConsoleGameView(_view, _teamsFolder);
        _matchController = new MatchController(_consoleGameView);
        _combatController = new CombatController(_consoleGameView);
        _combats = new List<Combat>();
    }

    public void Play()
    { 
        StartGame();   
    }

    private void StartGame()
    {
        TeamCollection teams = BuildTeamsFromScratch();
        if (teams.AreTeamsValid())
            StartGameDevelopment(teams);
        else
            AnnounceInvalidTeamMessage();
    }
    
    private TeamCollection BuildTeamsFromScratch()
    {
        string[] files = GetFileOptions();
        string selectedFile = SelectFile(files);
        string fileContent = ReadFileContent(selectedFile);
        List<Team> teamsList = BuildTeamsFromContent(fileContent);
        TeamCollection teams = new TeamCollection();
        foreach (Team team in teamsList)
        {
            teams.AddTeam(team);
        }
        return teams;
    }
    
    private string[] GetFileOptions()
    {
        return _consoleGameView.DisplayFiles();
    }
    
    private string SelectFile(string[] files)
    {
        return _consoleGameView.AskUserToSelectAnOption(files);
    }
    
    private string ReadFileContent(string filePath)
    {
        return File.ReadAllText(filePath);
    }

    private List<Team> BuildTeamsFromContent(string content)
    {
        TeamBuilder teamBuilder = new TeamBuilder();
        return teamBuilder.BuildTeams(content);
    }
    
    private void AnnounceInvalidTeamMessage() => _consoleGameView.AnnounceMessageForInvalidTeam();
    
    private void StartGameDevelopment(TeamCollection teams) => _matchController.ManageGame(teams.GetTeams(), _combats);
}