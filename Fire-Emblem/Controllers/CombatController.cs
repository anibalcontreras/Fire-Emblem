using Fire_Emblem.Combats.Damage;
using Fire_Emblem.Combats.Teams;
using Fire_Emblem.Combats.Units;
using Fire_Emblem.Combats.Views;
using Fire_Emblem.Combats.Weapons;

namespace Fire_Emblem.Combats.Controllers;
public class CombatController
{
    private readonly ConsoleGameView _consoleGameView;
    private readonly SkillController _skillController;

    public CombatController(ConsoleGameView consoleGameView)
    {
        _consoleGameView = consoleGameView;
        _skillController = new SkillController(consoleGameView);
    }

    public Combat ConductCombat(List<Team> teams, int round, int currentPlayer)
    {
        Combat combat = CreateCombat(teams, currentPlayer);
        Unit attacker = combat.Attacker;
        Unit defender = combat.Defender;
        attacker.SetIsAttacker();
        _consoleGameView.AnnounceRoundStart(round, attacker, currentPlayer);
        AnnounceWeaponAdvantage(combat);
        ActivateSkills(combat);
        ExecuteCombatProcess(attacker,defender, combat);
        return combat;
    }
    
    private Combat CreateCombat(List<Team> teams, int currentPlayer)
    {
        Team activeTeam = teams[currentPlayer];
        Team opponentTeam = teams[(currentPlayer + 1) % 2];
        int attackerPlayerNumber = currentPlayer + 1;
        int defenderPlayerNumber = (currentPlayer + 1) % 2 + 1;
        Unit attacker = _consoleGameView.SelectUnit(activeTeam, attackerPlayerNumber);
        Unit defender = _consoleGameView.SelectUnit(opponentTeam, defenderPlayerNumber);
        Combat combat = new Combat(attacker, defender);
        return combat;
    }
    
    private void AnnounceWeaponAdvantage(Combat combat)
    {
        Unit attacker = combat.Attacker;
        Unit defender = combat.Defender;
        Weapon selectedWeapon = attacker.Weapon;
        AdvantageState weaponAdvantage = selectedWeapon.CalculateAdvantage(defender);
        _consoleGameView.AnnounceAdvantage(attacker, defender, weaponAdvantage);
    }
    
    private void ActivateSkills(Combat combat)
        => _skillController.ActivateSkills(combat);
    
    private void ExecuteCombatProcess(Unit attacker, Unit defender, Combat combat)
    {
        if (HandleAttack(attacker, defender)) return;
        if (HandleCounterattack(attacker, defender)) return;
        HandleFollowUp(combat);
        EndCombat(attacker, defender);
    }

    private bool HandleAttack(Unit attacker, Unit defender)
    {
        PerformAttack(attacker, defender);
        if (defender.CurrentHP <= 0)
        {
            _consoleGameView.ShowCurrentHealth(attacker, defender);
            DeactivateSkills(attacker, defender);
            return true;
        }
        return false;
    }
    
    private void PerformAttack(Unit attacker, Unit defender)
    {
        int damage = CalculateFirstAttackDamage(attacker, defender);
        attacker.ResetFirstAttackBonusStats();
        defender.ResetFirstAttackPenaltyStats();
        _consoleGameView.AnnounceAttack(attacker, defender, damage);
    }
    
    
    private bool HandleCounterattack(Unit attacker, Unit defender)
    {
        PerformCounterattack(attacker, defender);
        if (attacker.CurrentHP <= 0)
        {
            _consoleGameView.ShowCurrentHealth(attacker, defender);
            DeactivateSkills(attacker, defender);
            return true;
        }
        return false;
    }
    
    private void PerformCounterattack(Unit attacker, Unit defender)
    {
        int damage = CalculateFirstAttackDamage(defender, attacker);
        defender.ResetFirstAttackBonusStats();
        attacker.ResetFirstAttackPenaltyStats();
        _consoleGameView.AnnounceCounterattack(defender, attacker, damage);
    }
    
    private int CalculateFirstAttackDamage(Unit attacker, Unit defender)
    {
        FirstAttackDamage damage = new FirstAttackDamage(attacker, defender);
        return damage.CalculateDamage();
    }

    private int CalculateFollowUpDamage(Unit attacker, Unit defender)
    {
        FollowUpDamage damage = new FollowUpDamage(attacker, defender);
        return damage.CalculateDamage();
    }
    
    private void HandleFollowUp(Combat combat)
    {
        if (combat.CanAttackerPerformFollowUp())
            PerformAttackerFollowUp(combat.Attacker, combat.Defender);
        else if (combat.CanDefenderPerformFollowUp())
            PerformDefenderFollowUp(combat.Attacker, combat.Defender);
        else
            _consoleGameView.ShowMessageForNoFollowUpAttack();
    }
    
    private void PerformAttackerFollowUp(Unit attacker, Unit defender)
    {
        int damage = CalculateFollowUpDamage(attacker, defender);
        _consoleGameView.AnnounceAttack(attacker, defender, damage);
        attacker.ResetFollowUpStats();
    }
    
    private void PerformDefenderFollowUp(Unit attacker, Unit defender)
    {
        int damage = CalculateFollowUpDamage(defender, attacker);
        _consoleGameView.AnnounceCounterattack(defender, attacker, damage);
        defender.ResetFollowUpStats();
    }
    
    private void EndCombat(Unit attacker, Unit defender)
    {
        _consoleGameView.ShowCurrentHealth(attacker, defender); 
        DeactivateSkills(attacker, defender);
    }
    
    private void DeactivateSkills(Unit attacker, Unit defender)
    {
        attacker.SetLastUnitFaced(defender);
        defender.SetLastUnitFaced(attacker);
        DeactivateAttackerSkills(attacker);
        DeactivateDefenderSkills(defender);
    }

    private void DeactivateAttackerSkills(Unit attacker)
    {
        attacker.ResetEffects();
        attacker.ResetFirstAttackBonusStats();
        attacker.ResetFirstAttackPenaltyStats();
        attacker.ClearActiveEffects();
        attacker.SetHasBeenAttackerBefore();
        attacker.ResetIsAttacker();
    }

    private void DeactivateDefenderSkills(Unit defender)
    {
        defender.ResetEffects();
        defender.ResetFirstAttackBonusStats();
        defender.ResetFirstAttackPenaltyStats();
        defender.ClearActiveEffects();
        defender.SetHasBeenDefenderBefore();
    }
}
