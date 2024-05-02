namespace Fire_Emblem.Skills;

public class SkillFactory : ISkillFactory
{
    public Skill CreateSkill(string skillName)
    {
        switch (skillName)
        {
            case "Armored Blow":
                return SkillBuilder.CreateArmoredBlowSkill();
            case "Death Blow":
                return SkillBuilder.CreateDeathBlowSkill();
            case "Darting Blow":
                return SkillBuilder.CreateDartingBlowSkill();
            case "Warding Blow":
                return SkillBuilder.CreateWardingBlowSkill();
            case "Swift Sparrow":
                return SkillBuilder.CreateSwiftSparrowSkill();
            case "Sturdy Blow":
                return SkillBuilder.CreateSturdyBlowSkill();
            case "Mirror Strike":
                return SkillBuilder.CreateMirrorStrikeSkill();
            case "Steady Blow":
                return SkillBuilder.CreateSteadyBlowSkill();
            case "Swift Strike":
                return SkillBuilder.CreateSwiftStrikeSkill();
            case "Bracing Blow":
                return SkillBuilder.CreateBracingBlowSkill();
            case "Attack +6":
                return SkillBuilder.CreateAttackPlus6Skill();
            case "Speed +5":
                return SkillBuilder.CreateSpeedPlus5Skill();
            case "Defense +5":
                return SkillBuilder.CreateDefensePlus5Skill();
            case "Resistance +5":
                return SkillBuilder.CreateResistancePlus5Skill();
            case "Atk/Def +5":
                return SkillBuilder.CreateAtkDefPlus5Skill();
            case "Spd/Res +5":
                return SkillBuilder.CreateSpdResPlus5Skill();
            case "Atk/Res +5":
                return SkillBuilder.CreateAtkResPlus5Skill();
            case "Tome Precision":
                return SkillBuilder.CreateTomePrecisionSkill();
            case "Brazen Atk/Spd":
                return SkillBuilder.CreateBrazenAtkSpdSkill();
            case "Brazen Atk/Def":
                return SkillBuilder.CreateBrazenAtkDefSkill();
            case "Brazen Atk/Res":
                return SkillBuilder.CreateBrazenAtkResSkill();
            case "Brazen Spd/Def":
                return SkillBuilder.CreateBrazenSpdDefSkill();
            case "Brazen Spd/Res":
                return SkillBuilder.CreateBrazenSpdResSkill();
            case "Brazen Def/Res":
                return SkillBuilder.CreateBrazenDefResSkill();
            case "Deadly Blade":
                return SkillBuilder.CreateDeadlyBladeSkill();
            case "Chaos Style":
                return SkillBuilder.CreateChaosStyleSkill();
            case "Fire Boost":
                return SkillBuilder.CreateFireBoostSkill();
            case "Wind Boost":
                return SkillBuilder.CreateWindBoostSkill();
            case "Earth Boost":
                return SkillBuilder.CreateEarthBoostSkill();
            case "Water Boost":
                return SkillBuilder.CreateWaterBoostSkill();
            case "Stunning Smile":
                return SkillBuilder.CreateStunningSmileSkill();
            case "Disarming Sigh":
                return SkillBuilder.CreateDisarmingSighSkill();
            case "Blinding Flash":
                return SkillBuilder.CreateBlindingFlashSkill();
            case "Not *Quite*":
                return SkillBuilder.CreateNotQuiteSkill();
            case "Sword Agility":
                return SkillBuilder.CreateSwordAgilitySkill();
            case "Lance Power":
                return SkillBuilder.CreateLancePowerSkill();
            case "Sword Power":
                return SkillBuilder.CreateSwordPowerSkill();
            case "Bow Focus":
                return SkillBuilder.CreateBowFocusSkill();
            case "Lance Agility":
                return SkillBuilder.CreateLanceAgilitySkill();
            case "Axe Power":
                return SkillBuilder.CreateAxePowerSkill();
            case "Bow Agility":
                return SkillBuilder.CreateBowAgilitySkill();
            case "Sword Focus":
                return SkillBuilder.CreateSwordFocusSkill();
            case "Fort. Def/Res":
                return SkillBuilder.CreateFortDefResSkill();
            case "Life and Death":
                return SkillBuilder.CreateLifeAndDeathSkill();
            case "Solid Ground":
                return SkillBuilder.CreateSolidGroundSkill();
            case "Still Water":
                return SkillBuilder.CreateStillWaterSkill();
            case "Fair Fight":
                return SkillBuilder.CreateFairFightSkill();
            case "Will to Win":
                return SkillBuilder.CreateWillToWinSkill();
            case "Resolve":
                return SkillBuilder.CreateResolveSkill();
            case "Beorc's Blessing":
                return SkillBuilder.CreateBeorcsBlessingSkill();
            default:
                throw new ArgumentException($"Unknown skill name: {skillName}");
        }
    }
}
