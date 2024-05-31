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
    private Unit _activator { get; }
    private Unit _opponent { get; }
    public SecondOrderEffectsHandler(Unit activator, Unit opponent)
    {
        _activator = activator;
        _opponent = opponent;
    }
    
    public void CollectConditionMetEffects(List<(Unit, IEffect)> effectsToApply)
    {
        foreach (Skill skill in _activator.Skills)
        {
            AddConditionalEffects(skill, effectsToApply);
        }
    }

    private void AddConditionalEffects(Skill skill, List<(Unit, IEffect)> effectsToApply)
    {
        try
        {
            foreach (IEffect effect in skill.Effect)
            {
                ProcessEffect(effect, effectsToApply);
            }
        }
        catch (NullReferenceException)
        {
            throw new NotImplementedEffectException();
        }
    }

    private void ProcessEffect(IEffect effect, List<(Unit, IEffect)> effectsToApply)
    {
        if (effect is ConditionalEffect conditionalEffect && !EffectUtils.IsFirstOrderEffect(conditionalEffect))
        {
            AddEffectIfConditionMet(conditionalEffect, effectsToApply);
        }
    }

    private void AddEffectIfConditionMet(ConditionalEffect conditionalEffect, List<(Unit, IEffect)> effectsToApply)
    {
        if (conditionalEffect.Condition.IsConditionMet(_activator, _opponent))
        {
            effectsToApply.Add((_activator, conditionalEffect));
        }
    }


    public void ApplyEffectsInOrder(List<(Unit, IEffect)> effectsToApply)
    {
        ApplyEffects<IExtraDamageEffect>(effectsToApply);
        ApplyEffects<FirstAttackExtraDamageEffect>(effectsToApply);
        ApplyEffects<AbsoluteDamageReductionEffect>(effectsToApply);
        ApplyEffects<IPercentageDamageReductionEffect>(effectsToApply);
        ApplyEffects<FirstAttackPercentageDamageReductionEffect>(effectsToApply);
        ApplyEffects<FollowUpPercentageDamageReductionEffect>(effectsToApply);
    }
    
    private void ApplyEffects<T>(List<(Unit, IEffect)> effectsToApply) where T : IEffect
    {
        foreach ((Unit, IEffect) effectPair in effectsToApply)
        {
            ApplyEffectToUnit<T>(effectPair);
        }
    }
    
    private void ApplyEffectToUnit<T>((Unit, IEffect) effectPair) where T : IEffect
    {
        Unit unit = effectPair.Item1;
        IEffect effect = effectPair.Item2;
        if (effect is ConditionalEffect conditionalEffect)
        {
            ApplyConditionalEffect<T>(unit, conditionalEffect);
        }
    }
    
    private void ApplyConditionalEffect<T>(Unit unit, ConditionalEffect conditionalEffect) where T : IEffect
    {
        if (conditionalEffect.Effect is T specificEffect)
            ApplySpecificEffect(unit, specificEffect);
    }
    
    private void ApplySpecificEffect(Unit unit, IEffect specificEffect)
    {
        Unit targetUnit = unit == _activator ? _opponent : _activator;
        specificEffect.ApplyEffect(unit, targetUnit);
    }
}