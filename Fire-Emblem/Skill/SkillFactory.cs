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
            default:
                throw new ArgumentException($"Unknown skill name: {skillName}");
        }
    }

    private static Skill CreateArmoredBlowSkill()
    {
        Skill skill = new Skill("Armored Blow", "Si la unidad inicia el combate, otorga Def+8 durante el combate.");
        skill.AddCondition(new UnitBeginAsAttackerCondition());
        skill.AddEffect(new BonusEffect(StatType.Def, 8));
        return skill;
    }

    private static Skill CreateDeathBlowSkill()
    {
        Skill skill = new Skill("Death Blow", "Si la unidad inicia el combate, otorga Atk+8 durante el combate.");
        skill.AddCondition(new UnitBeginAsAttackerCondition());
        skill.AddEffect(new BonusEffect(StatType.Atk, 8));
        return skill;
    }

    private static Skill CreateDartingBlowSkill()
    {
        Skill skill = new Skill("Darting Blow", "Si la unidad inicia el combate, otorga Spd+8 durante el combate.");
        skill.AddCondition(new UnitBeginAsAttackerCondition());
        skill.AddEffect(new BonusEffect(StatType.Spd, 8));
        return skill;
    }

    private static Skill CreateWardingBlowSkill()
    {
        Skill skill = new Skill("Warding Blow", "Si la unidad inicia el combate, otorga Res+8 durante el combate.");
        skill.AddCondition(new UnitBeginAsAttackerCondition());
        skill.AddEffect(new BonusEffect(StatType.Res, 8));
        return skill;
    }

    private static Skill CreateSwiftSparrowSkill()
    {
        Skill skill = new Skill("Swift Sparrow",
            "Si la unidad inicia el combate, otorga Atk/Spd+6 durante el combate.");
        skill.AddCondition(new UnitBeginAsAttackerCondition());
        skill.AddEffect(new BonusEffect(StatType.Atk, 6));
        skill.AddEffect(new BonusEffect(StatType.Spd, 6));
        return skill;
    }

    private static Skill CreateSturdyBlowSkill()
    {
        Skill skill = new Skill("Sturdy Blow", "Si la unidad inicia el combate, otorga Atk/Def+6 durante el combate.");
        skill.AddCondition(new UnitBeginAsAttackerCondition());
        skill.AddEffect(new BonusEffect(StatType.Atk, 6));
        skill.AddEffect(new BonusEffect(StatType.Def, 6));
        return skill;
    }

    private static Skill CreateMirrorStrikeSkill()
    {
        Skill skill = new Skill("Mirror Strike",
            "Si la unidad inicia el combate, otorga Atk/Res+6 durante el combate.");
        skill.AddCondition(new UnitBeginAsAttackerCondition());
        skill.AddEffect(new BonusEffect(StatType.Atk, 6));
        skill.AddEffect(new BonusEffect(StatType.Res, 6));
        return skill;
    }

    private static Skill CreateSteadyBlowSkill()
    {
        Skill skill = new Skill("Steady Blow", "Si la unidad inicia el combate, otorga Spd/Def+6 durante el combate.");
        skill.AddCondition(new UnitBeginAsAttackerCondition());
        skill.AddEffect(new BonusEffect(StatType.Spd, 6));
        skill.AddEffect(new BonusEffect(StatType.Def, 6));
        return skill;
    }

    private static Skill CreateSwiftStrikeSkill()
    {
        Skill skill = new Skill("Swift Strike", "Si la unidad inicia el combate, otorga Spd/Res+6 durante el combate.");
        skill.AddCondition(new UnitBeginAsAttackerCondition());
        skill.AddEffect(new BonusEffect(StatType.Spd, 6));
        skill.AddEffect(new BonusEffect(StatType.Res, 6));
        return skill;
    }

    private static Skill CreateBracingBlowSkill()
    {
        Skill skill = new Skill("Bracing Blow", "Si la unidad inicia el combate, otorga Def/Res+6 durante el combate.");
        skill.AddCondition(new UnitBeginAsAttackerCondition());
        skill.AddEffect(new BonusEffect(StatType.Def, 6));
        skill.AddEffect(new BonusEffect(StatType.Res, 6));
        return skill;
    }

    private static Skill CreateAttackPlus6Skill()
    {
        Skill skill = new Skill("Attack +6", "Otorga Atk+6.");
        skill.AddCondition(new NoCondition());
        skill.AddEffect(new BonusEffect(StatType.Atk, 6));
        return skill;
    }

    private static Skill CreateSpeedPlus5Skill()
    {
        Skill skill = new Skill("Speed +5", "Otorga Spd+5.");
        skill.AddCondition(new NoCondition());
        skill.AddEffect(new BonusEffect(StatType.Spd, 5));
        return skill;
    }

    private static Skill CreateDefensePlus5Skill()
    {
        Skill skill = new Skill("Defense +5", "Otorga Def+5.");
        skill.AddCondition(new NoCondition());
        skill.AddEffect(new BonusEffect(StatType.Def, 5));
        return skill;
    }

    private static Skill CreateResistancePlus5Skill()
    {
        Skill skill = new Skill("Resistance +5", "Otorga Res+5.");
        skill.AddCondition(new NoCondition());
        skill.AddEffect(new BonusEffect(StatType.Res, 5));
        return skill;
    }

    private static Skill CreateAtkDefPlus5Skill()
    {
        Skill skill = new Skill("Atk/Def +5", "Otorga Atk+5 y Def+5.");
        skill.AddCondition(new NoCondition());
        skill.AddEffect(new BonusEffect(StatType.Atk, 5));
        skill.AddEffect(new BonusEffect(StatType.Def, 5));
        return skill;
    }

    private static Skill CreateSpdResPlus5Skill()
    {
        Skill skill = new Skill("Spd/Res +5", "Otorga Spd+5 y Res+5.");
        skill.AddCondition(new NoCondition());
        skill.AddEffect(new BonusEffect(StatType.Spd, 5));
        skill.AddEffect(new BonusEffect(StatType.Res, 5));
        return skill;
    }

    private static Skill CreateAtkResPlus5Skill()
    {
        Skill skill = new Skill("Atk/Res +5", "Otorga Atk+5 y Red+5.");
        skill.AddCondition(new NoCondition());
        skill.AddEffect(new BonusEffect(StatType.Atk, 5));
        skill.AddEffect(new BonusEffect(StatType.Res, 5));
        return skill;
    }

    private static Skill CreateTomePrecisionSkill()
    {
        Skill skill = new Skill("Tome Precision", "Otorga Atk/Spd+6 al usar magia.");
        skill.AddCondition(new WeaponCondition("Magic"));
        skill.AddEffect(new BonusEffect(StatType.Atk, 6));
        skill.AddEffect(new BonusEffect(StatType.Spd, 6));
        return skill;
    }

    private static Skill CreateBrazenAtkSpdSkill()
    {
        Skill skill = new Skill("Brazen Atk/Spd", "Al inicio del combate, si el HP de la unidad \u2264 80 %, otorga Atk/Spd+10 durante el combate");
        skill.AddCondition(new BeginningOfTheCombatCondition());
        skill.AddCondition(new HpThresholdCondition(0.8));
        skill.AddEffect(new BonusEffect(StatType.Atk, 10));
        skill.AddEffect(new BonusEffect(StatType.Spd, 10));
        return skill;
    }
    
    private static Skill CreateBrazenAtkDefSkill()
    {
        Skill skill = new Skill("Brazen Atk/Def", "Al inicio del combate, si el HP de la unidad ≤ 80 %, otorga Atk/Def+10 durante el combate");
        skill.AddCondition(new BeginningOfTheCombatCondition());
        skill.AddCondition(new HpThresholdCondition(0.8));
        skill.AddEffect(new BonusEffect(StatType.Atk, 10));
        skill.AddEffect(new BonusEffect(StatType.Def, 10));
        return skill;
    }
    
    private static Skill CreateBrazenAtkResSkill()
    {
        Skill skill = new Skill("Brazen Atk/Res", "Al inicio del combate, si el HP de la unidad ≤ 80 %, otorga Atk/Res+10 durante el combate");
        skill.AddCondition(new BeginningOfTheCombatCondition());
        skill.AddCondition(new HpThresholdCondition(0.8));
        skill.AddEffect(new BonusEffect(StatType.Atk, 10));
        skill.AddEffect(new BonusEffect(StatType.Res, 10));
        return skill;
    }
    
    private static Skill CreateBrazenSpdDefSkill()
    {
        Skill skill = new Skill("Brazen Spd/Def", "Al inicio del combate, si el HP de la unidad ≤ 80 %, otorga Spd/Def+10 durante el combate");
        skill.AddCondition(new BeginningOfTheCombatCondition());
        skill.AddCondition(new HpThresholdCondition(0.8));
        skill.AddEffect(new BonusEffect(StatType.Spd, 10));
        skill.AddEffect(new BonusEffect(StatType.Def, 10));
        return skill;
    }
    
    private static Skill CreateBrazenSpdResSkill()
    {
        Skill skill = new Skill("Brazen Spd/Res", "Al inicio del combate, si el HP de la unidad ≤ 80 %, otorga Spd/Res+10 durante el combate");
        skill.AddCondition(new BeginningOfTheCombatCondition());
        skill.AddCondition(new HpThresholdCondition(0.8));
        skill.AddEffect(new BonusEffect(StatType.Spd, 10));
        skill.AddEffect(new BonusEffect(StatType.Res, 10));
        return skill;
    }

    private static Skill CreateBrazenDefResSkill()
    {
        Skill skill = new Skill("Brazen Def/Res", "Al inicio del combate, si el HP de la unidad ≤ 80 %, otorga Def/Res+10 durante el combate");
        skill.AddCondition(new BeginningOfTheCombatCondition());
        skill.AddCondition(new HpThresholdCondition(0.8));
        skill.AddEffect(new BonusEffect(StatType.Def, 10));
        skill.AddEffect(new BonusEffect(StatType.Res, 10));
        return skill;
    }

    private static Skill CreateDeadlyBladeSkill()
    {
        Skill skill = new Skill("Deadly Blade", "Si la unidad inicia el combate con una espada, otorga Atk/Spd+8 durante el combate.");
        skill.AddCondition(new WeaponCondition("Sword"));
        skill.AddCondition(new UnitBeginAsAttackerCondition());
        skill.AddEffect(new BonusEffect(StatType.Atk, 8));
        skill.AddEffect(new BonusEffect(StatType.Spd, 8));
        return skill;
    }
}
