﻿using Fire_Emblem_View;
using Fire_Emblem.Teams;

namespace Fire_Emblem;


public class Game
{
    private readonly View _view;
    private readonly GameView _gameView;
    private readonly string _teamsFolder;
    private MatchManager _matchManager;
    private List<Combat> _combats;
    
    public Game(View view, string teamsFolder)
    {
        _view = view;
        _teamsFolder = teamsFolder;
        _gameView = new GameView(_view, _teamsFolder);
        _matchManager = new MatchManager(_gameView);
        _combats = new List<Combat>();
    }

    public void Play()
    { 
        StartGame();   
    }

    private void StartGame()
    {
        List<Team> teams = BuildTeamsFromScratch();
        if (AreTeamsValid(teams))
            StartGameDevelopment(teams);
        else
            ShowInvalidTeamMessage();
    }
    
    private List<Team> BuildTeamsFromScratch()
    {
        string[] files = GetFileOptions();
        string selectedFile = SelectFile(files);
        string fileContent = ReadFileContent(selectedFile);
        List<Team> teams = BuildTeamsFromContent(fileContent);
        return teams;
    }
    
    private string[] GetFileOptions()
    {
        return _gameView.DisplayFiles();
    }
    
    private string SelectFile(string[] files)
    {
        return _gameView.AskUserToSelectAnOption(files);
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
    
    private bool AreTeamsValid(List<Team> teams)
    {
        return teams.All(team => team.IsValidTeam());
    }
    
    private void ShowInvalidTeamMessage() => _gameView.ShowMessageForInvalidTeam();
    
    private void StartGameDevelopment(List<Team> teams) => _matchManager.ManageGame(teams, _combats);
    
}