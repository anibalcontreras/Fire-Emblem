using Fire_Emblem.Damage;
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
            if (CanAttackerPerformFollowUp(combat.Attacker, combat.Defender))
            {
                PerformAttackerFollowUp(combat.Attacker, combat.Defender);
            }
            else if (CanDefenderPerformFollowUp(combat.Attacker, combat.Defender))
            {
                PerformDefenderFollowUp(combat.Attacker, combat.Defender);
            }
            if (ShouldPerformGuaranteedAttackerFollowUp(combat))
            {
                PerformAttackerFollowUp(combat.Attacker, combat.Defender);
            }
            else if (ShouldPerformGuaranteedDefenderFollowUp(combat))
            {
                PerformDefenderFollowUp(combat.Attacker, combat.Defender);
            }
        }

        private bool ShouldPerformGuaranteedAttackerFollowUp(Combat combat)
        {
            return combat.Attacker.HasFollowUpGuaranteed && 
                   !CanAttackerPerformFollowUp(combat.Attacker, combat.Defender) && 
                   !combat.Attacker.HasDenialFollowUpGuaranteed;
        }

        private bool ShouldPerformGuaranteedDefenderFollowUp(Combat combat)
        {
            return combat.Defender.HasFollowUpGuaranteed && 
                   !CanDefenderPerformFollowUp(combat.Attacker, combat.Defender) && 
                   !combat.Defender.HasDenialFollowUpGuaranteed;
        }

        private void HandleNoFollowUpScenario(Combat combat)
        {
            if (combat.Defender.HasNullifiedCounterattack)
            {
                _view.AnnounceMessageForNoFollowUpAttackDueNullifiedCounterattack(combat.Attacker);
            }
            else
            {
                HandlePotentialGuaranteedFollowUp(combat);
            }
        }

        private void HandlePotentialGuaranteedFollowUp(Combat combat)
        {
            if (ShouldPerformGuaranteedAttackerFollowUp(combat))
                PerformAttackerFollowUp(combat.Attacker, combat.Defender);
            else if (ShouldPerformGuaranteedDefenderFollowUp(combat))
                PerformDefenderFollowUp(combat.Attacker, combat.Defender);
            else
                _view.AnnounceMessageForNoFollowUpAttack();
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
            {
                AnnounceNoFollowUpAttackDueNullifiedCounterattack(attacker);
                ResetDefenderFollowUpStats(defender);
                return;
            }
            ExecuteDefenderFollowUpAttack(attacker, defender);
        }

        private bool ShouldAnnounceNoFollowUpAttackDueNullifiedCounterattack(Unit defender)
        {
            return defender.HasNullifiedCounterattack && !defender.HasNullifiedNullifiedCounterattack;
        }

        private void AnnounceNoFollowUpAttackDueNullifiedCounterattack(Unit attacker)
        {
            _view.AnnounceMessageForNoFollowUpAttackDueNullifiedCounterattack(attacker);
        }

        private void ResetDefenderFollowUpStats(Unit defender)
        {
            defender.ResetFollowUpStats();
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