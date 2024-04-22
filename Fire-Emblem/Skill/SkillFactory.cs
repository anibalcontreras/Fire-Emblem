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
            case "Stunning Smile":
                return CreateStunningSmileSkill();
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
            default:
                throw new ArgumentException($"Unknown skill name: {skillName}");
        }
    }
    
    private static Skill CreateAttackPlus6Skill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new NoCondition() });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 6) });
         Skill skill = new Skill("Attack +6", "Otorga Atk+6.", multiCondition, multiEffect);
         return skill;
     }

     private static Skill CreateSpeedPlus5Skill()
     { 
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new NoCondition() });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Spd, 5) });
         Skill skill = new Skill("Speed +5", "Otorga Spd+5.", multiCondition, multiEffect);
         return skill;
     }

     private static Skill CreateDefensePlus5Skill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new NoCondition() });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Def, 5) });
         Skill skill = new Skill("Defense +5", "Otorga Def+5.", multiCondition, multiEffect);
         return skill;
     }
     
     private static Skill CreateResistancePlus5Skill()
     {
            MultiCondition multiCondition = new MultiCondition(new ICondition[] { new NoCondition() });
            MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Res, 5) });
            Skill skill = new Skill("Resistance +5", "Otorga Res+5.", multiCondition, multiEffect);
            return skill;
     }

     private static Skill CreateAtkDefPlus5Skill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new NoCondition() });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 5), new BonusEffect(StatType.Def, 5) });
         Skill skill = new Skill("Atk/Def +5", "Otorga Atk+5 y Def+5.", multiCondition, multiEffect);
         return skill;
     }
     
     private static Skill CreateSpdResPlus5Skill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new NoCondition() });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Spd, 5), new BonusEffect(StatType.Res, 5) });
         Skill skill = new Skill("Spd/Res +5", "Otorga Spd+5 y Res+5.", multiCondition, multiEffect);
         return skill;
     }

     private static Skill CreateAtkResPlus5Skill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new NoCondition() });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 5), new BonusEffect(StatType.Res, 5) });
         Skill skill = new Skill("Atk/Res +5", "Otorga Atk+5 y Red+5.", multiCondition, multiEffect);
         return skill;
     }
     
    private static Skill CreateArmoredBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Def, 8) });
        Skill skill = new Skill("Armored Blow", "Si la unidad inicia el combate, otorga Def+8 durante el combate", multiCondition, multiEffect);
        return skill;
    }


    private static Skill CreateDeathBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 8) });
        Skill skill = new Skill("Death Blow", "Si la unidad inicia el combate, otorga Atk+8 durante el combate", multiCondition, multiEffect);
        return skill;
    }
    
    private static Skill CreateDartingBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Spd, 8) });
        Skill skill = new Skill("Darting Blow", "Si la unidad inicia el combate, otorga Spd+8 durante el combate", multiCondition, multiEffect);
        return skill;
    }

    private static Skill CreateWardingBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Res, 8) });
        Skill skill = new Skill("Warding Blow", "Si la unidad inicia el combate, otorga Res+8 durante el combate", multiCondition, multiEffect);
        return skill;
    }

    private static Skill CreateSwiftSparrowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 6), new BonusEffect(StatType.Spd, 6) });
        Skill skill = new Skill("Swift Sparrow", "Si la unidad inicia el combate, otorga Atk/Spd+6 durante el combate", multiCondition, multiEffect);
        return skill;
    }

    private static Skill CreateSturdyBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 6), new BonusEffect(StatType.Def, 6) });
        Skill skill = new Skill("Sturdy Blow", "Si la unidad inicia el combate, otorga Atk/Def+6 durante el combate", multiCondition, multiEffect);
        return skill;
    }

    private static Skill CreateMirrorStrikeSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 6), new BonusEffect(StatType.Res, 6) });
        Skill skill = new Skill("Mirror Strike", "Si la unidad inicia el combate, otorga Atk/Res+6 durante el combate", multiCondition, multiEffect);
        return skill;
    }

    private static Skill CreateSteadyBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Spd, 6), new BonusEffect(StatType.Def, 6) });
        Skill skill = new Skill("Steady Blow", "Si la unidad inicia el combate, otorga Spd/Def+6 durante el combate", multiCondition, multiEffect);
        return skill;
    }

    private static Skill CreateSwiftStrikeSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Spd, 6), new BonusEffect(StatType.Res, 6) });
        Skill skill = new Skill("Swift Strike", "Si la unidad inicia el combate, otorga Spd/Res+6 durante el combate", multiCondition, multiEffect);
        return skill;
    }

    private static Skill CreateBracingBlowSkill()
    {
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitBeginAsAttackerCondition() });
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Def, 6), new BonusEffect(StatType.Res, 6) });
        Skill skill = new Skill("Bracing Blow", "Si la unidad inicia el combate, otorga Def/Res+6 durante el combate", multiCondition, multiEffect);
        return skill;
    }

     
     private static Skill CreateTomePrecisionSkill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[] { new UnitWeaponCondition("Magic") });
         MultiEffect multiEffect = new MultiEffect(new IEffect[] { new BonusEffect(StatType.Atk, 6), new BonusEffect(StatType.Spd, 6) }); 
         Skill skill = new Skill("Tome Precision", "Otorga Atk/Spd+6 al usar magia.", multiCondition, multiEffect);
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
         Skill skill = new Skill("Brazen Spd/Res", "Al inicio del combate, si el HP de la unidad ≤ 80 %, otorga Spd/Res+10 durante el combate", multiCondition, multiEffect);
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
        Skill skill = new Skill("Brazen Atk/Spd", "Al inicio del combate, si el HP de la unidad ≤ 80 %, otorga Atk/Spd+10 durante el combate", multiCondition, multiEffect);
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
         Skill skill = new Skill("Brazen Atk/Def", "Al inicio del combate, si el HP de la unidad ≤ 80 %, otorga Atk/Def+10 durante el combate", multiCondition, multiEffect);
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
         Skill skill = new Skill("Brazen Atk/Res", "Al inicio del combate, si el HP de la unidad ≤ 80 %, otorga Atk/Res+10 durante el combate", multiCondition, multiEffect);
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
         Skill skill = new Skill("Brazen Spd/Def", "Al inicio del combate, si el HP de la unidad ≤ 80 %, otorga Spd/Def+10 durante el combate", multiCondition, multiEffect);
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
         Skill skill = new Skill("Brazen Def/Res", "Al inicio del combate, si el HP de la unidad ≤ 80 %, otorga Def/Res+10 durante el combate", multiCondition, multiEffect);
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
         Skill skill = new Skill("Deadly Blade", "Si la unidad inicia el combate con una espada, otorga Atk/Spd+8 durante el combate.", multiCondition, multiEffect);
         return skill;
     }
    
     private static Skill CreateStunningSmileSkill()
     {
         MultiCondition multiCondition = new MultiCondition(new ICondition[]
         {
             new RivalIsManCondition()
         });
         MultiEffect multiEffect = new MultiEffect(new IEffect[]
         {
            new PenaltyEffect(StatType.Spd, 8)
         });
         
            Skill skill = new Skill("Stunning Smile", "Si el rival es hombre, inflige Spd-8 en ese rival durante el combate.", multiCondition, multiEffect);
            return skill;
     }
     
     private static Skill CreateChaosStyleSkill()
     {
         ICondition beginsAsAttacker = new UnitBeginAsAttackerCondition();
         ICondition mixedWeaponCondition = new MixedWeaponCondition(
             new string[] { "Bow", "Sword", "Lance", "Axe" }, // Ejemplo de armas físicas
             new string[] { "Magic" } // Ejemplo de arma mágica
         );

         MultiCondition multiCondition = new MultiCondition(new ICondition[] {
             beginsAsAttacker,
             mixedWeaponCondition
         });

         MultiEffect multiEffect = new MultiEffect(new IEffect[]
         {
             new BonusEffect(StatType.Spd, 3)
         });

         return new Skill("Chaos Style", "Si la unidad inicia el combate con un ataque físico contra un rival armado con magia, o viceversa, otorga Spd+3 durante el combate.", multiCondition, multiEffect);
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

         return new Skill(name, $"Al inicio del combate, si el HP de la unidad ≥ HP del rival+3, otorga {statToBoost}+{boostAmount} durante el combate.", multiCondition, multiEffect);
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
