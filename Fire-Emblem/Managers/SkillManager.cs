using Fire_Emblem.Effects;
using Fire_Emblem.Effects.AlterBaseStat;
using Fire_Emblem.Effects.Damage.AbsoluteDamageReduction;
using Fire_Emblem.Effects.Damage.ExtraDamage;
using Fire_Emblem.Effects.Damage.PercentageDamageReduction;
using Fire_Emblem.Effects.Neutralization;
using Fire_Emblem.Units;
using Fire_Emblem.Views;

namespace Fire_Emblem;

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
    
    // Separar método
    private static void CollectConditionMetEffectsFromActiveUnit(Unit activator, Unit opponent,
        List<(Unit, IEffect)> effectsToApply)
    {
        foreach (var skill in activator.Skills)
        {
            foreach (var effect in skill.Effect)
            {
                if (effect is ConditionalEffect conditionalEffect)
                {
                    if (conditionalEffect.Condition.IsConditionMet(activator, opponent))
                    {
                        effectsToApply.Add((activator, conditionalEffect));
                    }
                }
                else
                {
                    effectsToApply.Add((activator, effect));
                }
            }
        }
    }
    
    
    private static void CollectConditionMetEffectsFromOpponentUnit(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        foreach (var skill in opponent.Skills)
        {
            foreach (var effect in skill.Effect)
            {
                if (effect is ConditionalEffect conditionalEffect)
                {
                    if (conditionalEffect.Condition.IsConditionMet(opponent, activator))
                    {
                        effectsToApply.Add((opponent, conditionalEffect));
                    }
                }
                else
                {
                    effectsToApply.Add((opponent, effect));
                }
            }
        }
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
        ApplyPercentageDamageReduction(activator, opponent, effectsToApply);
        ApplyFirstAttackPercentageDamageReduction(activator, opponent, effectsToApply);
        ApplyFollowUpPercentageDamageReduction(activator, opponent, effectsToApply);
        ApplyAbsoluteDamageReduction(activator, opponent, effectsToApply);
    }
    private static void ApplyAlterBaseStatEffects(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        foreach (var (unit, effect) in effectsToApply)
        {
            if (effect is ConditionalEffect conditionalEffect && conditionalEffect.Effect is AlterBaseStatEffect conditionalBaseStatEffect)
            {
                conditionalBaseStatEffect.ApplyEffect(unit, unit == activator ? opponent : activator);
            }
        }
    }
    
    private static void ApplyBonusEffects(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        foreach (var (unit, effect) in effectsToApply)
        {
            if (effect is ConditionalEffect conditionalEffect && conditionalEffect.Effect is IBonusEffect conditionalBonusEffect)
            {
                conditionalBonusEffect.ApplyEffect(unit, unit == activator ? opponent : activator);
            }
        }
    }
        
    private static void ApplyFirstAttackBonusEffects(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        foreach (var (unit, effect) in effectsToApply)
        {
            if (effect is ConditionalEffect conditionalEffect && conditionalEffect.Effect is FirstAttackBonusEffect conditionalFirstAttackBonusEffect)
            {
                conditionalFirstAttackBonusEffect.ApplyEffect(unit, unit == activator ? opponent : activator);
            }
        }
    }

    private static void ApplyPenaltyBonus(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        foreach (var (unit, effect) in effectsToApply)
        {
            if (effect is ConditionalEffect conditionalEffect && conditionalEffect.Effect is IPenaltyEffect conditionalPenaltyEffect)
            {
                conditionalPenaltyEffect.ApplyEffect(unit, unit == activator ? opponent : activator);
            }
        }
    }

    private static void ApplyFirstAttackPenaltyBonus(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        foreach (var (unit, effect) in effectsToApply)
        {
            if (effect is ConditionalEffect conditionalEffect && conditionalEffect.Effect is FirstAttackPenaltyEffect conditionalFirstAttackPenaltyEffect)
            {
                conditionalFirstAttackPenaltyEffect.ApplyEffect(unit, unit == activator ? opponent : activator);
            }
        }
    }

    private static void ApplyNeutralizationBonusEffect(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        foreach (var (unit, effect) in effectsToApply)
        {
            if (effect is ConditionalEffect conditionalEffect && conditionalEffect.Effect is NeutralizationBonusEffect conditionalNeutralizationBonusEffect)
            {
                conditionalNeutralizationBonusEffect.ApplyEffect(unit, unit == activator ? opponent : activator);
            }
        }
    }

    private static void ApplyNeutralizationPenaltyBonus(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        foreach (var (unit, effect) in effectsToApply)
        {
            if (effect is ConditionalEffect conditionalEffect && conditionalEffect.Effect is NeutralizationPenaltyEffect conditionalNeutralizationPenaltyEffect)
            {
                conditionalNeutralizationPenaltyEffect.ApplyEffect(unit, unit == activator ? opponent : activator);
            }
        }
    }

    private static void ApplyExtraDamage(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        foreach (var (unit, effect) in effectsToApply)
        {
            if (effect is ConditionalEffect conditionalEffect && conditionalEffect.Effect is IExtraDamageEffect conditionalExtraDamageEffect)
            {
                conditionalExtraDamageEffect.ApplyEffect(unit, unit == activator ? opponent : activator);
            }
        }
    }

    private static void ApplyAbsoluteDamageReduction(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        foreach (var (unit, effect) in effectsToApply)
        {
            if (effect is ConditionalEffect conditionalEffect && conditionalEffect.Effect is AbsoluteDamageReductionEffect conditionalAbsoluteDamageReductionEffect)
            {
                conditionalAbsoluteDamageReductionEffect.ApplyEffect(unit, unit == activator ? opponent : activator);
            }
        }
    }

    private static void ApplyPercentageDamageReduction(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        foreach (var (unit, effect) in effectsToApply)
        {
            if (effect is ConditionalEffect conditionalEffect && conditionalEffect.Effect is IPercentageDamageReductionEffect conditionalPercentageDamageReductionEffect)
            {
                conditionalPercentageDamageReductionEffect.ApplyEffect(unit, unit == activator ? opponent : activator);
            }
        }
    }

    private static void ApplyFirstAttackPercentageDamageReduction(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        foreach (var (unit, effect) in effectsToApply)
        {
            if (effect is ConditionalEffect conditionalEffect && conditionalEffect.Effect is FirstAttackPercentageDamageReductionEffect conditionalFirstAttackPercentageDamageReductionEffect)
            {
                conditionalFirstAttackPercentageDamageReductionEffect.ApplyEffect(unit, unit == activator ? opponent : activator);
            }
        }
    }

    private static void ApplyFollowUpPercentageDamageReduction(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        foreach (var (unit, effect) in effectsToApply)
        {
            if (effect is ConditionalEffect conditionalEffect && conditionalEffect.Effect is FollowUpPercentageDamageReductionEffect conditionalFollowUpPercentageDamageReductionEffect)
            {
                conditionalFollowUpPercentageDamageReductionEffect.ApplyEffect(unit, unit == activator ? opponent : activator);
            }
        }
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