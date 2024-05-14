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
            case "Agnea's Arrow":
                return SkillBuilder.CreateAgneasArrowSkill();
            case "Belief in Love":
                return SkillBuilder.CreateBeliefInLoveSkill();
            case "Close Def":
                return SkillBuilder.CreateCloseDefSkill();
            case "Distant Def":
                return SkillBuilder.CreateDistantDefSkill();
            case "Wrath":
                return SkillBuilder.CreateWrathSkill();
            case "Lull Atk/Spd":
                return SkillBuilder.CreateLullAtkSpdSkill();
            case "Lull Atk/Def":
                return SkillBuilder.CreateLullAtkDefSkill();
            case "Lull Atk/Res":
                return SkillBuilder.CreateLullAtkResSkill();
            case "Lull Spd/Def":
                return SkillBuilder.CreateLullSpdDefSkill();
            case "Lull Spd/Res":
                return SkillBuilder.CreateLullSpdResSkill();
            case "Lull Def/Res":
                return SkillBuilder.CreateLullDefResSkill();
            case "Light and Dark":
                return SkillBuilder.CreateLightAndDarkSkill();
            case "Dragonskin":
                return SkillBuilder.CreateDragonskinSkill();
            case "Ignis":
                return SkillBuilder.CreateIgnisSkill();
            case "Single-Minded":
                return SkillBuilder.CreateSingleMindedSkill();
            case "Charmer":
                return SkillBuilder.CreateCharmerSkill();
            case "Perceptive":
                return SkillBuilder.CreatePerceptiveSkill();
            case "Luna":
                return SkillBuilder.CreateLunaSkill();
            case "HP +15":
                return SkillBuilder.CreateHPPlus15Skill();
            // case "Soulblade":
            //     return SkillBuilder.CreateSoulbladeSkill();
            // case "Sandstorm":
            //     return SkillBuilder.CreateSandstormSkill();
            case "Bravery":
                return SkillBuilder.CreateBraverySkill();
            case "Gentility":
                return SkillBuilder.CreateGentilitySkill();
            case "Bow Guard":
                return SkillBuilder.CreateBowGuardSkill();
            case "Axe Guard":
                return SkillBuilder.CreateAxeGuardSkill();
            case "Magic Guard":
                return SkillBuilder.CreateMagicGuardSkill();
            case "Lance Guard":
                return SkillBuilder.CreateLanceGuardSkill();
            case "Arms Shield":
                return SkillBuilder.CreateArmsShieldSkill();
            case "Sympathetic":
                return SkillBuilder.CreateSympatheticSkill();
            case "Blue Skies":
                return SkillBuilder.CreateBlueSkiesSkill();
            case "Chivalry":
                return SkillBuilder.CreateChivalrySkill();
            case "Aegis Shield":
                return SkillBuilder.CreateAegisShieldSkill();
            case "Remote Sparrow":
                return SkillBuilder.CreateRemoteSparrowSkill();
            case "Remote Mirror":
                return SkillBuilder.CreateRemoteMirrorSkill();
            case "Remote Sturdy":
                return SkillBuilder.CreateRemoteSturdySkill();
            case "Fierce Stance":
                return SkillBuilder.CreateFierceStanceSkill();
            case "Darting Stance":
                return SkillBuilder.CreateDartingStanceSkill();
            case "Steady Stance":
                return SkillBuilder.CreateSteadyStanceSkill();
            case "Warding Stance":
                return SkillBuilder.CreateWardingStanceSkill();
            case "Kestrel Stance":
                return SkillBuilder.CreateKestrelStanceSkill();
            case "Sturdy Stance":
                return SkillBuilder.CreateSturdyStanceSkill();
            case "Mirror Stance":
                return SkillBuilder.CreateMirrorStanceSkill();
            case "Swift Stance":
                return SkillBuilder.CreateSwiftStanceSkill();
            case "Bracing Stance":
                return SkillBuilder.CreateBracingStanceSkill();
            case "Steady Posture":
                return SkillBuilder.CreateSteadyPostureSkill();
            default:
                throw new ArgumentException($"Unknown skill name: {skillName}");
        }
    }
}
