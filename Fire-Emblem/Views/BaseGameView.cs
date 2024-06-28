using Fire_Emblem.Teams;
using Fire_Emblem.Units;
using Fire_Emblem.Weapons;

namespace Fire_Emblem.Views;

public class BaseGameView : IView
{
    public virtual void AnnounceMessageForInvalidTeam() { }
    public virtual void AnnounceCurrentHealth(Unit attacker, Unit defender) { }
    public virtual Unit SelectUnit(Team team, int playerNumber) { throw new NotImplementedException(); }
    public virtual void AnnounceAdvantage(Unit attacker, Unit defender, AdvantageState advantage) { }
    public virtual void AnnounceRoundStart(int round, Unit activeUnit, int currentPlayer) { }
    public virtual string[] DisplayFiles() { throw new NotImplementedException(); }
    public virtual string AskUserToSelectAnOption(string[] options) { throw new NotImplementedException(); }
    public virtual void AnnounceAttack(Unit attacker, Unit defender, int damage) { }
    public virtual void AnnounceCounterattack(Unit defender, Unit attacker, int damage) { }
    public virtual void AnnounceWinner(int winnerTeamNumber) { }
    public virtual void AnnounceMessageForNoFollowUpAttack() { }
    public virtual void AnnounceAttackerBonusEffect(Unit unit) { }
    public virtual void AnnounceDefenderBonusEffect(Unit rival) { }
    public virtual void AnnounceAttackerPenaltyEffect(Unit unit) { }
    public virtual void AnnounceDefenderPenaltyEffect(Unit rival) { }
    public virtual void AnnounceNeutralizationBonusEffect(Unit unit) { }
    public virtual void AnnounceNeutralizationPenaltyEffect(Unit unit) { }
    public virtual void AnnounceExtraDamage(Unit unit) { }
    public virtual void AnnounceAbsoluteDamageReduction(Unit unit) { }
    public virtual void AnnouncePercentageReductionEffect(Unit unit) { }
    public virtual void AnnounceHealingEffect(Unit unit) { }
    public virtual void AnnounceHpHealing(Unit unit, int healingAmount) { }
    public virtual void AnnounceHpHealingInEachAttack(Unit unit) { }
    public virtual void AnnounceCounterattackDenialDenialEffect(Unit unit) { }
    public virtual void AnnounceDamageOutOfCombatEffect(Unit unit) { }
    public virtual void AnnounceMessageForNoFollowUpAttackDueNullifiedCounterattack(Unit unit) { }
    public virtual void AnnounceFollowUpGuarantee(Unit unit) { }
    public virtual void AnnounceDenialFollowUp(Unit unit) { }
    public virtual void AnnounceDenialOfDenialFollowUp(Unit unit) { }
    public virtual void AnnounceDenialFollowUpGuaranteed(Unit unit) { }
    public virtual void AnnounceCounterattackDenialEffect(Unit unit) { }
    public virtual void AnnounceDamageBeforeCombatEffect(Unit unit) { }

    public virtual string GetTeam1()
    {
        throw new NotImplementedException();
    }

    public virtual string GetTeam2()
    {
        throw new NotImplementedException();
    }
    
    public virtual void ShowInvalidTeamMessage()
    {
        throw new NotImplementedException();
    }

}