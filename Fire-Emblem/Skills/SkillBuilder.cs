using Fire_Emblem.Conditions;
using Fire_Emblem.Conditions.LogicalConditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.AlterBaseStat;
using Fire_Emblem.Effects.Damage.AbsoluteDamageReduction;
using Fire_Emblem.Effects.Damage.ExtraChivalryPercentageDamageReduction;
using Fire_Emblem.Effects.Damage.ExtraDamage;
using Fire_Emblem.Effects.Damage.PercentageDamageReduction;
using Fire_Emblem.Effects.Neutralization;
using Fire_Emblem.Stats;
using Fire_Emblem.Skills.TypesCreator;


namespace Fire_Emblem.Skills;

public static class SkillBuilder
{
    
    public static Skill CreateBrazenSpdResSkill()
    {
        return CreateBrazen.CreateBrazenSkill("Brazen Spd/Res", StatType.Spd, StatType.Res);
    }

    public static Skill CreateBrazenAtkSpdSkill()
    {
        return CreateBrazen.CreateBrazenSkill("Brazen Atk/Spd", StatType.Atk, StatType.Spd);
    }

    public static Skill CreateBrazenAtkDefSkill()
    {
        return CreateBrazen.CreateBrazenSkill("Brazen Atk/Def", StatType.Atk, StatType.Def);
    }

    public static Skill CreateBrazenAtkResSkill()
    {
        return CreateBrazen.CreateBrazenSkill("Brazen Atk/Res", StatType.Atk, StatType.Res);
    }

    public static Skill CreateBrazenSpdDefSkill()
    {
        return CreateBrazen.CreateBrazenSkill("Brazen Spd/Def", StatType.Spd, StatType.Def);
    }

    public static Skill CreateBrazenDefResSkill()
    {
        return CreateBrazen.CreateBrazenSkill("Brazen Def/Res", StatType.Def, StatType.Res);
    }
    
    public static Skill CreateFireBoostSkill()
    {
        return CreateBoost.CreateBoostSkill("Fire Boost", StatType.Atk, 6);
    }

    public static Skill CreateWindBoostSkill()
    {
        return CreateBoost.CreateBoostSkill("Wind Boost", StatType.Spd, 6);
    }

    public static Skill CreateEarthBoostSkill()
    {
        return CreateBoost.CreateBoostSkill("Earth Boost", StatType.Def, 6);
    }

    public static Skill CreateWaterBoostSkill()
    {
        return CreateBoost.CreateBoostSkill("Water Boost", StatType.Res, 6);
    }
    
    public static Skill CreateLullAtkSpdSkill()
    {
        return CreateLull.CreateLullSkill("Lull Atk/Spd", StatType.Atk, StatType.Spd);
    }

    public static Skill CreateLullAtkDefSkill()
    {
        return CreateLull.CreateLullSkill("Lull Atk/Def", StatType.Atk, StatType.Def);
    }

    public static Skill CreateLullAtkResSkill()
    {
        return CreateLull.CreateLullSkill("Lull Atk/Res", StatType.Atk, StatType.Res);
    }

    public static Skill CreateLullSpdDefSkill()
    {
        return CreateLull.CreateLullSkill("Lull Spd/Def", StatType.Spd, StatType.Def);
    }

    public static Skill CreateLullSpdResSkill()
    {
        return CreateLull.CreateLullSkill("Lull Spd/Res", StatType.Spd, StatType.Res);
    }

    public static Skill CreateLullDefResSkill()
    {
        return CreateLull.CreateLullSkill("Lull Def/Res", StatType.Def, StatType.Res);
    }
    
    public static Skill CreateSwordFocusSkill()
    {
        return CreateWeaponBonusPenaltySkill.CreateSkill("Sword Focus", "Sword", 
            StatType.Atk, 10, StatType.Res, 10);
    }

    public static Skill CreateBowAgilitySkill()
    {
        return CreateWeaponBonusPenaltySkill.CreateSkill("Bow Agility", "Bow", 
            StatType.Spd, 12, StatType.Atk, 6);
    }

    public static Skill CreateAxePowerSkill()
    {
        return CreateWeaponBonusPenaltySkill.CreateSkill("Axe Power", "Axe", 
            StatType.Atk, 10, StatType.Def, 10);
    }

    public static Skill CreateLanceAgilitySkill()
    {
        return CreateWeaponBonusPenaltySkill.CreateSkill("Lance Agility", "Lance", 
            StatType.Spd, 12, StatType.Atk, 6);
    }

    public static Skill CreateBowFocusSkill()
    {
        return CreateWeaponBonusPenaltySkill.CreateSkill("Bow Focus", "Bow", 
            StatType.Atk, 10, StatType.Res, 10);
    }

    public static Skill CreateSwordPowerSkill()
    {
        return CreateWeaponBonusPenaltySkill.CreateSkill("Sword Power", "Sword", 
            StatType.Atk, 10, StatType.Def, 10);
    }

    public static Skill CreateLancePowerSkill()
    {
        return CreateWeaponBonusPenaltySkill.CreateSkill("Lance Power", "Lance", 
            StatType.Atk, 10, StatType.Def, 10);
    }

    public static Skill CreateSwordAgilitySkill()
    {
        return CreateWeaponBonusPenaltySkill.CreateSkill("Sword Agility", "Sword", 
            StatType.Spd, 12, StatType.Atk, 6);
    }
    
   // Eliminar código duplicado 
    public static Skill CreateHpPlus15Skill()
    {
        ICondition condition = new HasUnitActivatedTheStatAbility();
        
        IEffect effect = new AlterBaseStatEffect(StatType.HP, 15, EffectTarget.Unit);
        
        ConditionalEffect conditionalEffect = new ConditionalEffect(condition, effect);
        
        MultiEffect effects = new MultiEffect(new IEffect[] { conditionalEffect });
        
        return new Skill("HP +15", effects);
    }

    public static Skill CreateWrathSkill()
    {
        ICondition trueCondition = new TrueCondition();
        
        IEffect atkBonusEffect = new DynamicBonusEffect(StatType.Atk, 30, EffectTarget.Unit);
        IEffect spdBonusEffect = new DynamicBonusEffect(StatType.Spd, 30, EffectTarget.Unit);
        
        ConditionalEffect conditionalAtkBonusEffect = new ConditionalEffect(trueCondition, atkBonusEffect);
        ConditionalEffect conditionalSpdBonusEffect = new ConditionalEffect(trueCondition, spdBonusEffect);
        
        MultiEffect effects = new MultiEffect(new IEffect[] { conditionalAtkBonusEffect, conditionalSpdBonusEffect });
        
        return new Skill("Wrath", effects);
    }


    public static Skill CreateBeorcsBlessingSkill()
    {
        ICondition trueCondition = new TrueCondition();
        
        IEffect atkNeutralizationEffect = new NeutralizationBonusEffect(EffectTarget.Rival, StatType.Atk);
        ConditionalEffect conditionalAtkNeutralizationEffect = new ConditionalEffect(trueCondition, atkNeutralizationEffect);

        IEffect spdNeutralizationEffect = new NeutralizationBonusEffect(EffectTarget.Rival, StatType.Spd);
        ConditionalEffect conditionalSpdNeutralizationEffect = new ConditionalEffect(trueCondition, spdNeutralizationEffect);

        IEffect defNeutralizationEffect = new NeutralizationBonusEffect(EffectTarget.Rival, StatType.Def);
        ConditionalEffect conditionalDefNeutralizationEffect = new ConditionalEffect(trueCondition, defNeutralizationEffect);

        IEffect resNeutralizationEffect = new NeutralizationBonusEffect(EffectTarget.Rival, StatType.Res);
        ConditionalEffect conditionalResNeutralizationEffect = new ConditionalEffect(trueCondition, resNeutralizationEffect);
        
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            conditionalAtkNeutralizationEffect,
            conditionalSpdNeutralizationEffect,
            conditionalDefNeutralizationEffect,
            conditionalResNeutralizationEffect
        });
        
        return new Skill("Beorc's Blessing", multiEffect);
    }


    public static Skill CreateAgneasArrowSkill()
{
    ICondition condition = new TrueCondition();

    IEffect atkNeutralizationEffect = new NeutralizationPenaltyEffect(EffectTarget.Unit, StatType.Atk);
    IEffect spdNeutralizationEffect = new NeutralizationPenaltyEffect(EffectTarget.Unit, StatType.Spd);
    IEffect defNeutralizationEffect = new NeutralizationPenaltyEffect(EffectTarget.Unit, StatType.Def);
    IEffect resNeutralizationEffect = new NeutralizationPenaltyEffect(EffectTarget.Unit, StatType.Res);

    ConditionalEffect conditionalAtkNeutralizationEffect = new ConditionalEffect(condition, atkNeutralizationEffect);
    ConditionalEffect conditionalSpdNeutralizationEffect = new ConditionalEffect(condition, spdNeutralizationEffect);
    ConditionalEffect conditionalDefNeutralizationEffect = new ConditionalEffect(condition, defNeutralizationEffect);
    ConditionalEffect conditionalResNeutralizationEffect = new ConditionalEffect(condition, resNeutralizationEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[]
    {
        conditionalAtkNeutralizationEffect,
        conditionalSpdNeutralizationEffect,
        conditionalDefNeutralizationEffect,
        conditionalResNeutralizationEffect
    });

    return new Skill("Agnea's Arrow", multiEffect);
}

public static Skill CreateResolveSkill()
{
    ICondition condition = new UnitHpThresholdCondition(0.75);

    IEffect defBonusEffect = new BonusEffect(StatType.Def, 7, EffectTarget.Unit);
    IEffect resBonusEffect = new BonusEffect(StatType.Res, 7, EffectTarget.Unit);

    ConditionalEffect conditionalDefBonusEffect = new ConditionalEffect(condition, defBonusEffect);
    ConditionalEffect conditionalResBonusEffect = new ConditionalEffect(condition, resBonusEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[]
    {
        conditionalDefBonusEffect,
        conditionalResBonusEffect
    });

    return new Skill("Resolve", multiEffect);
}

public static Skill CreateWillToWinSkill()
{
    ICondition condition = new UnitHpThresholdCondition(0.50);

    IEffect atkBonusEffect = new BonusEffect(StatType.Atk, 8, EffectTarget.Unit);
    ConditionalEffect conditionalAtkBonusEffect = new ConditionalEffect(condition, atkBonusEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalAtkBonusEffect });

    return new Skill("Will to Win", multiEffect);
}

public static Skill CreateFairFightSkill()
{
    ICondition condition = new UnitBeginAsAttackerCondition();

    IEffect atkBonusEffectUnit = new BonusEffect(StatType.Atk, 6, EffectTarget.Unit);
    IEffect atkBonusEffectRival = new BonusEffect(StatType.Atk, 6, EffectTarget.Rival);

    ConditionalEffect conditionalAtkBonusEffectUnit = new ConditionalEffect(condition, atkBonusEffectUnit);
    ConditionalEffect conditionalAtkBonusEffectRival = new ConditionalEffect(condition, atkBonusEffectRival);

    MultiEffect multiEffect = new MultiEffect(new IEffect[]
    {
        conditionalAtkBonusEffectUnit,
        conditionalAtkBonusEffectRival
    });

    return new Skill("Fair Fight", multiEffect);
}

public static Skill CreateFortDefResSkill()
{
    ICondition condition = new TrueCondition();

    IEffect defBonusEffect = new BonusEffect(StatType.Def, 6, EffectTarget.Unit);
    IEffect resBonusEffect = new BonusEffect(StatType.Res, 6, EffectTarget.Unit);
    IEffect atkPenaltyEffect = new PenaltyEffect(StatType.Atk, 2, EffectTarget.Unit);

    ConditionalEffect conditionalDefBonusEffect = new ConditionalEffect(condition, defBonusEffect);
    ConditionalEffect conditionalResBonusEffect = new ConditionalEffect(condition, resBonusEffect);
    ConditionalEffect conditionalAtkPenaltyEffect = new ConditionalEffect(condition, atkPenaltyEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[]
    {
        conditionalDefBonusEffect,
        conditionalResBonusEffect,
        conditionalAtkPenaltyEffect
    });

    return new Skill("Fort. Def/Res", multiEffect);
}

public static Skill CreateLifeAndDeathSkill()
{
    ICondition condition = new TrueCondition();

    IEffect atkBonusEffect = new BonusEffect(StatType.Atk, 6, EffectTarget.Unit);
    IEffect spdBonusEffect = new BonusEffect(StatType.Spd, 6, EffectTarget.Unit);
    IEffect defPenaltyEffect = new PenaltyEffect(StatType.Def, 5, EffectTarget.Unit);
    IEffect resPenaltyEffect = new PenaltyEffect(StatType.Res, 5, EffectTarget.Unit);

    ConditionalEffect conditionalAtkBonusEffect = new ConditionalEffect(condition, atkBonusEffect);
    ConditionalEffect conditionalSpdBonusEffect = new ConditionalEffect(condition, spdBonusEffect);
    ConditionalEffect conditionalDefPenaltyEffect = new ConditionalEffect(condition, defPenaltyEffect);
    ConditionalEffect conditionalResPenaltyEffect = new ConditionalEffect(condition, resPenaltyEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[]
    {
        conditionalAtkBonusEffect,
        conditionalSpdBonusEffect,
        conditionalDefPenaltyEffect,
        conditionalResPenaltyEffect
    });

    return new Skill("Life and Death", multiEffect);
}

public static Skill CreateSolidGroundSkill()
{
    ICondition condition = new TrueCondition();

    IEffect atkBonusEffect = new BonusEffect(StatType.Atk, 6, EffectTarget.Unit);
    IEffect defBonusEffect = new BonusEffect(StatType.Def, 6, EffectTarget.Unit);
    IEffect resPenaltyEffect = new PenaltyEffect(StatType.Res, 5, EffectTarget.Unit);

    ConditionalEffect conditionalAtkBonusEffect = new ConditionalEffect(condition, atkBonusEffect);
    ConditionalEffect conditionalDefBonusEffect = new ConditionalEffect(condition, defBonusEffect);
    ConditionalEffect conditionalResPenaltyEffect = new ConditionalEffect(condition, resPenaltyEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[]
    {
        conditionalAtkBonusEffect,
        conditionalDefBonusEffect,
        conditionalResPenaltyEffect
    });

    return new Skill("Solid Ground", multiEffect);
}

public static Skill CreateStillWaterSkill()
{
    ICondition condition = new TrueCondition();

    IEffect atkBonusEffect = new BonusEffect(StatType.Atk, 6, EffectTarget.Unit);
    IEffect resBonusEffect = new BonusEffect(StatType.Res, 6, EffectTarget.Unit);
    IEffect defPenaltyEffect = new PenaltyEffect(StatType.Def, 5, EffectTarget.Unit);

    ConditionalEffect conditionalAtkBonusEffect = new ConditionalEffect(condition, atkBonusEffect);
    ConditionalEffect conditionalResBonusEffect = new ConditionalEffect(condition, resBonusEffect);
    ConditionalEffect conditionalDefPenaltyEffect = new ConditionalEffect(condition, defPenaltyEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[]
    {
        conditionalAtkBonusEffect,
        conditionalResBonusEffect,
        conditionalDefPenaltyEffect
    });

    return new Skill("Still Water", multiEffect);
}


    public static Skill CreateAttackPlus6Skill()
    {
        ICondition trueCondition = new TrueCondition();
        IEffect atkBonusEffect = new BonusEffect(StatType.Atk, 6, EffectTarget.Unit);
        ConditionalEffect conditionalAtkBonusEffect = new ConditionalEffect(trueCondition, atkBonusEffect);

        MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalAtkBonusEffect });

        return new Skill("Attack +6", multiEffect);
    }

    public static Skill CreateSpeedPlus5Skill()
    {
        ICondition trueCondition = new TrueCondition();
        IEffect spdBonusEffect = new BonusEffect(StatType.Spd, 5, EffectTarget.Unit);
        ConditionalEffect conditionalSpdBonusEffect = new ConditionalEffect(trueCondition, spdBonusEffect);

        MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalSpdBonusEffect });

        return new Skill("Speed +5", multiEffect);
    }

    public static Skill CreateDefensePlus5Skill()
    {
        ICondition trueCondition = new TrueCondition();
        IEffect defBonusEffect = new BonusEffect(StatType.Def, 5, EffectTarget.Unit);
        ConditionalEffect conditionalDefBonusEffect = new ConditionalEffect(trueCondition, defBonusEffect);

        MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalDefBonusEffect });

        return new Skill("Defense +5", multiEffect);
    }

    public static Skill CreateResistancePlus5Skill()
    {
        ICondition trueCondition = new TrueCondition();
        IEffect resBonusEffect = new BonusEffect(StatType.Res, 5, EffectTarget.Unit);
        ConditionalEffect conditionalResBonusEffect = new ConditionalEffect(trueCondition, resBonusEffect);

        MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalResBonusEffect });

        return new Skill("Resistance +5", multiEffect);
    }

    public static Skill CreateAtkDefPlus5Skill()
    {
        ICondition trueCondition = new TrueCondition();
        IEffect atkBonusEffect = new BonusEffect(StatType.Atk, 5, EffectTarget.Unit);
        IEffect defBonusEffect = new BonusEffect(StatType.Def, 5, EffectTarget.Unit);

        ConditionalEffect conditionalAtkBonusEffect = new ConditionalEffect(trueCondition, atkBonusEffect);
        ConditionalEffect conditionalDefBonusEffect = new ConditionalEffect(trueCondition, defBonusEffect);

        MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalAtkBonusEffect, conditionalDefBonusEffect });

        return new Skill("Atk/Def +5", multiEffect);
    }

    public static Skill CreateSpdResPlus5Skill()
    {
        ICondition trueCondition = new TrueCondition();
        IEffect spdBonusEffect = new BonusEffect(StatType.Spd, 5, EffectTarget.Unit);
        IEffect resBonusEffect = new BonusEffect(StatType.Res, 5, EffectTarget.Unit);

        ConditionalEffect conditionalSpdBonusEffect = new ConditionalEffect(trueCondition, spdBonusEffect);
        ConditionalEffect conditionalResBonusEffect = new ConditionalEffect(trueCondition, resBonusEffect);

        MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalSpdBonusEffect, conditionalResBonusEffect });

        return new Skill("Spd/Res +5", multiEffect);
    }

    public static Skill CreateAtkResPlus5Skill()
    {
        ICondition trueCondition = new TrueCondition();
        IEffect atkBonusEffect = new BonusEffect(StatType.Atk, 5, EffectTarget.Unit);
        IEffect resBonusEffect = new BonusEffect(StatType.Res, 5, EffectTarget.Unit);

        ConditionalEffect conditionalAtkBonusEffect = new ConditionalEffect(trueCondition, atkBonusEffect);
        ConditionalEffect conditionalResBonusEffect = new ConditionalEffect(trueCondition, resBonusEffect);

        MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalAtkBonusEffect, conditionalResBonusEffect });

        return new Skill("Atk/Res +5", multiEffect);
    }


    public static Skill CreateArmoredBlowSkill()
{
    ICondition condition = new UnitBeginAsAttackerCondition();
    IEffect defBonusEffect = new BonusEffect(StatType.Def, 8, EffectTarget.Unit);
    ConditionalEffect conditionalDefBonusEffect = new ConditionalEffect(condition, defBonusEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalDefBonusEffect });

    return new Skill("Armored Blow", multiEffect);
}

public static Skill CreateDeathBlowSkill()
{
    ICondition condition = new UnitBeginAsAttackerCondition();
    IEffect atkBonusEffect = new BonusEffect(StatType.Atk, 8, EffectTarget.Unit);
    ConditionalEffect conditionalAtkBonusEffect = new ConditionalEffect(condition, atkBonusEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalAtkBonusEffect });

    return new Skill("Death Blow", multiEffect);
}

public static Skill CreateDartingBlowSkill()
{
    ICondition condition = new UnitBeginAsAttackerCondition();
    IEffect spdBonusEffect = new BonusEffect(StatType.Spd, 8, EffectTarget.Unit);
    ConditionalEffect conditionalSpdBonusEffect = new ConditionalEffect(condition, spdBonusEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalSpdBonusEffect });

    return new Skill("Darting Blow", multiEffect);
}

public static Skill CreateWardingBlowSkill()
{
    ICondition condition = new UnitBeginAsAttackerCondition();
    IEffect resBonusEffect = new BonusEffect(StatType.Res, 8, EffectTarget.Unit);
    ConditionalEffect conditionalResBonusEffect = new ConditionalEffect(condition, resBonusEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalResBonusEffect });

    return new Skill("Warding Blow", multiEffect);
}

public static Skill CreateSwiftSparrowSkill()
{
    ICondition condition = new UnitBeginAsAttackerCondition();
    IEffect atkBonusEffect = new BonusEffect(StatType.Atk, 6, EffectTarget.Unit);
    IEffect spdBonusEffect = new BonusEffect(StatType.Spd, 6, EffectTarget.Unit);

    ConditionalEffect conditionalAtkBonusEffect = new ConditionalEffect(condition, atkBonusEffect);
    ConditionalEffect conditionalSpdBonusEffect = new ConditionalEffect(condition, spdBonusEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalAtkBonusEffect, conditionalSpdBonusEffect });

    return new Skill("Swift Sparrow", multiEffect);
}

public static Skill CreateSturdyBlowSkill()
{
    ICondition condition = new UnitBeginAsAttackerCondition();
    IEffect atkBonusEffect = new BonusEffect(StatType.Atk, 6, EffectTarget.Unit);
    IEffect defBonusEffect = new BonusEffect(StatType.Def, 6, EffectTarget.Unit);

    ConditionalEffect conditionalAtkBonusEffect = new ConditionalEffect(condition, atkBonusEffect);
    ConditionalEffect conditionalDefBonusEffect = new ConditionalEffect(condition, defBonusEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalAtkBonusEffect, conditionalDefBonusEffect });

    return new Skill("Sturdy Blow", multiEffect);
}

public static Skill CreateMirrorStrikeSkill()
{
    ICondition condition = new UnitBeginAsAttackerCondition();
    IEffect atkBonusEffect = new BonusEffect(StatType.Atk, 6, EffectTarget.Unit);
    IEffect resBonusEffect = new BonusEffect(StatType.Res, 6, EffectTarget.Unit);

    ConditionalEffect conditionalAtkBonusEffect = new ConditionalEffect(condition, atkBonusEffect);
    ConditionalEffect conditionalResBonusEffect = new ConditionalEffect(condition, resBonusEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalAtkBonusEffect, conditionalResBonusEffect });

    return new Skill("Mirror Strike", multiEffect);
}

public static Skill CreateSteadyBlowSkill()
{
    ICondition condition = new UnitBeginAsAttackerCondition();
    IEffect spdBonusEffect = new BonusEffect(StatType.Spd, 6, EffectTarget.Unit);
    IEffect defBonusEffect = new BonusEffect(StatType.Def, 6, EffectTarget.Unit);

    ConditionalEffect conditionalSpdBonusEffect = new ConditionalEffect(condition, spdBonusEffect);
    ConditionalEffect conditionalDefBonusEffect = new ConditionalEffect(condition, defBonusEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalSpdBonusEffect, conditionalDefBonusEffect });

    return new Skill("Steady Blow", multiEffect);
}

public static Skill CreateSwiftStrikeSkill()
{
    ICondition condition = new UnitBeginAsAttackerCondition();
    IEffect spdBonusEffect = new BonusEffect(StatType.Spd, 6, EffectTarget.Unit);
    IEffect resBonusEffect = new BonusEffect(StatType.Res, 6, EffectTarget.Unit);

    ConditionalEffect conditionalSpdBonusEffect = new ConditionalEffect(condition, spdBonusEffect);
    ConditionalEffect conditionalResBonusEffect = new ConditionalEffect(condition, resBonusEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalSpdBonusEffect, conditionalResBonusEffect });

    return new Skill("Swift Strike", multiEffect);
}

public static Skill CreateBracingBlowSkill()
{
    ICondition condition = new UnitBeginAsAttackerCondition();
    IEffect defBonusEffect = new BonusEffect(StatType.Def, 6, EffectTarget.Unit);
    IEffect resBonusEffect = new BonusEffect(StatType.Res, 6, EffectTarget.Unit);

    ConditionalEffect conditionalDefBonusEffect = new ConditionalEffect(condition, defBonusEffect);
    ConditionalEffect conditionalResBonusEffect = new ConditionalEffect(condition, resBonusEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalDefBonusEffect, conditionalResBonusEffect });

    return new Skill("Bracing Blow", multiEffect);
}

public static Skill CreateTomePrecisionSkill()
{
    ICondition condition = new UnitWeaponCondition("Magic");
    IEffect atkBonusEffect = new BonusEffect(StatType.Atk, 6, EffectTarget.Unit);
    IEffect spdBonusEffect = new BonusEffect(StatType.Spd, 6, EffectTarget.Unit);

    ConditionalEffect conditionalAtkBonusEffect = new ConditionalEffect(condition, atkBonusEffect);
    ConditionalEffect conditionalSpdBonusEffect = new ConditionalEffect(condition, spdBonusEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalAtkBonusEffect, conditionalSpdBonusEffect });

    return new Skill("Tome Precision", multiEffect);
}

public static Skill CreateCloseDefSkill()
{
    ICondition condition = new AndCondition(
        new RivalBeginAsAttacker(),
        new RivalWeaponCondition("Sword", "Lance", "Axe")
    );

    IEffect defBonusEffect = new BonusEffect(StatType.Def, 8, EffectTarget.Unit);
    IEffect resBonusEffect = new BonusEffect(StatType.Res, 8, EffectTarget.Unit);
    IEffect atkNeutralizationEffect = new NeutralizationBonusEffect(EffectTarget.Rival, StatType.Atk);
    IEffect spdNeutralizationEffect = new NeutralizationBonusEffect(EffectTarget.Rival, StatType.Spd);
    IEffect defNeutralizationEffect = new NeutralizationBonusEffect(EffectTarget.Rival, StatType.Def);
    IEffect resNeutralizationEffect = new NeutralizationBonusEffect(EffectTarget.Rival, StatType.Res);

    ConditionalEffect conditionalDefBonusEffect = new ConditionalEffect(condition, defBonusEffect);
    ConditionalEffect conditionalResBonusEffect = new ConditionalEffect(condition, resBonusEffect);
    ConditionalEffect conditionalAtkNeutralizationEffect = new ConditionalEffect(condition, atkNeutralizationEffect);
    ConditionalEffect conditionalSpdNeutralizationEffect = new ConditionalEffect(condition, spdNeutralizationEffect);
    ConditionalEffect conditionalDefNeutralizationEffect = new ConditionalEffect(condition, defNeutralizationEffect);
    ConditionalEffect conditionalResNeutralizationEffect = new ConditionalEffect(condition, resNeutralizationEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[]
    {
        conditionalDefBonusEffect,
        conditionalResBonusEffect,
        conditionalAtkNeutralizationEffect,
        conditionalSpdNeutralizationEffect,
        conditionalDefNeutralizationEffect,
        conditionalResNeutralizationEffect
    });

    return new Skill("Close Def", multiEffect);
}

public static Skill CreateDistantDefSkill()
{
    ICondition condition = new AndCondition(
        new RivalBeginAsAttacker(),
        new RivalWeaponCondition("Magic", "Bow")
    );

    IEffect defBonusEffect = new BonusEffect(StatType.Def, 8, EffectTarget.Unit);
    IEffect resBonusEffect = new BonusEffect(StatType.Res, 8, EffectTarget.Unit);
    IEffect atkNeutralizationEffect = new NeutralizationBonusEffect(EffectTarget.Rival, StatType.Atk);
    IEffect spdNeutralizationEffect = new NeutralizationBonusEffect(EffectTarget.Rival, StatType.Spd);
    IEffect defNeutralizationEffect = new NeutralizationBonusEffect(EffectTarget.Rival, StatType.Def);
    IEffect resNeutralizationEffect = new NeutralizationBonusEffect(EffectTarget.Rival, StatType.Res);

    ConditionalEffect conditionalDefBonusEffect = new ConditionalEffect(condition, defBonusEffect);
    ConditionalEffect conditionalResBonusEffect = new ConditionalEffect(condition, resBonusEffect);
    ConditionalEffect conditionalAtkNeutralizationEffect = new ConditionalEffect(condition, atkNeutralizationEffect);
    ConditionalEffect conditionalSpdNeutralizationEffect = new ConditionalEffect(condition, spdNeutralizationEffect);
    ConditionalEffect conditionalDefNeutralizationEffect = new ConditionalEffect(condition, defNeutralizationEffect);
    ConditionalEffect conditionalResNeutralizationEffect = new ConditionalEffect(condition, resNeutralizationEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[]
    {
        conditionalDefBonusEffect,
        conditionalResBonusEffect,
        conditionalAtkNeutralizationEffect,
        conditionalSpdNeutralizationEffect,
        conditionalDefNeutralizationEffect,
        conditionalResNeutralizationEffect
    });

    return new Skill("Distant Def", multiEffect);
}

public static Skill CreateBeliefInLoveSkill()
{
    ICondition condition = new OrCondition(
        new RivalBeginAsAttacker(),
        new RivalHpThresholdCondition(1.0)
    );

    IEffect atkPenaltyEffect = new PenaltyEffect(StatType.Atk, 5, EffectTarget.Rival);
    IEffect defPenaltyEffect = new PenaltyEffect(StatType.Def, 5, EffectTarget.Rival);

    ConditionalEffect conditionalAtkPenaltyEffect = new ConditionalEffect(condition, atkPenaltyEffect);
    ConditionalEffect conditionalDefPenaltyEffect = new ConditionalEffect(condition, defPenaltyEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[]
    {
        conditionalAtkPenaltyEffect,
        conditionalDefPenaltyEffect
    });

    return new Skill("Belief in Love", multiEffect);
}

public static Skill CreateDeadlyBladeSkill()
{
    ICondition condition = new AndCondition(
        new UnitWeaponCondition("Sword"),
        new UnitBeginAsAttackerCondition()
    );

    IEffect atkBonusEffect = new BonusEffect(StatType.Atk, 8, EffectTarget.Unit);
    IEffect spdBonusEffect = new BonusEffect(StatType.Spd, 8, EffectTarget.Unit);

    ConditionalEffect conditionalAtkBonusEffect = new ConditionalEffect(condition, atkBonusEffect);
    ConditionalEffect conditionalSpdBonusEffect = new ConditionalEffect(condition, spdBonusEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[]
    {
        conditionalAtkBonusEffect,
        conditionalSpdBonusEffect
    });

    return new Skill("Deadly Blade", multiEffect);
}

public static Skill CreateBlindingFlashSkill()
{
    ICondition condition = new UnitBeginAsAttackerCondition();

    IEffect spdPenaltyEffect = new PenaltyEffect(StatType.Spd, 4, EffectTarget.Rival);
    ConditionalEffect conditionalSpdPenaltyEffect = new ConditionalEffect(condition, spdPenaltyEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalSpdPenaltyEffect });

    return new Skill("Blinding Flash", multiEffect);
}

    public static Skill CreateNotQuiteSkill()
{
    ICondition condition = new RivalBeginAsAttacker();
    IEffect atkPenaltyEffect = new PenaltyEffect(StatType.Atk, 4, EffectTarget.Rival);
    ConditionalEffect conditionalAtkPenaltyEffect = new ConditionalEffect(condition, atkPenaltyEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalAtkPenaltyEffect });

    return new Skill("Not Quite", multiEffect);
}

public static Skill CreateChaosStyleSkill()
{
    ICondition beginsAsAttacker = new UnitBeginAsAttackerCondition();
    ICondition mixedWeaponCondition = new MixedWeaponCondition(
        new string[] { "Bow", "Sword", "Lance", "Axe" },
        new string[] { "Magic" }
    );

    ICondition condition = new AndCondition(beginsAsAttacker, mixedWeaponCondition);
    IEffect spdBonusEffect = new BonusEffect(StatType.Spd, 3, EffectTarget.Unit);
    ConditionalEffect conditionalSpdBonusEffect = new ConditionalEffect(condition, spdBonusEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalSpdBonusEffect });

    return new Skill("Chaos Style", multiEffect);
}

public static Skill CreateStunningSmileSkill()
{
    ICondition condition = new RivalIsManCondition();
    IEffect spdPenaltyEffect = new PenaltyEffect(StatType.Spd, 8, EffectTarget.Rival);
    ConditionalEffect conditionalSpdPenaltyEffect = new ConditionalEffect(condition, spdPenaltyEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalSpdPenaltyEffect });

    return new Skill("Stunning Smile", multiEffect);
}

public static Skill CreateDisarmingSighSkill()
{
    ICondition condition = new RivalIsManCondition();
    IEffect atkPenaltyEffect = new PenaltyEffect(StatType.Atk, 8, EffectTarget.Rival);
    ConditionalEffect conditionalAtkPenaltyEffect = new ConditionalEffect(condition, atkPenaltyEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalAtkPenaltyEffect });

    return new Skill("Disarming Sigh", multiEffect);
}

public static Skill CreateLightAndDarkSkill()
{
    ICondition condition = new TrueCondition(); // Siempre se activa

    IEffect atkPenaltyEffect = new PenaltyEffect(StatType.Atk, 5, EffectTarget.Rival);
    IEffect spdPenaltyEffect = new PenaltyEffect(StatType.Spd, 5, EffectTarget.Rival);
    IEffect defPenaltyEffect = new PenaltyEffect(StatType.Def, 5, EffectTarget.Rival);
    IEffect resPenaltyEffect = new PenaltyEffect(StatType.Res, 5, EffectTarget.Rival);
    IEffect atkNeutralizationEffect = new NeutralizationBonusEffect(EffectTarget.Rival, StatType.Atk);
    IEffect spdNeutralizationEffect = new NeutralizationBonusEffect(EffectTarget.Rival, StatType.Spd);
    IEffect defNeutralizationEffect = new NeutralizationBonusEffect(EffectTarget.Rival, StatType.Def);
    IEffect resNeutralizationEffect = new NeutralizationBonusEffect(EffectTarget.Rival, StatType.Res);
    IEffect atkPenaltyNeutralizationEffect = new NeutralizationPenaltyEffect(EffectTarget.Unit, StatType.Atk);
    IEffect spdPenaltyNeutralizationEffect = new NeutralizationPenaltyEffect(EffectTarget.Unit, StatType.Spd);
    IEffect defPenaltyNeutralizationEffect = new NeutralizationPenaltyEffect(EffectTarget.Unit, StatType.Def);
    IEffect resPenaltyNeutralizationEffect = new NeutralizationPenaltyEffect(EffectTarget.Unit, StatType.Res);

    ConditionalEffect conditionalAtkPenaltyEffect = new ConditionalEffect(condition, atkPenaltyEffect);
    ConditionalEffect conditionalSpdPenaltyEffect = new ConditionalEffect(condition, spdPenaltyEffect);
    ConditionalEffect conditionalDefPenaltyEffect = new ConditionalEffect(condition, defPenaltyEffect);
    ConditionalEffect conditionalResPenaltyEffect = new ConditionalEffect(condition, resPenaltyEffect);
    ConditionalEffect conditionalAtkNeutralizationEffect = new ConditionalEffect(condition, atkNeutralizationEffect);
    ConditionalEffect conditionalSpdNeutralizationEffect = new ConditionalEffect(condition, spdNeutralizationEffect);
    ConditionalEffect conditionalDefNeutralizationEffect = new ConditionalEffect(condition, defNeutralizationEffect);
    ConditionalEffect conditionalResNeutralizationEffect = new ConditionalEffect(condition, resNeutralizationEffect);
    ConditionalEffect conditionalAtkPenaltyNeutralizationEffect = new ConditionalEffect(condition, atkPenaltyNeutralizationEffect);
    ConditionalEffect conditionalSpdPenaltyNeutralizationEffect = new ConditionalEffect(condition, spdPenaltyNeutralizationEffect);
    ConditionalEffect conditionalDefPenaltyNeutralizationEffect = new ConditionalEffect(condition, defPenaltyNeutralizationEffect);
    ConditionalEffect conditionalResPenaltyNeutralizationEffect = new ConditionalEffect(condition, resPenaltyNeutralizationEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[]
    {
        conditionalAtkPenaltyEffect,
        conditionalSpdPenaltyEffect,
        conditionalDefPenaltyEffect,
        conditionalResPenaltyEffect,
        conditionalAtkNeutralizationEffect,
        conditionalSpdNeutralizationEffect,
        conditionalDefNeutralizationEffect,
        conditionalResNeutralizationEffect,
        conditionalAtkPenaltyNeutralizationEffect,
        conditionalSpdPenaltyNeutralizationEffect,
        conditionalDefPenaltyNeutralizationEffect,
        conditionalResPenaltyNeutralizationEffect
    });

    return new Skill("Light and Dark", multiEffect);
}

public static Skill CreateDragonskinSkill()
{
    ICondition condition = new OrCondition(
        new RivalBeginAsAttacker(),
        new RivalHpAboveThresholdCondition(0.75)
    );

    IEffect atkBonusEffect = new BonusEffect(StatType.Atk, 6, EffectTarget.Unit);
    IEffect spdBonusEffect = new BonusEffect(StatType.Spd, 6, EffectTarget.Unit);
    IEffect defBonusEffect = new BonusEffect(StatType.Def, 6, EffectTarget.Unit);
    IEffect resBonusEffect = new BonusEffect(StatType.Res, 6, EffectTarget.Unit);
    IEffect atkNeutralizationEffect = new NeutralizationBonusEffect(EffectTarget.Rival, StatType.Atk);
    IEffect spdNeutralizationEffect = new NeutralizationBonusEffect(EffectTarget.Rival, StatType.Spd);
    IEffect defNeutralizationEffect = new NeutralizationBonusEffect(EffectTarget.Rival, StatType.Def);
    IEffect resNeutralizationEffect = new NeutralizationBonusEffect(EffectTarget.Rival, StatType.Res);

    ConditionalEffect conditionalAtkBonusEffect = new ConditionalEffect(condition, atkBonusEffect);
    ConditionalEffect conditionalSpdBonusEffect = new ConditionalEffect(condition, spdBonusEffect);
    ConditionalEffect conditionalDefBonusEffect = new ConditionalEffect(condition, defBonusEffect);
    ConditionalEffect conditionalResBonusEffect = new ConditionalEffect(condition, resBonusEffect);
    ConditionalEffect conditionalAtkNeutralizationEffect = new ConditionalEffect(condition, atkNeutralizationEffect);
    ConditionalEffect conditionalSpdNeutralizationEffect = new ConditionalEffect(condition, spdNeutralizationEffect);
    ConditionalEffect conditionalDefNeutralizationEffect = new ConditionalEffect(condition, defNeutralizationEffect);
    ConditionalEffect conditionalResNeutralizationEffect = new ConditionalEffect(condition, resNeutralizationEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[]
    {
        conditionalAtkBonusEffect,
        conditionalSpdBonusEffect,
        conditionalDefBonusEffect,
        conditionalResBonusEffect,
        conditionalAtkNeutralizationEffect,
        conditionalSpdNeutralizationEffect,
        conditionalDefNeutralizationEffect,
        conditionalResNeutralizationEffect
    });

    return new Skill("Dragonskin", multiEffect);
}

public static Skill CreateIgnisSkill()
{
    ICondition condition = new TrueCondition();
    IEffect firstAttackBonusEffect = new FirstAttackBonusEffect(StatType.Atk, 50, EffectTarget.Unit);
    ConditionalEffect conditionalFirstAttackBonusEffect = new ConditionalEffect(condition, firstAttackBonusEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalFirstAttackBonusEffect });

    return new Skill("Ignis", multiEffect);
}

public static Skill CreateSingleMindedSkill()
{
    ICondition condition = new RivalIsLastOpponentFaced();
    IEffect atkBonusEffect = new BonusEffect(StatType.Atk, 8, EffectTarget.Unit);
    ConditionalEffect conditionalAtkBonusEffect = new ConditionalEffect(condition, atkBonusEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalAtkBonusEffect });

    return new Skill("Single Minded", multiEffect);
}

public static Skill CreateCharmerSkill()
{
    ICondition condition = new RivalIsLastOpponentFaced();
    IEffect atkPenaltyEffect = new PenaltyEffect(StatType.Atk, 3, EffectTarget.Rival);
    IEffect spdPenaltyEffect = new PenaltyEffect(StatType.Spd, 3, EffectTarget.Rival);

    ConditionalEffect conditionalAtkPenaltyEffect = new ConditionalEffect(condition, atkPenaltyEffect);
    ConditionalEffect conditionalSpdPenaltyEffect = new ConditionalEffect(condition, spdPenaltyEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalAtkPenaltyEffect, conditionalSpdPenaltyEffect });

    return new Skill("Charmer", multiEffect);
}

public static Skill CreatePerceptiveSkill()
{
    ICondition condition = new UnitBeginAsAttackerCondition();
    IEffect perceptiveEffect = new PerceptiveEffect(EffectTarget.Unit);
    ConditionalEffect conditionalPerceptiveEffect = new ConditionalEffect(condition, perceptiveEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalPerceptiveEffect });

    return new Skill("Perceptive", multiEffect);
}

public static Skill CreateLunaSkill()
{
    ICondition condition = new TrueCondition();
    IEffect defPenaltyEffect = new FirstAttackPenaltyEffect(StatType.Def, 50, EffectTarget.Rival);
    IEffect resPenaltyEffect = new FirstAttackPenaltyEffect(StatType.Res, 50, EffectTarget.Rival);

    ConditionalEffect conditionalDefPenaltyEffect = new ConditionalEffect(condition, defPenaltyEffect);
    ConditionalEffect conditionalResPenaltyEffect = new ConditionalEffect(condition, resPenaltyEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalDefPenaltyEffect, conditionalResPenaltyEffect });

    return new Skill("Luna", multiEffect);
}

public static Skill CreateBraverySkill()
{
    ICondition condition = new TrueCondition();
    IEffect extraDamageEffect = new ExtraDamageEffect(5, EffectTarget.Unit);
    ConditionalEffect conditionalExtraDamageEffect = new ConditionalEffect(condition, extraDamageEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalExtraDamageEffect });

    return new Skill("Bravery", multiEffect);
}

public static Skill CreateGentilitySkill()
{
    ICondition condition = new TrueCondition();
    IEffect absoluteDamageReductionEffect = new AbsoluteDamageReductionEffect(5, EffectTarget.Unit);
    ConditionalEffect conditionalAbsoluteDamageReductionEffect = new ConditionalEffect(condition, absoluteDamageReductionEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalAbsoluteDamageReductionEffect });

    return new Skill("Gentility", multiEffect);
}

    public static Skill CreateBowGuardSkill()
    {
        return CreateWeaponGuard.CreateWeaponGuardSkill("Bow");
    }
    
    public static Skill CreateAxeGuardSkill()
    {
        return CreateWeaponGuard.CreateWeaponGuardSkill("Axe");
    }
    
    public static Skill CreateLanceGuardSkill()
    {
        return CreateWeaponGuard.CreateWeaponGuardSkill("Lance");
    }
    
    public static Skill CreateMagicGuardSkill()
    {
        return CreateWeaponGuard.CreateWeaponGuardSkill("Magic");
    }
    
    public static Skill CreateArmsShieldSkill()
{
    ICondition condition = new UnitWeaponAdvantageCondition();
    IEffect absoluteDamageReductionEffect = new AbsoluteDamageReductionEffect(7, EffectTarget.Unit);
    ConditionalEffect conditionalAbsoluteDamageReductionEffect = new ConditionalEffect(condition, absoluteDamageReductionEffect);

    MultiEffect effects = new MultiEffect(new IEffect[] { conditionalAbsoluteDamageReductionEffect });

    return new Skill("Arms Shield", effects);
}

public static Skill CreateSympatheticSkill()
{
    ICondition condition = new AndCondition(
        new RivalBeginAsAttacker(),
        new UnitHpThresholdCondition(0.5)
    );

    IEffect absoluteDamageReductionEffect = new AbsoluteDamageReductionEffect(5, EffectTarget.Unit);
    ConditionalEffect conditionalAbsoluteDamageReductionEffect = new ConditionalEffect(condition, absoluteDamageReductionEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalAbsoluteDamageReductionEffect });

    return new Skill("Sympathetic", multiEffect);
}

public static Skill CreateBlueSkiesSkill()
{
    ICondition condition = new TrueCondition();

    IEffect absoluteDamageReductionEffect = new AbsoluteDamageReductionEffect(5, EffectTarget.Unit);
    IEffect extraDamageEffect = new ExtraDamageEffect(5, EffectTarget.Unit);

    ConditionalEffect conditionalAbsoluteDamageReductionEffect = new ConditionalEffect(condition, absoluteDamageReductionEffect);
    ConditionalEffect conditionalExtraDamageEffect = new ConditionalEffect(condition, extraDamageEffect);

    MultiEffect effects = new MultiEffect(new IEffect[] { conditionalAbsoluteDamageReductionEffect, conditionalExtraDamageEffect });

    return new Skill("Blue Skies", effects);
}

public static Skill CreateChivalrySkill()
{
    ICondition condition = new AndCondition(
        new UnitBeginAsAttackerCondition(),
        new RivalHpThresholdCondition(1)
    );

    IEffect extraDamageEffect = new ExtraDamageEffect(2, EffectTarget.Unit);
    IEffect absoluteDamageReductionEffect = new AbsoluteDamageReductionEffect(2, EffectTarget.Unit);

    ConditionalEffect conditionalExtraDamageEffect = new ConditionalEffect(condition, extraDamageEffect);
    ConditionalEffect conditionalAbsoluteDamageReductionEffect = new ConditionalEffect(condition, absoluteDamageReductionEffect);

    MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalExtraDamageEffect, conditionalAbsoluteDamageReductionEffect });

    return new Skill("Chivalry", multiEffect);
}

public static Skill CreateAegisShieldSkill()
{
    ICondition condition = new TrueCondition();

    IEffect defBonusEffect = new BonusEffect(StatType.Def, 6, EffectTarget.Unit);
    IEffect resBonusEffect = new BonusEffect(StatType.Res, 3, EffectTarget.Unit);
    IEffect firstAttackPercentageDamageReductionEffect = new FirstAttackPercentageDamageReductionEffect(0.5, EffectTarget.Unit);

    ConditionalEffect conditionalDefBonusEffect = new ConditionalEffect(condition, defBonusEffect);
    ConditionalEffect conditionalResBonusEffect = new ConditionalEffect(condition, resBonusEffect);
    ConditionalEffect conditionalFirstAttackPercentageDamageReductionEffect = new ConditionalEffect(condition, firstAttackPercentageDamageReductionEffect);

    MultiEffect effects = new MultiEffect(new IEffect[]
    {
        conditionalDefBonusEffect,
        conditionalResBonusEffect,
        conditionalFirstAttackPercentageDamageReductionEffect
    });

    return new Skill("Aegis Shield", effects);
}

public static Skill CreateRemoteSparrowSkill()
{
    ICondition condition = new UnitBeginAsAttackerCondition();

    IEffect atkBonusEffect = new BonusEffect(StatType.Atk, 7, EffectTarget.Unit);
    IEffect spdBonusEffect = new BonusEffect(StatType.Spd, 7, EffectTarget.Unit);
    IEffect firstAttackPercentageDamageReductionEffect = new FirstAttackPercentageDamageReductionEffect(0.3, EffectTarget.Unit);

    ConditionalEffect conditionalAtkBonusEffect = new ConditionalEffect(condition, atkBonusEffect);
    ConditionalEffect conditionalSpdBonusEffect = new ConditionalEffect(condition, spdBonusEffect);
    ConditionalEffect conditionalFirstAttackPercentageDamageReductionEffect = new ConditionalEffect(condition, firstAttackPercentageDamageReductionEffect);

    MultiEffect effects = new MultiEffect(new IEffect[]
    {
        conditionalAtkBonusEffect,
        conditionalSpdBonusEffect,
        conditionalFirstAttackPercentageDamageReductionEffect
    });

    return new Skill("Remote Sparrow", effects);
}

public static Skill CreateRemoteMirrorSkill()
{
    ICondition condition = new UnitBeginAsAttackerCondition();

    IEffect atkBonusEffect = new BonusEffect(StatType.Atk, 7, EffectTarget.Unit);
    IEffect resBonusEffect = new BonusEffect(StatType.Res, 10, EffectTarget.Unit);
    IEffect firstAttackPercentageDamageReductionEffect = new FirstAttackPercentageDamageReductionEffect(0.3, EffectTarget.Unit);

    ConditionalEffect conditionalAtkBonusEffect = new ConditionalEffect(condition, atkBonusEffect);
    ConditionalEffect conditionalResBonusEffect = new ConditionalEffect(condition, resBonusEffect);
    ConditionalEffect conditionalFirstAttackPercentageDamageReductionEffect = new ConditionalEffect(condition, firstAttackPercentageDamageReductionEffect);

    MultiEffect effects = new MultiEffect(new IEffect[]
    {
        conditionalAtkBonusEffect,
        conditionalResBonusEffect,
        conditionalFirstAttackPercentageDamageReductionEffect
    });

    return new Skill("Remote Mirror", effects);
}

public static Skill CreateRemoteSturdySkill()
{
    ICondition condition = new UnitBeginAsAttackerCondition();

    IEffect atkBonusEffect = new BonusEffect(StatType.Atk, 7, EffectTarget.Unit);
    IEffect defBonusEffect = new BonusEffect(StatType.Def, 10, EffectTarget.Unit);
    IEffect firstAttackPercentageDamageReductionEffect = new FirstAttackPercentageDamageReductionEffect(0.3, EffectTarget.Unit);

    ConditionalEffect conditionalAtkBonusEffect = new ConditionalEffect(condition, atkBonusEffect);
    ConditionalEffect conditionalDefBonusEffect = new ConditionalEffect(condition, defBonusEffect);
    ConditionalEffect conditionalFirstAttackPercentageDamageReductionEffect = new ConditionalEffect(condition, firstAttackPercentageDamageReductionEffect);

    MultiEffect effects = new MultiEffect(new IEffect[]
    {
        conditionalAtkBonusEffect,
        conditionalDefBonusEffect,
        conditionalFirstAttackPercentageDamageReductionEffect
    });

    return new Skill("Remote Sturdy", effects);
}

    private static Skill CreateStanceSkill(string skillName, StatType[] stats, int[] statValues, double damageReduction)
    {
        ICondition condition = new RivalBeginAsAttacker();
        List<IEffect> effects = new List<IEffect>();

        for (int i = 0; i < stats.Length; i++)
        {
            IEffect bonusEffect = new BonusEffect(stats[i], statValues[i], EffectTarget.Unit);
            ConditionalEffect conditionalBonusEffect = new ConditionalEffect(condition, bonusEffect);
            effects.Add(conditionalBonusEffect);
        }

        IEffect damageReductionEffect = new FollowUpPercentageDamageReductionEffect(damageReduction, EffectTarget.Unit);
        ConditionalEffect conditionalDamageReductionEffect = new ConditionalEffect(condition, damageReductionEffect);
        effects.Add(conditionalDamageReductionEffect);

        MultiEffect multiEffect = new MultiEffect(effects);

        return new Skill(skillName, multiEffect);
    }

    public static Skill CreateFierceStanceSkill()
    {
        return CreateStanceSkill("Fierce Stance", new StatType[] { StatType.Atk }, new int[] { 8 }, 0.1);
    }

    public static Skill CreateDartingStanceSkill()
    {
        return CreateStanceSkill("Darting Stance", new StatType[] { StatType.Spd }, new int[] { 8 }, 0.1);
    }

    public static Skill CreateSteadyStanceSkill()
    {
        return CreateStanceSkill("Steady Stance", new StatType[] { StatType.Def }, new int[] { 8 }, 0.1);
    }

    public static Skill CreateWardingStanceSkill()
    {
        return CreateStanceSkill("Warding Stance", new StatType[] { StatType.Res }, new int[] { 8 }, 0.1);
    }

    public static Skill CreateKestrelStanceSkill()
    {
        return CreateStanceSkill("Kestrel Stance", new StatType[] { StatType.Atk, StatType.Spd }, new int[] { 6, 6 }, 0.1);
    }

    public static Skill CreateSturdyStanceSkill()
    {
        return CreateStanceSkill("Sturdy Stance", new StatType[] { StatType.Atk, StatType.Def }, new int[] { 6, 6 }, 0.1);
    }

    public static Skill CreateMirrorStanceSkill()
    {
        return CreateStanceSkill("Mirror Stance", new StatType[] { StatType.Atk, StatType.Res }, new int[] { 6, 6 }, 0.1);
    }

    public static Skill CreateSteadyPostureSkill()
    {
        return CreateStanceSkill("Steady Posture", new StatType[] { StatType.Spd, StatType.Def }, new int[] { 6, 6 }, 0.1);
    }

    public static Skill CreateSwiftStanceSkill()
    {
        return CreateStanceSkill("Swift Stance", new StatType[] { StatType.Spd, StatType.Res }, new int[] { 6, 6 }, 0.1);
    }

    public static Skill CreateBracingStanceSkill()
    {
        return CreateStanceSkill("Bracing Stance", new StatType[] { StatType.Def, StatType.Res }, new int[] { 6, 6 }, 0.1);
    }
    
    public static Skill CreateGoldenLotusSkill()
    {
        ICondition condition = new NotCondition(new RivalWeaponCondition("Magic"));
        IEffect effect = new FirstAttackPercentageDamageReductionEffect(0.5, EffectTarget.Unit);
        ConditionalEffect conditionalEffect = new ConditionalEffect(condition, effect);

        MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalEffect });

        return new Skill("Golden Lotus", multiEffect);
    }

    public static Skill CreateDragonWallSkill()
    {
        ICondition condition = new StatComparisionCondition(StatType.Res);
        IEffect effect = new PercentageComparisionDamageReductionEffect(StatType.Res, StatType.Res, EffectTarget.Unit);
        ConditionalEffect conditionalEffect = new ConditionalEffect(condition, effect);

        MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalEffect });

        return new Skill("Dragon Wall", multiEffect);
    }

    public static Skill CreateDodgeSkill()
    {
        ICondition condition = new StatComparisionCondition(StatType.Spd);
        IEffect effect = new PercentageComparisionDamageReductionEffect(StatType.Spd, StatType.Spd, EffectTarget.Unit);
        ConditionalEffect conditionalEffect = new ConditionalEffect(condition, effect);

        MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalEffect });

        return new Skill("Dodge", multiEffect);
    }

    public static Skill CreateLunarBraceSkill()
    {
        ICondition condition1 = new NotCondition(new UnitWeaponCondition("Magic"));
        ICondition condition2 = new UnitBeginAsAttackerCondition();
        MultiCondition multiCondition = new MultiCondition(new ICondition[] { condition1, condition2 });

        IEffect effect = new LunarBraceEffect(0.3, StatType.Def, EffectTarget.Unit);
        ConditionalEffect conditionalEffect = new ConditionalEffect(multiCondition, effect);

        MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalEffect });

        return new Skill("Lunar Brace", multiEffect);
    }

    public static Skill CreateBackAtYouSkill()
    {
        ICondition condition = new RivalBeginAsAttacker();
        IEffect effect = new BackAtYouEffect(EffectTarget.Unit);
        ConditionalEffect conditionalEffect = new ConditionalEffect(condition, effect);

        MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalEffect });

        return new Skill("Back at You", multiEffect);
    }

    public static Skill CreatePoeticJusticeSkill()
    {
        ICondition condition = new TrueCondition();
        IEffect penaltyEffect = new PenaltyEffect(StatType.Spd, 4, EffectTarget.Rival);
        IEffect lunarBraceEffect = new LunarBraceEffect(0.15, StatType.Atk, EffectTarget.Unit);

        ConditionalEffect conditionalPenaltyEffect = new ConditionalEffect(condition, penaltyEffect);
        ConditionalEffect conditionalLunarBraceEffect = new ConditionalEffect(condition, lunarBraceEffect);

        MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalPenaltyEffect, conditionalLunarBraceEffect });

        return new Skill("Poetic Justice", multiEffect);
    }

    public static Skill CreateLaguzFriendSkill()
    {
        ICondition condition = new TrueCondition();

        IEffect damageReductionEffect = new PercentageDamageReductionEffect(0.5, EffectTarget.Unit);
        IEffect defNeutralizationEffect = new NeutralizationBonusEffect(EffectTarget.Unit, StatType.Def);
        IEffect resNeutralizationEffect = new NeutralizationBonusEffect(EffectTarget.Unit, StatType.Res);
        IEffect defPenaltyEffect = new PercentagePenaltyEffect(StatType.Def, 0.50, EffectTarget.Unit);
        IEffect resPenaltyEffect = new PercentagePenaltyEffect(StatType.Res, 0.50, EffectTarget.Unit);

        ConditionalEffect conditionalDamageReductionEffect = new ConditionalEffect(condition, damageReductionEffect);
        ConditionalEffect conditionalDefNeutralizationEffect = new ConditionalEffect(condition, defNeutralizationEffect);
        ConditionalEffect conditionalResNeutralizationEffect = new ConditionalEffect(condition, resNeutralizationEffect);
        ConditionalEffect conditionalDefPenaltyEffect = new ConditionalEffect(condition, defPenaltyEffect);
        ConditionalEffect conditionalResPenaltyEffect = new ConditionalEffect(condition, resPenaltyEffect);

        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            conditionalDamageReductionEffect,
            conditionalDefNeutralizationEffect,
            conditionalResNeutralizationEffect,
            conditionalDefPenaltyEffect,
            conditionalResPenaltyEffect
        });

        return new Skill("Laguz Friend", multiEffect);
    }
    
    public static Skill CreateGuardBearingSkill()
    {
        ICondition condition = new TrueCondition();

        IEffect spdPenaltyEffect = new PenaltyEffect(StatType.Spd, 4, EffectTarget.Rival);
        IEffect defPenaltyEffect = new PenaltyEffect(StatType.Def, 4, EffectTarget.Rival);

        ICondition firstCombatCondition = new FirstCombatCondition();
        IEffect guardBearing60Effect = new ConditionalEffect(firstCombatCondition, new PercentageDamageReductionEffect(0.6, EffectTarget.Unit));
        IEffect guardBearing30Effect = new ConditionalEffect(new NotCondition(firstCombatCondition), new PercentageDamageReductionEffect(0.3, EffectTarget.Unit));

        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            new ConditionalEffect(condition, spdPenaltyEffect),
            new ConditionalEffect(condition, defPenaltyEffect),
            guardBearing60Effect,
            guardBearing30Effect
        });

        return new Skill("Guard Bearing", multiEffect);
    }

    public static Skill CreateBushidoSkill()
    {
        ICondition firstCondition = new TrueCondition();
        ICondition secondCondition = new StatComparisionCondition(StatType.Spd);
        IEffect extraDamageEffect = new ExtraDamageEffect(7, EffectTarget.Unit);
        IEffect percentageEffect = new PercentageComparisionDamageReductionEffect(StatType.Spd, StatType.Spd, EffectTarget.Unit);
        
        ConditionalEffect conditionalExtraDamageEffect = new ConditionalEffect(firstCondition, extraDamageEffect);
        ConditionalEffect conditionalPercentageEffect = new ConditionalEffect(secondCondition, percentageEffect);
        
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalExtraDamageEffect, conditionalPercentageEffect });
        
        return new Skill("Bushido", multiEffect);
    }
    
    public static Skill CreatePrescienceSkill()
    {
        ICondition condition1 = new TrueCondition();
        ICondition condition2 = new OrCondition(
            new UnitBeginAsAttackerCondition(), 
            new RivalWeaponCondition("Magic", "Bow")
        );
        
        IEffect atkPenaltyEffect = new PenaltyEffect(StatType.Atk, 5, EffectTarget.Rival);
        IEffect resPenaltyEffect = new PenaltyEffect(StatType.Res, 5, EffectTarget.Rival);
        IEffect firstAttackDamageReductionEffect = new FirstAttackPercentageDamageReductionEffect(0.3, EffectTarget.Unit);
        
        ConditionalEffect conditionalAtkPenaltyEffect = new ConditionalEffect(condition1, atkPenaltyEffect);
        ConditionalEffect conditionalResPenaltyEffect = new ConditionalEffect(condition1, resPenaltyEffect);
        ConditionalEffect conditionalFirstAttackDamageReductionEffect = new ConditionalEffect(condition2, firstAttackDamageReductionEffect);
        
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            conditionalAtkPenaltyEffect,
            conditionalResPenaltyEffect,
            conditionalFirstAttackDamageReductionEffect
        });
        
        return new Skill("Prescience", multiEffect);
    }


    public static Skill CreateMoonTwinWingSkill()
    {
        ICondition firstCondition = new UnitHpGreaterThanCertainPercentage(0.25);
        ICondition secondCondition = new StatComparisionCondition(StatType.Spd);
        
        IEffect atkPenaltyEffect = new PenaltyEffect(StatType.Atk, 5, EffectTarget.Rival);
        IEffect spdPenaltyEffect = new PenaltyEffect(StatType.Spd, 5, EffectTarget.Rival);
        IEffect percentageEffect = new PercentageComparisionDamageReductionEffect(StatType.Spd, StatType.Spd, EffectTarget.Unit);
        
        ICondition andCondition = new AndCondition(firstCondition, secondCondition);
        
        ConditionalEffect conditionalAtkPenaltyEffect = new ConditionalEffect(firstCondition, atkPenaltyEffect);
        ConditionalEffect conditionalSpdPenaltyEffect = new ConditionalEffect(firstCondition, spdPenaltyEffect);
        ConditionalEffect conditionalPercentageEffect = new ConditionalEffect(andCondition, percentageEffect);
        
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalAtkPenaltyEffect, conditionalSpdPenaltyEffect, conditionalPercentageEffect });
        
        return new Skill("Moon-Twin Wing", multiEffect);
    }

    public static Skill CreateExtraChivalrySkill()
    {
        ICondition firstCondition = new RivalHpAboveThresholdCondition(0.5);
        ICondition secondCondition = new TrueCondition();
        
        IEffect atkPenaltyEffect = new PenaltyEffect(StatType.Atk, 5, EffectTarget.Rival);
        IEffect spdPenaltyEffect = new PenaltyEffect(StatType.Spd, 5, EffectTarget.Rival);
        IEffect defPenaltyEffect = new PenaltyEffect(StatType.Def, 5, EffectTarget.Rival);
        IEffect damagePercentageReductionEffect =
            new ExtraChivalryPercentageDamageReductionEffect(0.5, EffectTarget.Unit);
        
        ConditionalEffect conditionalAtkPenaltyEffect = new ConditionalEffect(firstCondition, atkPenaltyEffect);
        ConditionalEffect conditionalSpdPenaltyEffect = new ConditionalEffect(firstCondition, spdPenaltyEffect);
        ConditionalEffect conditionalDefPenaltyEffect = new ConditionalEffect(firstCondition, defPenaltyEffect);
        
        
        ConditionalEffect conditionalDamagePercentageReductionEffect = new ConditionalEffect(secondCondition, damagePercentageReductionEffect);
        
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            conditionalAtkPenaltyEffect,
            conditionalSpdPenaltyEffect,
            conditionalDefPenaltyEffect,
            conditionalDamagePercentageReductionEffect
        });
        
        return new Skill("Extra Chivalry", multiEffect);
    }

    public static Skill CreateDragonsWrathSkill()
    {
        ICondition firstCondition = new TrueCondition();
        ICondition secondCondition = new DifferentStatComparision(StatType.Atk, StatType.Res);
        
        IEffect firstAttackDamageReductionEffect = new FirstAttackPercentageDamageReductionEffect(0.25, EffectTarget.Unit);
        IEffect firstAttackExtraDamageEffect = new FirstAttackExtraDamageEffect(EffectTarget.Unit);
        
        ConditionalEffect conditionalFirstAttackDamageReductionEffect = new ConditionalEffect(firstCondition, firstAttackDamageReductionEffect);
        ConditionalEffect conditionalExtraDamageEffect = new ConditionalEffect(secondCondition, firstAttackExtraDamageEffect);
        
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalFirstAttackDamageReductionEffect, conditionalExtraDamageEffect });
        
        return new Skill("Dragon’s Wrath", multiEffect);
    }
}