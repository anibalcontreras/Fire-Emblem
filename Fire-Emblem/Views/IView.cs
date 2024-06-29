using Fire_Emblem_GUI;
using Fire_Emblem.Teams;
using Fire_Emblem.Units;
using Fire_Emblem.Weapons;

namespace Fire_Emblem.Views;

public interface IView
{
    public void AnnounceMessageForInvalidTeam();
    public void AnnounceCurrentHealth(Unit attacker, Unit defender);
    public Unit SelectUnit(Team team, int playerNumber);
    public void AnnounceAdvantage(Unit attacker, Unit defender, AdvantageState advantage);
    public void AnnounceRoundStart(int round, Unit activeUnit, int currentPlayer);
    public string[] DisplayFiles();
    public string AskUserToSelectAnOption(string[] options);
    public void AnnounceAttack(Unit attacker, Unit defender, int damage);
    public void AnnounceCounterattack(Unit defender, Unit attacker, int damage);
    public void AnnounceWinner(int winnerTeamNumber);
    public void AnnounceMessageForNoFollowUpAttack();
    public void AnnounceAttackerBonusEffect(Unit unit);
    public void AnnounceDefenderBonusEffect(Unit rival);
    public void AnnounceAttackerPenaltyEffect(Unit unit);
    public void AnnounceDefenderPenaltyEffect(Unit rival);
    public void AnnounceNeutralizationBonusEffect(Unit unit);
    public void AnnounceNeutralizationPenaltyEffect(Unit unit);
    public void AnnounceExtraDamage(Unit unit);
    public void AnnounceAbsoluteDamageReduction(Unit unit);
    public void AnnouncePercentageReductionEffect(Unit unit);
    public void AnnounceHealingEffect(Unit unit);
    public void AnnounceHpHealing(Unit unit, int healingAmount);
    public void AnnounceHpHealingInEachAttack(Unit unit);
    public void AnnounceCounterattackDenialDenialEffect(Unit unit);
    public void AnnounceDamageOutOfCombatEffect(Unit unit);
    public void AnnounceMessageForNoFollowUpAttackDueNullifiedCounterattack(Unit unit);
    public void AnnounceFollowUpGuarantee(Unit unit);
    public void AnnounceDenialFollowUp(Unit unit);
    public void AnnounceDenialOfDenialFollowUp(Unit unit);
    public void AnnounceDenialFollowUpGuaranteed(Unit unit);
    public void AnnounceCounterattackDenialEffect(Unit unit);
    public void AnnounceDamageBeforeCombatEffect(Unit unit);
    public string GetTeam1();
    public string GetTeam2();
    public void ShowInvalidTeamMessage();
    public void UpdateTeams(IUnit[] unit1, IUnit[] unit2);
    public int SelectUnitFirstTeam();
    public int SelectUnitSecondTeam();
    public void ShowAttackFromTeam1(IUnit unit1, IUnit unit2);
    public void ShowAttackFromTeam2(IUnit unit1, IUnit unit2);
    public void UpdateUnitsStatsDuringBattle(IUnit unit1, IUnit unit2);
    public void CongratulateTeam1(IUnit[] winnerTeam);
    public void CongratulateTeam2(IUnit[] winnerTeam);
}