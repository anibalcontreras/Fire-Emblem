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
    private readonly GameInitializer _gameInitializer;
    private readonly CombatCollection _combats;

    public Game(View view, string teamsFolder)
    {
        _view = view;
        _teamsFolder = teamsFolder;
        _consoleGameView = new ConsoleGameView(_view, _teamsFolder);
        GameController gameController = new GameController(_consoleGameView);
        CombatController combatController = new CombatController(_consoleGameView);
        FileManager fileManager = new FileManager(_consoleGameView);
        TeamBuilder teamBuilder = new TeamBuilder();
        _gameInitializer = new GameInitializer(_consoleGameView, gameController, combatController, fileManager, teamBuilder);
        _combats = new CombatCollection();
    }

    public void Play()
    {
        _gameInitializer.InitializeGame(_combats);
    }
}