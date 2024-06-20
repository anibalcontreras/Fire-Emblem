using Fire_Emblem.Effects;
using Fire_Emblem.Effects.FollowUp;
using Fire_Emblem.Effects.Neutralization;
using Fire_Emblem.Exception;
using Fire_Emblem.Skills;
using Fire_Emblem.Stats;
using Fire_Emblem.Weapons;

namespace Fire_Emblem.Units;

public class Unit
{
    public string Name { get; init; }
    public string Gender { get; init; }
    public string DeathQuote { get; init; }
    public int BaseHp { get; init; }
    public int BaseAtk { get; init; }
    public int BaseSpd { get; init; }
    public int BaseDef { get; init; }
    public int BaseRes { get; init; }
    public Weapon Weapon { get; init; }

    private readonly List<Skill> _skills = new();

    public IEnumerable<Skill> Skills
        => _skills.AsReadOnly();

    public void AddSkill(Skill skill)
        => _skills.Add(skill);
    
    private readonly List<Unit> _allies = new();
    public void AddAlly(Unit ally)
        => _allies.Add(ally);
    
    public void RemoveAllAllies()
        => _allies.Clear();
    
    public bool HaveAllies => _allies.Count > 0;
        
    

    private readonly List<IEffect> _effects = new();
    private IEnumerable<IEffect> Effects => _effects.AsReadOnly();

    public void AddActiveEffect(IEffect effect)
        => _effects.Add(effect);

    public void ClearActiveEffects()
        => _effects.Clear();

    private int _currentHP;

    public int CurrentHP
    {
        get { return _currentHP; }
        set { _currentHP = Math.Max(0, value); }
    }

    public void InitializeCurrentHp()
        => _currentHP = BaseHp;

    public int AtkBonus { get; private set; }
    public int AtkPenalty { get; private set; }
    private int AtkBonusNeutralization { get; set; }
    private int AtkPenaltyNeutralization { get; set; }

    private int CurrentAtk => BaseAtk + AtkBonus - AtkPenalty -
        AtkBonusNeutralization + AtkPenaltyNeutralization;

    public int SpdBonus { get; private set; }
    public int SpdPenalty { get; private set; }
    private int SpdBonusNeutralization { get; set; }
    private int SpdPenaltyNeutralization { get; set; }

    private int CurrentSpd => BaseSpd + SpdBonus - SpdPenalty -
        SpdBonusNeutralization + SpdPenaltyNeutralization;

    public int DefBonus { get; private set; }
    public int DefPenalty { get; private set; }
    private int DefBonusNeutralization { get; set; }
    private int DefPenaltyNeutralization { get; set; }

    private int CurrentDef => BaseDef + DefBonus - DefPenalty -
        DefBonusNeutralization + DefPenaltyNeutralization;

    public int ResBonus { get; private set; }
    public int ResPenalty { get; private set; }
    private int ResBonusNeutralization { get; set; }
    private int ResPenaltyNeutralization { get; set; }

    private int CurrentRes => BaseRes + ResBonus - ResPenalty -
        ResBonusNeutralization + ResPenaltyNeutralization;

    public int FirstAttackAtkBonus { get; private set; }
    public int FirstAttackAtkPenalty { get; private set; }
    private int FirstAttackAtkBonusNeutralization { get; set; }
    private int FirstAttackAtkPenaltyNeutralization { get; set; }

    private int FirstAttackAtk => CurrentAtk + FirstAttackAtkBonus - FirstAttackAtkPenalty -
        FirstAttackAtkBonusNeutralization + FirstAttackAtkPenaltyNeutralization;

    public int FirstAttackDefBonus { get; private set; }
    public int FirstAttackDefPenalty { get; private set; }
    private int FirstAttackDefBonusNeutralization { get; set; }
    private int FirstAttackDefPenaltyNeutralization { get; set; }

    private int FirstAttackDef => CurrentDef + FirstAttackDefBonus - FirstAttackDefPenalty -
        FirstAttackDefBonusNeutralization + FirstAttackDefPenaltyNeutralization;

    public int FirstAttackResBonus { get; private set; }
    public int FirstAttackResPenalty { get; private set; }
    private int FirstAttackResBonusNeutralization { get; set; }
    private int FirstAttackResPenaltyNeutralization { get; set; }

    private int FirstAttackRes => CurrentRes + FirstAttackResBonus - FirstAttackResPenalty -
        FirstAttackResBonusNeutralization + FirstAttackResPenaltyNeutralization;

    private int FollowUpAtkBonus { get; set; }
    private int FollowUpAtkPenalty { get; set; }
    private int FollowUpAtk => CurrentAtk + FollowUpAtkBonus - FollowUpAtkPenalty;

    private int FollowUpDefBonus { get; set; }
    private int FollowUpDefPenalty { get; set; }
    public int FollowUpDef => CurrentDef + FollowUpDefBonus - FollowUpDefPenalty;

    private int FollowUpResBonus { get; set; }
    private int FollowUpResPenalty { get; set; }
    public int FollowUpRes => CurrentRes + FollowUpResBonus - FollowUpResPenalty;

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
    
    public int QuantityOfActiveGuaranteeFollowUpEffects
    {
        get
        {
            return Effects.Count(effect => effect is FollowUpGuaranteeEffect);
        }
    }
    

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

    public void ApplyStatBonus(StatType statType, int bonusAmount)
    {
        switch (statType)
        {
            case StatType.Atk:
                AtkBonus += bonusAmount;
                break;
            case StatType.Spd:
                SpdBonus += bonusAmount;
                break;
            case StatType.Def:
                DefBonus += bonusAmount;
                break;
            case StatType.Res:
                ResBonus += bonusAmount;
                break;
            case StatType.Hp:
                _currentHP += bonusAmount;
                break;
        }
    }

    public void ApplyStatPenalty(StatType statType, int penaltyAmount)
    {
        switch (statType)
        {
            case StatType.Atk:
                AtkPenalty += penaltyAmount;
                break;
            case StatType.Spd:
                SpdPenalty += penaltyAmount;
                break;
            case StatType.Def:
                DefPenalty += penaltyAmount;
                break;
            case StatType.Res:
                ResPenalty += penaltyAmount;
                break;
        }
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

    public void ApplyFirstAttackStatBonus(StatType statType, int bonusAmount)
    {
        switch (statType)
        {
            case StatType.Atk:
                FirstAttackAtkBonus += bonusAmount;
                break;
            case StatType.Def:
                FirstAttackDefBonus += bonusAmount;
                break;
            case StatType.Res:
                FirstAttackResBonus += bonusAmount;
                break;
        }
    }

    public void ApplyFirstAttackStatPenalty(StatType statType, int penaltyAmount)
    {
        switch (statType)
        {
            case StatType.Atk:
                FirstAttackAtkPenalty += penaltyAmount;
                break;
            case StatType.Def:
                FirstAttackDefPenalty += penaltyAmount;
                break;
            case StatType.Res:
                FirstAttackResPenalty += penaltyAmount;
                break;
        }
    }

    public int ExtraDamage { get; private set; }

    public void ApplyExtraDamageEffect(int amount)
        => ExtraDamage += amount;

    public int FirstAttackExtraDamage { get; private set; }

    public void ApplyFirstAttackExtraDamageEffect(int amount)
        => FirstAttackExtraDamage += amount;

    public int AbsoluteDamageReduction { get; private set; }

    public void ApplyAbsoluteDamageReduction(int amount)
        => AbsoluteDamageReduction += amount;

    public double PercentageDamageReduction { get; private set; }

    public void ApplyPercentageDamageReduction(double percentage)
        => PercentageDamageReduction = 1 - (1 - PercentageDamageReduction) * (1 - percentage);

    public double FirstAttackPercentageDamageReduction { get; private set; }

    public void ApplyFirstAttackPercentageDamageReduction(double percentage)
        => FirstAttackPercentageDamageReduction = 1 - (1 - FirstAttackPercentageDamageReduction) * (1 - percentage);

    public double FollowUpPercentageDamageReduction { get; private set; }

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

    public int FinalCausedDamage { get; private set; }

    public void SetFinalCausedDamage(int damage)
        => FinalCausedDamage = damage;

    public void ResetFinalCausedDamage()
        => FinalCausedDamage = 0;

    public double HealingPercentage { get; private set; }

    public void ApplyPercentageHealing(double percentage)
        => HealingPercentage += percentage;
    
    public void ResetHealingPercentage()
        => HealingPercentage = 0;
    
    public bool HasNullifiedCounterattack { get; private set; }

    public void SetNullifyCounterattack()
        => HasNullifiedCounterattack = true;

    public void ResetNullifyCounterattack()
        => HasNullifiedCounterattack = false;

    public bool HasNullifiedNullifiedCounterattack { get; private set; }

    public void SetNullifyNullifiedCounterattack()
        => HasNullifiedNullifiedCounterattack = true;

    public void ResetNullifyNullifiedCounterattack()
        => HasNullifiedNullifiedCounterattack = false;

    public bool HasUnitExecutedAStrike { get; private set; }

    public void SetUnitExecuteAStrike()
        => HasUnitExecutedAStrike = true;

    public void ResetUnitExecuteAStrike()
        => HasUnitExecutedAStrike = false;
    
    private int HealingAfterCombat { get; set; }
    private int DamageAfterCombat { get; set; }
    
    public int StatAfterCombat => HealingAfterCombat - DamageAfterCombat;

    public void ApplyHealingAfterCombat(int amount)
    {
        HealingAfterCombat += amount;
        _currentHP = Math.Min(BaseHp, _currentHP + HealingAfterCombat);
    }
    
    public void ApplyDamageAfterCombat(int amount)
    {
        DamageAfterCombat += amount;
        _currentHP = Math.Max(1, _currentHP - DamageAfterCombat);
    }

    public void ResetStatOutOfCombat()
    {
        HealingAfterCombat = 0;
        DamageAfterCombat = 0;
    }
    
    public int DamageBeforeCombat { get; private set; }
    
    public void ApplyDamageBeforeCombat(int amount)
    {
        DamageBeforeCombat += amount;
        _currentHP = Math.Max(1, _currentHP - DamageBeforeCombat);
    }
    public void ResetDamageBeforeCombat()
        => DamageBeforeCombat = 0;
    
    public bool FollowUpGuaranteed { get; private set; }
    
    public void SetFollowUpGuaranteed()
        => FollowUpGuaranteed = true;
    
    public void ResetFollowUpGuaranteed()
        => FollowUpGuaranteed = false;
    
}
