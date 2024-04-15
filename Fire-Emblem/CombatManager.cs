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
    
    public void ConductCombat(List<Team> teams, int round, int currentPlayer)
    {
        Team activeTeam = teams[currentPlayer];
        Team opponentTeam = teams[(currentPlayer + 1) % 2];
        Unit attacker = _gameView.SelectUnit(activeTeam, currentPlayer + 1);
        Unit defender = _gameView.SelectUnit(opponentTeam, (currentPlayer + 1) % 2 + 1);
        
        // attacker.SetAttacker(true);
        // defender.SetDefender(false);
        
        EstablishStatusUnits(attacker, defender);
        _gameView.AnnounceRoundStart(round, attacker, currentPlayer);
        AnnounceWeaponAdvantage(attacker, defender);
        
        foreach (var skill in attacker.Skills)
        {
            skill.ActivateEffects(attacker, _gameView);
        }
        foreach (var skill in defender.Skills)
        {
            skill.ActivateEffects(defender, _gameView);
        }
        
        PerformAttack(attacker, defender);
        if (defender.CurrentHP <= 0)
        {
            _gameView.ShowCurrentHealth(attacker, defender);
            foreach (var skill in attacker.Skills)
            {
                skill.DeactivateEffects(attacker, _gameView);
            }
            foreach (var skill in defender.Skills)
            {
                skill.DeactivateEffects(defender, _gameView);
            }
            return;
        }
        PerformAttack(defender, attacker);
        if (attacker.CurrentHP <= 0)
        {
            _gameView.ShowCurrentHealth(attacker, defender);
            foreach (var skill in attacker.Skills)
            {
                skill.DeactivateEffects(attacker, _gameView);
            }
            foreach (var skill in defender.Skills)
            {
                skill.DeactivateEffects(defender, _gameView);
            }
            return;
        }

        HandleFollowUp(attacker, defender);
        _gameView.ShowCurrentHealth(attacker, defender);
        foreach (var skill in attacker.Skills)
        {
            skill.DeactivateEffects(attacker, _gameView);
        }
        foreach (var skill in defender.Skills)
        {
            skill.DeactivateEffects(defender, _gameView);
        }
    }
    
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
    
    private bool CanPerformFollowUp(Unit attacker, Unit defender)
    {
        return attacker.Spd - defender.Spd >= 5;
    }
    
    private void HandleFollowUp(Unit attacker, Unit defender)
    {
        if (CanPerformFollowUp(attacker, defender))
            PerformAttack(attacker, defender);
        else if (CanPerformFollowUp(defender, attacker))
            PerformAttack(defender, attacker);
        else
            _gameView.ShowMessageForNoFollowUpAttack();
    }
}
