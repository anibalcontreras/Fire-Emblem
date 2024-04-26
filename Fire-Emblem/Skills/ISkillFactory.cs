namespace Fire_Emblem.Skills;

public interface ISkillFactory
{
    Skill CreateSkill(string skillName);
}