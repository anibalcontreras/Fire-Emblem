using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Stats;

namespace Fire_Emblem.Skills.TypesCreator;

public static class CreateDef
{
    public static Skill CreateDefSkill(string name, ICondition condition)
    {
        int bonusValue = 8;
        StatType[] bonusStatTypes = { StatType.Def, StatType.Res };
        StatType[] neutralizationStatTypes = { StatType.Atk, StatType.Spd, StatType.Def, StatType.Res };
        
        MultiEffect bonusEffects = ConditionalEffectBuilder.BuildBonusEffects(condition, bonusValue, bonusStatTypes);
        MultiEffect neutralizationBonusEffects = ConditionalEffectBuilder.BuildNeutralizationBonusEffects(condition, 
            neutralizationStatTypes);
        IEnumerable<IEffect> allEffects = bonusEffects.Concat(neutralizationBonusEffects);
        MultiEffect multiEffect = new MultiEffect(allEffects);
        return new Skill(name, multiEffect);
    }
}
