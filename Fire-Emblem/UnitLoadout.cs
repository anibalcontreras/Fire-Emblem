using Fire_Emblem.UnitManagment;
using Fire_Emblem.SkillManagment;

namespace Fire_Emblem;

public class UnitLoadout
{
    public Unit Unit { get; private set; }
    public List<Skill> EquippedSkills { get; private set; } = new List<Skill>();
    
    public UnitLoadout(Unit unit)
    {
        Unit = unit;
    }
    
    public void EquipSkill(Skill skill)
    {
        EquippedSkills.Add(skill);
    }
    
}