using Fire_Emblem.Damage;
using Fire_Emblem.Teams;
using Fire_Emblem.Units;
using Fire_Emblem.Views;
using Fire_Emblem.Weapons;

namespace Fire_Emblem.Controllers;
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
        attacker.SetIsAttacker();
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
        if (HasAttackerCompleteTheAttack(attacker, defender)) return;
        if (HasDefenderCompleteCounterAttack(attacker, defender)) return;
        HandleFollowUp(combat);
        EndCombat(attacker, defender);
    }
    
    private bool HasAttackerCompleteTheAttack(Unit attacker, Unit defender)
    {
        PerformAttack(attacker, defender);
        return CheckIfUnitDefeated(attacker, defender, defender);
    }
    
    private void PerformAttack(Unit attacker, Unit defender)
    {
        int damage = CalculateFirstAttackDamage(attacker, defender);
        attacker.SetUnitExecuteAStrike();
        attacker.ResetFirstAttackBonusStats();
        defender.ResetFirstAttackPenaltyStats();
        _consoleGameView.AnnounceAttack(attacker, defender, damage);
        _consoleGameView.AnnounceHpHealingInEachAttack(attacker);
    }
    
    private bool CheckIfUnitDefeated(Unit attacker, Unit defender, Unit unitToCheck)
    {
        if (unitToCheck.CurrentHP <= 0)
        {
            ManageEndOfCombat(attacker, defender);
            return true;
        }
        return false;
    }
    
    private bool HasDefenderCompleteCounterAttack(Unit attacker, Unit defender)
    {
        PerformCounterAttack(attacker, defender);
        return CheckIfUnitDefeated(attacker, defender, attacker);
    }
    
    private void PerformCounterAttack(Unit attacker, Unit defender)
    {
        if (defender.HasNullifiedCounterattack && !defender.HasNullifiedNullifiedCounterattack)
        {
            defender.ResetFirstAttackBonusStats();
            attacker.ResetFirstAttackPenaltyStats();
            return;
        }
        int damage = CalculateFirstAttackDamage(defender, attacker);
        defender.SetUnitExecuteAStrike();
        _consoleGameView.AnnounceCounterattack(defender, attacker, damage);
        _consoleGameView.AnnounceHpHealingInEachAttack(defender);
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
        {
            if (combat.Defender.HasNullifiedCounterattack)
                _consoleGameView.ShowMessageForNoFollowUpAttackDueNullifiedCounterattack(combat.Attacker);
            else
                _consoleGameView.ShowMessageForNoFollowUpAttack();
        }
            
    }
    
    private void PerformAttackerFollowUp(Unit attacker, Unit defender)
    {
        int damage = CalculateFollowUpDamage(attacker, defender);
        attacker.SetUnitExecuteAStrike();
        _consoleGameView.AnnounceAttack(attacker, defender, damage);
        _consoleGameView.AnnounceHpHealingInEachAttack(attacker);
        attacker.ResetFollowUpStats();
    }
    
    private void PerformDefenderFollowUp(Unit attacker, Unit defender)
    {
        if (defender.HasNullifiedCounterattack && !defender.HasNullifiedNullifiedCounterattack)
        {
            _consoleGameView.ShowMessageForNoFollowUpAttackDueNullifiedCounterattack(attacker);
            defender.ResetFollowUpStats();
            return;
        }
        int damage = CalculateFollowUpDamage(defender, attacker);
        defender.SetUnitExecuteAStrike();
        _consoleGameView.AnnounceCounterattack(defender, attacker, damage);
        _consoleGameView.AnnounceHpHealingInEachAttack(defender);
        defender.ResetFollowUpStats();
    }
    
    private void EndCombat(Unit attacker, Unit defender)
    {
        ManageEndOfCombat(attacker, defender);
    }
    
    private void ManageEndOfCombat(Unit attacker, Unit defender)
    {
        _skillController.ActivateAfterCombatSkills(attacker, defender);
        attacker.SetLastUnitFaced(defender);
        defender.SetLastUnitFaced(attacker);
        DeactivateAttackerSkills(attacker);
        DeactivateDefenderSkills(defender);
        _consoleGameView.ShowCurrentHealth(attacker, defender);
    }

    private void DeactivateAttackerSkills(Unit attacker)
    {
        attacker.ResetEffects();
        attacker.ResetFirstAttackBonusStats();
        attacker.ResetFirstAttackPenaltyStats();
        attacker.ClearActiveEffects();
        attacker.SetHasBeenAttackerBefore();
        attacker.ResetIsAttacker();
        attacker.ResetNullifyCounterattack();
        attacker.ResetNullifyNullifiedCounterattack();
        attacker.ResetFinalCausedDamage();
        attacker.ResetHealingPercentage();
        attacker.ResetUnitExecuteAStrike();
        attacker.ResetDamageOutOfCombat();
    }

    private void DeactivateDefenderSkills(Unit defender)
    {
        defender.ResetEffects();
        defender.ResetFirstAttackBonusStats();
        defender.ResetFirstAttackPenaltyStats();
        defender.ClearActiveEffects();
        defender.SetHasBeenDefenderBefore();
        defender.ResetNullifyCounterattack();
        defender.ResetNullifyNullifiedCounterattack();
        defender.ResetFinalCausedDamage();
        defender.ResetHealingPercentage();
        defender.ResetUnitExecuteAStrike();
        defender.ResetDamageOutOfCombat();
    }
}
