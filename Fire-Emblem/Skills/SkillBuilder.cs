using Fire_Emblem.Conditions;
using Fire_Emblem.Conditions.LogicalConditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.Neutralization;
using Fire_Emblem.Stats;

namespace Fire_Emblem.Skills;

public static class SkillBuilder
{
    
    public static Skill CreateWrathSkill()
    {
        ICondition startOfCombatCondition = new BeginningOfTheCombatCondition();

        MultiEffect effects = new MultiEffect(new IEffect[]
        {
            new DynamicBonusEffect(StatType.Atk, 30, EffectTarget.Unit),
            new DynamicBonusEffect(StatType.Spd, 30, EffectTarget.Unit)
        });

        return new Skill("Wrath", startOfCombatCondition, effects);
    }

    public static Skill CreateBeorcsBlessingSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[]
        {
            new TrueCondition()
        });
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new NeutralizationBonusEffect(EffectTarget.Rival)
        });

        return new Skill("Beorc's Blessing", multiCondition, multiEffect);
    }

    public static Skill CreateAgneasArrowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[]
        {
            new TrueCondition()
        });
        
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new NeutralizationPenaltyEffect(EffectTarget.Unit)
        });
        
        return new Skill("Agnea's Arrow", multiCondition, multiEffect);
    }
    
    public static Skill CreateResolveSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[]
        {
            new UnitHpThresholdCondition(0.75)
        });
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new BonusEffect(StatType.Def, 7, EffectTarget.Unit),
            new BonusEffect(StatType.Res, 7, EffectTarget.Unit)
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
            new BonusEffect(StatType.Atk, 8, EffectTarget.Unit)
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
            new BonusEffect(StatType.Atk, 6, EffectTarget.Unit),
            new BonusEffect(StatType.Atk, 6, EffectTarget.Rival)
        });
    
        return new Skill("Fair Fight", multiCondition, multiEffect);
    }

    
    public static Skill CreateFortDefResSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[]
        {
            new TrueCondition()
        });
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new BonusEffect(StatType.Def, 6, EffectTarget.Unit),
            new BonusEffect(StatType.Res, 6, EffectTarget.Unit),
            new PenaltyEffect(StatType.Atk, 2, EffectTarget.Unit)
        });

        return new Skill("Fort. Def/Res", multiCondition, multiEffect);
    }

    public static Skill CreateLifeAndDeathSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[]
        {
            new TrueCondition()
        });
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new BonusEffect(StatType.Atk, 6, EffectTarget.Unit),
            new BonusEffect(StatType.Spd, 6, EffectTarget.Unit),
            new PenaltyEffect(StatType.Def, 5, EffectTarget.Unit),
            new PenaltyEffect(StatType.Res, 5, EffectTarget.Unit)
        });

        return new Skill("Life and Death", multiCondition, multiEffect);
    }

    public static Skill CreateSolidGroundSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[]
        {
            new TrueCondition()
        });
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new BonusEffect(StatType.Atk, 6, EffectTarget.Unit),
            new BonusEffect(StatType.Def, 6, EffectTarget.Unit),
            new PenaltyEffect(StatType.Res, 5, EffectTarget.Unit)
        });

        return new Skill("Solid Ground", multiCondition, multiEffect);
    }

    public static Skill CreateStillWaterSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[]
        {
            new TrueCondition()
        });
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new BonusEffect(StatType.Atk, 6, EffectTarget.Unit),
            new BonusEffect(StatType.Res, 6, EffectTarget.Unit),
            new PenaltyEffect(StatType.Def, 5, EffectTarget.Unit)
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
            new BonusEffect(StatType.Atk, 10, EffectTarget.Unit),
            new PenaltyEffect(StatType.Res, 10, EffectTarget.Unit)
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
            new BonusEffect(StatType.Spd, 12, EffectTarget.Unit),
            new PenaltyEffect(StatType.Atk, 6, EffectTarget.Unit)
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
            new BonusEffect(StatType.Atk, 10, EffectTarget.Unit),
            new PenaltyEffect(StatType.Def, 10, EffectTarget.Unit)
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
            new BonusEffect(StatType.Spd, 12, EffectTarget.Unit),
            new PenaltyEffect(StatType.Atk, 6, EffectTarget.Unit)
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
            new BonusEffect(StatType.Atk, 10, EffectTarget.Unit),
            new PenaltyEffect(StatType.Res, 10, EffectTarget.Unit)
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
            new BonusEffect(StatType.Atk, 10, EffectTarget.Unit),
            new PenaltyEffect(StatType.Def, 10, EffectTarget.Unit)
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
            new BonusEffect(StatType.Atk, 10, EffectTarget.Unit),
            new PenaltyEffect(StatType.Def, 10, EffectTarget.Unit)
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
            new BonusEffect(StatType.Spd, 12, EffectTarget.Unit),
            new PenaltyEffect(StatType.Atk, 6, EffectTarget.Unit)
        });
        Skill skill = new Skill("Sword Agility", multiCondition, multiEffect);
        return skill;
    }
    
    public static Skill CreateAttackPlus6Skill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new TrueCondition() });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 6, EffectTarget.Unit) });
         Skill skill = new Skill("Attack +6", multiCondition, multiEffect);
         return skill;
     }

     public static Skill CreateSpeedPlus5Skill()
     { 
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new TrueCondition() });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Spd, 5, EffectTarget.Unit) });
         Skill skill = new Skill("Speed +5", multiCondition, multiEffect);
         return skill;
     }
     
     public static Skill CreateDefensePlus5Skill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new TrueCondition() });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Def, 5, EffectTarget.Unit) });
         Skill skill = new Skill("Defense +5", multiCondition, multiEffect);
         return skill;
     }
     
     public static Skill CreateResistancePlus5Skill()
     {
            MultiCondition multiCondition = new MultiCondition(new ICondition[] { new TrueCondition() });
            MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Res, 5, EffectTarget.Unit) });
            Skill skill = new Skill("Resistance +5", multiCondition, multiEffect);
            return skill;
     }

     public static Skill CreateAtkDefPlus5Skill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new TrueCondition() });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 5, EffectTarget.Unit), new BonusEffect(StatType.Def, 5, EffectTarget.Unit) });
         Skill skill = new Skill("Atk/Def +5", multiCondition, multiEffect);
         return skill;
     }
     
     public static Skill CreateSpdResPlus5Skill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new TrueCondition() });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Spd, 5, EffectTarget.Unit), new BonusEffect(StatType.Res, 5, EffectTarget.Unit) });
         Skill skill = new Skill("Spd/Res +5", multiCondition, multiEffect);
         return skill;
     }

     public static Skill CreateAtkResPlus5Skill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new TrueCondition() });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 5, EffectTarget.Unit), new BonusEffect(StatType.Res, 5, EffectTarget.Unit) });
         Skill skill = new Skill("Atk/Res +5", multiCondition, multiEffect);
         return skill;
     }
     
    public static Skill CreateArmoredBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Def, 8, EffectTarget.Unit) });
        Skill skill = new Skill("Armored Blow", multiCondition, multiEffect);
        return skill;
    }


    public static Skill CreateDeathBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 8, EffectTarget.Unit) });
        Skill skill = new Skill("Death Blow", multiCondition, multiEffect);
        return skill;
    }
    
    public static Skill CreateDartingBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Spd, 8, EffectTarget.Unit) });
        Skill skill = new Skill("Darting Blow", multiCondition, multiEffect);
        return skill;
    }

    public static Skill CreateWardingBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Res, 8, EffectTarget.Unit) });
        Skill skill = new Skill("Warding Blow", multiCondition, multiEffect);
        return skill;
    }

    public static Skill CreateSwiftSparrowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 6, EffectTarget.Unit), new BonusEffect(StatType.Spd, 6, EffectTarget.Unit) });
        Skill skill = new Skill("Swift Sparrow", multiCondition, multiEffect);
        return skill;
    }

    public static Skill CreateSturdyBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 6, EffectTarget.Unit), new BonusEffect(StatType.Def, 6, EffectTarget.Unit) });
        Skill skill = new Skill("Sturdy Blow", multiCondition, multiEffect);
        return skill;
    }

    public static Skill CreateMirrorStrikeSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 6, EffectTarget.Unit), new BonusEffect(StatType.Res, 6, EffectTarget.Unit) });
        Skill skill = new Skill("Mirror Strike", multiCondition, multiEffect);
        return skill;
    }

    public static Skill CreateSteadyBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Spd, 6, EffectTarget.Unit), new BonusEffect(StatType.Def, 6, EffectTarget.Unit) });
        Skill skill = new Skill("Steady Blow", multiCondition, multiEffect);
        return skill;
    }

    public static Skill CreateSwiftStrikeSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Spd, 6, EffectTarget.Unit), new BonusEffect(StatType.Res, 6, EffectTarget.Unit) });
        Skill skill = new Skill("Swift Strike", multiCondition, multiEffect);
        return skill;
    }

    public static Skill CreateBracingBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Def, 6, EffectTarget.Unit), new BonusEffect(StatType.Res, 6, EffectTarget.Unit) });
        Skill skill = new Skill("Bracing Blow", multiCondition, multiEffect);
        return skill;
    }

     
     public static Skill CreateTomePrecisionSkill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitWeaponCondition("Magic") });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 6, EffectTarget.Unit), new BonusEffect(StatType.Spd, 6, EffectTarget.Unit) }); 
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
             new BonusEffect(StatType.Spd, 10, EffectTarget.Unit),
             new BonusEffect(StatType.Res, 10, EffectTarget.Unit)
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
            new BonusEffect(StatType.Atk, 10, EffectTarget.Unit),
            new BonusEffect(StatType.Spd, 10, EffectTarget.Unit)
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
            new BonusEffect(StatType.Atk, 10, EffectTarget.Unit),
            new BonusEffect(StatType.Def, 10, EffectTarget.Unit)
        });
         Skill skill = new Skill("Brazen Atk/Def", multiCondition, multiEffect);
            return skill;
     }
     
     
     public static Skill CreateBrazenAtkResSkill()
     {
         ICondition multiCondition = new AndCondition(
             new BeginningOfTheCombatCondition(),
             new UnitHpThresholdCondition(0.8)
         );
         MultiEffect multiEffect = new MultiEffect(new IEffect[]
         {
             new BonusEffect(StatType.Atk, 10, EffectTarget.Unit),
             new BonusEffect(StatType.Res, 10, EffectTarget.Unit)
         });
         Skill skill = new Skill("Brazen Atk/Res", multiCondition, multiEffect);
         return skill;
     }
     
     public static Skill CreateCloseDefSkill()
     {
         ICondition closeWeaponCondition = new AndCondition(
             new RivalBeginAsAttacker(),
             new RivalWeaponCondition("Sword", "Lance", "Axe")
         );

         MultiEffect effects = new MultiEffect(new IEffect[]
         {
             new BonusEffect(StatType.Def, 8, EffectTarget.Unit),
             new BonusEffect(StatType.Res, 8, EffectTarget.Unit),
             new NeutralizationBonusEffect(EffectTarget.Rival)
         });

         return new Skill("Close Def", closeWeaponCondition, effects);
     }
     
     public static Skill CreateDistantDefSkill()
     {
         ICondition distantWeaponCondition = new AndCondition(
             new RivalBeginAsAttacker(),
             new RivalWeaponCondition("Magic", "Bow")
         );

         MultiEffect effects = new MultiEffect(new IEffect[]
         {
             new BonusEffect(StatType.Def, 8, EffectTarget.Unit),
             new BonusEffect(StatType.Res, 8, EffectTarget.Unit),
             new NeutralizationBonusEffect(EffectTarget.Rival)
         });

         return new Skill("Distant Def", distantWeaponCondition, effects);
     }


     
     public static Skill CreateBeliefInLoveSkill()
     {
         // Crear condiciones
         ICondition rivalInitiatesOrFullHp = new OrCondition(
             new RivalBeginAsAttacker(),
             new RivalHpThresholdCondition(1.0) // 100%
         );

         // Crear efectos
         MultiEffect effects = new MultiEffect(new IEffect[]
         {
             new PenaltyEffect(StatType.Atk, 5, EffectTarget.Rival),
             new PenaltyEffect(StatType.Def, 5, EffectTarget.Rival)
         });

         // Crear y retornar la habilidad
         return new Skill("Belief in Love", rivalInitiatesOrFullHp, effects);
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
             new BonusEffect(StatType.Spd, 10, EffectTarget.Unit),
             new BonusEffect(StatType.Def, 10, EffectTarget.Unit)
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
             new BonusEffect(StatType.Def, 10, EffectTarget.Unit),
             new BonusEffect(StatType.Res, 10, EffectTarget.Unit)
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
             new BonusEffect(StatType.Atk, 8, EffectTarget.Unit),
             new BonusEffect(StatType.Spd, 8, EffectTarget.Unit)
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
             new PenaltyEffect(StatType.Spd, 4, EffectTarget.Rival)
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
            new PenaltyEffect(StatType.Atk, 4, EffectTarget.Rival)
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
             new BonusEffect(StatType.Spd, 3, EffectTarget.Unit)
         });

         return new Skill("Chaos Style", multiCondition, multiEffect);
     }
     
     public static Skill CreateStunningSmileSkill()
     {
         ICondition rivalIsMan = new RivalIsManCondition();
         IEffect speedPenalty = new PenaltyEffect(StatType.Spd, 8, EffectTarget.Rival);
         
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { rivalIsMan });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { speedPenalty });

         return new Skill("Stunning Smile",
             multiCondition, multiEffect);
     }

     public static Skill CreateDisarmingSighSkill()
     {
         ICondition rivalIsMan = new RivalIsManCondition();
         IEffect attackPenalty = new PenaltyEffect(StatType.Atk, 8, EffectTarget.Rival);
         
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
             new BonusEffect(statToBoost, boostAmount, EffectTarget.Unit)
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