using Fire_Emblem.Teams;
using Fire_Emblem.Views;
using Fire_Emblem.Damage;
using Fire_Emblem.Effects;
using Fire_Emblem.Units;
using Fire_Emblem.Weapons;

namespace Fire_Emblem.Controllers;
public class CombatController
{
    private readonly IView _view;
    private readonly SkillController _skillController;
    private readonly FollowUpController _followUpController;

    public CombatController(IView view)
    {
        _view = view;
        _skillController = new SkillController(view);
        _followUpController = new FollowUpController(view);
    }
    
    public Combat ConductCombat(TeamCollection teams, int round, int currentPlayer)
    {
        Combat combat = CreateCombat(teams, currentPlayer);
        Unit attacker = combat.Attacker;
        Unit defender = combat.Defender;
        _view.AnnounceRoundStart(round, attacker, currentPlayer);
        AnnounceWeaponAdvantage(combat);
        ActivateSkills(combat);
        ExecuteCombatProcess(attacker, defender, combat);
        return combat;
    }

    private Combat CreateCombat(TeamCollection teams, int currentPlayer)
    {
        List<Team> teamList = teams.GetTeams();
        Team activeTeam = teamList[currentPlayer];
        Team opponentTeam = teamList[(currentPlayer + 1) % 2];
        int attackerPlayerNumber = currentPlayer + 1;
        int defenderPlayerNumber = (currentPlayer + 1) % 2 + 1;
        Unit attacker = _view.SelectUnit(activeTeam, attackerPlayerNumber);
        Unit defender = _view.SelectUnit(opponentTeam, defenderPlayerNumber);
        activeTeam.AddAllies(attacker);
        opponentTeam.AddAllies(defender);
        SetBeforeCombatStats(attacker, defender);
        Combat combat = new Combat(attacker, defender);
        return combat;
    }

    private static void SetBeforeCombatStats(Unit attacker, Unit defender)
    {
        attacker.SetStartOfCombatHp();
        defender.SetStartOfCombatHp();
        attacker.SetIsAttacker();
    }

    private void AnnounceWeaponAdvantage(Combat combat)
    {
        Unit attacker = combat.Attacker;
        Unit defender = combat.Defender;
        Weapon selectedWeapon = attacker.Weapon;
        AdvantageState weaponAdvantage = selectedWeapon.CalculateAdvantage(defender);
        _view.AnnounceAdvantage(attacker, defender, weaponAdvantage);
    }

    private void ActivateSkills(Combat combat)
        => _skillController.ActivateSkills(combat);

    private void ExecuteCombatProcess(Unit attacker, Unit defender, Combat combat)
    {
        if (HasAttackerCompleteTheAttack(attacker, defender)) return;
        if (HasDefenderCompleteCounterAttack(attacker, defender)) return;
        _followUpController.HandleFollowUp(combat);
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
        _view.AnnounceAttack(attacker, defender, damage);
        _view.AnnounceHpHealingInEachAttack(attacker);
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
            return;
        int damage = CalculateFirstAttackDamage(defender, attacker);
        defender.SetUnitExecuteAStrike();
        _view.AnnounceCounterattack(defender, attacker, damage);
        _view.AnnounceHpHealingInEachAttack(defender);
    }
    
    private int CalculateFirstAttackDamage(Unit attacker, Unit defender)
    {
        FirstAttackDamage damage = new FirstAttackDamage(attacker, defender);
        return damage.CalculateDamage();
    }
    
    private void EndCombat(Unit attacker, Unit defender)
        => ManageEndOfCombat(attacker, defender);

    private void ManageEndOfCombat(Unit attacker, Unit defender)
    { 
        _skillController.ActivateAfterCombatSkills(attacker, defender);
        _view.AnnounceCurrentHealth(attacker, defender);
        attacker.SetLastUnitFaced(defender);
        defender.SetLastUnitFaced(attacker);
        ClearUnitsEffects(attacker, defender);
        DeactivateAttackerSkills(attacker);
        DeactivateDefenderSkills(defender);
    }
    
    private void ClearUnitsEffects(Unit attacker, Unit defender)
    {
        EffectsList attackerEffects = attacker.Effects;
        EffectsList defenderEffects = defender.Effects;
        attackerEffects.ClearEffects();
        defenderEffects.ClearEffects();
    }
    
    private void DeactivateAttackerSkills(Unit attacker)
    {
        attacker.ResetStatEffects();
        attacker.SetHasBeenAttackerBefore();
        attacker.ResetGameConditions();
        attacker.ResetIsAttacker();
    }

    private void DeactivateDefenderSkills(Unit defender)
    {
        defender.ResetStatEffects();
        defender.SetHasBeenDefenderBefore();
        defender.ResetGameConditions();
    }
}
