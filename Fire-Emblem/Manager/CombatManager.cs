using Fire_Emblem.TeamManagment;
using Fire_Emblem.UnitManagment;
using Fire_Emblem.Weapon;

namespace Fire_Emblem;

public class CombatManager
{
    private GameView _gameView;

    public CombatManager(GameView gameView)
    {
        _gameView = gameView;
    }

    public Combat ConductCombat(List<Team> teams, int round, int currentPlayer)
    {
        
        Combat combat = CreateCombat(teams, currentPlayer);
        combat.UpdateState(CombatState.StartOfCombat);
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
    
    
    private void ExecuteCombatProcess(Combat combat)
    {
        PerformAttack(combat);
        if (combat.Defender.CurrentHP <= 0)
        {
            _gameView.ShowCurrentHealth(combat.Attacker, combat.Defender);
            combat.UpdateState(CombatState.EndOfCombat);
            DeactivateSkills(combat);
            return;
        }

        PerformCounterattack(combat);
        if (combat.Attacker.CurrentHP <= 0)
        {
            _gameView.ShowCurrentHealth(combat.Attacker, combat.Defender);
            combat.UpdateState(CombatState.EndOfCombat);
            DeactivateSkills(combat);
            return;
        }
        
        HandleFollowUp(combat);
        
        EndCombat(combat);
    }

    private void AnnounceWeaponAdvantage(Combat combat)
    {
        AdvantageState weaponAdvantage = combat.Attacker.Weapon.CalculateAdvantage(combat.Attacker, combat.Defender);
        _gameView.AnnounceAdvantage(combat.Attacker, combat.Defender, weaponAdvantage);
    }

    private void ActivateSkills(Combat combat)
    {
        ActivateSkills(combat.Attacker, combat.Defender, combat);
        ActivateSkills(combat.Defender, combat.Attacker, combat);
    }

    private void ActivateSkills(Unit activator, Unit opponent, Combat combat)
    {
        foreach (var skill in activator.Skills)
        {
            if (skill.Condition.IsConditionMet(combat, activator, opponent))
            {
                skill.ActivateEffects(combat, _gameView, activator, opponent);
            }
        }
    }
    
    private void DeactivateSkills(Combat combat)
    {
        combat.Attacker.ResetStatBonuses();
        combat.Defender.ResetStatBonuses();
    }
    
    private void PerformAttack(Combat combat)
    {
        combat.UpdateState(CombatState.UnitAttacks);
        int damage = combat.Attacker.CalculateDamage(combat.Defender);
        _gameView.AnnounceAttack(combat.Attacker, combat.Defender, damage);
    }
    
    private void PerformCounterattack(Combat combat)
    {
        combat.UpdateState(CombatState.OpponentCounterattacks);
        int damage = combat.Defender.CalculateDamage(combat.Attacker);
        _gameView.AnnounceCounterattack(combat.Defender, combat.Attacker, damage);
    }
    
    private void HandleFollowUp(Combat combat)
    {
        combat.UpdateState(CombatState.FollowUp);
        if (combat.CanAttackerPerformFollowUp())
            PerformAttack(combat);
        else if (combat.CanDefenderPerformFollowUp())
            PerformCounterattack(combat);
        else
            _gameView.ShowMessageForNoFollowUpAttack();
    }
    
    private void EndCombat(Combat combat)
    {
        combat.UpdateState(CombatState.EndOfCombat);
       _gameView.ShowCurrentHealth(combat.Attacker, combat.Defender); 
        DeactivateSkills(combat);
    }
}
