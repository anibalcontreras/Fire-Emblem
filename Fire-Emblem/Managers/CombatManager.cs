using Fire_Emblem.Damage;
using Fire_Emblem.Teams;
using Fire_Emblem.Units;
using Fire_Emblem.Views;
using Fire_Emblem.Weapons;

namespace Fire_Emblem.Managers;
public class CombatManager
{
    private readonly ConsoleGameView _consoleGameView;
    private readonly SkillManager _skillManager;

    public CombatManager(ConsoleGameView consoleGameView)
    {
        _consoleGameView = consoleGameView;
        _skillManager = new SkillManager(consoleGameView);
    }

    public Combat ConductCombat(List<Team> teams, int round, int currentPlayer)
    {
        Combat combat = CreateCombat(teams, currentPlayer);
        combat.Attacker.SetIsAttacker();
        combat.Defender.SetIsDefender();
        _consoleGameView.AnnounceRoundStart(round, combat.Attacker, currentPlayer);
        AnnounceWeaponAdvantage(combat);
        ActivateSkills(combat);
        ExecuteCombatProcess(combat);
        return combat;
    }
    
    private Combat CreateCombat(List<Team> teams, int currentPlayer)
    {
        Team activeTeam = teams[currentPlayer];
        Team opponentTeam = teams[(currentPlayer + 1) % 2];
        Unit attacker = _consoleGameView.SelectUnit(activeTeam, currentPlayer + 1);
        Unit defender = _consoleGameView.SelectUnit(opponentTeam, (currentPlayer + 1) % 2 + 1);
        Combat combat = new Combat(activeTeam, opponentTeam, attacker, defender);
        return combat;
    }
    
    private void AnnounceWeaponAdvantage(Combat combat)
    {
        AdvantageState weaponAdvantage = combat.Attacker.Weapon.CalculateAdvantage(combat.Defender);
        _consoleGameView.AnnounceAdvantage(combat.Attacker, combat.Defender, weaponAdvantage);
    }
    
    private void ActivateSkills(Combat combat)
    {
        _skillManager.ActivateSkills(combat);
    }
    
    private void ExecuteCombatProcess(Combat combat)
    {
    if (HandleAttack(combat)) return;
    if (HandleCounterattack(combat)) return;
    HandleFollowUp(combat);
    EndCombat(combat);
    }
    

    private bool HandleAttack(Combat combat)
    {
        PerformAttack(combat);
        if (combat.Defender.CurrentHP <= 0)
        {
            _consoleGameView.ShowCurrentHealth(combat.Attacker, combat.Defender);
            DeactivateSkills(combat);
            return true;
        }
        return false;
    }
    
    private void PerformAttack(Combat combat)
    {
        int damage = CalculateFirstAttackDamage(combat.Attacker, combat.Defender);
        combat.Attacker.ResetFirstAttackEffectsStats();
        combat.Defender.ResetFirstAttackPenaltyStats();
        _consoleGameView.AnnounceAttack(combat.Attacker, combat.Defender, damage);
    }
    
    
    private bool HandleCounterattack(Combat combat)
    {
        PerformCounterattack(combat);
        if (combat.Attacker.CurrentHP <= 0)
        {
            _consoleGameView.ShowCurrentHealth(combat.Attacker, combat.Defender);
            DeactivateSkills(combat);
            return true;
        }
        return false;
    }
    
    private void PerformCounterattack(Combat combat)
    {
        
        int damage = CalculateFirstAttackDamage(combat.Defender, combat.Attacker);
        combat.Defender.ResetFirstAttackEffectsStats();
        combat.Attacker.ResetFirstAttackPenaltyStats();
        _consoleGameView.AnnounceCounterattack(combat.Defender, combat.Attacker, damage);
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
    
    private void DeactivateSkills(Combat combat)
    {
        Unit attacker = combat.Attacker;
        Unit defender = combat.Defender;
        
        attacker.ResetEffects();
        defender.ResetEffects();
        attacker.ResetFirstAttackEffectsStats();
        defender.ResetFirstAttackEffectsStats();
        attacker.ResetFirstAttackPenaltyStats();
        defender.ResetFirstAttackPenaltyStats();
        attacker.ClearActiveEffects();
        defender.ClearActiveEffects();
        attacker.SetLastUnitFaced(defender);
        defender.SetLastUnitFaced(attacker);
        attacker.SetHasBeenAttackerBefore();
        defender.SetHasBeenDefenderBefore();
        attacker.ResetIsAttacker();
        defender.ResetIsDefender();
    }
    
    private void HandleFollowUp(Combat combat)
    {
        // combat.UpdateState(CombatState.FollowUp);
        if (combat.CanAttackerPerformFollowUp())
            PerformAttackerFollowUp(combat);
        else if (combat.CanDefenderPerformFollowUp())
            PerformDefenderFollowUp(combat);
        else
            _consoleGameView.ShowMessageForNoFollowUpAttack();
    }
    
    private void PerformAttackerFollowUp(Combat combat)
    {
        int damage = CalculateFollowUpDamage(combat.Attacker, combat.Defender);
        _consoleGameView.AnnounceAttack(combat.Attacker, combat.Defender, damage);
        combat.Attacker.ResetFollowUpStats();
    }
    
    private void PerformDefenderFollowUp(Combat combat)
    {
        int damage = CalculateFollowUpDamage(combat.Defender, combat.Attacker);
        _consoleGameView.AnnounceCounterattack(combat.Defender, combat.Attacker, damage);
        combat.Defender.ResetFollowUpStats();
    }
    
    private void EndCombat(Combat combat)
    {
        _consoleGameView.ShowCurrentHealth(combat.Attacker, combat.Defender); 
        DeactivateSkills(combat);
    }
}
