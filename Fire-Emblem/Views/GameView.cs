using Fire_Emblem_View;
using Fire_Emblem.Stats;
using Fire_Emblem.Teams;
using Fire_Emblem.Units;
using Fire_Emblem.Weapons;

namespace Fire_Emblem.Views;

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

    public void AnnounceCounterattack(Unit defender, Unit attacker, int damage)
        => _view.WriteLine($"{defender.Name} ataca a {attacker.Name} con {damage} de daño");


    public void AnnounceWinner(int winnerTeamNumber)
        => _view.WriteLine($"Player {winnerTeamNumber} ganó");

    private bool IsValueOutsideTheValidRange(int minValue, int value, int maxValue)
        => value < minValue || value > maxValue;

    public void ShowMessageForInvalidTeam()
        => _view.WriteLine("Archivo de equipos no válido");

    public void ShowMessageForNoFollowUpAttack()
        => _view.WriteLine("Ninguna unidad puede hacer un follow up");
    
    
    public void AnnounceAttackerBonusStat(Unit unit)
    {
        AnnounceIfPositiveBonus(unit);
        AnnounceIfPositiveFirstAttackBonus(unit);
    }
    
    public void AnnounceDefenderBonusEffects(Unit rival)
    {
        AnnounceIfPositiveBonus(rival);
        AnnounceIfPositiveFirstAttackBonus(rival);
    }
    
    public void AnnounceAttackerPenaltyStat(Unit unit)
    {
        AnnounceIfPositivePenalty(unit);
        AnnounceIfPositiveFirstAttackPenalty(unit);
    }
    public void AnnounceDefenderPenaltyEffects(Unit rival)
    {
        AnnounceIfPositivePenalty(rival);
        AnnounceIfPositiveFirstAttackPenalty(rival);
    }
    
    public void AnnounceNeutralizationBonusEffect(Unit unit)
    {
        AnnounceBonusNeutralizationStat(unit);
    }
    
    public void AnnounceNeutralizationPenaltyEffect(Unit unit)
    {
        AnnouncePenaltyNeutralizationStat(unit);
    }

    public void AnnounceExtraDamage(Unit unit)
    {
        AnnounceExtraDamageEffect(unit);
    }
    
    public void AnnounceAbsoluteDamageReduction(Unit unit)
    {
        AnnounceAbsoluteDamageReductionEffect(unit);
    }
    
    public void AnnounceEachAttackPercentageReduction(Unit unit)
    {
        AnnounceEachAttackPercentageReductionEffect(unit);
    }
    
    public void AnnounceFirstAttackPercentageReduction(Unit unit)
    {
        AnnounceFirstAttackPercentageReductionEffect(unit);
    }
    
    public void AnnounceFollowUpPercentageReduction(Unit unit)
    {
        AnnounceFollowUpPercentageReductionEffect(unit);
    }
    
    
    private void AnnounceNeutralizationAtkPenaltyStat(Unit unit)
    {
        _view.WriteLine($"Los penalty de Atk de {unit.Name} fueron neutralizados");
    }
    
    private void AnnounceNeutralizationSpdPenaltyStat(Unit unit)
    {
        _view.WriteLine($"Los penalty de Spd de {unit.Name} fueron neutralizados");
    }
    
    private void AnnounceNeutralizationDefPenaltyStat(Unit unit)
    {
        _view.WriteLine($"Los penalty de Def de {unit.Name} fueron neutralizados");
    }
    
    private void AnnounceNeutralizationResPenaltyStat(Unit unit)
    {
        _view.WriteLine($"Los penalty de Res de {unit.Name} fueron neutralizados");
    }

    private void AnnounceNeutralizationAtkBonusStat(Unit unit)
    {
        _view.WriteLine($"Los bonus de Atk de {unit.Name} fueron neutralizados");
    }
    
    private void AnnounceNeutralizationSpdBonusStat(Unit unit)
    {
        _view.WriteLine($"Los bonus de Spd de {unit.Name} fueron neutralizados");
    }
    
    private void AnnounceNeutralizationDefBonusStat(Unit unit)
    {
        _view.WriteLine($"Los bonus de Def de {unit.Name} fueron neutralizados");
    }
    
    private void AnnounceNeutralizationResBonusStat(Unit unit)
    {
        _view.WriteLine($"Los bonus de Res de {unit.Name} fueron neutralizados");
    }
    
    private void AnnounceAtkBonusStat(Unit unit)
    {
        _view.WriteLine($"{unit.Name} obtiene Atk+{unit.AtkBonus}");
    }

    private void AnnounceFirstAttackAtkBonusStat(Unit unit)
    {
        _view.WriteLine($"{unit.Name} obtiene Atk+{unit.FirstAttackAtkBonus} en su primer ataque");
    }
    
    private void AnnounceFirstAttackDefBonusStat(Unit unit)
    {
        _view.WriteLine($"{unit.Name} obtiene Def+{unit.FirstAttackDefBonus} en su primer ataque");
    }
    
    private void AnnounceFirstAttackResBonusStat(Unit unit)
    {
        _view.WriteLine($"{unit.Name} obtiene Res+{unit.FirstAttackResBonus} en su primer ataque");
    }
    
    private void AnnounceFirstAttackAtkPenaltyStat(Unit unit)
    {
        _view.WriteLine($"{unit.Name} obtiene Atk-{unit.FirstAttackAtkPenalty} en su primer ataque");
    }
    
    private void AnnounceFirstAttackDefPenaltyStat(Unit unit)
    {
        _view.WriteLine($"{unit.Name} obtiene Def-{unit.FirstAttackDefPenalty} en su primer ataque");
    }
    
    private void AnnounceFirstAttackResPenaltyStat(Unit unit)
    {
        _view.WriteLine($"{unit.Name} obtiene Res-{unit.FirstAttackResPenalty} en su primer ataque");
    }

    private void AnnounceSpdBonusStat(Unit unit)
    {
        _view.WriteLine($"{unit.Name} obtiene Spd+{unit.SpdBonus}");
    }

    private void AnnounceDefBonusStat(Unit unit)
    {
        _view.WriteLine($"{unit.Name} obtiene Def+{unit.DefBonus}");
    }

    private void AnnounceResBonusStat(Unit unit)
    {
        _view.WriteLine($"{unit.Name} obtiene Res+{unit.ResBonus}");
    }

    private void AnnounceAtkPenaltyStat(Unit unit)
    {
        _view.WriteLine($"{unit.Name} obtiene Atk-{unit.AtkPenalty}");
    }
    
    private void AnnounceSpdPenaltyStat(Unit unit)
    {
        _view.WriteLine($"{unit.Name} obtiene Spd-{unit.SpdPenalty}");
    }
    
    private void AnnounceDefPenaltyStat(Unit unit)
    {
        _view.WriteLine($"{unit.Name} obtiene Def-{unit.DefPenalty}");
    }
    
    private void AnnounceResPenaltyStat(Unit unit)
    {
        _view.WriteLine($"{unit.Name} obtiene Res-{unit.ResPenalty}");
    }
    
    private void AnnounceIfPositiveBonus(Unit unit)
    {
        if (unit.HasActiveBonus(StatType.Atk)) AnnounceAtkBonusStat(unit);
        if (unit.HasActiveBonus(StatType.Spd)) AnnounceSpdBonusStat(unit);
        if (unit.HasActiveBonus(StatType.Def)) AnnounceDefBonusStat(unit);
        if (unit.HasActiveBonus(StatType.Res)) AnnounceResBonusStat(unit);
    }
    
    private void AnnounceIfPositiveFirstAttackBonus(Unit unit)
    {
        if (unit.HasActiveFirstAttackBonus(StatType.Atk)) AnnounceFirstAttackAtkBonusStat(unit);
        if (unit.HasActiveFirstAttackBonus(StatType.Def)) AnnounceFirstAttackDefBonusStat(unit);
        if (unit.HasActiveFirstAttackBonus(StatType.Res)) AnnounceFirstAttackResBonusStat(unit);
    }
    
    private void AnnounceIfPositivePenalty(Unit unit)
    {
        if (unit.HasActivePenalty(StatType.Atk)) AnnounceAtkPenaltyStat(unit);
        if (unit.HasActivePenalty(StatType.Spd)) AnnounceSpdPenaltyStat(unit);
        if (unit.HasActivePenalty(StatType.Def)) AnnounceDefPenaltyStat(unit);
        if (unit.HasActivePenalty(StatType.Res)) AnnounceResPenaltyStat(unit);
    }
    
    private void AnnounceIfPositiveFirstAttackPenalty(Unit unit)
    {
        if (unit.HasActiveFirstAttackPenalty(StatType.Atk)) AnnounceFirstAttackAtkPenaltyStat(unit);
        if (unit.HasActiveFirstAttackPenalty(StatType.Def)) AnnounceFirstAttackDefPenaltyStat(unit);
        if (unit.HasActiveFirstAttackPenalty(StatType.Res)) AnnounceFirstAttackResPenaltyStat(unit);
    }

    private void AnnounceBonusNeutralizationStat(Unit unit)
    {
        if (unit.HasActiveNeutralizationBonus(StatType.Atk)) AnnounceNeutralizationAtkBonusStat(unit);
        if (unit.HasActiveNeutralizationBonus(StatType.Spd)) AnnounceNeutralizationSpdBonusStat(unit);
        if (unit.HasActiveNeutralizationBonus(StatType.Def)) AnnounceNeutralizationDefBonusStat(unit);
        if (unit.HasActiveNeutralizationBonus(StatType.Res)) AnnounceNeutralizationResBonusStat(unit);
    }
    
    private void AnnouncePenaltyNeutralizationStat(Unit unit)
    {
        if (unit.HasActiveNeutralizationPenalty(StatType.Atk)) AnnounceNeutralizationAtkPenaltyStat(unit);
        if (unit.HasActiveNeutralizationPenalty(StatType.Spd)) AnnounceNeutralizationSpdPenaltyStat(unit);
        if (unit.HasActiveNeutralizationPenalty(StatType.Def)) AnnounceNeutralizationDefPenaltyStat(unit);
        if (unit.HasActiveNeutralizationPenalty(StatType.Res)) AnnounceNeutralizationResPenaltyStat(unit);
    }
    
    private void AnnounceExtraDamageInEachAttack(Unit unit)
    {
        // Esto está feo
        if (unit.ExtraDamage > 0)_view.WriteLine($"{unit.Name} realizará +{unit.ExtraDamage} daño extra en cada ataque");
    }
    
    private void AnnounceExtraDamageInFirstAttack(Unit unit)
    {
        if (unit.FirstAttackExtraDamage > 0) _view.WriteLine($"{unit.Name} realizará +{unit.FirstAttackExtraDamage} daño extra en su primer ataque");
    }
    
    private void AnnounceExtraDamageInFollowUpAttack(Unit unit)
    {
        _view.WriteLine($"{unit.Name} realizará +{unit.ExtraDamage} daño extra en su Follow-Up");
    }
    
    private void AnnounceExtraDamageEffect(Unit unit)
    {
        if (unit.HasActiveExtraDamageEffect()) AnnounceExtraDamageInEachAttack(unit);
        if (unit.HasActiveFirstAttackExtraDamageEffect()) AnnounceExtraDamageInFirstAttack(unit);
    }
    
    private void AnnounceAbsoluteDamageReductionEffect(Unit unit)
    {
        if (unit.HasActiveAbsoluteDamageReductionEffect()) AnnounceAbsoluteDamageReductionInEachAttack(unit);
    }
    
    private void AnnounceAbsoluteDamageReductionInEachAttack(Unit unit)
    {
        _view.WriteLine($"{unit.Name} recibirá -{unit.AbsoluteDamageReduction} daño en cada ataque");
    }

    private void AnnounceFirstAttackPercentageReductionEffect(Unit unit)
    {
        if (unit.HasActiveFirstAttackPercentageDamageReductionEffect()) AnnounceFirstAttackPercentageDamageReduction(unit);
    }
    
    private void AnnounceFollowUpPercentageReductionEffect(Unit unit)
    {
        if (unit.HasActiveFollowUpPercentageDamageReductionEffect()) AnnounceFollowUpPercentageDamageReduction(unit);
    }
    
    private void AnnounceEachAttackPercentageReductionEffect(Unit unit)
    {
        if (unit.HasActivePercentageDamageReductionEffect()) AnnounceEachAttackPercentageDamageReduction(unit);
    }
    
    private void AnnounceEachAttackPercentageDamageReduction(Unit unit)
    {
        double roundedReduction = Math.Round(unit.PercentageDamageReduction, 2);
        int percentage = Convert.ToInt32(Math.Floor(roundedReduction * 100));
        if (percentage > 0)
        {
            _view.WriteLine($"{unit.Name} reducirá el daño de los ataques del rival en un {percentage}%");
        }
    }

    private void AnnounceFirstAttackPercentageDamageReduction(Unit unit)
    {
        double roundedReduction = Math.Round(unit.FirstAttackPercentageDamageReduction, 2);
        int percentage = Convert.ToInt32(Math.Floor(roundedReduction * 100));
        if (percentage > 0)
        {
            _view.WriteLine($"{unit.Name} reducirá el daño del primer ataque del rival en un {percentage}%");
        }
    }
    
    private void AnnounceFollowUpPercentageDamageReduction(Unit unit)
    {
        // Dejar esto fuera de la vista
        // Hacer lo mismo que en AnnounceIfPositiveBonus
        double roundedReduction = Math.Round(unit.FollowUpPercentageDamageReduction, 2);
        int percentage = Convert.ToInt32(Math.Floor(roundedReduction * 100));
        if (percentage > 0) 
        {
            _view.WriteLine($"{unit.Name} reducirá el daño del Follow-Up del rival en un {percentage}%");
        }
    }
}