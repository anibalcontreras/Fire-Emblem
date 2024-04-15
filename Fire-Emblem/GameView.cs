using Fire_Emblem_View;
using Fire_Emblem.Effect;
using Fire_Emblem.SkillManagment;
using Fire_Emblem.TeamManagment;
using Fire_Emblem.UnitManagment;
using Fire_Emblem.Weapon;

namespace Fire_Emblem;

public class GameView
{
    private View _view;
    private readonly string _teamsFolder;
    
    public GameView(View view, string teamsFolder)
    {
        _view = view;
        _teamsFolder = teamsFolder;
    }
    
    public void ShowCurrentHealth(Unit attacker, Unit defender)
        => _view.WriteLine(
            $"{attacker.Name} ({attacker.CurrentHP}) : {defender.Name} ({defender.CurrentHP})");
    
    public Unit SelectUnit(Team team, int playerNumber)
    {
        _view.WriteLine($"Player {playerNumber} selecciona una opción");
        ShowUnitOptions(team);
        int selectedOption = AskUserToSelectNumber(0, team.Units.Count - 1);
        return team.Units[selectedOption];
    }
    
    private void ShowUnitOptions(Team team)
    {
        for (int i = 0; i < team.Units.Count; i++)
        {
            if (team.Units[i].CurrentHP > 0)
            {
                _view.WriteLine($"{i}: {team.Units[i].Name}");
            }
        }
    }

    public void AnnounceAdvantage(Unit attacker, Unit defender, AdvantageState advantage)
    {
        string message = advantage switch
        {
            AdvantageState.Advantage =>
                $"{attacker.Name} ({attacker.Weapon.Name}) tiene ventaja con respecto a {defender.Name} ({defender.Weapon.Name})",
            AdvantageState.Disadvantage =>
                $"{defender.Name} ({defender.Weapon.Name}) tiene ventaja con respecto a {attacker.Name} ({attacker.Weapon.Name})",
            AdvantageState.Neutral => "Ninguna unidad tiene ventaja con respecto a la otra",
            _ => "Estado de ventaja desconocido"
        };
        _view.WriteLine(message);
    }
    
    public void AnnounceRoundStart(int round, Unit activeUnit, int currentPlayer)
        => _view.WriteLine($"Round {round}: {activeUnit.Name} (Player {currentPlayer + 1}) comienza");

    public string[] DisplayFiles()
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
    
    public string AskUserToSelectAnOption(string[] options)
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
    
    public void AnnounceAttack(Unit attacker, Unit defender, int damage)
     => _view.WriteLine($"{attacker.Name} ataca a {defender.Name} con {damage} de daño");

    public void AnnounceWinner(int winnerTeamNumber)
        => _view.WriteLine($"Player {winnerTeamNumber} ganó");
    
    private bool IsValueOutsideTheValidRange(int minValue, int value, int maxValue)
        => value < minValue || value > maxValue;
    
    public void ShowMessageForInvalidTeam()
        => _view.WriteLine("Archivo de equipos no válido");
    
    public void ShowMessageForNoFollowUpAttack()
        => _view.WriteLine("Ninguna unidad puede hacer un follow up");
    
    public void AnnounceBonusStat(string unitName, string effectDescription)
    {
        _view.WriteLine($"{unitName} obtiene {effectDescription}");
    }
}