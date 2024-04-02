using Fire_Emblem_View;
using Fire_Emblem.TeamManagment;
using Fire_Emblem.Loader;

namespace Fire_Emblem;


public class Game
{
    private View _view;
    private string _teamsFolder;
    private TeamBuilder _teamBuilder;
    
    public Game(View view, string teamsFolder)
    {
        _view = view;
        _teamsFolder = teamsFolder;
        _teamBuilder = new TeamBuilder();
    }

    public void Play()
    { 
        StartGame();   
    }

    private void StartGame()
    {
        TeamBuilder teamBuilder = new TeamBuilder();
        string[] files = DisplayFiles();
        string selectedOption = AskUserToSelectAnOption(files);
        string fileContent = File.ReadAllText(selectedOption);
        List<Team> buildedTeams = teamBuilder.BuildTeams(fileContent);
        // Esta forma de validar esta curiosa (PENSAR)
        if (buildedTeams.All(team => team.IsValidTeam()))
        {
            StartCombatPhase(buildedTeams);
        }
        else
            ShowMessageForInvalidTeam();
    }


    private void StartCombatPhase(List<Team> teams)
    {
        int currentPlayer = 0;
        
        int round = 1;
        while (teams[0].UnitsLoadout.Any(u => u.Unit.CurrentHP > 0) && teams[1].UnitsLoadout.Any(u => u.Unit.CurrentHP > 0))
        {
            // Imprime la cantidad de unidades disponibles en ambos equipos
            // Console.WriteLine($"Player 1: {teams[0].UnitsLoadout.Count(u => u.Unit.CurrentHP > 0)} unidades disponibles");
            // Console.WriteLine($"Player 2: {teams[1].UnitsLoadout.Count(u => u.Unit.CurrentHP > 0)} unidades disponibles");
            
            _view.WriteLine($"Player {currentPlayer + 1} selecciona una opción");
            var activeTeam = teams[currentPlayer];
            for (int i = 0; i < activeTeam.UnitsLoadout.Count; i++)
            {
                if (activeTeam.UnitsLoadout[i].Unit.CurrentHP > 0)
                {
                    _view.WriteLine($"{i}: {activeTeam.UnitsLoadout[i].Unit.Name}");
                }
            }

            int selectedOption = AskUserToSelectNumber(0, activeTeam.UnitsLoadout.Count - 1);
            // while (activeTeam.UnitsLoadout[selectedOption].Unit.CurrentHP <= 0)
            // {
            //     _view.WriteLine("Unidad no disponible, elige otra.");
            //     selectedOption = AskUserToSelectNumber(0, activeTeam.UnitsLoadout.Count - 1);
            // }

            var opponentTeam = teams[(currentPlayer + 1) % 2];
            _view.WriteLine($"Player {(currentPlayer + 1) % 2 + 1} selecciona una opción");
            for (int i = 0; i < opponentTeam.UnitsLoadout.Count; i++)
            {
                if (opponentTeam.UnitsLoadout[i].Unit.CurrentHP > 0)
                {
                    _view.WriteLine($"{i}: {opponentTeam.UnitsLoadout[i].Unit.Name}");
                }
            }

            int opponentSelectedOption = AskUserToSelectNumber(0, opponentTeam.UnitsLoadout.Count - 1);
            // while (opponentTeam.UnitsLoadout[opponentSelectedOption].Unit.CurrentHP <= 0)
            // {
            //     _view.WriteLine("Unidad no disponible, elige otra.");
            //     opponentSelectedOption = AskUserToSelectNumber(0, opponentTeam.UnitsLoadout.Count - 1);
            // }
            
            _view.WriteLine($"Round {round++}: {activeTeam.UnitsLoadout[selectedOption].Unit.Name} (Player {currentPlayer + 1}) comienza");
            RoundCombats(activeTeam.UnitsLoadout[selectedOption], opponentTeam.UnitsLoadout[opponentSelectedOption]);
            teams[0].RemoveDefeatedUnits();
            teams[1].RemoveDefeatedUnits();
            currentPlayer = (currentPlayer + 1) % 2;
        }

        bool team1HasLivingUnits = teams[0].UnitsLoadout.Any(u => u.Unit.CurrentHP > 0);
        bool team2HasLivingUnits = teams[1].UnitsLoadout.Any(u => u.Unit.CurrentHP > 0);

        if (team1HasLivingUnits && !team2HasLivingUnits)
        {
            // El equipo 1 es el ganador
            _view.WriteLine($"Player 1 ganó");
        }
        else if (!team1HasLivingUnits && team2HasLivingUnits)
        {
            // El equipo 2 es el ganador
            _view.WriteLine($"Player 2 ganó");
        }
    }


    private void RoundCombats(UnitLoadout attacker, UnitLoadout defender)
    {
        // Anunciar quien tiene ventaja
        (double wtb, string message) = attacker.Unit.Weapon.CalculateAdvantage(attacker.Unit, defender.Unit);
        _view.WriteLine(message);
        
        int damage = attacker.Unit.CalculateDamage(defender.Unit);
        _view.WriteLine($"{attacker.Unit.Name} ataca a {defender.Unit.Name} con {damage} de daño");
        if (defender.Unit.CurrentHP <= 0)
        {
            ShowCurrentHealth(attacker, defender); // Mostrar la salud actual
            return; // Salir de la función
        }
        
        int damage2 = defender.Unit.CalculateDamage(attacker.Unit);
        _view.WriteLine($"{defender.Unit.Name} ataca a {attacker.Unit.Name} con {damage2} de daño");
        if (attacker.Unit.CurrentHP <= 0)
        {
            ShowCurrentHealth(attacker, defender); // Mostrar la salud actual
            return; // Salir de la función
        }

        
        if (attacker.Unit.Spd - defender.Unit.Spd >= 5)
        {
            damage = attacker.Unit.CalculateDamage(defender.Unit);
            _view.WriteLine($"{attacker.Unit.Name} ataca a {defender.Unit.Name} con {damage} de daño");
            if (defender.Unit.CurrentHP <= 0)
            {
                ShowCurrentHealth(attacker, defender); // Mostrar la salud actual
                return; // Salir de la función
            }
        }
        else if (defender.Unit.Spd - attacker.Unit.Spd >= 5)
        {
            damage2 = defender.Unit.CalculateDamage(attacker.Unit);
            _view.WriteLine($"{defender.Unit.Name} ataca a {attacker.Unit.Name} con {damage2} de daño");
            if (attacker.Unit.CurrentHP <= 0)
            {
                ShowCurrentHealth(attacker, defender); // Mostrar la salud actual
                return; // Salir de la función
            }
        }
        else
        {
            _view.WriteLine("Ninguna unidad puede hacer un follow up");
        }
        ShowCurrentHealth(attacker, defender);
    }
    
    private void ShowCurrentHealth(UnitLoadout attacker, UnitLoadout defender)
        => _view.WriteLine(
            $"{attacker.Unit.Name} ({attacker.Unit.CurrentHP}) : {defender.Unit.Name} ({defender.Unit.CurrentHP})");
    
    
    private string[] DisplayFiles()
    {
        _view.WriteLine("Elige un archivo para cargar los equipos");
        string[] files = Directory.GetFiles(_teamsFolder, "*.txt");
        Array.Sort(files);
        ShowArrayOfOptions(files);
        return files;
    }
    
    
    private void ShowArrayOfOptions(string[] options)
    {
        for (int i = 0; i < options.Length; i++)
        {
            string fileName = Path.GetFileName(options[i]);
            _view.WriteLine($"{i}: {fileName}");
        }
    }
    
    private string AskUserToSelectAnOption(string[] options)
    {
        int minValue = 0;
        int maxValue = options.Length - 1;
        int selectedOption = AskUserToSelectNumber(minValue, maxValue);
        return options[selectedOption];
    }
    
    private int AskUserToSelectNumber(int minValue, int maxValue)
    {
        Console.WriteLine($"(Ingresa un número entre {minValue} y {maxValue})");
        int value;
        bool wasParsePossible;
        do
        {
            string? userInput = _view.ReadLine();
            wasParsePossible = int.TryParse(userInput, out value);
        } while (!wasParsePossible || IsValueOutsideTheValidRange(minValue, value, maxValue));

        return value;
    }

    private bool IsValueOutsideTheValidRange(int minValue, int value, int maxValue)
        => value < minValue || value > maxValue;
    
    private void ShowMessageForInvalidTeam()
        =>_view.WriteLine("Archivo de equipos no válido");
}