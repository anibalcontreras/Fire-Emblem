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
    
    public int AtkPenalty { get; set; } = 0;
    public int SpdPenalty { get; set; } = 0;
    public int DefPenalty { get; set; } = 0;
    public int ResPenalty { get; set; } = 0;
    
    private int CurrentAtk => BaseAtk + AtkBonus - AtkPenalty;
    public int CurrentSpd => BaseSpd + SpdBonus - SpdPenalty;
    private int CurrentDef => BaseDef + DefBonus - DefPenalty;
    private int CurrentRes => BaseRes + ResBonus - ResPenalty;
    
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
    
    public void ApplyStatBonusAndPenaltyEffect(StatType statType, int effectAmount)
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
    
    // public int GetStatBonus(StatType statType)
    // {
    //     return statType switch
    //     {
    //         StatType.Atk => AtkBonus,
    //         StatType.Spd => SpdBonus,
    //         StatType.Def => DefBonus,
    //         StatType.Res => ResBonus,
    //         _ => throw new ArgumentException("Unsupported stat type.")
    //     };
    // }
    //
    // public int GetStatPenalty(StatType statType)
    // {
    //     return statType switch
    //     {
    //         StatType.Atk => AtkPenalty,
    //         StatType.Spd => SpdPenalty,
    //         StatType.Def => DefPenalty,
    //         StatType.Res => ResPenalty,
    //         _ => throw new ArgumentException("Unsupported stat type.")
    //     };
    // }

    
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
    
    private List<Skill> _activatedSkills = new List<Skill>();
    public IEnumerable<Skill> ActivatedSkills
        => _activatedSkills.AsReadOnly();
}