using Fire_Emblem.Effects;
using Fire_Emblem.Effects.Damage.AbsoluteDamageReduction;
using Fire_Emblem.Effects.Damage.ExtraDamage;
using Fire_Emblem.Effects.Damage.PercentageDamageReduction;
using Fire_Emblem.Exception;
using Fire_Emblem.Skills;
using Fire_Emblem.Units;

namespace Fire_Emblem.Handlers;

public class SecondOrderEffectsHandler
{
    public void CollectConditionMetEffects(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        foreach (Skill skill in activator.Skills)
        {
            AddConditionalEffects(skill, activator, opponent, effectsToApply);
        }
    }

    private void AddConditionalEffects(Skill skill, Unit activator, Unit opponent, 
        List<(Unit, IEffect)> effectsToApply)
    {
        try
        {
            foreach (IEffect effect in skill.Effect)
            {
                ProcessEffect(effect, activator, opponent, effectsToApply);
            }
        }
        catch (NullReferenceException)
        {
            throw new NotImplementedEffectException();
        }
    }

    private void ProcessEffect(IEffect effect, Unit activator, Unit opponent, 
        List<(Unit, IEffect)> effectsToApply)
    {
        if (effect is ConditionalEffect conditionalEffect && !EffectUtils.IsFirstOrderEffect(conditionalEffect))
        {
            AddEffectIfConditionMet(conditionalEffect, activator, opponent, effectsToApply);
        }
    }

    private void AddEffectIfConditionMet(ConditionalEffect conditionalEffect, Unit activator, Unit opponent, 
        List<(Unit, IEffect)> effectsToApply)
    {
        if (conditionalEffect.Condition.IsConditionMet(activator, opponent))
        {
            effectsToApply.Add((activator, conditionalEffect));
        }
    }


    public void ApplyEffectsInOrder(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        ApplyEffects<IExtraDamageEffect>(activator, opponent, effectsToApply);
        ApplyEffects<FirstAttackExtraDamageEffect>(activator, opponent, effectsToApply);
        ApplyEffects<AbsoluteDamageReductionEffect>(activator, opponent, effectsToApply);
        ApplyEffects<IPercentageDamageReductionEffect>(activator, opponent, effectsToApply);
        ApplyEffects<FirstAttackPercentageDamageReductionEffect>(activator, opponent, effectsToApply);
        ApplyEffects<FollowUpPercentageDamageReductionEffect>(activator, opponent, effectsToApply);
    }
    
    private void ApplyEffects<T>(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply) where T : IEffect
    {
        foreach (var (unit, effect) in effectsToApply)
        {
            if (effect is ConditionalEffect conditionalEffect && conditionalEffect.Effect is T specificEffect)
            {
                specificEffect.ApplyEffect(unit, unit == activator ? opponent : activator);
            }
        }
    }
}