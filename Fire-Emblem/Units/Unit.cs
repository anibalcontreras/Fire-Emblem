using Fire_Emblem.Effects;
using Fire_Emblem.Effects.Damage.AbsoluteDamageReduction;
using Fire_Emblem.Effects.Damage.ExtraDamage;
using Fire_Emblem.Effects.Damage.PercentageDamageReduction;
using Fire_Emblem.Effects.Neutralization;
using Fire_Emblem.Skills;
using Fire_Emblem.Stats;

namespace Fire_Emblem.Units;

using Weapons;

public class Unit
{
    public string Name { get; set; }
    public string Gender { get; set; }
    public string DeathQuote { get; set; }
    public int BaseHp { get; set; }
    public int BaseAtk { get; set; }
    public int BaseSpd { get; set; }
    public int BaseDef { get; set; }
    public int BaseRes { get; set; }
    public Weapon Weapon { get; set; }
       
    private List<Skill> _skills = new List<Skill>();

    public IEnumerable<Skill> Skills
        => _skills.AsReadOnly();

    public void AddSkill(Skill skill)
        => _skills.Add(skill);
    
    public Unit LastUnitFaced { get; private set; }
    
    public void SetLastUnitFaced(Unit unit)
    {
        LastUnitFaced = unit;
    }
    
    public bool IsAttacker { get; private set; } = false;
    
    public void SetIsAttacker()
    {
        IsAttacker = true;
    }
    
    public bool ResetIsAttacker()
    {
        return IsAttacker = false;
    }
    
    public bool IsDefender { get; private set; } = false;
    
    public void SetIsDefender()
    {
        IsDefender = true;
    }
    
    public bool ResetIsDefender()
    {
        return IsDefender = false;
    }

    public bool HasActivatedAlterStatBase { get; private set; } = false;
    
    public void SetActivatedAlterStatBase()
    {
        HasActivatedAlterStatBase = true;
    }
    
    public bool HasBeenAttackerBefore { get; private set; } = false;
    public bool HasBeenDefenderBefore { get; private set; } = false;
    
    public void SetHasBeenAttackerBefore()
    {
        HasBeenAttackerBefore = true;
    }
    
    public void SetHasBeenDefenderBefore()
    {
        HasBeenDefenderBefore = true;
    }
    
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

    public int CurrentAtk => BaseAtk + AtkBonus - AtkPenalty - AtkBonusNeutralization + AtkPenaltyNeutralization;
    public int CurrentSpd => BaseSpd + SpdBonus - SpdPenalty - SpdBonusNeutralization + SpdPenaltyNeutralization;
    public int CurrentDef => BaseDef + DefBonus - DefPenalty - DefBonusNeutralization + DefPenaltyNeutralization;
    public int CurrentRes => BaseRes + ResBonus - ResPenalty - ResBonusNeutralization + ResPenaltyNeutralization;
    
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
    
    
    private int FollowUpAtkBonus { get; set; }
    private int FollowUpDefBonus { get; set; }
    private int FollowUpResBonus { get; set; }
    
    private int FollowUpAtkPenalty { get; set; }
    private int FollowUpDefPenalty { get; set; }
    private int FollowUpResPenalty { get; set; }
    
    private int FirstAttackAtkBonusNeutralization { get; set; }
    private int FirstAttackDefBonusNeutralization { get; set; }
    private int FirstAttackResBonusNeutralization { get; set; }
    
    private int FirstAttackAtkPenaltyNeutralization { get; set; }
    private int FirstAttackDefPenaltyNeutralization { get; set; }
    private int FirstAttackResPenaltyNeutralization { get; set; }
    
    
    public int FirstAttackAtk => CurrentAtk + FirstAttackAtkBonus - FirstAttackAtkPenalty - FirstAttackAtkBonusNeutralization + FirstAttackAtkPenaltyNeutralization;
    public int FirstAttackDef => CurrentDef + FirstAttackDefBonus - FirstAttackDefPenalty - FirstAttackDefBonusNeutralization + FirstAttackDefPenaltyNeutralization;
    public int FirstAttackRes => CurrentRes + FirstAttackResBonus - FirstAttackResPenalty - FirstAttackResBonusNeutralization + FirstAttackResPenaltyNeutralization;
    
    public int FollowUpAtk => CurrentAtk + FollowUpAtkBonus - FollowUpAtkPenalty;
    public int FollowUpDef => CurrentDef + FollowUpDefBonus - FollowUpDefPenalty;
    public int FollowUpRes => CurrentRes + FollowUpResBonus - FollowUpResPenalty;
    
    
    public void ApplyStatBonusEffect(StatType statType, int effectAmount)
    {
        switch (statType)
        {
            case StatType.Atk:
                AtkBonus += effectAmount;
                break;
            case StatType.Spd:
                SpdBonus += effectAmount;
                break;
            case StatType.Def:
                DefBonus += effectAmount;
                break;
            case StatType.Res:
                ResBonus += effectAmount;
                break;
            case StatType.HP:
                _currentHP += effectAmount;
                break;
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
            default: throw new ArgumentException($"Stat '{statType}' is not recognized.");
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
            default: throw new ArgumentException($"Stat '{statType}' is not recognized.");
        }
    }
    
    public void ApplyStatPenaltyEffect(StatType statType, int effectAmount)
    {
        switch (statType)
        {
            case StatType.Atk:
                AtkPenalty += effectAmount;
                break;
            case StatType.Spd:
                SpdPenalty += effectAmount;
                break;
            case StatType.Def:
                DefPenalty += effectAmount;
                break;
            case StatType.Res:
                ResPenalty += effectAmount;
                break;
        }
    }
    
    public void ApplyFirstAttackStatBonusEffect(StatType statType, int effectAmount)
    {
        switch (statType)
        {
            case StatType.Atk:
                FirstAttackAtkBonus += effectAmount;
                break;
            case StatType.Def:
                FirstAttackDefBonus += effectAmount;
                break;
            case StatType.Res:
                FirstAttackResBonus += effectAmount;
                break;
            default:
                throw new ArgumentException($"Stat '{statType}' is not recognized.");
        }
    }
    
    public void ApplyFirstAttackStatPenaltyEffect(StatType statType, int effectAmount)
    {
        switch (statType)
        {
            case StatType.Atk:
                FirstAttackAtkPenalty += effectAmount;
                break;
            case StatType.Def:
                FirstAttackDefPenalty += effectAmount;
                break;
            case StatType.Res:
                FirstAttackResPenalty += effectAmount;
                break;
            default:
                throw new ArgumentException($"Stat '{statType}' is not recognized.");
        }
    }
    
    private List<IEffect> _effects = new List<IEffect>();

    private IEnumerable<IEffect> Effects => _effects.AsReadOnly();
    
    public void AddActiveEffect(IEffect effect)
    {
        _effects.Add(effect);
    }
    
    public void ClearActiveEffects()
    {
        _effects.Clear();
    }
    
    public bool HasActiveExtraDamageEffect()
    {
        return Effects.Any(effect => effect is IExtraDamageEffect); 
    }
    
    public bool HasActiveFirstAttackExtraDamageEffect()
    {
        return Effects.Any(effect => effect is IFirstAttackExtraDamageEffect);
    }

    public bool HasActiveAbsoluteDamageReductionEffect()
    {
        return Effects.Any(effect => effect is IAbsoluteDamageReductionEffect);
    }
    
    public bool HasActivePercentageDamageReductionEffect()
    {
        return Effects.Any(effect => effect is IPercentageDamageReductionEffect);
    }
    
    public bool HasActiveFirstAttackPercentageDamageReductionEffect()
    {
        return Effects.Any(effect => effect is FirstAttackPercentageDamageReductionEffect);
    }
    
    public bool HasActiveFollowUpPercentageDamageReductionEffect()
    {
        return Effects.Any(effect => effect is FollowUpPercentageDamageReductionEffect);
    }
    
    public bool HasActiveNeutralizationPenalty(StatType statType)
    {
        return Effects.Any(effect => effect is NeutralizationPenaltyEffect penalty && penalty.StatType == statType);
    }
    
    public bool HasActiveNeutralizationBonus(StatType statType)
    {
        return Effects.Any(effect => effect is NeutralizationBonusEffect bonus && bonus.StatType == statType);
    }
    
    public bool HasActiveBonus(StatType statType)
    {
        return Effects.Any(effect => effect is IBonusEffect bonus && bonus.StatType == statType && bonus.Amount > 0);
    }
    
    public bool HasActiveFirstAttackBonus(StatType statType)
    {
        return Effects.Any(effect => effect is FirstAttackBonusEffect bonus && bonus.StatType == statType && bonus.Amount > 0);
    }
    
    public bool HasActiveFirstAttackPenalty(StatType statType)
    {
        return Effects.Any(effect => effect is FirstAttackPenaltyEffect penalty && penalty.StatType == statType && penalty.Amount > 0);
    }

    // Replicar los bools para todos los efectos
    
    public bool HasActivePenalty(StatType statType)
    {
        return Effects.Any(effect => effect is IPenaltyEffect penalty && penalty.StatType == statType && penalty.Amount > 0);
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
    {
        ExtraDamage += amount;
    }
    
    public void ApplyFirstAttackExtraDamageEffect(int amount)
    {
        FirstAttackExtraDamage += amount;
    }
    
    public int AbsoluteDamageReduction { get; private set; }
    
    public double PercentageDamageReduction { get; private set; }
    
    public double FirstAttackPercentageDamageReduction { get; private set; }
    public double FollowUpPercentageDamageReduction { get; private set; }
    
    
    public void ApplyAbsoluteDamageReductionEffect(int amount)
    {
        AbsoluteDamageReduction += amount;
    }
    
    public void ApplyPercentageDamageReductionEffect(double percentage)
    {
        PercentageDamageReduction = 1 - (1 - PercentageDamageReduction) * (1 - percentage);
    }
    public void ApplyFirstAttackPercentageDamageReductionEffect(double percentage)
    {
        FirstAttackPercentageDamageReduction = 1 - (1 - FirstAttackPercentageDamageReduction) * (1 - percentage);
    }
    
    public void ApplyFollowUpPercentageDamageReductionEffect(double percentage)
    {
        FollowUpPercentageDamageReduction = 1 - (1 - FollowUpPercentageDamageReduction) * (1 - percentage);
    }
    
    public void ResetEffects()
    {
        AtkBonus = 0;
        SpdBonus = 0;
        DefBonus = 0;
        ResBonus = 0;
        AtkPenalty = 0;
        SpdPenalty = 0;
        DefPenalty = 0;
        ResPenalty = 0;
        AtkBonusNeutralization = 0;
        SpdBonusNeutralization = 0;
        DefBonusNeutralization = 0;
        ResBonusNeutralization = 0;
        AtkPenaltyNeutralization = 0;
        SpdPenaltyNeutralization = 0;
        DefPenaltyNeutralization = 0;
        ResPenaltyNeutralization = 0;
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
}
