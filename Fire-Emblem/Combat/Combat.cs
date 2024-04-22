using Fire_Emblem.TeamManagment;
using Fire_Emblem.UnitManagment;
using Fire_Emblem.Weapon;

namespace Fire_Emblem;

public class Combat
{
    public Team ActiveTeam { get; private set; }
    public Team OpponentTeam { get; private set; }
    public Unit Attacker { get; private set; }
    public Unit Defender { get; private set; }
    
    private List<Unit> AlliesUnits => ActiveTeam.Units.Where(unit => unit != Attacker).ToList();
    
    
    
    public CombatState State { get; private set; }
    private readonly GameView _gameView;
    private void SetState(CombatState newState)
        => State = newState;
    
    

    public Combat(Team activeTeam, Team opponentTeam, Unit attacker, Unit defender, GameView gameView)
    {
        ActiveTeam = activeTeam;
        OpponentTeam = opponentTeam;
        Attacker = attacker;
        Defender = defender;
        _gameView = gameView;
    }
    
    public void ProcessCombat()
    {
        SetState(CombatState.StartOfCombat);
        AnnounceWeaponAdvantage();
        ActivateUnitsSkills();
        SetState(CombatState.UnitAttacks);
        PerformAttack();
        if (Defender.CurrentHP <= 0)
        {
            _gameView.ShowCurrentHealth(Attacker, Defender); 
            SetState(CombatState.EndOfCombat);
            DeactivateSkills();
            return;
        }
        
        SetState(CombatState.OpponentCounterattacks);
        PerformCounterattack();
        if (Attacker.CurrentHP <= 0)
        {
            _gameView.ShowCurrentHealth(Attacker, Defender);
            SetState(CombatState.EndOfCombat);
            DeactivateSkills();
            return;
        }
        HandleFollowUp();
        EndCombat();
    }
    
    private void AnnounceWeaponAdvantage()
    {
        AdvantageState weaponAdvantage = Attacker.Weapon.CalculateAdvantage(Attacker, Defender);
        _gameView.AnnounceAdvantage(Attacker, Defender, weaponAdvantage);
    }
    
    private void ActivateUnitsSkills()
    {
        foreach (var skill in Attacker.Skills)
        {
            skill.ActivateEffects(Attacker, this, _gameView);
        }
    
        foreach (var skill in Defender.Skills)
        {
            skill.ActivateEffects(Defender, this, _gameView);
        }
    }
    
    
    private void DeactivateSkills()
    {
        foreach (var skill in Attacker.Skills)
        {
            skill.DeactivateEffects(Attacker, this, _gameView);
        }

        foreach (var skill in Defender.Skills)
        {
            skill.DeactivateEffects(Defender, this, _gameView);
        }
    }
    
    private void HandleFollowUp()
    {
        SetState(CombatState.FollowUp);
        if (CanAttackerPerformFollowUp())
            PerformAttack();
        else if (CanDefenderPerformFollowUp())
            PerformCounterattack();
        else
            _gameView.ShowMessageForNoFollowUpAttack();
    }
    
    private void PerformAttack()
    {
        int damage = Attacker.CalculateDamage(Defender);
        _gameView.AnnounceAttack(Attacker, Defender, damage);
    }
    
    private void PerformCounterattack()
    {
        int damage = Defender.CalculateDamage(Attacker);
        _gameView.AnnounceCounterattack(Defender, Attacker, damage);
    }
    
    private bool CanAttackerPerformFollowUp()
    {
        return Attacker.Spd - Defender.Spd >= 5;
    }

    private bool CanDefenderPerformFollowUp()
    {
        return Defender.Spd - Attacker.Spd >= 5;
    }
    
    private void EndCombat()
    {
        _gameView.ShowCurrentHealth(Attacker, Defender);
        SetState(CombatState.EndOfCombat);
        DeactivateSkills();
    }
}
