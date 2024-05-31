using Fire_Emblem.Effects;
using Fire_Emblem.Effects.Neutralization;
using Fire_Emblem.Exception;
using Fire_Emblem.Skills;
using Fire_Emblem.Stats;

namespace Fire_Emblem.Units;
using Weapons;
public class Unit
{
    private readonly List<Skill> _skills = new();
    private readonly List<IEffect> _effects = new();
    private IEnumerable<IEffect> Effects => _effects.AsReadOnly();
    
    public bool HasActiveNeutralizationBonus(StatType statType)
    {
        return Effects.Any(effect => effect is NeutralizationBonusEffect 
            bonus && bonus.StatType == statType);
    }
    
    public bool HasActiveNeutralizationPenalty(StatType statType)
    {
        return Effects.Any(effect => effect is NeutralizationPenaltyEffect 
            penalty && penalty.StatType == statType);
    }
    
    public IEnumerable<Skill> Skills
        => _skills.AsReadOnly();
    
    public void AddSkill(Skill skill)
        => _skills.Add(skill);

    public Unit LastUnitFaced { get; private set; }
    
    public void SetLastUnitFaced(Unit unit)
        => LastUnitFaced = unit;
    
    public bool IsAttacker { get; private set; }
    
    public void SetIsAttacker()
        => IsAttacker = true;
    
    public void ResetIsAttacker()
        => IsAttacker = false;
    
    public bool HasActivatedAlterStatBase { get; private set; }
    
    public void SetActivatedAlterStatBase()
        => HasActivatedAlterStatBase = true;
    
    public bool HasBeenAttackerBefore { get; private set; }
    
    public bool HasBeenDefenderBefore { get; private set; }
    
    public void SetHasBeenAttackerBefore()
        => HasBeenAttackerBefore = true;
    
    public void SetHasBeenDefenderBefore()
        => HasBeenDefenderBefore = true;
    
    private int _currentHP;
    
    public int CurrentHP
    {
        get { return _currentHP; }
        set { _currentHP = Math.Max(0, value); }
    }
    
    public void InitializeCurrentHp()
    {
        _currentHP = BaseHp;
    }

    private int CurrentAtk => BaseAtk + AtkBonus - AtkPenalty - 
        AtkBonusNeutralization + AtkPenaltyNeutralization;
    private int CurrentSpd => BaseSpd + SpdBonus - SpdPenalty - 
        SpdBonusNeutralization + SpdPenaltyNeutralization;
    private int CurrentDef => BaseDef + DefBonus - DefPenalty - 
        DefBonusNeutralization + DefPenaltyNeutralization;
    private int CurrentRes => BaseRes + ResBonus - ResPenalty - 
        ResBonusNeutralization + ResPenaltyNeutralization;
    
    public int AtkBonus { get; private set; }
    public int SpdBonus { get; private set; }
    public int DefBonus { get; private set; }
    public int ResBonus { get; private set; }
    
    private int AtkBonusNeutralization { get; set; }
    private int SpdBonusNeutralization { get; set; }
    private int DefBonusNeutralization { get; set; }
    private int ResBonusNeutralization { get; set; }
    
    private int AtkPenaltyNeutralization { get; set; }
    private int SpdPenaltyNeutralization { get; set; }
    private int DefPenaltyNeutralization { get; set; }
    private int ResPenaltyNeutralization { get; set; }
    
    public int AtkPenalty { get; private set; }
    public int SpdPenalty { get; private set; }
    public int DefPenalty { get; private set; }
    public int ResPenalty { get; private set; }
    public int FirstAttackAtkBonus { get; private set; }
    public int FirstAttackDefBonus { get; private set; }
    public int FirstAttackResBonus { get; private set; }
    public int FirstAttackAtkPenalty { get; private set; }
    public int FirstAttackDefPenalty { get; private set; }
    public int FirstAttackResPenalty { get; private set; }
    public int FollowUpAtkBonus { get; private set; }
    public int FollowUpDefBonus { get; private set; }
    public int FollowUpResBonus { get; private set; }
    
    public int FollowUpAtkPenalty { get; private set; }
    public int FollowUpDefPenalty { get; private set; }
    public int FollowUpResPenalty { get; private set; }
    
    private int FirstAttackAtkBonusNeutralization { get; set; }
    private int FirstAttackDefBonusNeutralization { get; set; }
    private int FirstAttackResBonusNeutralization { get; set; }
    
    private int FirstAttackAtkPenaltyNeutralization { get; set; }
    private int FirstAttackDefPenaltyNeutralization { get; set; }
    private int FirstAttackResPenaltyNeutralization { get; set; }
    
    private int FirstAttackAtk => CurrentAtk + FirstAttackAtkBonus - FirstAttackAtkPenalty - 
        FirstAttackAtkBonusNeutralization + FirstAttackAtkPenaltyNeutralization;
    private int FirstAttackDef => CurrentDef + FirstAttackDefBonus - FirstAttackDefPenalty - 
        FirstAttackDefBonusNeutralization + FirstAttackDefPenaltyNeutralization;
    private int FirstAttackRes => CurrentRes + FirstAttackResBonus - FirstAttackResPenalty - 
        FirstAttackResBonusNeutralization + FirstAttackResPenaltyNeutralization;
    
    private int FollowUpAtk => CurrentAtk + FollowUpAtkBonus - FollowUpAtkPenalty;
    public int FollowUpDef => CurrentDef + FollowUpDefBonus - FollowUpDefPenalty;
    public int FollowUpRes => CurrentRes + FollowUpResBonus - FollowUpResPenalty;
    
    public int GetFirstAttackStat(StatType statType)
    {
        switch (statType)
        {
            case StatType.Atk: return FirstAttackAtk;
            case StatType.Def: return FirstAttackDef;
            case StatType.Res: return FirstAttackRes;
            default: throw new StatNotRecognizedException();
        }
    }
    
    public int GetFollowUpStat(StatType statType)
    {
        switch (statType)
        {
            case StatType.Atk: return FollowUpAtk;
            case StatType.Def: return FollowUpDef;
            case StatType.Res: return FollowUpRes;
            default: throw new StatNotRecognizedException();
        }
    }
    
    public int GetBaseStat(StatType statType)
    {
        switch (statType)
        {
            case StatType.Atk: return BaseAtk;
            case StatType.Spd: return BaseSpd;
            case StatType.Def: return BaseDef;
            case StatType.Res: return BaseRes;
            default: throw new StatNotRecognizedException();
        }
    }
    
    public int GetCurrentStat(StatType statType)
    {
        switch (statType)
        {
            case StatType.Atk: return CurrentAtk;
            case StatType.Spd: return CurrentSpd;
            case StatType.Def: return CurrentDef;
            case StatType.Res: return CurrentRes;
            default: throw new StatNotRecognizedException();
        }
    }
    
    public void ApplyStatBonusEffect(StatType statType, int effectAmount)
    {
        switch (statType)
        {
            case StatType.Atk: AtkBonus += effectAmount; break;
            case StatType.Spd: SpdBonus += effectAmount; break;
            case StatType.Def: DefBonus += effectAmount; break;
            case StatType.Res: ResBonus += effectAmount; break;
            case StatType.Hp: _currentHP += effectAmount; break;
        }
    }
    
    public void ApplyStatPenaltyEffect(StatType statType, int effectAmount)
    {
        switch (statType)
        {
            case StatType.Atk: AtkPenalty += effectAmount; break;
            case StatType.Spd: SpdPenalty += effectAmount; break;
            case StatType.Def: DefPenalty += effectAmount; break;
            case StatType.Res: ResPenalty += effectAmount; break;
        }
    }
    
    public void ApplyFirstAttackStatBonusEffect(StatType statType, int effectAmount)
    {
        switch (statType)
        {
            case StatType.Atk: FirstAttackAtkBonus += effectAmount; break;
            case StatType.Def: FirstAttackDefBonus += effectAmount; break;
            case StatType.Res: FirstAttackResBonus += effectAmount; break;
        }
    }
    
    public void ApplyFirstAttackStatPenaltyEffect(StatType statType, int effectAmount)
    {
        switch (statType)
        {
            case StatType.Atk: FirstAttackAtkPenalty += effectAmount; break;
            case StatType.Def: FirstAttackDefPenalty += effectAmount; break;
            case StatType.Res: FirstAttackResPenalty += effectAmount; break;
        }
    }
    
    public void AddActiveEffect(IEffect effect)
    {
        _effects.Add(effect);
    }
    
    public void ClearActiveEffects()
    {
        _effects.Clear();
    }
    
    public void NeutralizeBonus(StatType statType)
    {
        switch (statType)
        {
            case StatType.Atk:
                AtkBonusNeutralization = AtkBonus;
                FirstAttackAtkBonusNeutralization = FirstAttackAtkBonus;
                break;
            case StatType.Spd:
                SpdBonusNeutralization = SpdBonus;
                break;
            case StatType.Def:
                DefBonusNeutralization = DefBonus;
                FirstAttackDefBonusNeutralization = FirstAttackDefBonus;
                break;
            case StatType.Res:
                ResBonusNeutralization = ResBonus;
                FirstAttackResBonusNeutralization = FirstAttackResBonus;
                break;
        }
    }
    
    public void NeutralizePenalty(StatType statType)
    {
        switch (statType)
        {
            case StatType.Atk:
                AtkPenaltyNeutralization = AtkPenalty;
                FirstAttackAtkPenaltyNeutralization = FirstAttackAtkPenalty;
                break;
            case StatType.Spd:
                SpdPenaltyNeutralization = SpdPenalty;
                break;
            case StatType.Def:
                DefPenaltyNeutralization = DefPenalty;
                FirstAttackDefPenaltyNeutralization = FirstAttackDefPenalty;
                break;
            case StatType.Res:
                ResPenaltyNeutralization = ResPenalty;
                FirstAttackResPenaltyNeutralization = FirstAttackResPenalty;
                break;
        }
    }
    public int ExtraDamage { get; private set; }
    public int FirstAttackExtraDamage { get; private set; }
    public void ApplyExtraDamageEffect(int amount)
        => ExtraDamage += amount;
    
    public void ApplyFirstAttackExtraDamageEffect(int amount)
        =>FirstAttackExtraDamage += amount;
    
    public int AbsoluteDamageReduction { get; private set;}
    
    public double PercentageDamageReduction { get; private set; }
    
    public double FirstAttackPercentageDamageReduction { get; private set; }
    public double FollowUpPercentageDamageReduction { get; private set; }
    
    
    public void ApplyAbsoluteDamageReduction(int amount)
        => AbsoluteDamageReduction += amount;
    
    public void ApplyPercentageDamageReduction(double percentage)
        => PercentageDamageReduction = 1 - (1 - PercentageDamageReduction) * (1 - percentage);
    public void ApplyFirstAttackPercentageDamageReduction(double percentage)
        => FirstAttackPercentageDamageReduction = 1 - (1 - FirstAttackPercentageDamageReduction) * (1 - percentage);
    
    public void ApplyFollowUpPercentageDamageReduction(double percentage)
        => FollowUpPercentageDamageReduction = 1 - (1 - FollowUpPercentageDamageReduction) * (1 - percentage);
    
    public void ResetEffects()
    {
        ResetBonuses();
        ResetPenalties();
        ResetBonusNeutralization();
        ResetPenaltyNeutralization();
        ResetDamageModifiers();
    }

    private void ResetBonuses()
    {
        AtkBonus = 0;
        SpdBonus = 0;
        DefBonus = 0;
        ResBonus = 0;
    }

    private void ResetPenalties()
    {
        AtkPenalty = 0;
        SpdPenalty = 0;
        DefPenalty = 0;
        ResPenalty = 0;
    }

    private void ResetBonusNeutralization()
    {
        AtkBonusNeutralization = 0;
        SpdBonusNeutralization = 0;
        DefBonusNeutralization = 0;
        ResBonusNeutralization = 0;
    }

    private void ResetPenaltyNeutralization()
    {
        AtkPenaltyNeutralization = 0;
        SpdPenaltyNeutralization = 0;
        DefPenaltyNeutralization = 0;
        ResPenaltyNeutralization = 0;
    }

    private void ResetDamageModifiers()
    {
        ExtraDamage = 0;
        AbsoluteDamageReduction = 0;
        PercentageDamageReduction = 0;
        FirstAttackPercentageDamageReduction = 0;
        FollowUpPercentageDamageReduction = 0;
    }

    
    public void ResetFirstAttackBonusStats()
    {
        FirstAttackAtkBonus = 0;
        FirstAttackDefBonus = 0;
        FirstAttackResBonus = 0;
        FirstAttackAtkBonusNeutralization = 0;
        FirstAttackDefBonusNeutralization = 0;
        FirstAttackResBonusNeutralization = 0;
        FirstAttackExtraDamage = 0;
    }
    public void ResetFirstAttackPenaltyStats()
    {
        FirstAttackAtkPenalty = 0;
        FirstAttackDefPenalty = 0;
        FirstAttackResPenalty = 0;
        FirstAttackAtkPenaltyNeutralization = 0;
        FirstAttackDefPenaltyNeutralization = 0;
        FirstAttackResPenaltyNeutralization = 0;
    }
    
    public void ResetFollowUpStats()
    {
        FollowUpAtkBonus = 0;
        FollowUpDefBonus = 0;
        FollowUpResBonus = 0;
        FollowUpAtkPenalty = 0;
        FollowUpDefPenalty = 0;
        FollowUpResPenalty = 0;
    }
    public string Name { get; init; }
    public string Gender { get; init; }
    public string DeathQuote { get; init; }
    public int BaseHp { get; init; }
    public int BaseAtk { get; init; }
    public int BaseSpd { get; init; }
    public int BaseDef { get; init; }
    public int BaseRes { get; init; }
    public Weapon Weapon { get; init; }
}
