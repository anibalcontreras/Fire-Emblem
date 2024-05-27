namespace Fire_Emblem.Stats;

public class Stat
{
    public int BaseValue { get; set; }
    public int Bonus { get; private set; }
    public int Penalty { get; private set; }
    public int BonusNeutralization { get; private set; }
    public int PenaltyNeutralization { get; private set; }
    public int FirstAttackBonus { get; private set; }
    public int FirstAttackPenalty { get; private set; }
    public int FirstAttackBonusNeutralization { get; private set; }
    public int FirstAttackPenaltyNeutralization { get; private set; }
    public int FollowUpBonus { get; private set; }
    public int FollowUpPenalty { get; private set; }
    
    public int CurrentValue => BaseValue + Bonus - Penalty - BonusNeutralization + PenaltyNeutralization;
    public int FirstAttackValue => CurrentValue + FirstAttackBonus - FirstAttackPenalty - FirstAttackBonusNeutralization + FirstAttackPenaltyNeutralization;
    public int FollowUpValue => CurrentValue + FollowUpBonus - FollowUpPenalty;

    public void ApplyBonus(int amount) => Bonus += amount;
    public void ApplyPenalty(int amount) => Penalty += amount;
    public void ApplyBonusNeutralization() => BonusNeutralization = Bonus;
    public void ApplyPenaltyNeutralization() => PenaltyNeutralization = Penalty;
    public void ApplyFirstAttackBonus(int amount) => FirstAttackBonus += amount;
    public void ApplyFirstAttackPenalty(int amount) => FirstAttackPenalty += amount;
    public void ApplyFollowUpBonus(int amount) => FollowUpBonus += amount;
    public void ApplyFollowUpPenalty(int amount) => FollowUpPenalty += amount;
    
    public void Reset()
    {
        Bonus = 0;
        Penalty = 0;
        BonusNeutralization = 0;
        PenaltyNeutralization = 0;
        FirstAttackBonus = 0;
        FirstAttackPenalty = 0;
        FirstAttackBonusNeutralization = 0;
        FirstAttackPenaltyNeutralization = 0;
        FollowUpBonus = 0;
        FollowUpPenalty = 0;
    }
}