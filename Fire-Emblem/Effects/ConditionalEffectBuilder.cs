using Fire_Emblem.Conditions;
using Fire_Emblem.Stats;

namespace Fire_Emblem.Effects;

public static class ConditionalEffectBuilder
{
    public static MultiEffect BuildNeutralizationPenaltyEffect(ICondition condition, params StatType[] statTypes)
    {
        var effects = statTypes.Select(statType => 
            new ConditionalEffect(condition, 
                EffectBuilder.BuildNeutralizationPenaltyEffect(statType, EffectTarget.Unit))
        ).ToArray();
        return new MultiEffect(effects);
    }
    
    public static MultiEffect BuildPenaltyEffects(ICondition condition, int penaltyValue, params StatType[] statTypes)
    {
        ConditionalEffect[] effects = statTypes.Select(statType => 
            new ConditionalEffect(condition, 
                EffectBuilder.BuildPenaltyEffect(statType, penaltyValue, EffectTarget.Rival))
        ).ToArray();
        return new MultiEffect(effects);
    }
    
    public static MultiEffect BuildBonusEffects(ICondition condition, int bonusValue, params StatType[] statTypes)
    {
        ConditionalEffect[] effects = statTypes.Select(statType => 
            new ConditionalEffect(condition, 
                EffectBuilder.BuildBonusEffect(statType, bonusValue, EffectTarget.Unit))
        ).ToArray();
        return new MultiEffect(effects);
    }
    
    public static MultiEffect BuildNeutralizationBonusEffects(ICondition condition, params StatType[] statTypes)
    {
        var effects = statTypes.Select(statType => 
            new ConditionalEffect(condition, 
                EffectBuilder.BuildNeutralizationBonusEffect(statType, EffectTarget.Rival))
        ).ToArray();
        return new MultiEffect(effects);
    }
}