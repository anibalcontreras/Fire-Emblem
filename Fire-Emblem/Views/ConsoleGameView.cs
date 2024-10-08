using Fire_Emblem_View;
using Fire_Emblem.Effects;
using Fire_Emblem.Exception;
using Fire_Emblem.Stats;
using Fire_Emblem.Teams;
using Fire_Emblem.Units;
using Fire_Emblem.Weapons;
namespace Fire_Emblem.Views;

public class ConsoleGameView : BaseGameView
{
    private readonly View _view;
    private readonly string _teamsFolder;

    public ConsoleGameView(View view, string teamsFolder)
    {
        _view = view;
        _teamsFolder = teamsFolder;
    }

    public override void AnnounceCurrentHealth(Unit attacker, Unit defender)
        => _view.WriteLine(
            $"{attacker.Name} ({attacker.CurrentHP}) : {defender.Name} ({defender.CurrentHP})");

    public override Unit SelectUnit(Team team, int playerNumber)
    {
        _view.WriteLine($"Player {playerNumber} selecciona una opción");
        AnnounceUnitOptions(team);
        List<Unit> units = team.Units;
        int selectedOption = AskUserToSelectNumber(0, units.Count - 1);
        return team.Units[selectedOption];
    }

    private void AnnounceUnitOptions(Team team)
    {
        List<Unit> units = team.Units;
        for (int i = 0; i < units.Count; i++)
        {
            if (team.Units[i].CurrentHP > 0)
                _view.WriteLine($"{i}: {team.Units[i].Name}");
        }
    }

    public override string[] DisplayFiles()
    {
        _view.WriteLine("Elige un archivo para cargar los equipos");
        string[] files = Directory.GetFiles(_teamsFolder, "*.txt");
        Array.Sort(files);
        AnnounceArrayOfOptions(files);
        return files;
    }

    private void AnnounceArrayOfOptions(string[] options)
    {
        for (int i = 0; i < options.Length; i++)
        {
            string fileName = Path.GetFileName(options[i]);
            _view.WriteLine($"{i}: {fileName}");
        }
    }

    public override string AskUserToSelectAnOption(string[] options)
    {
        int minOptionValue = 0;
        int maxOptionValue = options.Length - 1;
        int selectedOption = AskUserToSelectNumber(minOptionValue, maxOptionValue);
        return options[selectedOption];
    }

    private int AskUserToSelectNumber(int minOptionValue, int maxOptionValue)
    {
        Console.WriteLine($"(Ingresa un número entre {minOptionValue} y {maxOptionValue})");
        return ValidateSelectedNumberByUser(minOptionValue, maxOptionValue);
    }

    private int ValidateSelectedNumberByUser(int minOptionValue, int maxOptionValue)
    {
        int defaultValueSelected = 0;
        bool isValid = false;
        while (!isValid)
        {
            try
            {
                defaultValueSelected = RetrieveOnlyValidatedNumbers(minOptionValue, maxOptionValue, out isValid);
            }
            catch (MenuOptionValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        return defaultValueSelected;
    }

    private int RetrieveOnlyValidatedNumbers(int minValue, int maxValue, out bool isValid)
    {
        int value;
        value = int.Parse(_view.ReadLine());
        ValidateValueInRange(minValue, value, maxValue);
        isValid = true;
        return value;
    }

    public override void AnnounceRoundStart(int round, Unit activeUnit, int currentPlayer)
        => _view.WriteLine($"Round {round}: {activeUnit.Name} (Player {currentPlayer + 1}) comienza");

    public override void AnnounceAdvantage(Unit attacker, Unit defender, AdvantageState advantage)
    {
        Weapon attackerWeapon = attacker.Weapon;
        Weapon defenderWeapon = defender.Weapon;
        string message = advantage switch
        {
            AdvantageState.Advantage =>
                $"{attacker.Name} ({attackerWeapon.Name}) tiene ventaja con respecto a " +
                $"{defender.Name} ({defenderWeapon.Name})",
            AdvantageState.Disadvantage =>
                $"{defender.Name} ({defenderWeapon.Name}) tiene ventaja con respecto a " +
                $"{attacker.Name} ({attackerWeapon.Name})",
            AdvantageState.Neutral => "Ninguna unidad tiene ventaja con respecto a la otra",
            _ => "Estado de ventaja desconocido"
        };
        _view.WriteLine(message);
    }

    public override void AnnounceAttack(Unit attacker, Unit defender, int damage)
        => _view.WriteLine($"{attacker.Name} ataca a {defender.Name} con {damage} de daño");

    public override void AnnounceCounterattack(Unit defender, Unit attacker, int damage)
        => _view.WriteLine($"{defender.Name} ataca a {attacker.Name} con {damage} de daño");

    public override void AnnounceWinner(int winnerTeamNumber)
        => _view.WriteLine($"Player {winnerTeamNumber} ganó");

    private void ValidateValueInRange(int minValue, int value, int maxValue)
    {
        if (value < minValue || value > maxValue)
        {
            throw new MenuOptionValueOutOfRangeException(minValue, maxValue, value);
        }
    }

    public override void AnnounceMessageForInvalidTeam()
        => _view.WriteLine("Archivo de equipos no válido");

    public override void AnnounceMessageForNoFollowUpAttack()
        => _view.WriteLine("Ninguna unidad puede hacer un follow up");

    public override void AnnounceMessageForNoFollowUpAttackDueNullifiedCounterattack(Unit unit)
        => _view.WriteLine($"{unit.Name} no puede hacer un follow up");

    public override void AnnounceAttackerBonusEffect(Unit unit)
    {
        AnnounceIfPositiveBonus(unit);
        AnnounceIfPositiveFirstAttackBonus(unit);
    }

    public override void AnnounceDefenderBonusEffect(Unit rival)
    {
        AnnounceIfPositiveBonus(rival);
        AnnounceIfPositiveFirstAttackBonus(rival);
    }

    private void AnnounceIfPositiveBonus(Unit unit)
    {
        if (unit.AtkBonus > 0) AnnounceAtkBonusStat(unit);
        if (unit.SpdBonus > 0) AnnounceSpdBonusStat(unit);
        if (unit.DefBonus > 0) AnnounceDefBonusStat(unit);
        if (unit.ResBonus > 0) AnnounceResBonusStat(unit);
    }

    private void AnnounceAtkBonusStat(Unit unit)
        => _view.WriteLine($"{unit.Name} obtiene Atk+{unit.AtkBonus}");

    private void AnnounceSpdBonusStat(Unit unit)
        => _view.WriteLine($"{unit.Name} obtiene Spd+{unit.SpdBonus}");

    private void AnnounceDefBonusStat(Unit unit)
        => _view.WriteLine($"{unit.Name} obtiene Def+{unit.DefBonus}");

    private void AnnounceResBonusStat(Unit unit)
        => _view.WriteLine($"{unit.Name} obtiene Res+{unit.ResBonus}");

    private void AnnounceIfPositiveFirstAttackBonus(Unit unit)
    {
        if (unit.FirstAttackAtkBonus > 0) AnnounceFirstAttackAtkBonusStat(unit);
        if (unit.FirstAttackDefBonus > 0) AnnounceFirstAttackDefBonusStat(unit);
        if (unit.FirstAttackResBonus > 0) AnnounceFirstAttackResBonusStat(unit);
    }

    private void AnnounceFirstAttackAtkBonusStat(Unit unit)
        => _view.WriteLine($"{unit.Name} obtiene Atk+{unit.FirstAttackAtkBonus} en su primer ataque");

    private void AnnounceFirstAttackDefBonusStat(Unit unit)
        => _view.WriteLine($"{unit.Name} obtiene Def+{unit.FirstAttackDefBonus} en su primer ataque");

    private void AnnounceFirstAttackResBonusStat(Unit unit)
        => _view.WriteLine($"{unit.Name} obtiene Res+{unit.FirstAttackResBonus} en su primer ataque");


    public override void AnnounceAttackerPenaltyEffect(Unit unit)
    {
        AnnounceIfPositivePenalty(unit);
        AnnounceIfPositiveFirstAttackPenalty(unit);
    }

    public override void AnnounceDefenderPenaltyEffect(Unit rival)
    {
        AnnounceIfPositivePenalty(rival);
        AnnounceIfPositiveFirstAttackPenalty(rival);
    }

    private void AnnounceIfPositivePenalty(Unit unit)
    {
        if (unit.AtkPenalty > 0) AnnounceAtkPenaltyStat(unit);
        if (unit.SpdPenalty > 0) AnnounceSpdPenaltyStat(unit);
        if (unit.DefPenalty > 0) AnnounceDefPenaltyStat(unit);
        if (unit.ResPenalty > 0) AnnounceResPenaltyStat(unit);
    }

    private void AnnounceAtkPenaltyStat(Unit unit)
        => _view.WriteLine($"{unit.Name} obtiene Atk-{unit.AtkPenalty}");

    private void AnnounceSpdPenaltyStat(Unit unit)
        => _view.WriteLine($"{unit.Name} obtiene Spd-{unit.SpdPenalty}");

    private void AnnounceDefPenaltyStat(Unit unit)
        => _view.WriteLine($"{unit.Name} obtiene Def-{unit.DefPenalty}");

    private void AnnounceResPenaltyStat(Unit unit)
        => _view.WriteLine($"{unit.Name} obtiene Res-{unit.ResPenalty}");

    private void AnnounceIfPositiveFirstAttackPenalty(Unit unit)
    {
        if (unit.FirstAttackAtkPenalty > 0) AnnounceFirstAttackAtkPenaltyStat(unit);
        if (unit.FirstAttackDefPenalty > 0) AnnounceFirstAttackDefPenaltyStat(unit);
        if (unit.FirstAttackResPenalty > 0) AnnounceFirstAttackResPenaltyStat(unit);
    }

    private void AnnounceFirstAttackAtkPenaltyStat(Unit unit)
        => _view.WriteLine($"{unit.Name} obtiene Atk-{unit.FirstAttackAtkPenalty} en su primer ataque");

    private void AnnounceFirstAttackDefPenaltyStat(Unit unit)
        => _view.WriteLine($"{unit.Name} obtiene Def-{unit.FirstAttackDefPenalty} en su primer ataque");

    private void AnnounceFirstAttackResPenaltyStat(Unit unit)
        => _view.WriteLine($"{unit.Name} obtiene Res-{unit.FirstAttackResPenalty} en su primer ataque");

    public override void AnnounceNeutralizationBonusEffect(Unit unit)
        => AnnounceBonusNeutralizationStat(unit);

    private void AnnounceBonusNeutralizationStat(Unit unit)
    {
        EffectCollection effects = unit.Effects;
        if (effects.HasActiveNeutralizationBonus(StatType.Atk)) AnnounceNeutralizationAtkBonusStat(unit);
        if (effects.HasActiveNeutralizationBonus(StatType.Spd)) AnnounceNeutralizationSpdBonusStat(unit);
        if (effects.HasActiveNeutralizationBonus(StatType.Def)) AnnounceNeutralizationDefBonusStat(unit);
        if (effects.HasActiveNeutralizationBonus(StatType.Res)) AnnounceNeutralizationResBonusStat(unit);
    }

    private void AnnounceNeutralizationAtkBonusStat(Unit unit)
        => _view.WriteLine($"Los bonus de Atk de {unit.Name} fueron neutralizados");

    private void AnnounceNeutralizationSpdBonusStat(Unit unit)
        => _view.WriteLine($"Los bonus de Spd de {unit.Name} fueron neutralizados");

    private void AnnounceNeutralizationDefBonusStat(Unit unit)
        => _view.WriteLine($"Los bonus de Def de {unit.Name} fueron neutralizados");

    private void AnnounceNeutralizationResBonusStat(Unit unit)
        => _view.WriteLine($"Los bonus de Res de {unit.Name} fueron neutralizados");

    public override void AnnounceNeutralizationPenaltyEffect(Unit unit)
        => AnnouncePenaltyNeutralizationStat(unit);

    private void AnnouncePenaltyNeutralizationStat(Unit unit)
    {
        EffectCollection effects = unit.Effects;
        if (effects.HasActiveNeutralizationPenalty(StatType.Atk)) AnnounceNeutralizationAtkPenaltyStat(unit);
        if (effects.HasActiveNeutralizationPenalty(StatType.Spd)) AnnounceNeutralizationSpdPenaltyStat(unit);
        if (effects.HasActiveNeutralizationPenalty(StatType.Def)) AnnounceNeutralizationDefPenaltyStat(unit);
        if (effects.HasActiveNeutralizationPenalty(StatType.Res)) AnnounceNeutralizationResPenaltyStat(unit);
    }


    public override void AnnounceFollowUpGuarantee(Unit unit)
        => AnnounceFollowUpGuaranteeEffect(unit);

    private void AnnounceFollowUpGuaranteeEffect(Unit unit)
    {
        if (unit.HasFollowUpGuaranteed)
            _view.WriteLine($"{unit.Name} tiene {unit.QuantityOfActiveGuaranteeFollowUpEffects} efecto(s)" +
                            $" que garantiza(n) su follow up activo(s)");
    }

    public override void AnnounceDenialFollowUp(Unit unit)
        => AnnounceDenialFollowUpEffect(unit);

    private void AnnounceDenialFollowUpEffect(Unit unit)
    {
        if (unit.HasDenialFollowUp)
            _view.WriteLine($"{unit.Name} tiene {unit.QuantityOfActiveDenialFollowUpEffects} efecto(s)" +
                            $" que neutraliza(n) su follow up activo(s)");
    }

    public override void AnnounceDenialFollowUpGuaranteed(Unit unit)
        => AnnounceDenialFollowUpGuaranteedEffect(unit);

    private void AnnounceDenialFollowUpGuaranteedEffect(Unit unit)
    {
        if (unit.HasDenialFollowUpGuaranteed)
            _view.WriteLine($"{unit.Name} es inmune a los efectos que garantizan su follow up");
    }

    public override void AnnounceDenialOfDenialFollowUp(Unit unit)
        => AnnounceDenialOfDenialFollowUpEffect(unit);

    private void AnnounceDenialOfDenialFollowUpEffect(Unit unit)
    {
        if (unit.HasDenialOfDenialFollowUp)
            _view.WriteLine($"{unit.Name} es inmune a los efectos que neutralizan su follow up");

    }

    private void AnnounceNeutralizationAtkPenaltyStat(Unit unit)
        => _view.WriteLine($"Los penalty de Atk de {unit.Name} fueron neutralizados");

    private void AnnounceNeutralizationSpdPenaltyStat(Unit unit)
        => _view.WriteLine($"Los penalty de Spd de {unit.Name} fueron neutralizados");

    private void AnnounceNeutralizationDefPenaltyStat(Unit unit)
        => _view.WriteLine($"Los penalty de Def de {unit.Name} fueron neutralizados");

    private void AnnounceNeutralizationResPenaltyStat(Unit unit)
        => _view.WriteLine($"Los penalty de Res de {unit.Name} fueron neutralizados");

    public override void AnnounceExtraDamage(Unit unit)
        => AnnounceIfActiveExtraDamageEffect(unit);

    private void AnnounceIfActiveExtraDamageEffect(Unit unit)
    {
        if (unit.ExtraDamage > 0) AnnounceExtraDamageInEachAttack(unit);
        if (unit.FirstAttackExtraDamage > 0) AnnounceExtraDamageInFirstAttack(unit);
    }

    private void AnnounceExtraDamageInEachAttack(Unit unit)
    {
        if (unit.ExtraDamage > 0)
            _view.WriteLine($"{unit.Name} realizará +{unit.ExtraDamage} daño extra en cada ataque");
    }

    private void AnnounceExtraDamageInFirstAttack(Unit unit)
    {
        if (unit.FirstAttackExtraDamage > 0)
            _view.WriteLine($"{unit.Name} realizará +{unit.FirstAttackExtraDamage} " +
                            $"daño extra en su primer ataque");
    }

    public override void AnnounceAbsoluteDamageReduction(Unit unit)
        => AnnounceAbsoluteDamageReductionEffect(unit);

    private void AnnounceAbsoluteDamageReductionEffect(Unit unit)
    {
        if (unit.AbsoluteDamageReduction > 0) AnnounceAbsoluteDamageReductionInEachAttack(unit);
    }

    private void AnnounceAbsoluteDamageReductionInEachAttack(Unit unit)
        => _view.WriteLine($"{unit.Name} recibirá -{unit.AbsoluteDamageReduction} daño en cada ataque");


    public override void AnnouncePercentageReductionEffect(Unit unit)
    {
        AnnounceEachAttackPercentageReductionEffect(unit);
        AnnounceFirstAttackPercentageReductionEffect(unit);
        AnnounceFollowUpPercentageReductionEffect(unit);
    }

    private void AnnounceEachAttackPercentageReductionEffect(Unit unit)
    {
        if (unit.PercentageDamageReduction > 0) AnnounceEachAttackPercentageDamageReduction(unit);
    }

    private void AnnounceEachAttackPercentageDamageReduction(Unit unit)
    {
        double roundedReduction = Math.Round(unit.PercentageDamageReduction, 2);
        int percentage = Convert.ToInt32(Math.Floor(roundedReduction * 100));
        if (percentage > 0)
            _view.WriteLine($"{unit.Name} reducirá el daño de los ataques del rival en un {percentage}%");
    }

    private void AnnounceFirstAttackPercentageReductionEffect(Unit unit)
    {
        if (unit.FirstAttackPercentageDamageReduction > 0)
            AnnounceFirstAttackPercentageDamageReduction(unit);
    }

    private void AnnounceFirstAttackPercentageDamageReduction(Unit unit)
    {
        double roundedReduction = Math.Round(unit.FirstAttackPercentageDamageReduction, 2);
        int percentage = Convert.ToInt32(Math.Floor(roundedReduction * 100));
        if (percentage > 0)
            _view.WriteLine($"{unit.Name} reducirá el daño del primer ataque del rival en un {percentage}%");
    }

    private void AnnounceFollowUpPercentageReductionEffect(Unit unit)
    {
        if (unit.FollowUpPercentageDamageReduction > 0)
            AnnounceFollowUpPercentageDamageReduction(unit);
    }

    private void AnnounceFollowUpPercentageDamageReduction(Unit unit)
    {
        double roundedReduction = Math.Round(unit.FollowUpPercentageDamageReduction, 2);
        int percentage = Convert.ToInt32(Math.Floor(roundedReduction * 100));
        if (percentage > 0)
            _view.WriteLine($"{unit.Name} reducirá el daño del Follow-Up del rival en un {percentage}%");
    }

    public override void AnnounceHealingEffect(Unit unit)
        => AnnounceHealing(unit);

    private void AnnounceHealing(Unit unit)
    {
        if (unit.HealingPercentage > 0)
            AnnounceHealingPercentage(unit);
    }

    private void AnnounceHealingPercentage(Unit unit)
    {
        double roundedHealing = Math.Round(unit.HealingPercentage, 2);
        int percentage = Convert.ToInt32(Math.Floor(roundedHealing * 100));
        if (percentage > 0)
            _view.WriteLine($"{unit.Name} recuperará HP igual al {percentage}% " +
                            $"del daño realizado en cada ataque");
    }

    public override void AnnounceHpHealing(Unit unit, int healingAmount)
        => _view.WriteLine($"{unit.Name} recupera {healingAmount} HP luego de atacar y " +
                           $"queda con {unit.CurrentHP} HP.");

    public override void AnnounceHpHealingInEachAttack(Unit unit)
    {
        double unitHealingPercentage = unit.HealingPercentage;
        int finalDamage = unit.FinalCausedDamage;
        int healingAmount = Convert.ToInt32(Math.Floor(finalDamage * unitHealingPercentage));
        if (healingAmount > 0)
            _view.WriteLine($"{unit.Name} recupera {healingAmount} HP luego de atacar y " +
                            $"queda con {unit.CurrentHP} HP.");
    }

    public override void AnnounceCounterattackDenialEffect(Unit unit)
        => AnnounceCounterattackDenial(unit);

    private void AnnounceCounterattackDenial(Unit unit)
    {
        if (unit.HasNullifiedCounterattack && !unit.HasNullifiedNullifiedCounterattack)
            _view.WriteLine($"{unit.Name} no podrá contraatacar");
    }

    public override void AnnounceCounterattackDenialDenialEffect(Unit unit)
        => AnnounceCounterattackDenialDenial(unit);

    private void AnnounceCounterattackDenialDenial(Unit unit)
    {
        if (unit.HasNullifiedNullifiedCounterattack && unit.HasNullifiedCounterattack)
            _view.WriteLine($"{unit.Name} neutraliza los efectos que previenen sus contraataques");
    }

    public override void AnnounceDamageOutOfCombatEffect(Unit unit)
        => AnnounceDamageOutOfCombat(unit);


    private void AnnounceDamageOutOfCombat(Unit unit)
    {
        if (unit.StatAfterCombat < 0)
            _view.WriteLine($"{unit.Name} recibe {Math.Abs(unit.StatAfterCombat)} de daño " +
                            $"despues del combate");
        if (unit.StatAfterCombat > 0)
            _view.WriteLine($"{unit.Name} recupera {unit.StatAfterCombat} HP despues del combate");
    }

    public override void AnnounceDamageBeforeCombatEffect(Unit unit)
        => AnnounceDamageBeforeCombat(unit);

    private void AnnounceDamageBeforeCombat(Unit unit)
    {
        if (unit.DamageBeforeCombat > 0)
        {
            _view.WriteLine($"{unit.Name} recibe {Math.Abs(unit.DamageBeforeCombat)} de daño " +
                            $"antes de iniciar el combate y queda con {unit.CurrentHP} HP");
        }
    }
}
