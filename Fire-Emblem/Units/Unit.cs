using Fire_Emblem.Effects;
using Fire_Emblem.Effects.FollowUp;
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
    public SkillCollection Skills { get; } = new();
    public Allies Allies { get; } = new();
    public EffectCollection Effects { get; } = new();
    private int _currentHP;
    public int AtkBonus { get; private set; }
    public int AtkPenalty { get; private set; }
    public int AtkBonusNeutralization { get; private set; }
    public int AtkPenaltyNeutralization { get; private set; }
    public int SpdBonus { get; private set; }
    public int SpdPenalty { get; private set; }
    public int SpdBonusNeutralization { get; private set; }
    public int SpdPenaltyNeutralization { get; private set; }
    public int DefBonus { get; private set; }
    public int DefPenalty { get; private set; }
    public int DefBonusNeutralization { get; private set; }
    public int DefPenaltyNeutralization { get; private set; }
    public int ResBonus { get; private set; }
    public int ResPenalty { get; private set; }
    public int ResBonusNeutralization { get; private set; }
    public int ResPenaltyNeutralization { get; private set; }
    public int FirstAttackAtkBonus { get; private set; }
    public int FirstAttackAtkPenalty { get; private set; }
    private int _firstAttackAtkBonusNeutralization { get; set; }
    private int _firstAttackAtkPenaltyNeutralization { get; set; }
    public int FirstAttackDefBonus { get; private set; }
    public int FirstAttackDefPenalty { get; private set; }
    private int _firstAttackDefBonusNeutralization { get; set; }
    private int _firstAttackDefPenaltyNeutralization { get; set; }
    public int FirstAttackResBonus { get; private set; }
    public int FirstAttackResPenalty { get; private set; }
    private int _firstAttackResBonusNeutralization { get; set; }
    private int _firstAttackResPenaltyNeutralization { get; set; }
    private int _followUpAtkBonus { get; set; }
    private int _followUpAtkPenalty { get; set; }
    private int _followUpDefBonus { get; set; }
    private int _followUpDefPenalty { get; set; }
    private int _followUpResBonus { get; set; }
    private int _followUpResPenalty { get; set; }
    public int ExtraDamage { get; private set; }
    public int FirstAttackExtraDamage { get; private set; }
    public int AbsoluteDamageReduction { get; private set; }
    private double _percentageDamageReductionReduction { get; set; } = 1;
    public double PercentageDamageReduction { get; private set; }
    public double FirstAttackPercentageDamageReduction { get; private set; }
    public double FollowUpPercentageDamageReduction { get; private set; }
    public Unit LastUnitFaced { get; private set; }
    public bool IsAttacker { get; private set; }
    public bool HasActivatedAlterStatBase { get; private set; }
    public bool HasBeenAttackerBefore { get; private set; }
    public bool HasBeenDefenderBefore { get; private set; }
    public int StartOfCombatHp { get; private set; }
    public int FinalCausedDamage { get; private set; }
    public double HealingPercentage { get; private set; }
    public bool HasNullifiedCounterattack { get; private set; }
    public bool HasNullifiedNullifiedCounterattack { get; private set; }
    public bool HasUnitExecutedAStrike { get; private set; }
    private int _healingAfterCombat;
    private int _damageAfterCombat;
    public int DamageBeforeCombat { get; private set; }
    public bool HasFollowUpGuaranteed { get; private set; }
    public bool HasDenialFollowUpGuaranteed { get; private set; }
    public bool HasDenialFollowUp { get; private set; }
    public bool HasDenialOfDenialFollowUp { get; private set; }
    private int _currentAtk => BaseAtk + AtkBonus - AtkPenalty -
        AtkBonusNeutralization + AtkPenaltyNeutralization;

    private int _currentSpd => BaseSpd + SpdBonus - SpdPenalty -
        SpdBonusNeutralization + SpdPenaltyNeutralization;
    
    private int _currentDef => BaseDef + DefBonus - DefPenalty -
        DefBonusNeutralization + DefPenaltyNeutralization;
    
    private int _currentRes => BaseRes + ResBonus - ResPenalty -
        ResBonusNeutralization + ResPenaltyNeutralization;
    
    private int _firstAttackAtk => _currentAtk + FirstAttackAtkBonus - FirstAttackAtkPenalty -
        _firstAttackAtkBonusNeutralization + _firstAttackAtkPenaltyNeutralization;
    
    private int _firstAttackDef => _currentDef + FirstAttackDefBonus - FirstAttackDefPenalty -
        _firstAttackDefBonusNeutralization + _firstAttackDefPenaltyNeutralization;
    
    private int _firstAttackRes => _currentRes + FirstAttackResBonus - FirstAttackResPenalty -
        _firstAttackResBonusNeutralization + _firstAttackResPenaltyNeutralization;
    
    private int _followUpAtk => _currentAtk + _followUpAtkBonus - _followUpAtkPenalty;
    
    private int _followUpDef => _currentDef + _followUpDefBonus - _followUpDefPenalty;
    
    private int _followUpRes => _currentRes + _followUpResBonus - _followUpResPenalty;
    public int StatAfterCombat => _healingAfterCombat - _damageAfterCombat;
    
    public void InitializeCurrentHp()
        => _currentHP = BaseHp;
    
    public int CurrentHP
    {
        get { return _currentHP; }
        private set { _currentHP = value; }
    }
    
    public void IncreaseCurrentHpDueHealing(int healing)
    {
        _currentHP += healing;
        if (_currentHP > BaseHp)
            _currentHP = BaseHp;
    }
    
    public void DecreaseCurrentHpDueDamage(int value)
    {
        CurrentHP = Math.Max(0, _currentHP - value);
    }
    
    public void SetStartOfCombatHp()
        => StartOfCombatHp = _currentHP;
    
    public int GetFirstAttackStat(StatType statType)
    {
        switch (statType)
        {
            case StatType.Atk: return _firstAttackAtk;
            case StatType.Def: return _firstAttackDef;
            case StatType.Res: return _firstAttackRes;
            default: throw new StatNotRecognizedForRetrieveException(statType);
        }
    }

    public int GetFollowUpStat(StatType statType)
    {
        switch (statType)
        {
            case StatType.Atk: return _followUpAtk;
            case StatType.Def: return _followUpDef;
            case StatType.Res: return _followUpRes;
            default: throw new StatNotRecognizedForRetrieveException(statType);
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
            default: throw new StatNotRecognizedForRetrieveException(statType);
        }
    }

    public int GetCurrentStat(StatType statType)
    {
        switch (statType)
        {
            case StatType.Atk: return _currentAtk;
            case StatType.Spd: return _currentSpd;
            case StatType.Def: return _currentDef;
            case StatType.Res: return _currentRes;
            default: throw new StatNotRecognizedForRetrieveException(statType);
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
                _firstAttackAtkBonusNeutralization = FirstAttackAtkBonus;
                break;
            case StatType.Spd:
                SpdBonusNeutralization = SpdBonus;
                break;
            case StatType.Def:
                DefBonusNeutralization = DefBonus;
                _firstAttackDefBonusNeutralization = FirstAttackDefBonus;
                break;
            case StatType.Res:
                ResBonusNeutralization = ResBonus;
                _firstAttackResBonusNeutralization = FirstAttackResBonus;
                break;
        }
    }

    public void NeutralizePenalty(StatType statType)
    {
        switch (statType)
        {
            case StatType.Atk:
                AtkPenaltyNeutralization = AtkPenalty;
                _firstAttackAtkPenaltyNeutralization = FirstAttackAtkPenalty;
                break;
            case StatType.Spd:
                SpdPenaltyNeutralization = SpdPenalty;
                break;
            case StatType.Def:
                DefPenaltyNeutralization = DefPenalty;
                _firstAttackDefPenaltyNeutralization = FirstAttackDefPenalty;
                break;
            case StatType.Res:
                ResPenaltyNeutralization = ResPenalty;
                _firstAttackResPenaltyNeutralization = FirstAttackResPenalty;
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
    
    public void ApplyExtraDamageEffect(int amount)
        => ExtraDamage += amount;
    
    public void ApplyFirstAttackExtraDamageEffect(int amount)
        => FirstAttackExtraDamage += amount;
    
    public void ApplyAbsoluteDamageReduction(int amount)
        => AbsoluteDamageReduction += amount;
    
    public void SetPercentageDamageReductionReduction(double percentage)
        => _percentageDamageReductionReduction = percentage;
    
    private void ResetPercentageDamageReductionReduction()
        => _percentageDamageReductionReduction = 1;
    
    public void ApplyPercentageDamageReduction(double percentage)
    {
        PercentageDamageReduction = 1 - (1 - PercentageDamageReduction) * (1 - percentage);
        PercentageDamageReduction *= _percentageDamageReductionReduction;    
    }
    
    public void ApplyFirstAttackPercentageDamageReduction(double percentage)
    {
        FirstAttackPercentageDamageReduction = 1 - (1 - FirstAttackPercentageDamageReduction) * (1 - percentage);
        FirstAttackPercentageDamageReduction *= _percentageDamageReductionReduction;
    }

    public void ApplyFollowUpPercentageDamageReduction(double percentage)
    {
        FollowUpPercentageDamageReduction = 1 - (1 - FollowUpPercentageDamageReduction) * (1 - percentage);
        FollowUpPercentageDamageReduction *= _percentageDamageReductionReduction;
    }
    
    public void SetLastUnitFaced(Unit unit)
        => LastUnitFaced = unit;
    
    public void SetIsAttacker()
        => IsAttacker = true;
    
    public void SetActivatedAlterStatBase()
        => HasActivatedAlterStatBase = true;
    
    public void SetHasBeenAttackerBefore()
        => HasBeenAttackerBefore = true;

    public void SetHasBeenDefenderBefore()
        => HasBeenDefenderBefore = true;

    public void SetFinalCausedDamage(int damage)
        => FinalCausedDamage = damage;
    
    public void ApplyPercentageHealing(double percentage)
        => HealingPercentage += percentage;
    
    public void SetNullifyCounterattack()
        => HasNullifiedCounterattack = true;

    public void SetNullifyNullifiedCounterattack()
        => HasNullifiedNullifiedCounterattack = true;
    
    public void SetUnitExecuteAStrike()
        => HasUnitExecutedAStrike = true;
    
    public void ApplyHealingAfterCombat(int amount)
    {
        _currentHP = Math.Min(BaseHp, _currentHP + amount);
        _healingAfterCombat += amount;
    }
    
    public void ApplyDamageAfterCombat(int amount)
    {
        _currentHP = Math.Max(1, _currentHP - amount);
        _damageAfterCombat += amount;
    }
    
    public void ApplyDamageBeforeCombat(int amount)
    {
        _currentHP = Math.Max(1, _currentHP - amount);
        DamageBeforeCombat += amount;
    }
    
    public void SetFollowUpGuaranteed()
        => HasFollowUpGuaranteed = true;
    
    public void SetDenialFollowUpGuaranteed()
        => HasDenialFollowUpGuaranteed = true;
    
    public int QuantityOfActiveGuaranteeFollowUpEffects
    {
        get { return Effects.Items.Count(effect => effect is FollowUpGuaranteeEffect); }
    }
    public int QuantityOfActiveDenialFollowUpEffects
    {
        get { return Effects.Items.Count(effect => effect is DenialFollowUpEffect); }
    }
    
    public void SetDenialFollowUp()
        => HasDenialFollowUp = true;
    
    
    public void SetDenialOfDenialFollowUp()
        => HasDenialOfDenialFollowUp = true;
    
    public void ResetStatEffects()
    {
        ResetBonuses();
        ResetFirstAttackBonusStats();
        ResetPenalties();
        ResetFirstAttackPenaltyStats();
        ResetDamageModifiers();
    }

    private void ResetBonuses()
    {
        AtkBonus = 0;
        SpdBonus = 0;
        DefBonus = 0;
        ResBonus = 0;
        AtkBonusNeutralization = 0;
        SpdBonusNeutralization = 0;
        DefBonusNeutralization = 0;
        ResBonusNeutralization = 0;
    }
    
    private void ResetFirstAttackBonusStats()
    {
        FirstAttackAtkBonus = 0;
        FirstAttackDefBonus = 0;
        FirstAttackResBonus = 0;
        _firstAttackAtkBonusNeutralization = 0;
        _firstAttackDefBonusNeutralization = 0;
        _firstAttackResBonusNeutralization = 0;
        FirstAttackExtraDamage = 0;
    }

    private void ResetPenalties()
    {
        AtkPenalty = 0;
        SpdPenalty = 0;
        DefPenalty = 0;
        ResPenalty = 0;
        AtkPenaltyNeutralization = 0;
        SpdPenaltyNeutralization = 0;
        DefPenaltyNeutralization = 0;
        ResPenaltyNeutralization = 0;
    }
    
    private void ResetFirstAttackPenaltyStats()
    {
        FirstAttackAtkPenalty = 0;
        FirstAttackDefPenalty = 0;
        FirstAttackResPenalty = 0;
        _firstAttackAtkPenaltyNeutralization = 0;
        _firstAttackDefPenaltyNeutralization = 0;
        _firstAttackResPenaltyNeutralization = 0;
    }
    
    private void ResetDamageModifiers()
    {
        ExtraDamage = 0;
        AbsoluteDamageReduction = 0;
        PercentageDamageReduction = 0;
        FirstAttackPercentageDamageReduction = 0;
        FollowUpPercentageDamageReduction = 0;
    }
    
    public void ResetGameConditions()
    {
        ResetFinalCausedDamage();
        ResetHealingPercentage();
        ResetNullifyCounterattack();
        ResetNullifyNullifiedCounterattack();
        ResetUnitExecuteAStrike();
        ResetStatOutOfCombat();
        ResetDamageBeforeCombat();
        ResetFollowUpGuaranteed();
        ResetDenialFollowUpGuaranteed();
        ResetDenialFollowUp();
        ResetDenialOfDenialFollowUp();
        ResetPercentageDamageReductionReduction();
    }

    public void ResetFinalCausedDamage()
        => FinalCausedDamage = 0;
    
    public void ResetHealingPercentage()
        => HealingPercentage = 0;
    
    private void ResetNullifyCounterattack()
        => HasNullifiedCounterattack = false;
    
    private void ResetNullifyNullifiedCounterattack()
        => HasNullifiedNullifiedCounterattack = false;
    
    private void ResetUnitExecuteAStrike()
        => HasUnitExecutedAStrike = false;
    
    private void ResetDamageBeforeCombat()
        => DamageBeforeCombat = 0;
    private void ResetStatOutOfCombat()
    {
        _healingAfterCombat = 0;
        _damageAfterCombat = 0;
    }
    
    public void ResetIsAttacker()
        => IsAttacker = false;
    
    private void ResetFollowUpGuaranteed()
        => HasFollowUpGuaranteed = false;

    private void ResetDenialFollowUpGuaranteed()
        => HasDenialFollowUpGuaranteed = false;
    
    private void ResetDenialFollowUp()
        => HasDenialFollowUp = false;
    
    private void ResetDenialOfDenialFollowUp()
        => HasDenialOfDenialFollowUp = false;
    
    public void ResetFollowUpStats()
    {
        _followUpAtkBonus = 0;
        _followUpDefBonus = 0;
        _followUpResBonus = 0;
        _followUpAtkPenalty = 0;
        _followUpDefPenalty = 0;
        _followUpResPenalty = 0;
    }
}
