using Fire_Emblem.Damage;
using Fire_Emblem.Teams;
using Fire_Emblem.Units;
using Fire_Emblem.Views;
using Fire_Emblem.Weapons;

namespace Fire_Emblem.Managers;
public class CombatManager
{
    private readonly GameView _gameView;
    private readonly SkillManager _skillManager;

    public CombatManager(GameView gameView)
    {
        _gameView = gameView;
        _skillManager = new SkillManager(gameView);
    }

    public Combat ConductCombat(List<Team> teams, int round, int currentPlayer)
    {
        Combat combat = CreateCombat(teams, currentPlayer);
        combat.UpdateState(CombatState.StartOfCombat);
        combat.Attacker.SetIsAttacker();
        combat.Defender.SetIsDefender();
        _gameView.AnnounceRoundStart(round, combat.Attacker, currentPlayer);
        AnnounceWeaponAdvantage(combat);
        ActivateSkills(combat);
        ExecuteCombatProcess(combat);
        return combat;
    }
    
    private Combat CreateCombat(List<Team> teams, int currentPlayer)
    {
        Team activeTeam = teams[currentPlayer];
        Team opponentTeam = teams[(currentPlayer + 1) % 2];
        Unit attacker = _gameView.SelectUnit(activeTeam, currentPlayer + 1);
        Unit defender = _gameView.SelectUnit(opponentTeam, (currentPlayer + 1) % 2 + 1);
        Combat combat = new Combat(activeTeam, opponentTeam, attacker, defender);
        return combat;
    }
    
    private void AnnounceWeaponAdvantage(Combat combat)
    {
        AdvantageState weaponAdvantage = combat.Attacker.Weapon.CalculateAdvantage(combat.Defender);
        _gameView.AnnounceAdvantage(combat.Attacker, combat.Defender, weaponAdvantage);
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
            _gameView.ShowCurrentHealth(combat.Attacker, combat.Defender);
            combat.UpdateState(CombatState.EndOfCombat);
            DeactivateSkills(combat);
            return true;
        }
        return false;
    }
    
    private void PerformAttack(Combat combat)
    {
        combat.UpdateState(CombatState.UnitAttacks);
        int damage = CalculateFirstAttackDamage(combat.Attacker, combat.Defender);
        combat.Attacker.ResetFirstAttackEffectsStats();
        combat.Defender.ResetFirstAttackPenaltyStats();
        _gameView.AnnounceAttack(combat.Attacker, combat.Defender, damage);
    }
    
    
    private bool HandleCounterattack(Combat combat)
    {
        PerformCounterattack(combat);
        if (combat.Attacker.CurrentHP <= 0)
        {
            _gameView.ShowCurrentHealth(combat.Attacker, combat.Defender);
            combat.UpdateState(CombatState.EndOfCombat);
            DeactivateSkills(combat);
            return true;
        }
        return false;
    }
    
    private void PerformCounterattack(Combat combat)
    {
        combat.UpdateState(CombatState.OpponentCounterattacks);
        int damage = CalculateFirstAttackDamage(combat.Defender, combat.Attacker);
        combat.Defender.ResetFirstAttackEffectsStats();
        combat.Attacker.ResetFirstAttackPenaltyStats();
        _gameView.AnnounceCounterattack(combat.Defender, combat.Attacker, damage);
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
        combat.UpdateState(CombatState.FollowUp);
        if (combat.CanAttackerPerformFollowUp())
            PerformAttackerFollowUp(combat);
        else if (combat.CanDefenderPerformFollowUp())
            PerformDefenderFollowUp(combat);
        else
            _gameView.ShowMessageForNoFollowUpAttack();
    }
    
    private void PerformAttackerFollowUp(Combat combat)
    {
        int damage = CalculateFollowUpDamage(combat.Attacker, combat.Defender);
        _gameView.AnnounceAttack(combat.Attacker, combat.Defender, damage);
        combat.Attacker.ResetFollowUpStats();
    }
    
    private void PerformDefenderFollowUp(Combat combat)
    {
        int damage = CalculateFollowUpDamage(combat.Defender, combat.Attacker);
        _gameView.AnnounceCounterattack(combat.Defender, combat.Attacker, damage);
        combat.Defender.ResetFollowUpStats();
    }
    
    private void EndCombat(Combat combat)
    {
        combat.UpdateState(CombatState.EndOfCombat);
        _gameView.ShowCurrentHealth(combat.Attacker, combat.Defender); 
        DeactivateSkills(combat);
    }
}
