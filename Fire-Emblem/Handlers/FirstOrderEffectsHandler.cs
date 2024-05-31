using Fire_Emblem.Effects;
using Fire_Emblem.Effects.AlterBaseStat;
using Fire_Emblem.Effects.Neutralization;
using Fire_Emblem.Exception;
using Fire_Emblem.Skills;
using Fire_Emblem.Units;

namespace Fire_Emblem.Handlers;

public class FirstOrderEffectsHandler
{
    private Unit _activator { get; }
    private Unit _opponent { get; }
    public FirstOrderEffectsHandler(Unit activator, Unit opponent)
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
        if (effect is ConditionalEffect conditionalEffect && EffectUtils.IsFirstOrderEffect(conditionalEffect))
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
        ApplyEffects<AlterBaseStatEffect>(effectsToApply);
        ApplyEffects<IBonusEffect>(effectsToApply);
        ApplyEffects<FirstAttackBonusEffect>(effectsToApply);
        ApplyEffects<IPenaltyEffect>(effectsToApply);
        ApplyEffects<FirstAttackPenaltyEffect>(effectsToApply);
        ApplyEffects<NeutralizationBonusEffect>(effectsToApply);
        ApplyEffects<NeutralizationPenaltyEffect>(effectsToApply);
    }
    
    private void ApplyEffects<T>(List<(Unit, IEffect)> effectsToApply) where T : IEffect
    {
        foreach (var (unit, effect) in effectsToApply)
        {
            if (effect is ConditionalEffect conditionalEffect && conditionalEffect.Effect is T specificEffect)
            {
                specificEffect.ApplyEffect(unit, unit == _activator ? _opponent : _activator);
            }
        }
    }
}