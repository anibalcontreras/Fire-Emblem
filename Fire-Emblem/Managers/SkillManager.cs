using Fire_Emblem.Effects;
using Fire_Emblem.Effects.AlterBaseStat;
using Fire_Emblem.Effects.Damage.AbsoluteDamageReduction;
using Fire_Emblem.Effects.Damage.ExtraDamage;
using Fire_Emblem.Effects.Damage.PercentageDamageReduction;
using Fire_Emblem.Effects.Neutralization;
using Fire_Emblem.Exception;
using Fire_Emblem.Skills;
using Fire_Emblem.Units;
using Fire_Emblem.Views;

namespace Fire_Emblem.Managers;

public class SkillManager
{
    
    private readonly GameView _gameView;
    public SkillManager(GameView gameView)
    {
        _gameView = gameView;
    }
    
    public void ActivateSkills(Combat combat)
    {
        ApplySkills(combat.Attacker, combat.Defender);
        AnnounceEffects(combat);
    }
    
    private void ApplySkills(Unit activator, Unit opponent)
    {
        List<(Unit, IEffect)> effectsToApply = new List<(Unit, IEffect)>();
        CollectConditionMetEffectsFromActiveUnit(activator, opponent, effectsToApply);
        CollectConditionMetEffectsFromOpponentUnit(activator, opponent, effectsToApply);
        ApplyTheProperSkills(activator, opponent, effectsToApply);
    }
    
    private static void CollectConditionMetEffectsFromUnit(Unit source, Unit target, List<(Unit, IEffect)> effectsToApply)
    {
        foreach (Skill skill in source.Skills)
        {
            CollectEffectsFromSkill(source, target, skill, effectsToApply);
        }
    }

    private static void CollectEffectsFromSkill(Unit source, Unit target, Skill skill, List<(Unit, IEffect)> effectsToApply)
    {
        
        try
        {
            foreach (IEffect effect in skill.Effect)
            {
                AddEffectIfConditionMet(source, target, effect, effectsToApply);
            }
        }
        catch (NullReferenceException)
        {
            throw new NotImplementedEffectException();
        }
    }

    private static void AddEffectIfConditionMet(Unit source, Unit target, IEffect effect, List<(Unit, IEffect)> effectsToApply)
    {
        if (effect is ConditionalEffect conditionalEffect)
            CheckAndAddConditionalEffect(source, target, conditionalEffect, effectsToApply);
        else
            effectsToApply.Add((source, effect));
    }

    private static void CheckAndAddConditionalEffect(Unit source, Unit target, ConditionalEffect conditionalEffect, 
        List<(Unit, IEffect)> effectsToApply)
    {
        if (conditionalEffect.Condition.IsConditionMet(source, target))
        {
            effectsToApply.Add((source, conditionalEffect));
        }
    }

    private static void CollectConditionMetEffectsFromActiveUnit(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        CollectConditionMetEffectsFromUnit(activator, opponent, effectsToApply);
    }

    private static void CollectConditionMetEffectsFromOpponentUnit(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        CollectConditionMetEffectsFromUnit(opponent, activator, effectsToApply);
    }
    
    private static void ApplyTheProperSkills(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        ApplyAlterBaseStatEffects(activator, opponent, effectsToApply);
        ApplyBonusEffects(activator, opponent, effectsToApply);
        ApplyFirstAttackBonusEffects(activator, opponent, effectsToApply);
        ApplyPenaltyBonus(activator, opponent, effectsToApply);
        ApplyFirstAttackPenaltyBonus(activator, opponent, effectsToApply);
        ApplyNeutralizationBonusEffect(activator, opponent, effectsToApply);
        ApplyNeutralizationPenaltyBonus(activator, opponent, effectsToApply);
        ApplyExtraDamage(activator, opponent, effectsToApply);
        ApplyFirstAttackExtraDamage(activator, opponent, effectsToApply);
        ApplyPercentageDamageReduction(activator, opponent, effectsToApply);
        ApplyFirstAttackPercentageDamageReduction(activator, opponent, effectsToApply);
        ApplyFollowUpPercentageDamageReduction(activator, opponent, effectsToApply);
        ApplyAbsoluteDamageReduction(activator, opponent, effectsToApply);
    }
    private static void ApplyEffects<T>(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply) where T : IEffect
    {
        foreach (var (unit, effect) in effectsToApply)
        {
            if (effect is ConditionalEffect conditionalEffect && conditionalEffect.Effect is T specificEffect)
            {
                specificEffect.ApplyEffect(unit, unit == activator ? opponent : activator);
            }
        }
    }

    private static void ApplyAlterBaseStatEffects(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        ApplyEffects<AlterBaseStatEffect>(activator, opponent, effectsToApply);
    }

    private static void ApplyBonusEffects(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        ApplyEffects<IBonusEffect>(activator, opponent, effectsToApply);
    }

    private static void ApplyFirstAttackBonusEffects(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        ApplyEffects<FirstAttackBonusEffect>(activator, opponent, effectsToApply);
    }

    private static void ApplyPenaltyBonus(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        ApplyEffects<IPenaltyEffect>(activator, opponent, effectsToApply);
    }

    private static void ApplyFirstAttackPenaltyBonus(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        ApplyEffects<FirstAttackPenaltyEffect>(activator, opponent, effectsToApply);
    }

    private static void ApplyNeutralizationBonusEffect(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        ApplyEffects<NeutralizationBonusEffect>(activator, opponent, effectsToApply);
    }

    private static void ApplyNeutralizationPenaltyBonus(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        ApplyEffects<NeutralizationPenaltyEffect>(activator, opponent, effectsToApply);
    }

    private static void ApplyExtraDamage(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        ApplyEffects<IExtraDamageEffect>(activator, opponent, effectsToApply);
    }
    
    private static void ApplyFirstAttackExtraDamage(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        ApplyEffects<FirstAttackExtraDamageEffect>(activator, opponent, effectsToApply);
    }

    private static void ApplyAbsoluteDamageReduction(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        ApplyEffects<AbsoluteDamageReductionEffect>(activator, opponent, effectsToApply);
    }

    private static void ApplyPercentageDamageReduction(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        ApplyEffects<IPercentageDamageReductionEffect>(activator, opponent, effectsToApply);
    }

    private static void ApplyFirstAttackPercentageDamageReduction(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        ApplyEffects<FirstAttackPercentageDamageReductionEffect>(activator, opponent, effectsToApply);
    }

    private static void ApplyFollowUpPercentageDamageReduction(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        ApplyEffects<FollowUpPercentageDamageReductionEffect>(activator, opponent, effectsToApply);
    }
    
    private void AnnounceEffects(Combat combat)
    {
        AnnounceAttackerSkills(combat);
        AnnounceDefenderSkills(combat);
    }
    private void AnnounceAttackerSkills(Combat combat)
    {
        _gameView.AnnounceAttackerBonusStat(combat.Attacker);
        _gameView.AnnounceAttackerPenaltyStat(combat.Attacker);
        _gameView.AnnounceNeutralizationBonusEffect(combat.Attacker);
        _gameView.AnnounceNeutralizationPenaltyEffect(combat.Attacker);
        _gameView.AnnounceExtraDamage(combat.Attacker);
        _gameView.AnnounceEachAttackPercentageReduction(combat.Attacker);
        _gameView.AnnounceFirstAttackPercentageReduction(combat.Attacker);
        _gameView.AnnounceFollowUpPercentageReduction(combat.Attacker);
        _gameView.AnnounceAbsoluteDamageReduction(combat.Attacker);
    }
    private void AnnounceDefenderSkills(Combat combat)
    {
        _gameView.AnnounceDefenderBonusEffects(combat.Defender);
        _gameView.AnnounceDefenderPenaltyEffects(combat.Defender);
        _gameView.AnnounceNeutralizationBonusEffect(combat.Defender);
        _gameView.AnnounceNeutralizationPenaltyEffect(combat.Defender);
        _gameView.AnnounceExtraDamage(combat.Defender);
        _gameView.AnnounceEachAttackPercentageReduction(combat.Defender);
        _gameView.AnnounceFirstAttackPercentageReduction(combat.Defender);
        _gameView.AnnounceFollowUpPercentageReduction(combat.Defender);
        _gameView.AnnounceAbsoluteDamageReduction(combat.Defender);
    }
}