using Fire_Emblem.Teams;
using Fire_Emblem.Units;
using Fire_Emblem.Views;
using Fire_Emblem.Weapons;

namespace Fire_Emblem;
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
        combat.Attacker.SetHasBeenAttackerBefore();
        int damage = CalculateFirstAttackDamage(combat.Attacker, combat.Defender);
        combat.Attacker.ResetFirstAttackBonusStats();
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
        combat.Defender.SetHasBeenDefenderBefore();
        int damage = CalculateFirstAttackDamage(combat.Defender, combat.Attacker);
        combat.Defender.ResetFirstAttackBonusStats();
        combat.Attacker.ResetFirstAttackPenaltyStats();
        _gameView.AnnounceCounterattack(combat.Defender, combat.Attacker, damage);
    }
    
    private int CalculateFirstAttackDamage(Unit attacker, Unit defender)
    {
        int defenseValue = CalculateDefenseValue(defender, isFollowUp: false, attacker.Weapon);
        double initialDamage = CalculateInitialDamage(defenseValue, attacker.FirstAttackAtk, defender, attacker.Weapon);
        int damageAfterExtra = ApplyExtraDamage(initialDamage, attacker.ExtraDamage, 0);
        double totalPercentageReduction = 1 - ((1 - defender.PercentageDamageReduction) * (1 - defender.FirstAttackPercentageDamageReduction));
        double damageAfterPercentageReduction = ApplyPercentageDamageReduction(damageAfterExtra, totalPercentageReduction);
        double finalDamage = ApplyAbsoluteDamageReduction(damageAfterPercentageReduction, defender.AbsoluteDamageReduction);
        return UpdateOpponentHpDueTheDamage(defender, finalDamage);
    }

    private int CalculateFollowUpDamage(Unit attacker, Unit defender)
    {
        int defenseValue = CalculateDefenseValue(defender, isFollowUp: true, attacker.Weapon);
        double initialDamage = CalculateInitialDamage(defenseValue, attacker.FollowUpAtk, defender, attacker.Weapon);
        int damageAfterExtra = ApplyExtraDamage(initialDamage, attacker.ExtraDamage, attacker.FirstAttackExtraDamage);
        double totalPercentageReduction = 1 - ((1 - defender.PercentageDamageReduction) * (1 - defender.FollowUpPercentageDamageReduction));
        double damageAfterPercentageReduction = ApplyPercentageDamageReduction(damageAfterExtra, totalPercentageReduction);
        double finalDamage = ApplyAbsoluteDamageReduction(damageAfterPercentageReduction, defender.AbsoluteDamageReduction);
        return UpdateOpponentHpDueTheDamage(defender, finalDamage);
    }

    private int CalculateDefenseValue(Unit opponent, bool isFollowUp, Weapon weapon)
    {
        return weapon is Magic
            ? Convert.ToInt32(isFollowUp ? opponent.FollowUpRes : opponent.FirstAttackRes)
            : Convert.ToInt32(isFollowUp ? opponent.FollowUpDef : opponent.FirstAttackDef);
    }

    private double CalculateInitialDamage(int defenseValue, int attackValue, Unit opponent, Weapon weapon)
    {
        return (Convert.ToDouble(attackValue) * Convert.ToDouble(weapon.GetWTB(opponent.Weapon))) - defenseValue;
    }

    private int ApplyExtraDamage(double initialDamage, int extraDamage, int followUpExtraDamage)
    {
        return (int)Math.Max(0, Math.Truncate(initialDamage) + extraDamage + followUpExtraDamage);
    }

    private double ApplyPercentageDamageReduction(int damage, double percentageReduction)
    {
        double reductionFactor = 1 - percentageReduction;
        double reducedDamage = damage * reductionFactor;
        return reducedDamage;
    }

    private double ApplyAbsoluteDamageReduction(double damage, int damageReduction)
    {
        return Math.Max(0, damage - damageReduction);
    }

    private int UpdateOpponentHpDueTheDamage(Unit opponent, double finalDamage)
    {
        int finalDamageInt = Convert.ToInt32(Math.Floor(finalDamage));
        opponent.CurrentHP -= finalDamageInt;
        return finalDamageInt;
    }
    
    private void DeactivateSkills(Combat combat)
    {
        Unit attacker = combat.Attacker;
        Unit defender = combat.Defender;
        
        attacker.ResetEffects();
        defender.ResetEffects();
        attacker.ResetFirstAttackBonusStats();
        defender.ResetFirstAttackBonusStats();
        attacker.ResetFirstAttackPenaltyStats();
        defender.ResetFirstAttackPenaltyStats();
        attacker.ClearActiveEffects();
        defender.ClearActiveEffects();
        attacker.SetLastUnitFaced(defender);
        defender.SetLastUnitFaced(attacker);
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
