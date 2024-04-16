using Fire_Emblem.TeamManagment;
using Fire_Emblem.UnitManagment;
using Fire_Emblem.Weapon;

namespace Fire_Emblem;

public class CombatManager
{
    private GameView _gameView;
    private Combat _combat;
    
    public CombatManager(GameView gameView)
    {
        _gameView = gameView;
    }
    
    public void ConductCombat(List<Team> teams, int round, int currentPlayer)
    {
        Team activeTeam = teams[currentPlayer];
        Team opponentTeam = teams[(currentPlayer + 1) % 2];
        Unit attacker = _gameView.SelectUnit(activeTeam, currentPlayer + 1);
        Unit defender = _gameView.SelectUnit(opponentTeam, (currentPlayer + 1) % 2 + 1);
        _combat = new Combat(activeTeam, opponentTeam, attacker, defender);

        // Combat combat = InitCombat(teams, currentPlayer);
        // Unit attacker = combat.Attacker;
        // Unit defender = combat.Defender;
        
        
        EstablishStatusUnits(attacker, defender);
        _gameView.AnnounceRoundStart(round, attacker, currentPlayer);
        AnnounceWeaponAdvantage(attacker, defender);
        ActivateUnitsSkills(attacker, defender, _combat);
        
        _combat.SetState(CombatState.UnitAttacks);
        PerformAttack(attacker, defender);
        
        if (defender.CurrentHP <= 0)
        {
            _gameView.ShowCurrentHealth(attacker, defender);
            _combat.SetState(CombatState.EndOfCombat);
            DeactivateUnitsSkills(attacker, defender, _combat);
            return;
        }
        // HandleDeathOfDefender(attacker, defender);
        
        _combat.SetState(CombatState.OpponentCounterattacks);
        PerformCounterattack(defender, attacker);
        if (attacker.CurrentHP <= 0)
        {
            _gameView.ShowCurrentHealth(attacker, defender);
            _combat.SetState(CombatState.EndOfCombat);
            DeactivateUnitsSkills(attacker, defender, _combat);
            return;
        }
        HandleFollowUp(attacker, defender);
        EndCombat(attacker, defender);
    }
    
    // private Combat InitCombat(List<Team> teams, int currentPlayer)
    // {
    //     Team activeTeam = teams[currentPlayer];
    //     Team opponentTeam = teams[(currentPlayer + 1) % 2];
    //     Unit attacker = _gameView.SelectUnit(activeTeam, currentPlayer + 1);
    //     Unit defender = _gameView.SelectUnit(opponentTeam, (currentPlayer + 1) % 2 + 1);
    //     
    //     return new Combat(activeTeam, opponentTeam, attacker, defender);
    // }
    
    // private void HandleDeathOfDefender(Unit attacker, Unit defender)
    // {
    //     if (defender.CurrentHP <= 0)
    //     {
    //         _gameView.ShowCurrentHealth(attacker, defender);
    //         _combat.SetState(CombatState.EndOfCombat);
    //         DeactivateUnitsSkills(attacker, defender, _combat);
    //         return;
    //     }
    // }
    
    private void EstablishStatusUnits(Unit attacker, Unit defender)
    {
        attacker.SetAttacker(true);
        attacker.SetDefender(false);
        defender.SetDefender(true);
        defender.SetAttacker(false);
    }
    
    private void AnnounceWeaponAdvantage(Unit attacker, Unit defender)
    {
        AdvantageState advantage = attacker.Weapon.CalculateAdvantage(attacker, defender);
        _gameView.AnnounceAdvantage(attacker, defender, advantage);
    }
    
    private void PerformAttack(Unit attacker, Unit defender)
    {
        int damage = attacker.CalculateDamage(defender);
        _gameView.AnnounceAttack(attacker, defender, damage);
    }
    
    private void PerformCounterattack(Unit defender, Unit attacker)
    {
        int damage = defender.CalculateDamage(attacker);
        _gameView.AnnounceAttack(defender, attacker, damage);
    }
    
    private bool CanPerformFollowUp(Unit attacker, Unit defender)
    {
        return attacker.Spd - defender.Spd >= 5;
    }
    
    private void HandleFollowUp(Unit attacker, Unit defender)
    {
        _combat.SetState(CombatState.FollowUp);
        if (CanPerformFollowUp(attacker, defender))
            PerformAttack(attacker, defender);
        else if (CanPerformFollowUp(defender, attacker))
            PerformCounterattack(defender, attacker);
        else
            _gameView.ShowMessageForNoFollowUpAttack();
    }
    
    private void ActivateUnitsSkills(Unit attacker, Unit defender, Combat combat)
    {
        foreach (var skill in attacker.Skills)
        {
            skill.ActivateEffects(attacker, combat, _gameView);
        }

        foreach (var skill in defender.Skills)
        {
            skill.ActivateEffects(defender, combat, _gameView);
        }
    }

    private void DeactivateUnitsSkills(Unit attacker, Unit defender, Combat combat)
    {
        foreach (var skill in attacker.Skills)
        {
            skill.DeactivateEffects(attacker, combat, _gameView);
        }

        foreach (var skill in defender.Skills)
        {
            skill.DeactivateEffects(defender, combat, _gameView);
        }
    }

    private void EndCombat(Unit attacker, Unit defender)
    {
        _gameView.ShowCurrentHealth(attacker, defender);
        _combat.SetState(CombatState.EndOfCombat);
        DeactivateUnitsSkills(attacker, defender, _combat);
    }
}
