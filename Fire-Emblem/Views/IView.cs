using Fire_Emblem.Teams;
using Fire_Emblem.Units;
using Fire_Emblem.Weapons;

namespace Fire_Emblem.Views;

public interface IView
{
    public void AnnounceCurrentHealth(Unit attacker, Unit defender);
    public Unit SelectUnit(Team team, int playerNumber);
    public void AnnounceAdvantage(Unit attacker, Unit defender, AdvantageState advantage);
    public void AnnounceRoundStart(int round, Unit activeUnit, int currentPlayer);
    public string[] DisplayFiles();
    public string AskUserToSelectAnOption(string[] options);
    public void AnnounceAttack(Unit attacker, Unit defender, int damage);
    public void AnnounceCounterattack(Unit defender, Unit attacker, int damage);
    public void AnnounceWinner(int winnerTeamNumber);
    public void AnnounceMessageForInvalidTeam();
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
}