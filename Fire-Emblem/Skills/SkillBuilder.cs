using Fire_Emblem.Conditions;
using Fire_Emblem.Conditions.LogicalConditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.AlterBaseStat;
using Fire_Emblem.Effects.Damage.AbsoluteDamageReduction;
using Fire_Emblem.Effects.Damage.ExtraDamage;
using Fire_Emblem.Effects.Damage.PercentageDamageReduction;
using Fire_Emblem.Effects.Neutralization;
using Fire_Emblem.Skills.TypesCreator;
using Fire_Emblem.Stats;
using Fire_Emblem.Weapons;

namespace Fire_Emblem.Skills;

public static class SkillBuilder
{
    public static Skill CreateBowGuardSkill()
    {
        return CreateWeaponGuard.CreateWeaponGuardSkill(typeof(Bow));
    }
    
    public static Skill CreateAxeGuardSkill()
    {
        return CreateWeaponGuard.CreateWeaponGuardSkill(typeof(Axe));
    }
    
    public static Skill CreateLanceGuardSkill()
    {
        return CreateWeaponGuard.CreateWeaponGuardSkill(typeof(Lance));
    }
    
    public static Skill CreateMagicGuardSkill()
    {
        return CreateWeaponGuard.CreateWeaponGuardSkill(typeof(Magic));
    }
    
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
        return CreateWeaponBonusPenalty.CreateSkill("Sword Focus", typeof(Sword), 
            StatType.Atk, 10, StatType.Res, 10);
    }

    public static Skill CreateBowAgilitySkill()
    {
        return CreateWeaponBonusPenalty.CreateSkill("Bow Agility", typeof(Bow), 
            StatType.Spd, 12, StatType.Atk, 6);
    }

    public static Skill CreateAxePowerSkill()
    {
        return CreateWeaponBonusPenalty.CreateSkill("Axe Power", typeof(Axe), 
            StatType.Atk, 10, StatType.Def, 10);
    }

    public static Skill CreateLanceAgilitySkill()
    {
        return CreateWeaponBonusPenalty.CreateSkill("Lance Agility", typeof(Lance), 
            StatType.Spd, 12, StatType.Atk, 6);
    }

    public static Skill CreateBowFocusSkill()
    {
        return CreateWeaponBonusPenalty.CreateSkill("Bow Focus", typeof(Bow), 
            StatType.Atk, 10, StatType.Res, 10);
    }

    public static Skill CreateSwordPowerSkill()
    {
        return CreateWeaponBonusPenalty.CreateSkill("Sword Power", typeof(Sword), 
            StatType.Atk, 10, StatType.Def, 10);
    }

    public static Skill CreateLancePowerSkill()
    {
        return CreateWeaponBonusPenalty.CreateSkill("Lance Power", typeof(Lance), 
            StatType.Atk, 10, StatType.Def, 10);
    }

    public static Skill CreateSwordAgilitySkill()
    {
        return CreateWeaponBonusPenalty.CreateSkill("Sword Agility", typeof(Sword), 
            StatType.Spd, 12, StatType.Atk, 6);
    }
    
    public static Skill CreateAttackPlus6Skill()
    {
        return CreateBonus.CreateBonusSkill("Attack +6", new StatType[] 
            { StatType.Atk }, new int[] { 6 });
    }

    public static Skill CreateSpeedPlus5Skill()
    {
        return CreateBonus.CreateBonusSkill("Speed +5", new StatType[] 
            { StatType.Spd }, new int[] { 5 });
    }

    public static Skill CreateDefensePlus5Skill()
    {
        return CreateBonus.CreateBonusSkill("Defense +5", new StatType[] 
            { StatType.Def }, new int[] { 5 });
    }

    public static Skill CreateResistancePlus5Skill()
    {
        return CreateBonus.CreateBonusSkill("Resistance +5", new StatType[] 
            { StatType.Res }, new int[] { 5 });
    }

    public static Skill CreateAtkDefPlus5Skill()
    {
        return CreateBonus.CreateBonusSkill("Atk/Def +5", new StatType[] 
            { StatType.Atk, StatType.Def }, new int[] { 5, 5 });
    }

    public static Skill CreateSpdResPlus5Skill()
    {
        return CreateBonus.CreateBonusSkill("Spd/Res +5", new StatType[] 
            { StatType.Spd, StatType.Res }, new int[] { 5, 5 });
    }

    public static Skill CreateAtkResPlus5Skill()
    {
        return CreateBonus.CreateBonusSkill("Atk/Res +5", new StatType[]
            { StatType.Atk, StatType.Res }, new int[] { 5, 5 });
    }
    
    public static Skill CreateFierceStanceSkill()
    {
        return CreateStance.CreateStanceSkill("Fierce Stance", new StatType[] { StatType.Atk },
            new int[] { 8 }, 0.1);
    }

    public static Skill CreateDartingStanceSkill()
    {
        return CreateStance.CreateStanceSkill("Darting Stance", new StatType[] { StatType.Spd },
            new int[] { 8 }, 0.1);
    }

    public static Skill CreateSteadyStanceSkill()
    {
        return CreateStance.CreateStanceSkill("Steady Stance", new StatType[] { StatType.Def },
            new int[] { 8 }, 0.1);
    }

    public static Skill CreateWardingStanceSkill()
    {
        return CreateStance.CreateStanceSkill("Warding Stance", new StatType[] { StatType.Res },
            new int[] { 8 }, 0.1);
    }

    public static Skill CreateKestrelStanceSkill()
    {
        return CreateStance.CreateStanceSkill("Kestrel Stance", new StatType[] { StatType.Atk, StatType.Spd },
            new int[] { 6, 6 }, 0.1);
    }

    public static Skill CreateSturdyStanceSkill()
    {
        return CreateStance.CreateStanceSkill("Sturdy Stance", new StatType[] { StatType.Atk, StatType.Def },
            new int[] { 6, 6 }, 0.1);
    }

    public static Skill CreateMirrorStanceSkill()
    {
        return CreateStance.CreateStanceSkill("Mirror Stance", new StatType[] { StatType.Atk, StatType.Res },
            new int[] { 6, 6 }, 0.1);
    }

    public static Skill CreateSteadyPostureSkill()
    {
        return CreateStance.CreateStanceSkill("Steady Posture", new StatType[] { StatType.Spd, StatType.Def },
            new int[] { 6, 6 }, 0.1);
    }

    public static Skill CreateSwiftStanceSkill()
    {
        return CreateStance.CreateStanceSkill("Swift Stance", new StatType[] { StatType.Spd, StatType.Res },
            new int[] { 6, 6 }, 0.1);
    }

    public static Skill CreateBracingStanceSkill()
    {
        return CreateStance.CreateStanceSkill("Bracing Stance", new StatType[] { StatType.Def, StatType.Res },
            new int[] { 6, 6 }, 0.1);
    }
    
    public static Skill CreateStunningSmileSkill()
    {
        return CreateManRivalWithPenalty.CreateSkill("Stunning Smile", StatType.Spd, 8);
    }

    public static Skill CreateDisarmingSighSkill()
    {
        return CreateManRivalWithPenalty.CreateSkill("Disarming Sigh", StatType.Atk, 8);
    }
    
    public static Skill CreateArmoredBlowSkill()
    {
        return CreateBlow.CreateBlowSkill("Armored Blow", StatType.Def, 8);
    }
    
    public static Skill CreateDeathBlowSkill()
    {
        return CreateBlow.CreateBlowSkill("Death Blow", StatType.Atk, 8);
    }

    public static Skill CreateDartingBlowSkill()
    {
        return CreateBlow.CreateBlowSkill("Darting Blow", StatType.Spd, 8);
    }

    public static Skill CreateWardingBlowSkill()
    {
        return CreateBlow.CreateBlowSkill("Warding Blow", StatType.Res, 8);
    }
    
    public static Skill CreateRemoteSparrowSkill()
    {
        return CreateRemote.CreateRemoteSkill("Remote Sparrow", StatType.Spd, 7);
    }

    public static Skill CreateRemoteMirrorSkill()
    {
        return CreateRemote.CreateRemoteSkill("Remote Mirror", StatType.Res, 10);
    }

    public static Skill CreateRemoteSturdySkill()
    {
        return CreateRemote.CreateRemoteSkill("Remote Sturdy", StatType.Def, 10);
    }
    
    public static Skill CreateSwiftSparrowSkill()
    {
        return CreateSixBonus.CreateSkill("Swift Sparrow", new UnitBeginAsAttackerCondition(), 
            StatType.Atk, StatType.Spd);
    }

    public static Skill CreateSturdyBlowSkill()
    {
        return CreateSixBonus.CreateSkill("Sturdy Blow", new UnitBeginAsAttackerCondition(), 
            StatType.Atk, StatType.Def);
    }

    public static Skill CreateMirrorStrikeSkill()
    {
        return CreateSixBonus.CreateSkill("Mirror Strike", new UnitBeginAsAttackerCondition(), 
            StatType.Atk, StatType.Res);
    }

    public static Skill CreateSteadyBlowSkill()
    {
        return CreateSixBonus.CreateSkill("Steady Blow", new UnitBeginAsAttackerCondition(), 
            StatType.Spd, StatType.Def);
    }

    public static Skill CreateSwiftStrikeSkill()
    {
        return CreateSixBonus.CreateSkill("Swift Strike", new UnitBeginAsAttackerCondition(), 
            StatType.Spd, StatType.Res);
    }

    public static Skill CreateBracingBlowSkill()
    {
        return CreateSixBonus.CreateSkill("Bracing Blow", new UnitBeginAsAttackerCondition(), 
            StatType.Def, StatType.Res);
    }

    public static Skill CreateTomePrecisionSkill()
    {
        return CreateSixBonus.CreateSkill("Tome Precision", new UnitWeaponCondition(typeof(Magic)), 
            StatType.Atk, StatType.Spd);
    }
    
    public static Skill CreateCloseDefSkill()
    {
        ICondition condition = new AndCondition(
            new RivalBeginAsAttacker(),
            new RivalWeaponCondition(typeof(Sword), typeof(Lance), typeof(Axe))
        );
        return CreateDef.CreateDefSkill("Close Def", condition);
    }
    
    public static Skill CreateDistantDefSkill()
    {
        ICondition condition = new AndCondition(
            new RivalBeginAsAttacker(),
            new RivalWeaponCondition(typeof(Magic), typeof(Bow))
        );
        return CreateDef.CreateDefSkill("Distant Def", condition);
    }
    
    public static Skill CreateAgneasArrowSkill()
    {
        ICondition condition = new TrueCondition();
        MultiEffect multiEffect = ConditionalEffectBuilder.BuildNeutralizationPenaltyEffect(condition,
            StatType.Atk, StatType.Spd, StatType.Def, StatType.Res);
        return new Skill("Agnea's Arrow", multiEffect);
    }

    public static Skill CreateLightAndDarkSkill()
    {
        StatType[] statTypes = { StatType.Atk, StatType.Spd, StatType.Def, StatType.Res };
        int penaltyValue = 5;
        ICondition condition = new TrueCondition();
        MultiEffect penaltyEffects = ConditionalEffectBuilder.BuildRivalPenaltyEffects(condition, penaltyValue,
            statTypes);
        MultiEffect bonusNeutralizationEffects = 
            ConditionalEffectBuilder.BuildRivalNeutralizationBonusEffects(condition, statTypes);
        MultiEffect penaltyNeutralizationEffects = 
            ConditionalEffectBuilder.BuildNeutralizationPenaltyEffect(condition, statTypes);
        IEnumerable<IEffect>allEffects = penaltyEffects.Concat(bonusNeutralizationEffects.
            Concat(penaltyNeutralizationEffects));
        MultiEffect multiEffect = new MultiEffect(allEffects);
        return new Skill("Light and Dark", multiEffect);
    }

    public static Skill CreateDragonskinSkill()
    {
        StatType[] statTypes = { StatType.Atk, StatType.Spd, StatType.Def, StatType.Res };
        int bonusValue = 6;
        ICondition condition = new OrCondition(
            new RivalBeginAsAttacker(),
            new RivalHpAboveThresholdCondition(0.75)
            );
        MultiEffect bonusEffects = ConditionalEffectBuilder.BuildBonusEffects(condition, bonusValue, statTypes);
        MultiEffect neutralizationEffects = ConditionalEffectBuilder.BuildRivalNeutralizationBonusEffects(condition,
            statTypes);
        IEnumerable<IEffect> allEffects = bonusEffects.Concat(neutralizationEffects);
        MultiEffect multiEffect = new MultiEffect(allEffects);
        return new Skill("Dragonskin", multiEffect);
    }
    
    public static Skill CreateHpPlus15Skill()
    {
        ICondition condition = new HasUnitActivatedTheStatAbility();
        IEffect effect = new AlterBaseStatEffect(StatType.Hp, 15, EffectTarget.Unit);
        ConditionalEffect conditionalEffect = new ConditionalEffect(condition, effect);
        MultiEffect effects = new MultiEffect(new IEffect[] { conditionalEffect });
        return new Skill("HP +15", effects);
    }
    
    public static Skill CreateBeorcsBlessingSkill()
    {
        ICondition trueCondition = new TrueCondition();
        MultiEffect multiEffect = ConditionalEffectBuilder.BuildRivalNeutralizationBonusEffects(trueCondition,
            StatType.Atk, StatType.Spd, StatType.Def, StatType.Res);
        return new Skill("Beorc's Blessing", multiEffect);
    }
    
    public static Skill CreateWrathSkill()
    {
        ICondition trueCondition = new TrueCondition();
        IEffect atkBonusEffect = new DynamicBonusEffect(StatType.Atk, 30, EffectTarget.Unit);
        IEffect spdBonusEffect = new DynamicBonusEffect(StatType.Spd, 30, EffectTarget.Unit);
        ConditionalEffect conditionalAtkBonusEffect = new ConditionalEffect(trueCondition, atkBonusEffect);
        ConditionalEffect conditionalSpdBonusEffect = new ConditionalEffect(trueCondition, spdBonusEffect);
        MultiEffect effects = new MultiEffect(new IEffect[] 
            { conditionalAtkBonusEffect, conditionalSpdBonusEffect });
        return new Skill("Wrath", effects);
    }
    
    public static Skill CreateResolveSkill()
    {
        ICondition condition = new UnitHpThresholdCondition(0.75);
        MultiEffect multiEffect = ConditionalEffectBuilder.BuildBonusEffects(condition, 
            7, StatType.Def, StatType.Res);
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
        MultiEffect bonusEffects = ConditionalEffectBuilder.BuildBonusEffects(condition, 
            6, StatType.Def, StatType.Res);
        MultiEffect penaltyEffects = ConditionalEffectBuilder.BuildUnitPenaltyEffects(condition, 
            2, StatType.Atk);
        IEnumerable<IEffect> allEffects = bonusEffects.Concat(penaltyEffects);
        MultiEffect multiEffect = new MultiEffect(allEffects);
        return new Skill("Fort. Def/Res", multiEffect);
    }

    public static Skill CreateLifeAndDeathSkill()
    {
        ICondition condition = new TrueCondition();
        MultiEffect bonusEffects = ConditionalEffectBuilder.BuildBonusEffects(condition, 
            6, StatType.Atk, StatType.Spd);
        MultiEffect penaltyEffects = ConditionalEffectBuilder.BuildUnitPenaltyEffects(condition, 
            5, StatType.Def, StatType.Res);
        IEnumerable<IEffect> allEffects = bonusEffects.Concat(penaltyEffects);
        MultiEffect multiEffect = new MultiEffect(allEffects);
        return new Skill("Life and Death", multiEffect);
    }

    public static Skill CreateSolidGroundSkill()
    {
        ICondition condition = new TrueCondition();
        MultiEffect bonusEffects = ConditionalEffectBuilder.BuildBonusEffects(condition, 
            6, StatType.Atk, StatType.Def);
        MultiEffect penaltyEffects = ConditionalEffectBuilder.BuildUnitPenaltyEffects(condition, 
            5, StatType.Res);
        IEnumerable<IEffect> allEffects = bonusEffects.Concat(penaltyEffects);
        MultiEffect multiEffect = new MultiEffect(allEffects);
        return new Skill("Solid Ground", multiEffect);
    }

    public static Skill CreateStillWaterSkill()
    {
        ICondition condition = new TrueCondition();
        MultiEffect bonusEffects = ConditionalEffectBuilder.BuildBonusEffects(condition, 
            6, StatType.Atk, StatType.Res);
        MultiEffect penaltyEffects = ConditionalEffectBuilder.BuildUnitPenaltyEffects(condition, 
            5, StatType.Def);
        IEnumerable<IEffect> allEffects = bonusEffects.Concat(penaltyEffects);
        MultiEffect multiEffect = new MultiEffect(allEffects);
        return new Skill("Still Water", multiEffect);
    }
    
    public static Skill CreateBeliefInLoveSkill()
    {
        ICondition condition = new OrCondition(
            new RivalBeginAsAttacker(),
            new RivalHpThresholdCondition(1.0)
        );
        MultiEffect penaltyEffects = ConditionalEffectBuilder.BuildRivalPenaltyEffects(
            condition, 5, StatType.Atk, StatType.Def);
        MultiEffect multiEffect = new MultiEffect(penaltyEffects);
        return new Skill("Belief in Love", multiEffect);
    }

    public static Skill CreateDeadlyBladeSkill()
    {
        ICondition condition = new AndCondition(
            new UnitWeaponCondition(typeof(Sword)),
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
        ICondition mixedWeaponCondition = new MixedWeaponCondition();
        ICondition condition = new AndCondition(beginsAsAttacker, mixedWeaponCondition);
        IEffect spdBonusEffect = new BonusEffect(StatType.Spd, 3, EffectTarget.Unit);
        ConditionalEffect conditionalSpdBonusEffect = new ConditionalEffect(condition, spdBonusEffect);
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalSpdBonusEffect });
        return new Skill("Chaos Style", multiEffect);
    }
    
    public static Skill CreateIgnisSkill()
    {
        ICondition condition = new TrueCondition();
        IEffect firstAttackBonusEffect = new FirstAttackBonusEffect(StatType.Atk, 
            50, EffectTarget.Unit);
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
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            conditionalAtkPenaltyEffect, conditionalSpdPenaltyEffect
        });
        return new Skill("Charmer", multiEffect);
    }

    public static Skill CreatePerceptiveSkill()
    {
        ICondition condition = new UnitBeginAsAttackerCondition();
        IEffect perceptiveEffect = new PerceptiveBonusEffect(EffectTarget.Unit);
        ConditionalEffect conditionalPerceptiveEffect = new ConditionalEffect(condition, perceptiveEffect);
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalPerceptiveEffect });
        return new Skill("Perceptive", multiEffect);
    }

    public static Skill CreateLunaSkill()
    {
        ICondition condition = new TrueCondition();
        IEffect defPenaltyEffect = new FirstAttackPenaltyEffect(StatType.Def, 
            50, EffectTarget.Rival);
        IEffect resPenaltyEffect = new FirstAttackPenaltyEffect(StatType.Res, 
            50, EffectTarget.Rival);
        ConditionalEffect conditionalDefPenaltyEffect = new ConditionalEffect(condition, defPenaltyEffect);
        ConditionalEffect conditionalResPenaltyEffect = new ConditionalEffect(condition, resPenaltyEffect);
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            conditionalDefPenaltyEffect, conditionalResPenaltyEffect
        });
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
        ConditionalEffect conditionalAbsoluteDamageReductionEffect = 
            new ConditionalEffect(condition, absoluteDamageReductionEffect);
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalAbsoluteDamageReductionEffect });
        return new Skill("Gentility", multiEffect);
    }

    public static Skill CreateArmsShieldSkill()
    {
        ICondition condition = new UnitWeaponAdvantageCondition();
        IEffect absoluteDamageReductionEffect = new AbsoluteDamageReductionEffect(7, EffectTarget.Unit);
        ConditionalEffect conditionalAbsoluteDamageReductionEffect = 
            new ConditionalEffect(condition, absoluteDamageReductionEffect);
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
        ConditionalEffect conditionalAbsoluteDamageReductionEffect = new ConditionalEffect(condition, 
            absoluteDamageReductionEffect);
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalAbsoluteDamageReductionEffect });
        return new Skill("Sympathetic", multiEffect);
    }

    public static Skill CreateBlueSkiesSkill()
    {
        ICondition condition = new TrueCondition();
        IEffect absoluteDamageReductionEffect = new AbsoluteDamageReductionEffect(5, EffectTarget.Unit);
        IEffect extraDamageEffect = new ExtraDamageEffect(5, EffectTarget.Unit);
        ConditionalEffect conditionalAbsoluteDamageReductionEffect = new ConditionalEffect(condition, 
            absoluteDamageReductionEffect);
        ConditionalEffect conditionalExtraDamageEffect = new ConditionalEffect(condition, extraDamageEffect);
        MultiEffect effects = new MultiEffect(new IEffect[]
        {
            conditionalAbsoluteDamageReductionEffect, conditionalExtraDamageEffect
        });
        return new Skill("Blue Skies", effects);
    }

    public static Skill CreateChivalrySkill()
    {
        ICondition condition = new AndCondition(
            new UnitBeginAsAttackerCondition(), new RivalHpThresholdCondition(1));
        IEffect extraDamageEffect = new ExtraDamageEffect(2, EffectTarget.Unit);
        IEffect absoluteDamageReductionEffect = new AbsoluteDamageReductionEffect(2, EffectTarget.Unit);
        ConditionalEffect conditionalExtraDamageEffect = new ConditionalEffect(condition, extraDamageEffect);
        ConditionalEffect conditionalAbsoluteDamageReductionEffect = 
            new ConditionalEffect(condition, absoluteDamageReductionEffect);
        MultiEffect multiEffect = new MultiEffect(
            new IEffect[] { conditionalExtraDamageEffect, conditionalAbsoluteDamageReductionEffect });
        return new Skill("Chivalry", multiEffect);
    }

    public static Skill CreateAegisShieldSkill()
    {
        ICondition condition = new TrueCondition();
        IEffect defBonusEffect = new BonusEffect(StatType.Def, 6, EffectTarget.Unit);
        IEffect resBonusEffect = new BonusEffect(StatType.Res, 3, EffectTarget.Unit);
        IEffect firstAttackPercentageDamageReductionEffect = 
            new FirstAttackPercentageDamageReductionEffect(0.5, EffectTarget.Unit);
        ConditionalEffect conditionalDefBonusEffect = new ConditionalEffect(condition, defBonusEffect);
        ConditionalEffect conditionalResBonusEffect = new ConditionalEffect(condition, resBonusEffect);
        ConditionalEffect conditionalFirstAttackPercentageDamageReductionEffect = new ConditionalEffect(condition, 
            firstAttackPercentageDamageReductionEffect);
        MultiEffect effects = new MultiEffect(new IEffect[]
        {
            conditionalDefBonusEffect,
            conditionalResBonusEffect,
            conditionalFirstAttackPercentageDamageReductionEffect
        });
        return new Skill("Aegis Shield", effects);
    }
    
    public static Skill CreateGoldenLotusSkill()
    {
        ICondition condition = new NotCondition(new RivalWeaponCondition(typeof(Magic)));
        IEffect effect = new FirstAttackPercentageDamageReductionEffect(0.5, EffectTarget.Unit);
        ConditionalEffect conditionalEffect = new ConditionalEffect(condition, effect);
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalEffect });
        return new Skill("Golden Lotus", multiEffect);
    }

    public static Skill CreateDragonWallSkill()
    {
        ICondition condition = new StatComparisionCondition(StatType.Res);
        IEffect effect = new PercentageComparisionDamageReductionEffect(StatType.Res, StatType.Res, 
            EffectTarget.Unit);
        ConditionalEffect conditionalEffect = new ConditionalEffect(condition, effect);
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalEffect });
        return new Skill("Dragon Wall", multiEffect);
    }

    public static Skill CreateDodgeSkill()
    {
        ICondition statComparisionCondition = new StatComparisionCondition(StatType.Spd);
        IEffect percentageComparisionDamageReductionEffect = 
            new PercentageComparisionDamageReductionEffect(StatType.Spd, 
            StatType.Spd, EffectTarget.Unit);
        ConditionalEffect conditionalEffect = new ConditionalEffect(
            statComparisionCondition, percentageComparisionDamageReductionEffect);
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalEffect });
        return new Skill("Dodge", multiEffect);
    }

    public static Skill CreateLunarBraceSkill()
    {
        ICondition notCondition = new NotCondition(new UnitWeaponCondition(typeof(Magic)));
        ICondition unitBeginAsAttackerCondition = new UnitBeginAsAttackerCondition();
        MultiCondition multiCondition = new MultiCondition(new ICondition[] 
            { notCondition, unitBeginAsAttackerCondition });
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
        MultiEffect multiEffect = new MultiEffect(new IEffect[] 
            { conditionalPenaltyEffect, conditionalLunarBraceEffect });
        return new Skill("Poetic Justice", multiEffect);
    }

    public static Skill CreateLaguzFriendSkill()
    {
        ICondition condition = new TrueCondition();
        IEffect damageReductionEffect = new PercentageDamageReductionEffect(0.5, EffectTarget.Unit);
        IEffect defNeutralizationEffect = new NeutralizationBonusEffect(EffectTarget.Unit, StatType.Def);
        IEffect resNeutralizationEffect = new NeutralizationBonusEffect(EffectTarget.Unit, StatType.Res);
        IEffect defPenaltyEffect = 
            new PercentagePenaltyEffect(StatType.Def, 0.50, EffectTarget.Unit);
        IEffect resPenaltyEffect = 
            new PercentagePenaltyEffect(StatType.Res, 0.50, EffectTarget.Unit);
        ConditionalEffect conditionalDamageReductionEffect = new ConditionalEffect(condition, damageReductionEffect);
        ConditionalEffect conditionalDefNeutralizationEffect = 
            new ConditionalEffect(condition, defNeutralizationEffect);
        ConditionalEffect conditionalResNeutralizationEffect = 
            new ConditionalEffect(condition, resNeutralizationEffect);
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
        ICondition firstCombatCondition = new UnitFirstCombatCondition();
        IEffect guardBearing60Effect = 
            new ConditionalEffect(firstCombatCondition, new PercentageDamageReductionEffect(0.6, EffectTarget.Unit));
        IEffect guardBearing30Effect = new ConditionalEffect(new NotCondition(firstCombatCondition), 
            new PercentageDamageReductionEffect(0.3, EffectTarget.Unit));
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
        IEffect percentageEffect = new PercentageComparisionDamageReductionEffect(StatType.Spd, 
            StatType.Spd, EffectTarget.Unit);
        ConditionalEffect conditionalExtraDamageEffect = new ConditionalEffect(firstCondition, extraDamageEffect);
        ConditionalEffect conditionalPercentageEffect = new ConditionalEffect(secondCondition, percentageEffect);
        MultiEffect multiEffect = new MultiEffect(new IEffect[] 
            { conditionalExtraDamageEffect, conditionalPercentageEffect });
        return new Skill("Bushido", multiEffect);
    }
    
    public static Skill CreatePrescienceSkill()
    {
        ICondition condition1 = new TrueCondition();
        ICondition condition2 = new OrCondition(
            new UnitBeginAsAttackerCondition(), 
            new RivalWeaponCondition(typeof(Magic), typeof(Bow))
        );
        IEffect firstAttackDamageReductionEffect = 
            new FirstAttackPercentageDamageReductionEffect(0.3, EffectTarget.Unit);
        MultiEffect penaltyEffects = ConditionalEffectBuilder.BuildRivalPenaltyEffects(
            condition1, 5, StatType.Atk, StatType.Res);
        ConditionalEffect conditionalFirstAttackDamageReductionEffect = 
            new ConditionalEffect(condition2, firstAttackDamageReductionEffect);
        IEnumerable<IEffect> allEffects = penaltyEffects.Concat(new IEffect[] 
            { conditionalFirstAttackDamageReductionEffect });
        MultiEffect multiEffect = new MultiEffect(allEffects);
        return new Skill("Prescience", multiEffect);
    }


    public static Skill CreateMoonTwinWingSkill()
    {
        ICondition firstCondition = new UnitHpGreaterThanCertainPercentage(0.25);
        ICondition secondCondition = new StatComparisionCondition(StatType.Spd);
        IEffect percentageEffect = new PercentageComparisionDamageReductionEffect(
            StatType.Spd, StatType.Spd, EffectTarget.Unit);
        ICondition andCondition = new AndCondition(firstCondition, secondCondition);
        MultiEffect penaltyEffects = ConditionalEffectBuilder.BuildRivalPenaltyEffects(
            firstCondition, 5, StatType.Atk, StatType.Spd);
        ConditionalEffect conditionalPercentageEffect = new ConditionalEffect(andCondition, percentageEffect);
        IEnumerable<IEffect> allEffects = penaltyEffects.Concat(new IEffect[] { conditionalPercentageEffect });
        MultiEffect multiEffect = new MultiEffect(allEffects);
        return new Skill("Moon-Twin Wing", multiEffect);
    }

    public static Skill CreateExtraChivalrySkill()
    {
        ICondition firstCondition = new RivalHpAboveThresholdCondition(0.5);
        ICondition secondCondition = new TrueCondition();
        IEffect damagePercentageReductionEffect = new ExtraChivalryPercentageDamageReductionEffect(EffectTarget.Unit);
        MultiEffect penaltyEffects = ConditionalEffectBuilder.BuildRivalPenaltyEffects(
            firstCondition, 5, StatType.Atk, StatType.Spd, StatType.Def);
        ConditionalEffect conditionalDamagePercentageReductionEffect = 
            new ConditionalEffect(secondCondition, damagePercentageReductionEffect);
        IEnumerable<IEffect> allEffects = penaltyEffects.Concat(
            new IEffect[] { conditionalDamagePercentageReductionEffect });
        MultiEffect multiEffect = new MultiEffect(allEffects);
        return new Skill("Extra Chivalry", multiEffect);
    }
    
    public static Skill CreateDragonsWrathSkill()
    {
        ICondition firstCondition = new TrueCondition();
        ICondition secondCondition = new DifferentStatComparision(StatType.Atk, StatType.Res);
        IEffect firstAttackDamageReductionEffect = 
            new FirstAttackPercentageDamageReductionEffect(0.25, EffectTarget.Unit);
        IEffect firstAttackExtraDamageEffect = new FirstAttackExtraDamageEffect(EffectTarget.Unit);
        ConditionalEffect conditionalFirstAttackDamageReductionEffect = 
            new ConditionalEffect(firstCondition, firstAttackDamageReductionEffect);
        ConditionalEffect conditionalExtraDamageEffect = 
            new ConditionalEffect(secondCondition, firstAttackExtraDamageEffect);
        MultiEffect multiEffect = new MultiEffect(new IEffect[] 
            { conditionalFirstAttackDamageReductionEffect, conditionalExtraDamageEffect });
        return new Skill("Dragon’s Wrath", multiEffect);
    }

    public static Skill CreateDivineRecreationSkill()
    {
        ICondition rivalHpAboveThresholdCondition = new RivalHpAboveThresholdCondition(0.5);
        MultiEffect penaltyEffects = ConditionalEffectBuilder.BuildRivalPenaltyEffects(rivalHpAboveThresholdCondition, 
            4, 
            StatType.Atk, StatType.Spd, StatType.Def, StatType.Res);
        IEffect reduceFirstAttackDamageEffect = new FirstAttackPercentageDamageReductionEffect(0.3, EffectTarget.Unit);
        IEffect extraDamageEffect = new ExtraDamageEffect(4, EffectTarget.Unit);
        ConditionalEffect conditionalReduceFirstAttackDamageEffect = 
            new ConditionalEffect(rivalHpAboveThresholdCondition, reduceFirstAttackDamageEffect);
        ConditionalEffect conditionalExtraDamageEffect = 
            new ConditionalEffect(rivalHpAboveThresholdCondition, extraDamageEffect);
        MultiEffect multiEffect = new MultiEffect(penaltyEffects.Concat(new IEffect[]
        {
            conditionalReduceFirstAttackDamageEffect,
            conditionalExtraDamageEffect
        }).ToArray());
        return new Skill("Divine Recreation", multiEffect);
    }
}
