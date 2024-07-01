using Fire_Emblem_GUI;
using Fire_Emblem.Teams;
using Fire_Emblem.Units;
using Fire_Emblem.Weapons;

namespace Fire_Emblem.Views;

public abstract class BaseGameView : IView
{
    public virtual void AnnounceMessageForInvalidTeam() => throw new NotImplementedException();
    public virtual void AnnounceCurrentHealth(Unit attacker, Unit defender) => throw new NotImplementedException();
    public virtual Unit SelectUnit(Team team, int playerNumber) => throw new NotImplementedException();
    public virtual void AnnounceAdvantage(Unit attacker, Unit defender, AdvantageState advantage) => throw new NotImplementedException();
    public virtual void AnnounceRoundStart(int round, Unit activeUnit, int currentPlayer) => throw new NotImplementedException();
    public virtual string[] DisplayFiles() => throw new NotImplementedException();
    public virtual string AskUserToSelectAnOption(string[] options) => throw new NotImplementedException();
    public virtual void AnnounceAttack(Unit attacker, Unit defender, int damage) => throw new NotImplementedException();
    public virtual void AnnounceCounterattack(Unit defender, Unit attacker, int damage) => throw new NotImplementedException();
    public virtual void AnnounceWinner(int winnerTeamNumber) => throw new NotImplementedException();
    public virtual void AnnounceMessageForNoFollowUpAttack() => throw new NotImplementedException();
    public virtual void AnnounceAttackerBonusEffect(Unit unit) => throw new NotImplementedException();
    public virtual void AnnounceDefenderBonusEffect(Unit rival) => throw new NotImplementedException();
    public virtual void AnnounceAttackerPenaltyEffect(Unit unit) => throw new NotImplementedException();
    public virtual void AnnounceDefenderPenaltyEffect(Unit rival) => throw new NotImplementedException();
    public virtual void AnnounceNeutralizationBonusEffect(Unit unit) => throw new NotImplementedException();
    public virtual void AnnounceNeutralizationPenaltyEffect(Unit unit) => throw new NotImplementedException();
    public virtual void AnnounceExtraDamage(Unit unit) => throw new NotImplementedException();
    public virtual void AnnounceAbsoluteDamageReduction(Unit unit) => throw new NotImplementedException();
    public virtual void AnnouncePercentageReductionEffect(Unit unit) => throw new NotImplementedException();
    public virtual void AnnounceHealingEffect(Unit unit) => throw new NotImplementedException();
    public virtual void AnnounceHpHealing(Unit unit, int healingAmount) => throw new NotImplementedException();
    public virtual void AnnounceHpHealingInEachAttack(Unit unit) => throw new NotImplementedException();
    public virtual void AnnounceCounterattackDenialDenialEffect(Unit unit) => throw new NotImplementedException();
    public virtual void AnnounceDamageOutOfCombatEffect(Unit unit) => throw new NotImplementedException();
    public virtual void AnnounceMessageForNoFollowUpAttackDueNullifiedCounterattack(Unit unit) => throw new NotImplementedException();
    public virtual void AnnounceFollowUpGuarantee(Unit unit) => throw new NotImplementedException();
    public virtual void AnnounceDenialFollowUp(Unit unit) => throw new NotImplementedException();
    public virtual void AnnounceDenialOfDenialFollowUp(Unit unit) => throw new NotImplementedException();
    public virtual void AnnounceDenialFollowUpGuaranteed(Unit unit) => throw new NotImplementedException();
    public virtual void AnnounceCounterattackDenialEffect(Unit unit) => throw new NotImplementedException();
    public virtual void AnnounceDamageBeforeCombatEffect(Unit unit) => throw new NotImplementedException();
    public virtual string GetTeam1() => throw new NotImplementedException();
    public virtual string GetTeam2() => throw new NotImplementedException();
    public virtual void ShowInvalidTeamMessage() => throw new NotImplementedException();
    public virtual void UpdateTeams(IUnit[] firstUnit, IUnit[] secondUnit) => throw new NotImplementedException();
    public virtual int SelectUnitFirstTeam() => throw new NotImplementedException();
    public virtual int SelectUnitSecondTeam() => throw new NotImplementedException();
    public virtual void UpdateUnitsStatsDuringBattle(IUnit firstUnit, IUnit secondUnit) => throw new NotImplementedException();
}
