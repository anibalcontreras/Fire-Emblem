using Fire_Emblem.Exception;

namespace Fire_Emblem.Skills;

public class SkillFactory
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
                return SkillBuilder.CreateHpPlus15Skill();
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
            case "Golden Lotus":
                return SkillBuilder.CreateGoldenLotusSkill();
            case "Dodge":
                return SkillBuilder.CreateDodgeSkill();
            case "Back at You":
                return SkillBuilder.CreateBackAtYouSkill();
            case "Lunar Brace":
                return SkillBuilder.CreateLunarBraceSkill();
            case "Poetic Justice":
                return SkillBuilder.CreatePoeticJusticeSkill();
            case "Bushido":
                return SkillBuilder.CreateBushidoSkill();
            case "Prescience":
                return SkillBuilder.CreatePrescienceSkill();
            case "Extra Chivalry":
                return SkillBuilder.CreateExtraChivalrySkill();
            case "Laguz Friend":
                return SkillBuilder.CreateLaguzFriendSkill();
            case "Dragon Wall":
                return SkillBuilder.CreateDragonWallSkill();
            case "Moon-Twin Wing":
                return SkillBuilder.CreateMoonTwinWingSkill();
            case "Dragon's Wrath":
                return SkillBuilder.CreateDragonsWrathSkill();
            case "Guard Bearing":
                return SkillBuilder.CreateGuardBearingSkill();
            case "Divine Recreation":
                return SkillBuilder.CreateDivineRecreationSkill();
            case "Windsweep":
                return SkillBuilder.CreateWindsweepSkill();
            case "Surprise Attack":
                return SkillBuilder.CreateSurpriseAttackSkill();
            case "Hliðskjálf":
                return SkillBuilder.CreateHliðskjálfSkill();
            case "Null C-Disrupt":
                return SkillBuilder.CreateNullCDisruptSkill();
            case "Laws of Sacae":
                return SkillBuilder.CreateLawsOfSacaeSkill();
            case "Sol":
                return SkillBuilder.CreateSolSkill();
            case "Nosferatu":
                return SkillBuilder.CreateNosferatuSkill();
            case "Solar Brace":
                return SkillBuilder.CreateSolarBraceSkill();
            case "Eclipse Brace":
                return SkillBuilder.CreateEclipseBraceSkill();
            case "Atk/Spd Push":
                return SkillBuilder.CreateAtkSpdPushSkill();
            case "Atk/Def Push":
                return SkillBuilder.CreateAtkDefPushSkill();
            case "Atk/Res Push":
                return SkillBuilder.CreateAtkResPushSkill();
            case "Spd/Def Push":
                return SkillBuilder.CreateSpdDefPushSkill();
            case "Spd/Res Push":
                return SkillBuilder.CreateSpdResPushSkill();
            case "Def/Res Push":
                return SkillBuilder.CreateDefResPushSkill();
            case "Flare":
                return SkillBuilder.CreateFlareSkill();
            case "Mystic Boost":
                return SkillBuilder.CreateMysticBoostSkill();
            case "Fury":
                return SkillBuilder.CreateFurySkill();
            case "Scendscale":
                return SkillBuilder.CreateScendscaleSkill();
            case "Resonance":
                return SkillBuilder.CreateResonanceSkill();
            case "Mastermind":
                return SkillBuilder.CreateMastermindSkill();
            case "Quick Riposte":
                return SkillBuilder.CreateQuickRiposteSkill();
            case "Follow-Up Ring":
                return SkillBuilder.CreateFollowUpRingSkill();
            case "Wary Fighter":
                return SkillBuilder.CreateWaryFighterSkill();
            case "Piercing Tribute":
                return SkillBuilder.CreatePiercingTributeSkill();
            case "Mjölnir":
                return SkillBuilder.CreateMjolnirSkill();
            case "Melee Breaker":
                return SkillBuilder.CreateMeleeBreakerSkill();
            case "Range Breaker":
                return SkillBuilder.CreateRangeBreakerSkill();
            case "Sturdy Impact":
                return SkillBuilder.CreateSturdyImpactSkill();
            case "Mirror Impact":
                return SkillBuilder.CreateMirrorImpactSkill();
            case "Swift Impact":
                return SkillBuilder.CreateSwiftImpactSkill();
            case "Steady Impact":
                return SkillBuilder.CreateSteadyImpactSkill();
            case "Slick Fighter":
                return SkillBuilder.CreateSlickFighterSkill();
            case "Wily Fighter":
                return SkillBuilder.CreateWilyFighterSkill();
            case "Flow Force":
                return SkillBuilder.CreateFlowForceSkill();
            case "Flow Refresh":
                return SkillBuilder.CreateFlowRefreshSkill();
            case "Null Follow-Up":
                return SkillBuilder.CreateNullFollowUpSkill();
            case "True Dragon Wall":
                return SkillBuilder.CreateTrueDragonWallSkill();
            case "Bewitching Tome":
                return SkillBuilder.CreateBewitchingTomeSkill();
            case "Black Eagle Rule":
                return SkillBuilder.CreateBlackEagleRuleSkill();
            case "Blue Lion Rule":
                return SkillBuilder.CreateBlueLionRuleSkill();
            case "New Divinity":
                return SkillBuilder.CreateNewDivinitySkill();
            case "Sun-Twin Wing":
                return SkillBuilder.CreateSunTwinWingSkill();
            case "Dragon's Ire":
                return SkillBuilder.CreateDragonsIreSkill();
            case "Savvy Fighter":
                return SkillBuilder.CreateSavvyFighterSkill();
            case "Binding Shield":
                return SkillBuilder.CreateBindingShieldSkill();
            case "Flow Feather":
                return SkillBuilder.CreateFlowFeatherSkill();
            case "Flow Flight":
                return SkillBuilder.CreateFlowFlightSkill();
            case "Pegasus Flight":
                return SkillBuilder.CreatePegasusFlightSkill();
            case "Wyvern Flight":
                return SkillBuilder.CreateWyvernFlightSkill();
            case "Phys. Null Follow":
                return SkillBuilder.CreatePhysNullFollowSkill();
            case "Mag. Null Follow":
                return SkillBuilder.CreateMagNullFollowSkill();
            default:
                throw new NotImplementedSkillException();
        }
    }
}
