using Fire_Emblem.Effects;
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
    
    public int AtkBonus { get; private set; } = 0;
    public int SpdBonus { get; private set; } = 0;
    public int DefBonus { get; private set; } = 0;
    public int ResBonus { get; private set; } = 0;
    
    private int AtkBonusNeutralization { get; set; } = 0;
    private int SpdBonusNeutralization { get; set; } = 0;
    private int DefBonusNeutralization { get; set; } = 0;
    private int ResBonusNeutralization { get; set; } = 0;
    
    private int AtkPenaltyNeutralization { get; set; } = 0;
    private int SpdPenaltyNeutralization { get; set; } = 0;
    private int DefPenaltyNeutralization { get; set; } = 0;
    private int ResPenaltyNeutralization { get; set; } = 0;
    
    
    public int AtkPenalty { get; set; } = 0;
    public int SpdPenalty { get; set; } = 0;
    public int DefPenalty { get; set; } = 0;
    public int ResPenalty { get; set; } = 0;
    
    
    private int CurrentAtk => BaseAtk + AtkBonus - AtkPenalty - AtkBonusNeutralization + AtkPenaltyNeutralization;
    public int CurrentSpd => BaseSpd + SpdBonus - SpdPenalty - SpdBonusNeutralization + SpdPenaltyNeutralization;
    private int CurrentDef => BaseDef + DefBonus - DefPenalty - DefBonusNeutralization + DefPenaltyNeutralization;
    private int CurrentRes => BaseRes + ResBonus - ResPenalty - ResBonusNeutralization + ResPenaltyNeutralization;
    
    
    public Weapon Weapon { get; set; }
    
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
    
    public void ApplyStatBonusEffect(StatType statType, int effectAmount)
    {
        switch (statType)
        {
            case StatType.HP:
                BaseHp += effectAmount;
                break;
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
            default:
                throw new ArgumentException($"Stat '{statType}' is not recognized.");
        }
    }
    
    public void ApplyStatPenaltyEffect(StatType statType, int effectAmount)
    {
        switch (statType)
        {
            case StatType.HP:
                BaseHp -= effectAmount;
                break;
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
            default:
                throw new ArgumentException($"Stat '{statType}' is not recognized.");
        }
    }
    
    public void ResetStatBonuses()
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
    }
    
    private List<Skill> _skills = new List<Skill>();

    public IEnumerable<Skill> Skills
        => _skills.AsReadOnly();

    public void AddSkill(Skill skill)
        => _skills.Add(skill);
    
    public int CalculateDamage(Unit opponent)
    {
        int defenseValue = Weapon is Magic ? Convert.ToInt32(opponent.CurrentRes) : Convert.ToInt32(opponent.CurrentDef);
        double damage = (Convert.ToDouble(CurrentAtk) * Convert.ToDouble(Weapon.GetWTB(opponent.Weapon))) - defenseValue;
        opponent.CurrentHP -= (int)Math.Max(0, Math.Truncate(damage));
        
        return (int)Math.Max(0, Math.Truncate(damage));
    }
    
    private List<IEffect> _effects = new List<IEffect>();

    public IEnumerable<IEffect> Effects => _effects.AsReadOnly();
    
    public void AddActiveEffect(IEffect effect)
    {
        _effects.Add(effect);
    }
    
    public void ClearActiveEffects()
    {
        _effects.Clear();
    }
    
    public bool HasActiveBonus(StatType statType)
    {
        return Effects.Any(effect => effect is IBonusEffect bonus && bonus.StatType == statType && bonus.Amount > 0);
    }

    public bool HasActivePenalty(StatType statType)
    {
        return Effects.Any(effect => effect is PenaltyEffect penalty && penalty.StatType == statType && penalty.Amount > 0);
    }
    
    public bool HasNeutralizationBonus
    {
        get { return _effects.Any(effect => effect is NeutralizationBonusEffect); }
    }
    
    public bool HasNeutralizationPenalty
    {
        get { return _effects.Any(effect => effect is NeutralizationPenaltyEffect); }
    }
    
    public void NeutralizeBonus()
    {
        AtkBonusNeutralization = AtkBonus;
        SpdBonusNeutralization = SpdBonus;
        DefBonusNeutralization = DefBonus;
        ResBonusNeutralization = ResBonus;
    }

    public void NeutralizePenalty()
    {
        AtkPenaltyNeutralization = AtkPenalty;
        SpdPenaltyNeutralization = SpdPenalty;
        DefPenaltyNeutralization = DefPenalty;
        ResPenaltyNeutralization = ResPenalty;
    }
}
