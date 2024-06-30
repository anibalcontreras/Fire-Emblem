using Fire_Emblem.Damage;
using Fire_Emblem.Exception.FollowUpException;
using Fire_Emblem.Stats;
using Fire_Emblem.Units;
using Fire_Emblem.Views;

namespace Fire_Emblem.Controllers;

public class FollowUpController
{
    private readonly int _spdNumberDifference = 5;
    private readonly IView _view;
    
    public FollowUpController(IView view)
    {
        _view = view;
    }
    
    public void HandleFollowUp(Combat combat)
    {
        try
        {
            ProcessFollowUpScenario(combat);
        }
        catch (NoFollowUpAttackDueNullifiedCounterattackException)
        {
            _view.AnnounceMessageForNoFollowUpAttackDueNullifiedCounterattack(combat.Attacker);
        }
        catch (FollowUpException)
        {
            _view.AnnounceMessageForNoFollowUpAttack();
        }
    }

    private void ProcessFollowUpScenario(Combat combat)
    {
        if (CanAnyUnitPerformFollowUp(combat))
            HandleGuaranteedFollowUp(combat);
        else
            HandleNoFollowUpScenario(combat);
    }

    private bool CanAnyUnitPerformFollowUp(Combat combat)
    {
        return CanAttackerPerformFollowUp(combat.Attacker, combat.Defender) || 
               CanDefenderPerformFollowUp(combat.Attacker, combat.Defender);
    }
    
    private bool CanAttackerPerformFollowUp(Unit attacker, Unit defender)
    {
        if (attacker.HasDenialFollowUp && !attacker.HasDenialOfDenialFollowUp)
            return false;
        int attackerCurrentStat = attacker.GetCurrentStat(StatType.Spd);
        int defenderCurrentStat = defender.GetCurrentStat(StatType.Spd);
        return attackerCurrentStat - defenderCurrentStat >= _spdNumberDifference;
    }

    private bool CanDefenderPerformFollowUp(Unit attacker, Unit defender)
    {
        if (defender.HasDenialFollowUp && !defender.HasDenialOfDenialFollowUp)
            return false;
        int defenderCurrentStat = defender.GetCurrentStat(StatType.Spd);
        int attackerCurrentStat = attacker.GetCurrentStat(StatType.Spd);
        return defenderCurrentStat - attackerCurrentStat >= _spdNumberDifference;
    }

    private void HandleGuaranteedFollowUp(Combat combat)
    {
        PerformFirstGroupOfFollowUp(combat);
        PerformSecondGroupOfFollowUp(combat);
    }
    
    private void PerformFirstGroupOfFollowUp(Combat combat)
    {
        if (CanAttackerPerformFollowUp(combat.Attacker, combat.Defender))
            PerformAttackerFollowUp(combat.Attacker, combat.Defender);
        else if (CanDefenderPerformFollowUp(combat.Attacker, combat.Defender))
            PerformDefenderFollowUp(combat.Attacker, combat.Defender);
    }

    private void PerformSecondGroupOfFollowUp(Combat combat)
    {
        if (ShouldAttackerPerformGuaranteedFollowUp(combat))
            PerformAttackerFollowUp(combat.Attacker, combat.Defender);
        else if (ShouldDefenderPerformGuaranteedFollowUp(combat))
            PerformDefenderFollowUp(combat.Attacker, combat.Defender);
    }
    
    private bool ShouldAttackerPerformGuaranteedFollowUp(Combat combat)
    {
        Unit attacker = combat.Attacker;
        return attacker.HasFollowUpGuaranteed && 
               !CanAttackerPerformFollowUp(combat.Attacker, combat.Defender) && 
               !attacker.HasDenialFollowUpGuaranteed;
    }

    private bool ShouldDefenderPerformGuaranteedFollowUp(Combat combat)
    {
        Unit defender = combat.Defender;
        return defender.HasFollowUpGuaranteed && 
               !CanDefenderPerformFollowUp(combat.Attacker, combat.Defender) && 
               !defender.HasDenialFollowUpGuaranteed;
    }

    private void HandleNoFollowUpScenario(Combat combat)
    {
        Unit defender = combat.Defender;
        if (defender.HasNullifiedCounterattack)
            throw new NoFollowUpAttackDueNullifiedCounterattackException();
        HandlePotentialGuaranteedFollowUp(combat);
    }

    private void HandlePotentialGuaranteedFollowUp(Combat combat)
    {
        if (ShouldAttackerPerformGuaranteedFollowUp(combat))
            PerformAttackerFollowUp(combat.Attacker, combat.Defender);
        else if (ShouldDefenderPerformGuaranteedFollowUp(combat))
            PerformDefenderFollowUp(combat.Attacker, combat.Defender);
        else
            throw new FollowUpException();
    }

    private void PerformAttackerFollowUp(Unit attacker, Unit defender)
    {
        int damage = CalculateFollowUpDamage(attacker, defender);
        attacker.SetUnitExecuteAStrike();
        AnnounceAttack(attacker, defender, damage);
        attacker.ResetFollowUpStats();
    }

    private void PerformDefenderFollowUp(Unit attacker, Unit defender)
    {
        if (ShouldAnnounceNoFollowUpAttackDueNullifiedCounterattack(defender))
            throw new NoFollowUpAttackDueNullifiedCounterattackException();
        ExecuteDefenderFollowUpAttack(attacker, defender);
    }

    private bool ShouldAnnounceNoFollowUpAttackDueNullifiedCounterattack(Unit defender)
    {
        return defender.HasNullifiedCounterattack && !defender.HasNullifiedNullifiedCounterattack;
    }
    
    private void ExecuteDefenderFollowUpAttack(Unit attacker, Unit defender)
    {
        int damage = CalculateFollowUpDamage(defender, attacker);
        defender.SetUnitExecuteAStrike();
        AnnounceCounterattack(defender, attacker, damage);
        defender.ResetFollowUpStats();
    }
    
    private void AnnounceAttack(Unit attacker, Unit defender, int damage)
    {
        _view.AnnounceAttack(attacker, defender, damage);
        _view.AnnounceHpHealingInEachAttack(attacker);
    }

    private void AnnounceCounterattack(Unit defender, Unit attacker, int damage)
    {
        _view.AnnounceCounterattack(defender, attacker, damage);
        _view.AnnounceHpHealingInEachAttack(defender);
    }

    private int CalculateFollowUpDamage(Unit attacker, Unit defender)
    {
        FollowUpDamage damage = new FollowUpDamage(attacker, defender);
        return damage.CalculateDamage();
    }
}
