using Fire_Emblem.Teams;
using Fire_Emblem.Views;
using Fire_Emblem.Damage;
using Fire_Emblem.Units;
using Fire_Emblem.Weapons;

namespace Fire_Emblem.Controllers
{
    public class CombatController
    {
        private readonly IView _view;
        private readonly SkillController _skillController;
        private readonly FollowUpController _followUpController;

        public CombatController(IView view)
        {
            _view = view;
            _skillController = new SkillController(view);
            _followUpController = new FollowUpController();
        }
        
        public Combat ConductCombat(List<Team> teams, int round, int currentPlayer)
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

        private Combat CreateCombat(List<Team> teams, int currentPlayer)
        {
            Team activeTeam = teams[currentPlayer];
            Team opponentTeam = teams[(currentPlayer + 1) % 2];
            int attackerPlayerNumber = currentPlayer + 1;
            int defenderPlayerNumber = (currentPlayer + 1) % 2 + 1;
            Unit attacker = _view.SelectUnit(activeTeam, attackerPlayerNumber);
            Unit defender = _view.SelectUnit(opponentTeam, defenderPlayerNumber);
            activeTeam.AddAllies(attacker);
            opponentTeam.AddAllies(defender);
            attacker.SetStartOfCombatHp();
            defender.SetStartOfCombatHp();
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
            _view.AnnounceAdvantage(attacker, defender, weaponAdvantage);
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
            {
                defender.ResetFirstAttackBonusStats();
                attacker.ResetFirstAttackPenaltyStats();
                return;
            }
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

        private int CalculateFollowUpDamage(Unit attacker, Unit defender)
        {
            FollowUpDamage damage = new FollowUpDamage(attacker, defender);
            return damage.CalculateDamage();
        }

        private void HandleFollowUp(Combat combat)
        {
            if (CanAnyUnitPerformFollowUp(combat))
                HandleGuaranteedFollowUp(combat);
            else
                HandleNoFollowUpScenario(combat);
        }

        private bool CanAnyUnitPerformFollowUp(Combat combat)
        {
            return _followUpController.CanAttackerPerformFollowUp(combat.Attacker, combat.Defender) || _followUpController.CanDefenderPerformFollowUp(combat.Attacker, combat.Defender);
        }

        private void HandleGuaranteedFollowUp(Combat combat)
        {
            if (CanAttackerPerformFollowUp(combat))
            {
                PerformAttackerFollowUp(combat.Attacker, combat.Defender);
            }
            else if (CanDefenderPerformFollowUp(combat))
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

        private bool CanAttackerPerformFollowUp(Combat combat)
        {
            return _followUpController.CanAttackerPerformFollowUp(combat.Attacker, combat.Defender);
        }

        private bool CanDefenderPerformFollowUp(Combat combat)
        {
            return _followUpController.CanDefenderPerformFollowUp(combat.Attacker, combat.Defender);
        }

        private bool ShouldPerformGuaranteedAttackerFollowUp(Combat combat)
        {
            return combat.Attacker.HasFollowUpGuaranteed && !_followUpController.CanAttackerPerformFollowUp(combat.Attacker, combat.Defender) && !combat.Attacker.HasDenialFollowUpGuaranteed;
        }

        private bool ShouldPerformGuaranteedDefenderFollowUp(Combat combat)
        {
            return combat.Defender.HasFollowUpGuaranteed && !_followUpController.CanDefenderPerformFollowUp(combat.Attacker, combat.Defender) && !combat.Defender.HasDenialFollowUpGuaranteed;
        }

        private void HandleNoFollowUpScenario(Combat combat)
        {
            if (combat.Defender.HasNullifiedCounterattack)
            {
                _view.AnnounceMessageForNoFollowUpAttackDueNullifiedCounterattack(combat.Attacker);
            }
            else
            {
                HandlePotentialFollowUp(combat);
            }
        }

        private void HandlePotentialFollowUp(Combat combat)
        {
            if (ShouldPerformGuaranteedAttackerFollowUp(combat))
            {
                PerformAttackerFollowUp(combat.Attacker, combat.Defender);
            }
            else if (ShouldPerformGuaranteedDefenderFollowUp(combat))
            {
                PerformDefenderFollowUp(combat.Attacker, combat.Defender);
            }
            else
            {
                _view.AnnounceMessageForNoFollowUpAttack();
            }
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
            if (defender.HasNullifiedCounterattack && !defender.HasNullifiedNullifiedCounterattack)
            {
                _view.AnnounceMessageForNoFollowUpAttackDueNullifiedCounterattack(attacker);
                defender.ResetFollowUpStats();
                return;
            }
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


        private void EndCombat(Unit attacker, Unit defender)
        {
            ManageEndOfCombat(attacker, defender);
        }

        private void ManageEndOfCombat(Unit attacker, Unit defender)
        { 
            _skillController.ActivateAfterCombatSkills(attacker, defender);
            _view.AnnounceCurrentHealth(attacker, defender);
            attacker.SetLastUnitFaced(defender);
            defender.SetLastUnitFaced(attacker);
            DeactivateAttackerSkills(attacker);
            DeactivateDefenderSkills(defender);
        }

        private void DeactivateAttackerSkills(Unit attacker)
        {
            attacker.ResetStatEffects();
            attacker.ResetFirstAttackBonusStats();
            attacker.ResetFirstAttackPenaltyStats();
            // TODO: CAMBIAR ESTO
            attacker.Effects.ClearEffects();
            attacker.SetHasBeenAttackerBefore();
            attacker.ResetIsAttacker();
            attacker.ResetNullifyCounterattack();
            attacker.ResetNullifyNullifiedCounterattack();
            attacker.ResetFinalCausedDamage();
            attacker.ResetHealingPercentage();
            attacker.ResetUnitExecuteAStrike();
            attacker.ResetStatOutOfCombat();
            attacker.ResetDamageBeforeCombat();
            attacker.ResetFollowUpGuaranteed();
            attacker.ResetDenialFollowUp();
            attacker.ResetDenialFollowUpGuaranteed();
            attacker.ResetDenialOfDenialFollowUp();
            attacker.ResetPercentageDamageReductionReduction();
        }

        private void DeactivateDefenderSkills(Unit defender)
        {
            defender.ResetStatEffects();
            defender.ResetFirstAttackBonusStats();
            defender.ResetFirstAttackPenaltyStats();
            // TODO: Cambiar esto
            defender.Effects.ClearEffects();
            defender.SetHasBeenDefenderBefore();
            defender.ResetNullifyCounterattack();
            defender.ResetNullifyNullifiedCounterattack();
            defender.ResetFinalCausedDamage();
            defender.ResetHealingPercentage();
            defender.ResetUnitExecuteAStrike();
            defender.ResetStatOutOfCombat();
            defender.ResetDamageBeforeCombat();
            defender.ResetFollowUpGuaranteed();
            defender.ResetDenialFollowUp();
            defender.ResetDenialFollowUpGuaranteed();
            defender.ResetDenialOfDenialFollowUp();
            defender.ResetPercentageDamageReductionReduction();
        }
    }
}
