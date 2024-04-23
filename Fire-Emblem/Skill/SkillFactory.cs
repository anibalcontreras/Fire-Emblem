using Fire_Emblem.Condition;
using Fire_Emblem.Effect;
using Fire_Emblem.Stats;

namespace Fire_Emblem.SkillManagment;

public class SkillFactory
{
    public static Skill CreateSkill(string skillName)
    {
        switch (skillName)
        {
            case "Armored Blow":
                return CreateArmoredBlowSkill();
            case "Death Blow":
                return CreateDeathBlowSkill();
            case "Darting Blow":
                return CreateDartingBlowSkill();
            case "Warding Blow":
                return CreateWardingBlowSkill();
            case "Swift Sparrow":
                return CreateSwiftSparrowSkill();
            case "Sturdy Blow":
                return CreateSturdyBlowSkill();
            case "Mirror Strike":
                return CreateMirrorStrikeSkill();
            case "Steady Blow":
                return CreateSteadyBlowSkill();
            case "Swift Strike":
                return CreateSwiftStrikeSkill();
            case "Bracing Blow":
                return CreateBracingBlowSkill();
            case "Attack +6":
                return CreateAttackPlus6Skill();
            case "Speed +5":
                return CreateSpeedPlus5Skill();
            case "Defense +5":
                return CreateDefensePlus5Skill();
            case "Resistance +5":
                return CreateResistancePlus5Skill();
            case "Atk/Def +5":
                return CreateAtkDefPlus5Skill();
            case "Spd/Res +5":
                return CreateSpdResPlus5Skill();
            case "Atk/Res +5":
                return CreateAtkResPlus5Skill();
            case "Tome Precision":
                return CreateTomePrecisionSkill();
            case "Brazen Atk/Spd":
                return CreateBrazenAtkSpdSkill();
            case "Brazen Atk/Def":
                return CreateBrazenAtkDefSkill();
            case "Brazen Atk/Res":
                return CreateBrazenAtkResSkill();
            case "Brazen Spd/Def":
                return CreateBrazenSpdDefSkill();
            case "Brazen Spd/Res":
                return CreateBrazenSpdResSkill();
            case "Brazen Def/Res":
                return CreateBrazenDefResSkill();
            case "Deadly Blade":
                return CreateDeadlyBladeSkill();
            case "Chaos Style":
                return CreateChaosStyleSkill();
            case "Fire Boost":
                return CreateFireBoostSkill();
            case "Wind Boost":
                return CreateWindBoostSkill();
            case "Earth Boost":
                return CreateEarthBoostSkill();
            case "Water Boost":
                return CreateWaterBoostSkill();
            case "Wrath":
                return CreateWrathSkill();
            case "Stunning Smile":
                return CreateStunningSmileSkill();
            case "Disarming Sigh":
                return CreateDisarmingSighSkill();
            case "Blinding Flash":
                return CreateBlindingFlashSkill();
            case "Not *Quite*":
                return CreateNotQuiteSkill();
            case "Sword Agility":
                return CreateSwordAgilitySkill();
            case "Lance Power":
                return CreateLancePowerSkill();
            case "Sword Power":
                return CreateSwordPowerSkill();
            case "Bow Focus":
                return CreateBowFocusSkill();
            case "Lance Agility":
                return CreateLanceAgilitySkill();
            case "Axe Power":
                return CreateAxePowerSkill();
            case "Bow Agility":
                return CreateBowAgilitySkill();
            case "Sword Focus":
                return CreateSwordFocusSkill();
            case "Fort. Def/Res":
                return CreateFortDefResSkill();
            case "Life and Death":
                return CreateLifeAndDeathSkill();
            case "Solid Ground":
                return CreateSolidGroundSkill();
            case "Still Water":
                return CreateStillWaterSkill();
            default:
                throw new ArgumentException($"Unknown skill name: {skillName}");
        }
    }
    
    private static Skill CreateFortDefResSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[]
        {
            new NoCondition()
        });
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new BonusEffect(StatType.Def, 6),
            new BonusEffect(StatType.Res, 6),
            new UnitPenaltyEffect(StatType.Atk, 2)
        });

        return new Skill("Fort. Def/Res", multiCondition, multiEffect);
    }

    private static Skill CreateLifeAndDeathSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[]
        {
            new NoCondition()
        });
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new BonusEffect(StatType.Atk, 6),
            new BonusEffect(StatType.Spd, 6),
            new UnitPenaltyEffect(StatType.Def, 5),
            new UnitPenaltyEffect(StatType.Res, 5)
        });

        return new Skill("Life and Death", multiCondition, multiEffect);
    }

    private static Skill CreateSolidGroundSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[]
        {
            new NoCondition()
        });
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new BonusEffect(StatType.Atk, 6),
            new BonusEffect(StatType.Def, 6),
            new UnitPenaltyEffect(StatType.Res, 5)
        });

        return new Skill("Solid Ground", multiCondition, multiEffect);
    }

    private static Skill CreateStillWaterSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[]
        {
            new NoCondition()
        });
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new BonusEffect(StatType.Atk, 6),
            new BonusEffect(StatType.Res, 6),
            new UnitPenaltyEffect(StatType.Def, 5)
        });

        return new Skill("Still Water", multiCondition, multiEffect);
    }

    
    private static Skill CreateSwordFocusSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[]
        {
            new UnitWeaponCondition("Sword")
        });
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new BonusEffect(StatType.Atk, 10),
            new UnitPenaltyEffect(StatType.Res, 10)
        });
        
        Skill skill = new Skill("Sword Focus", multiCondition, multiEffect);
        return skill;
    }
    
    private static Skill CreateBowAgilitySkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[]
        {
            new UnitWeaponCondition("Bow")
        });
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new BonusEffect(StatType.Spd, 12),
            new UnitPenaltyEffect(StatType.Atk, 6)
        });
        Skill skill = new Skill("Bow Agility", multiCondition, multiEffect);
        return skill;
    }

    private static Skill CreateAxePowerSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[]
        {
            new UnitWeaponCondition("Axe")
        });
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new BonusEffect(StatType.Atk, 10),
            new UnitPenaltyEffect(StatType.Def, 10)
        });
        
        Skill skill = new Skill("Axe Power", multiCondition, multiEffect);
        return skill;
    }
    private static Skill CreateLanceAgilitySkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[]
        {
            new UnitWeaponCondition("Lance")
        });
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new BonusEffect(StatType.Spd, 12),
            new UnitPenaltyEffect(StatType.Atk, 6)
        });
        Skill skill = new Skill("Lance Agility", multiCondition, multiEffect);
        return skill;
    }
    private static Skill CreateBowFocusSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[]
        {
            new UnitWeaponCondition("Bow")
        });
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new BonusEffect(StatType.Atk, 10),
            new UnitPenaltyEffect(StatType.Res, 10)
        });
        
        Skill skill = new Skill("Bow Focus", multiCondition, multiEffect);
        return skill;
    }
    
    private static Skill CreateSwordPowerSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[]
        {
            new UnitWeaponCondition("Sword")
        });
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new BonusEffect(StatType.Atk, 10),
            new UnitPenaltyEffect(StatType.Def, 10)
        });
        
        Skill skill = new Skill("Sword Power", multiCondition, multiEffect);
        return skill;
    }

    private static Skill CreateLancePowerSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[]
        {
            new UnitWeaponCondition("Lance")
        });
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new BonusEffect(StatType.Atk, 10),
            new UnitPenaltyEffect(StatType.Def, 10)
        });
        
        Skill skill = new Skill("Lance Power", multiCondition, multiEffect);
        return skill;
    }

    private static Skill CreateSwordAgilitySkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[]
        {
            new UnitWeaponCondition("Sword")
        });
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new BonusEffect(StatType.Spd, 12),
            new UnitPenaltyEffect(StatType.Atk, 6)
        });
        Skill skill = new Skill("Sword Agility", multiCondition, multiEffect);
        return skill;
    }
    
    private static Skill CreateAttackPlus6Skill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new NoCondition() });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 6) });
         Skill skill = new Skill("Attack +6", multiCondition, multiEffect);
         return skill;
     }

     private static Skill CreateSpeedPlus5Skill()
     { 
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new NoCondition() });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Spd, 5) });
         Skill skill = new Skill("Speed +5", multiCondition, multiEffect);
         return skill;
     }

     // private static Skill CreateLunaSkill()
     // {
     //     MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
     //     MultiEffect multiEffect = new MultiEffect(new IEffect[] { new LunaPenaltyEffect() });
     //     Skill skill = new Skill("Luna", multiCondition, multiEffect);
     //     return skill;
     // }   
    
     private static Skill CreateDefensePlus5Skill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new NoCondition() });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Def, 5) });
         Skill skill = new Skill("Defense +5", multiCondition, multiEffect);
         return skill;
     }
     
     private static Skill CreateResistancePlus5Skill()
     {
            MultiCondition multiCondition = new MultiCondition(new ICondition[] { new NoCondition() });
            MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Res, 5) });
            Skill skill = new Skill("Resistance +5", multiCondition, multiEffect);
            return skill;
     }

     private static Skill CreateAtkDefPlus5Skill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new NoCondition() });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 5), new BonusEffect(StatType.Def, 5) });
         Skill skill = new Skill("Atk/Def +5", multiCondition, multiEffect);
         return skill;
     }
     
     private static Skill CreateSpdResPlus5Skill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new NoCondition() });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Spd, 5), new BonusEffect(StatType.Res, 5) });
         Skill skill = new Skill("Spd/Res +5", multiCondition, multiEffect);
         return skill;
     }

     private static Skill CreateAtkResPlus5Skill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new NoCondition() });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 5), new BonusEffect(StatType.Res, 5) });
         Skill skill = new Skill("Atk/Res +5", multiCondition, multiEffect);
         return skill;
     }
     
    private static Skill CreateArmoredBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Def, 8) });
        Skill skill = new Skill("Armored Blow", multiCondition, multiEffect);
        return skill;
    }


    private static Skill CreateDeathBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 8) });
        Skill skill = new Skill("Death Blow", multiCondition, multiEffect);
        return skill;
    }
    
    private static Skill CreateDartingBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Spd, 8) });
        Skill skill = new Skill("Darting Blow", multiCondition, multiEffect);
        return skill;
    }

    private static Skill CreateWardingBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Res, 8) });
        Skill skill = new Skill("Warding Blow", multiCondition, multiEffect);
        return skill;
    }

    private static Skill CreateSwiftSparrowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 6), new BonusEffect(StatType.Spd, 6) });
        Skill skill = new Skill("Swift Sparrow", multiCondition, multiEffect);
        return skill;
    }

    private static Skill CreateSturdyBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 6), new BonusEffect(StatType.Def, 6) });
        Skill skill = new Skill("Sturdy Blow", multiCondition, multiEffect);
        return skill;
    }

    private static Skill CreateMirrorStrikeSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 6), new BonusEffect(StatType.Res, 6) });
        Skill skill = new Skill("Mirror Strike", multiCondition, multiEffect);
        return skill;
    }

    private static Skill CreateSteadyBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Spd, 6), new BonusEffect(StatType.Def, 6) });
        Skill skill = new Skill("Steady Blow", multiCondition, multiEffect);
        return skill;
    }

    private static Skill CreateSwiftStrikeSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Spd, 6), new BonusEffect(StatType.Res, 6) });
        Skill skill = new Skill("Swift Strike", multiCondition, multiEffect);
        return skill;
    }

    private static Skill CreateBracingBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Def, 6), new BonusEffect(StatType.Res, 6) });
        Skill skill = new Skill("Bracing Blow", multiCondition, multiEffect);
        return skill;
    }

     
     private static Skill CreateTomePrecisionSkill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitWeaponCondition("Magic") });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 6), new BonusEffect(StatType.Spd, 6) }); 
         Skill skill = new Skill("Tome Precision", multiCondition, multiEffect);
         return skill;
     }
     
     private static Skill CreateBrazenSpdResSkill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[]
         {
             new BeginningOfTheCombatCondition(),
             new UnitHpThresholdCondition(0.8)
         });
         MultiEffect multiEffect = new MultiEffect(new IEffect[]
         {
             new BonusEffect(StatType.Spd, 10),
             new BonusEffect(StatType.Res, 10)
         });
         Skill skill = new Skill("Brazen Spd/Res", multiCondition, multiEffect);
         return skill;
     }
     
     private static Skill CreateBrazenAtkSpdSkill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[]
         {
             new BeginningOfTheCombatCondition(),
             new UnitHpThresholdCondition(0.8)
         });
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new BonusEffect(StatType.Atk, 10),
            new BonusEffect(StatType.Spd, 10)
        });
        Skill skill = new Skill("Brazen Atk/Spd", multiCondition, multiEffect);
        return skill;
     }

     private static Skill CreateBrazenAtkDefSkill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[]
         {
             new BeginningOfTheCombatCondition(),
             new UnitHpThresholdCondition(0.8)
         }); 
         MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new BonusEffect(StatType.Atk, 10),
            new BonusEffect(StatType.Def, 10)
        });
         Skill skill = new Skill("Brazen Atk/Def", multiCondition, multiEffect);
            return skill;
     }
     
     
     private static Skill CreateBrazenAtkResSkill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[]
         {
             new BeginningOfTheCombatCondition(),
             new UnitHpThresholdCondition(0.8)
         });
         MultiEffect multiEffect = new MultiEffect(new IEffect[]
         {
             new BonusEffect(StatType.Atk, 10),
             new BonusEffect(StatType.Res, 10)
         });
         Skill skill = new Skill("Brazen Atk/Res", multiCondition, multiEffect);
         return skill;
     }
     
     private static Skill CreateBrazenSpdDefSkill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[]
         {
             new BeginningOfTheCombatCondition(),
             new UnitHpThresholdCondition(0.8)
         });
         MultiEffect multiEffect = new MultiEffect(new IEffect[]
         {
             new BonusEffect(StatType.Spd, 10),
             new BonusEffect(StatType.Def, 10)
         });
         Skill skill = new Skill("Brazen Spd/Def", multiCondition, multiEffect);
         return skill;
     }
     
     private static Skill CreateBrazenDefResSkill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[]
         {
             new BeginningOfTheCombatCondition(),
             new UnitHpThresholdCondition(0.8)
         });
         MultiEffect multiEffect = new MultiEffect(new IEffect[]
         {
             new BonusEffect(StatType.Def, 10),
             new BonusEffect(StatType.Res, 10)
         });
         Skill skill = new Skill("Brazen Def/Res", multiCondition, multiEffect);
         return skill;
     }

     private static Skill CreateDeadlyBladeSkill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[]
         {
             new UnitWeaponCondition("Sword"),
             new UnitBeginAsAttackerCondition()
         });
         MultiEffect multiEffect = new MultiEffect(new IEffect[]
         {
             new BonusEffect(StatType.Atk, 8),
             new BonusEffect(StatType.Spd, 8)
         });
         Skill skill = new Skill("Deadly Blade", multiCondition, multiEffect);
         return skill;
     }

     private static Skill CreateBlindingFlashSkill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[]
         {
             new UnitBeginAsAttackerCondition()
         });
         MultiEffect multiEffect = new MultiEffect(new IEffect[]
         {
             new RivalPenaltyEffect(StatType.Spd, 4)
         });
         Skill skill = new Skill("Blinding Flash", multiCondition, multiEffect);
         return skill;
     }

     private static Skill CreateNotQuiteSkill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[]
         {
             new RivalBeginAsAttacker()
         });
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new RivalPenaltyEffect(StatType.Atk, 4)
        });
         
        Skill skill = new Skill("Not Quite", multiCondition, multiEffect);
           return skill;
     }
     
     // private static Skill CreateFairFightSkill()
     // {
     //     ICondition beginsAsAttacker = new UnitBeginAsAttackerCondition();
     //
     //     IEffect bonusToAttacker = new BonusEffect(StatType.Atk, 6);
     //     IEffect bonusToDefender = new BonusEffect(StatType.Atk, 6);
     //
     //     MultiEffect multiEffect = new MultiEffect(new IEffect[] {
     //         new ApplyEffectToBoth(bonusToAttacker, bonusToDefender)
     //     });
     //
     //     return new Skill("Fair Fight", "Si la unidad inicia el combate, otorga Atk+6 a la unidad y al rival durante el combate.", beginsAsAttacker, multiEffect);
     // }
     
    
     private static Skill CreateChaosStyleSkill()
     {
         ICondition beginsAsAttacker = new UnitBeginAsAttackerCondition();
         ICondition mixedWeaponCondition = new MixedWeaponCondition(
             new string[] { "Bow", "Sword", "Lance", "Axe" },
             new string[] { "Magic" }
         );

         MultiCondition multiCondition = new MultiCondition(new ICondition[] {
             beginsAsAttacker,
             mixedWeaponCondition
         });

         MultiEffect multiEffect = new MultiEffect(new IEffect[]
         {
             new BonusEffect(StatType.Spd, 3)
         });

         return new Skill("Chaos Style", multiCondition, multiEffect);
     }
     
     private static Skill CreateWrathSkill()
     {
         ICondition atStartOfCombat = new BeginningOfTheCombatCondition();
         IEffect wrathEffect = new WrathBonusEffect();

         MultiCondition multiCondition = new MultiCondition(new ICondition[] { atStartOfCombat });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { wrathEffect });

         return new Skill("Wrath", multiCondition, multiEffect);
     }
     
     private static Skill CreateStunningSmileSkill()
     {
         ICondition rivalIsMan = new RivalIsManCondition();
         IEffect speedPenalty = new RivalPenaltyEffect(StatType.Spd, 8);
         
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { rivalIsMan });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { speedPenalty });

         return new Skill("Stunning Smile",
             multiCondition, multiEffect);
     }

     private static Skill CreateDisarmingSighSkill()
     {
         ICondition rivalIsMan = new RivalIsManCondition();
         IEffect attackPenalty = new RivalPenaltyEffect(StatType.Atk, 8);
         
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { rivalIsMan });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { attackPenalty });

         return new Skill("Disarming Sigh",
             multiCondition, multiEffect);
     }
     
     private static Skill CreateBoostSkill(string name, StatType statToBoost, int boostAmount)
     {
         ICondition atStartOfCombat = new BeginningOfTheCombatCondition();
         ICondition hpAboveRivalPlusThree = new HpComparisonCondition(3);

         MultiCondition multiCondition = new MultiCondition(new ICondition[] {
             atStartOfCombat,
             hpAboveRivalPlusThree
         });

         MultiEffect multiEffect = new MultiEffect(new IEffect[] {
             new BonusEffect(statToBoost, boostAmount)
         });

         return new Skill(name, multiCondition, multiEffect);
     }

     private static Skill CreateFireBoostSkill()
     {
         return CreateBoostSkill("Fire Boost", StatType.Atk, 6);
     }

     private static Skill CreateWindBoostSkill()
     {
         return CreateBoostSkill("Wind Boost", StatType.Spd, 6);
     }

     private static Skill CreateEarthBoostSkill()
     {
         return CreateBoostSkill("Earth Boost", StatType.Def, 6);
     }

     private static Skill CreateWaterBoostSkill()
     {
         return CreateBoostSkill("Water Boost", StatType.Res, 6);
     }
     
}
