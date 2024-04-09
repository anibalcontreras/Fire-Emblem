using Fire_Emblem_View;
using Fire_Emblem.TeamManagment;

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
        
        while (IsCombatContinuing(teams))
        {
            Team activeTeam = teams[currentPlayer];
            Team opponentTeam = teams[(currentPlayer + 1) % 2];

            UnitLoadout activeUnit = SelectUnit(activeTeam, $"Player {currentPlayer + 1} selecciona una opción");
            UnitLoadout opponentUnit = SelectUnit(opponentTeam, $"Player {(currentPlayer + 1) % 2 + 1} selecciona una opción");
            
            ExecuteRound(activeUnit, opponentUnit, round++, currentPlayer);

            RemoveDefeatedUnits(teams);
            currentPlayer = (currentPlayer + 1) % 2;
        }

        AnnounceWinner(teams);
    }

    private UnitLoadout SelectUnit(Team team, string prompt)
    {
        _view.WriteLine(prompt);
        ShowUnitOptions(team);
        int selectedOption = AskUserToSelectNumber(0, team.UnitsLoadout.Count - 1);
        return team.UnitsLoadout[selectedOption];
    }

    private void ShowUnitOptions(Team team)
    {
        for (int i = 0; i < team.UnitsLoadout.Count; i++)
        {
            if (team.UnitsLoadout[i].Unit.CurrentHP > 0)
            {
                _view.WriteLine($"{i}: {team.UnitsLoadout[i].Unit.Name}");
            }
        }
    }

    private void ExecuteRound(UnitLoadout activeUnit, UnitLoadout opponentUnit, int round, int currentPlayer)
    {
        _view.WriteLine($"Round {round}: {activeUnit.Unit.Name} (Player {currentPlayer + 1}) comienza");
        RoundCombats(activeUnit, opponentUnit);
    }

    private bool IsCombatContinuing(List<Team> teams)
    {
        return teams.All(team => team.UnitsLoadout.Any(u => u.Unit.CurrentHP > 0));
    }

    private void RemoveDefeatedUnits(List<Team> teams)
    {
        foreach (var team in teams)
        {
            team.RemoveDefeatedUnits();
        }
    }

    private void AnnounceWinner(List<Team> teams)
    {
        bool team1HasLivingUnits = teams[0].UnitsLoadout.Any(u => u.Unit.CurrentHP > 0);
        bool team2HasLivingUnits = teams[1].UnitsLoadout.Any(u => u.Unit.CurrentHP > 0);

        if (team1HasLivingUnits && !team2HasLivingUnits)
        {
            _view.WriteLine("Player 1 ganó");
        }
        else if (!team1HasLivingUnits && team2HasLivingUnits)
        {
            _view.WriteLine("Player 2 ganó");
        }
    }
    
    private void RoundCombats(UnitLoadout attacker, UnitLoadout defender)
    {
        AnnounceAdvantage(attacker, defender);
        PerformAttack(attacker, defender);

        if (defender.Unit.CurrentHP <= 0)
        {
            ShowCurrentHealth(attacker, defender);
            return;
        }

        PerformAttack(defender, attacker);

        if (attacker.Unit.CurrentHP <= 0)
        {
            ShowCurrentHealth(attacker, defender);
            return;
        }

        HandleFollowUp(attacker, defender);
        ShowCurrentHealth(attacker, defender);
    }

    private void AnnounceAdvantage(UnitLoadout attacker, UnitLoadout defender)
    {
        string message = attacker.Unit.Weapon.CalculateAdvantage(attacker.Unit, defender.Unit);
        _view.WriteLine(message);
    }

    private void PerformAttack(UnitLoadout attacker, UnitLoadout defender)
    {
        int damage = attacker.Unit.CalculateDamage(defender.Unit);
        _view.WriteLine($"{attacker.Unit.Name} ataca a {defender.Unit.Name} con {damage} de daño");
    }

    private void HandleFollowUp(UnitLoadout attacker, UnitLoadout defender)
    {
        if (CanPerformFollowUp(attacker, defender))
        {
            PerformAttack(attacker, defender);
        }
        else if (CanPerformFollowUp(defender, attacker))
        {
            PerformAttack(defender, attacker);
        }
        else
        {
            _view.WriteLine("Ninguna unidad puede hacer un follow up");
        }
    }

    private bool CanPerformFollowUp(UnitLoadout attacker, UnitLoadout defender)
    {
        return attacker.Unit.Spd - defender.Unit.Spd >= 5;
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