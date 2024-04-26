using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Stats;

namespace Fire_Emblem.Skills;

public static class SkillBuilder
{
    public static Skill CreateBeliefInLoveSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[]
        {
            new RivalBeginAsAttacker(),
            new RivalHpThresholdCondition(1)
        });

        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new RivalPenaltyEffect(StatType.Atk, 5),
            new RivalPenaltyEffect(StatType.Def, 5)
        });
        
        return new Skill("Belief in Love", multiCondition, multiEffect);
    }
    
    public static Skill CreateWrathSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[]
        {
            new BeginningOfTheCombatCondition(),
            new UnitHasLostHpCondition()
        });

        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new WrathBonusEffect(30)
        });
        
        return new Skill("Wrath", multiCondition, multiEffect);
    }
    
    public static Skill CreateResolveSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[]
        {
            new UnitHpThresholdCondition(0.75)
        });
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new BonusEffect(StatType.Def, 7),
            new BonusEffect(StatType.Res, 7)
        });

        return new Skill("Resolve", multiCondition, multiEffect);
    }

    
    public static Skill CreateWillToWinSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[]
        {
            new BeginningOfTheCombatCondition(),
            new UnitHpThresholdCondition(0.50)
        });
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new BonusEffect(StatType.Atk, 8)
        });

        return new Skill("Will to Win", multiCondition, multiEffect);
    }
    
    public static Skill CreateFairFightSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[]
        {
            new UnitBeginAsAttackerCondition()
        });
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new MutualBonusEffect(StatType.Atk, 6)
        });

        return new Skill("Fair Fight", multiCondition, multiEffect);
    }

    
    public static Skill CreateFortDefResSkill()
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

    public static Skill CreateLifeAndDeathSkill()
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

    public static Skill CreateSolidGroundSkill()
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

    public static Skill CreateStillWaterSkill()
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

    
    public static Skill CreateSwordFocusSkill()
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
    
    public static Skill CreateBowAgilitySkill()
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

    public static Skill CreateAxePowerSkill()
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
    public static Skill CreateLanceAgilitySkill()
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
    public static Skill CreateBowFocusSkill()
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
    
    public static Skill CreateSwordPowerSkill()
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

    public static Skill CreateLancePowerSkill()
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

    public static Skill CreateSwordAgilitySkill()
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
    
    public static Skill CreateAttackPlus6Skill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new NoCondition() });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 6) });
         Skill skill = new Skill("Attack +6", multiCondition, multiEffect);
         return skill;
     }

     public static Skill CreateSpeedPlus5Skill()
     { 
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new NoCondition() });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Spd, 5) });
         Skill skill = new Skill("Speed +5", multiCondition, multiEffect);
         return skill;
     }
     
     public static Skill CreateDefensePlus5Skill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new NoCondition() });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Def, 5) });
         Skill skill = new Skill("Defense +5", multiCondition, multiEffect);
         return skill;
     }
     
     public static Skill CreateResistancePlus5Skill()
     {
            MultiCondition multiCondition = new MultiCondition(new ICondition[] { new NoCondition() });
            MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Res, 5) });
            Skill skill = new Skill("Resistance +5", multiCondition, multiEffect);
            return skill;
     }

     public static Skill CreateAtkDefPlus5Skill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new NoCondition() });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 5), new BonusEffect(StatType.Def, 5) });
         Skill skill = new Skill("Atk/Def +5", multiCondition, multiEffect);
         return skill;
     }
     
     public static Skill CreateSpdResPlus5Skill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new NoCondition() });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Spd, 5), new BonusEffect(StatType.Res, 5) });
         Skill skill = new Skill("Spd/Res +5", multiCondition, multiEffect);
         return skill;
     }

     public static Skill CreateAtkResPlus5Skill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new NoCondition() });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 5), new BonusEffect(StatType.Res, 5) });
         Skill skill = new Skill("Atk/Res +5", multiCondition, multiEffect);
         return skill;
     }
     
    public static Skill CreateArmoredBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Def, 8) });
        Skill skill = new Skill("Armored Blow", multiCondition, multiEffect);
        return skill;
    }


    public static Skill CreateDeathBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 8) });
        Skill skill = new Skill("Death Blow", multiCondition, multiEffect);
        return skill;
    }
    
    public static Skill CreateDartingBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Spd, 8) });
        Skill skill = new Skill("Darting Blow", multiCondition, multiEffect);
        return skill;
    }

    public static Skill CreateWardingBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Res, 8) });
        Skill skill = new Skill("Warding Blow", multiCondition, multiEffect);
        return skill;
    }

    public static Skill CreateSwiftSparrowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 6), new BonusEffect(StatType.Spd, 6) });
        Skill skill = new Skill("Swift Sparrow", multiCondition, multiEffect);
        return skill;
    }

    public static Skill CreateSturdyBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 6), new BonusEffect(StatType.Def, 6) });
        Skill skill = new Skill("Sturdy Blow", multiCondition, multiEffect);
        return skill;
    }

    public static Skill CreateMirrorStrikeSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 6), new BonusEffect(StatType.Res, 6) });
        Skill skill = new Skill("Mirror Strike", multiCondition, multiEffect);
        return skill;
    }

    public static Skill CreateSteadyBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Spd, 6), new BonusEffect(StatType.Def, 6) });
        Skill skill = new Skill("Steady Blow", multiCondition, multiEffect);
        return skill;
    }

    public static Skill CreateSwiftStrikeSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Spd, 6), new BonusEffect(StatType.Res, 6) });
        Skill skill = new Skill("Swift Strike", multiCondition, multiEffect);
        return skill;
    }

    public static Skill CreateBracingBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Def, 6), new BonusEffect(StatType.Res, 6) });
        Skill skill = new Skill("Bracing Blow", multiCondition, multiEffect);
        return skill;
    }

     
     public static Skill CreateTomePrecisionSkill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitWeaponCondition("Magic") });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 6), new BonusEffect(StatType.Spd, 6) }); 
         Skill skill = new Skill("Tome Precision", multiCondition, multiEffect);
         return skill;
     }
     
     public static Skill CreateBrazenSpdResSkill()
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
     
     public static Skill CreateBrazenAtkSpdSkill()
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

     public static Skill CreateBrazenAtkDefSkill()
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
     
     
     public static Skill CreateBrazenAtkResSkill()
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
     
     public static Skill CreateBrazenSpdDefSkill()
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
     
     public static Skill CreateBrazenDefResSkill()
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

     public static Skill CreateDeadlyBladeSkill()
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

     public static Skill CreateBlindingFlashSkill()
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

     public static Skill CreateNotQuiteSkill()
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
     
     public static Skill CreateChaosStyleSkill()
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
     
     public static Skill CreateStunningSmileSkill()
     {
         ICondition rivalIsMan = new RivalIsManCondition();
         IEffect speedPenalty = new RivalPenaltyEffect(StatType.Spd, 8);
         
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { rivalIsMan });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { speedPenalty });

         return new Skill("Stunning Smile",
             multiCondition, multiEffect);
     }

     public static Skill CreateDisarmingSighSkill()
     {
         ICondition rivalIsMan = new RivalIsManCondition();
         IEffect attackPenalty = new RivalPenaltyEffect(StatType.Atk, 8);
         
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { rivalIsMan });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { attackPenalty });

         return new Skill("Disarming Sigh",
             multiCondition, multiEffect);
     }
     
     public static Skill CreateBoostSkill(string name, StatType statToBoost, int boostAmount)
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

     public static Skill CreateFireBoostSkill()
     {
         return CreateBoostSkill("Fire Boost", StatType.Atk, 6);
     }

     public static Skill CreateWindBoostSkill()
     {
         return CreateBoostSkill("Wind Boost", StatType.Spd, 6);
     }

     public static Skill CreateEarthBoostSkill()
     {
         return CreateBoostSkill("Earth Boost", StatType.Def, 6);
     }

     public static Skill CreateWaterBoostSkill()
     {
         return CreateBoostSkill("Water Boost", StatType.Res, 6);
     }
}