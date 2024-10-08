using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Exception;
using Fire_Emblem.Skills;
using Fire_Emblem.Units;
namespace Fire_Emblem.Handlers;

public abstract class EffectsHandler
{
    private Unit _activator { get; }
    private Unit _opponent { get; }
    
    protected EffectsHandler(Unit activator, Unit opponent)
    {
        _activator = activator;
        _opponent = opponent;
    }

    public void CollectConditionMetEffects(List<(Unit, IEffect)> effectsToApply)
    {
        SkillCollection activatorSkills = _activator.Skills;
        IEnumerable<Skill> skills = activatorSkills.Items;
        foreach (Skill skill in skills)
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
        if (effect is ConditionalEffect conditionalEffect && ShouldProcessEffect(conditionalEffect))
            AddEffectIfConditionMet(conditionalEffect, effectsToApply);
    }

    private void AddEffectIfConditionMet(ConditionalEffect conditionalEffect, List<(Unit, IEffect)> effectsToApply)
    {
        ICondition condition = conditionalEffect.Condition;
        if (condition.IsConditionMet(_activator, _opponent))
            effectsToApply.Add((_activator, conditionalEffect));
    }

    public void ApplyEffectsInOrder(List<(Unit, IEffect)> effectsToApply)
    {
        foreach (Type effectType in GetEffectTypesInOrder())
        {
            ApplyEffects(effectType, effectsToApply);
        }
    }

    private void ApplyEffects(Type effectType, List<(Unit, IEffect)> effectsToApply)
    {
        foreach ((Unit, IEffect) effectPair in effectsToApply)
        {
            ApplyEffectToUnit(effectType, effectPair);
        }
    }

    private void ApplyEffectToUnit(Type effectType, (Unit, IEffect) effectPair)
    {
        Unit unit = effectPair.Item1;
        IEffect effect = effectPair.Item2;
        if (effect is ConditionalEffect conditionalEffect)
            ApplyConditionalEffect(effectType, unit, conditionalEffect);
    }

    private void ApplyConditionalEffect(Type effectType, Unit unit, ConditionalEffect conditionalEffect)
    {
        if (effectType.IsInstanceOfType(conditionalEffect.Effect))
            ApplySpecificEffect(unit, conditionalEffect.Effect);
    }

    private void ApplySpecificEffect(Unit unit, IEffect specificEffect)
    {
        Unit targetUnit = unit == _activator ? _opponent : _activator;
        specificEffect.ApplyEffect(unit, targetUnit);
    }

    protected abstract bool ShouldProcessEffect(ConditionalEffect conditionalEffect);
    protected abstract IEnumerable<Type> GetEffectTypesInOrder();
}