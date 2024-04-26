using Fire_Emblem.Skills;
using Fire_Emblem.Stats;

namespace Fire_Emblem.UnitManagment;

using Fire_Emblem.Weapon;

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
    
    public int AtkBonus { get; set; } = 0;
    public int SpdBonus { get; set; } = 0;
    private int DefBonus { get; set; } = 0;
    private int ResBonus { get; set; } = 0;
    
    private int CurrentAtk => BaseAtk + AtkBonus;
    public int CurrentSpd => BaseSpd + SpdBonus;
    private int CurrentDef => BaseDef + DefBonus;
    private int CurrentRes => BaseRes + ResBonus;
    
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
    
    public void ApplyStatEffect(StatType statType, int effectAmount)
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
    
    public void ResetStatBonuses()
    {
        AtkBonus = 0;
        SpdBonus = 0;
        DefBonus = 0;
        ResBonus = 0;
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
    
}