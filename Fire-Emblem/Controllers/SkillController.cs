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

namespace Fire_Emblem.Controllers;

// TODO: LIMPIAR CODIGO URGENTEMENTE
// 1) Hacer que vuelva a usarse la excepcion NotImplementedEffectException
// 2) Eliminar código duplicado
// 3) Verificar que las funciones tengan máximo 3 argumentos
// 4) Eliminar comentarios innecesarios
public class SkillController
{
    
    private readonly ConsoleGameView _consoleGameView;
    public SkillController(ConsoleGameView consoleGameView)
    {
        _consoleGameView = consoleGameView;
    }
    
    public void ActivateSkills(Combat combat)
    {
        ApplySkills(combat.Attacker, combat.Defender);
        AnnounceEffects(combat);
    }
    
    private void ApplySkills(Unit activator, Unit opponent)
    {
        List<(Unit, IEffect)> firstEffectsToApply = new List<(Unit, IEffect)>();
        CollectConditionMetFirstOrderEffects(activator, opponent, firstEffectsToApply);
        CollectConditionMetFirstOrderEffects(opponent, activator, firstEffectsToApply);
        ApplyFirstEffectsInOrder(activator, opponent, firstEffectsToApply);
        
        List<(Unit, IEffect)> secondEffectsToApply = new List<(Unit, IEffect)>();
        CollectConditionMetSecondOrderEffects(activator, opponent, secondEffectsToApply);
        CollectConditionMetSecondOrderEffects(opponent, activator, secondEffectsToApply);
        ApplySecondEffectsInOrder(activator, opponent, secondEffectsToApply);
    }
    
    private void CollectConditionMetFirstOrderEffects(Unit source, Unit target, List<(Unit, IEffect)> effectsToApply)
    {
        foreach (Skill skill in source.Skills)
        {
            foreach (IEffect effect in skill.Effect)
            {
                if (effect is ConditionalEffect conditionalEffect)
                {
                    if (IsFirstOrderEffect(conditionalEffect))
                    {
                        if (conditionalEffect.Condition.IsConditionMet(source, target))
                        {
                            effectsToApply.Add((source, conditionalEffect));
                        }
                    }
                }
                else if (IsFirstOrderEffect(new ConditionalEffect(null, effect)))
                {
                    effectsToApply.Add((source, effect));
                }
            }
        }
    }

    private void CollectConditionMetSecondOrderEffects(Unit source, Unit target, List<(Unit, IEffect)> effectsToApply)
    {
        foreach (Skill skill in source.Skills)
        {
            foreach (IEffect effect in skill.Effect)
            {
                if (effect is ConditionalEffect conditionalEffect)
                {
                    if (!IsFirstOrderEffect(conditionalEffect))
                    {
                        if (conditionalEffect.Condition.IsConditionMet(source, target))
                        {
                            effectsToApply.Add((source, conditionalEffect));
                        }
                    }
                }
                else if (!IsFirstOrderEffect(new ConditionalEffect(null, effect)))
                {
                    effectsToApply.Add((source, effect));
                }
            }
        }
    }


//     private void CollectConditionMetEffectsFromUnit(Unit source, Unit target, List<(Unit, IEffect)> firstEffectsToApply, List<(Unit, IEffect)> secondEffectsToApply)
// {
//     foreach (Skill skill in source.Skills)
//     {
//         CollectEffectsFromSkill(source, target, skill, firstEffectsToApply, secondEffectsToApply);
//     }
// }
//
// private void CollectEffectsFromSkill(Unit source, Unit target, Skill skill, List<(Unit, IEffect)> firstEffectsToApply, List<(Unit, IEffect)> secondEffectsToApply)
// {
//     try
//     {
//         AddEffects(source, target, skill, firstEffectsToApply, secondEffectsToApply);
//     }
//     catch (NullReferenceException)
//     {
//         throw new NotImplementedEffectException();
//     }
// }
//
// private void AddEffects(Unit source, Unit target, Skill skill, List<(Unit, IEffect)> firstEffectsToApply, List<(Unit, IEffect)> secondEffectsToApply)
// {
//     foreach (IEffect effect in skill.Effect)
//     {
//         AddEffectIfConditionMet(source, target, effect, firstEffectsToApply, secondEffectsToApply);
//     }
// }
//
// private void AddEffectIfConditionMet(Unit source, Unit target, IEffect effect, List<(Unit, IEffect)> firstEffectsToApply, List<(Unit, IEffect)> secondEffectsToApply)
// {
//     if (effect is ConditionalEffect conditionalEffect)
//         AddConditionalEffect(source, target, conditionalEffect, firstEffectsToApply, secondEffectsToApply);
// }
//
// private void AddConditionalEffect(Unit source, Unit target, ConditionalEffect conditionalEffect, 
//     List<(Unit, IEffect)> firstEffectsToApply, List<(Unit, IEffect)> secondEffectsToApply)
// {
//     if (conditionalEffect.Condition.IsConditionMet(source, target))
//     {
//         if (IsFirstOrderEffect(conditionalEffect))
//         {
//             firstEffectsToApply.Add((source, conditionalEffect));
//         }
//         else
//         {
//             secondEffectsToApply.Add((source, conditionalEffect));
//         }
//     }
// }

private bool IsFirstOrderEffect(ConditionalEffect effect)
{
    return effect.Effect is AlterBaseStatEffect ||
           effect.Effect is IBonusEffect ||
           effect.Effect is FirstAttackBonusEffect ||
           effect.Effect is IPenaltyEffect ||
           effect.Effect is FirstAttackPenaltyEffect ||
           effect.Effect is NeutralizationBonusEffect ||
           effect.Effect is NeutralizationPenaltyEffect;
}

   

    // private void CollectConditionMetEffectsFromActiveUnit(Unit activator, Unit opponent, List<(Unit, IEffect)> firstEffectsToApply, List<(Unit, IEffect)> secondEffectsToApply)
    // {
    //     CollectConditionMetEffectsFromUnit(activator, opponent, firstEffectsToApply, secondEffectsToApply);
    // }
    //
    // private void CollectConditionMetEffectsFromOpponentUnit(Unit activator, Unit opponent, List<(Unit, IEffect)> firstEffectsToApply, List<(Unit, IEffect)> secondEffectsToApply)
    // {
    //     CollectConditionMetEffectsFromUnit(opponent, activator, firstEffectsToApply, secondEffectsToApply);
    // }

    
    private void ApplyFirstEffectsInOrder(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        ApplyAlterBaseStatEffect(activator, opponent, effectsToApply);
        ApplyBonusEffect(activator, opponent, effectsToApply);
        ApplyFirstAttackBonusEffect(activator, opponent, effectsToApply);
        ApplyPenaltyEffect(activator, opponent, effectsToApply);
        ApplyFirstAttackPenaltyBonusEffect(activator, opponent, effectsToApply);
        ApplyNeutralizationBonusEffect(activator, opponent, effectsToApply);
        ApplyNeutralizationPenaltyEffect(activator, opponent, effectsToApply);
    }

    private void ApplySecondEffectsInOrder(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        ApplyExtraDamageEffect(activator, opponent, effectsToApply);
        ApplyFirstAttackExtraDamageEffect(activator, opponent, effectsToApply);
        ApplyAbsoluteDamageReductionEffect(activator, opponent, effectsToApply);
        ApplyPercentageDamageReductionEffect(activator, opponent, effectsToApply);
        ApplyFirstAttackPercentageDamageReductionEffect(activator, opponent, effectsToApply);
        ApplyFollowUpPercentageDamageReductionEffect(activator, opponent, effectsToApply);
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

    private void ApplyAlterBaseStatEffect(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        ApplyEffects<AlterBaseStatEffect>(activator, opponent, effectsToApply);
    }

    private void ApplyBonusEffect(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        ApplyEffects<IBonusEffect>(activator, opponent, effectsToApply);
    }

    private void ApplyFirstAttackBonusEffect(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        ApplyEffects<FirstAttackBonusEffect>(activator, opponent, effectsToApply);
    }

    private void ApplyPenaltyEffect(Unit activator, Unit opponent, 
        List<(Unit, IEffect)> effectsToApply)
    {
        ApplyEffects<IPenaltyEffect>(activator, opponent, effectsToApply);
    }

    private void ApplyFirstAttackPenaltyBonusEffect(Unit activator, Unit opponent, 
        List<(Unit, IEffect)> effectsToApply)
    {
        ApplyEffects<FirstAttackPenaltyEffect>(activator, opponent, effectsToApply);
    }

    private void ApplyNeutralizationBonusEffect(Unit activator, Unit opponent, 
        List<(Unit, IEffect)> effectsToApply)
    {
        ApplyEffects<NeutralizationBonusEffect>(activator, opponent, effectsToApply);
    }

    private void ApplyNeutralizationPenaltyEffect(Unit activator, Unit opponent, 
        List<(Unit, IEffect)> effectsToApply)
    {
        ApplyEffects<NeutralizationPenaltyEffect>(activator, opponent, effectsToApply);
    }

    private void ApplyExtraDamageEffect(Unit activator, Unit opponent, 
        List<(Unit, IEffect)> effectsToApply)
    {
        ApplyEffects<IExtraDamageEffect>(activator, opponent, effectsToApply);
    }
    
    private void ApplyFirstAttackExtraDamageEffect(Unit activator, Unit opponent, 
        List<(Unit, IEffect)> effectsToApply)
    {
        ApplyEffects<FirstAttackExtraDamageEffect>(activator, opponent, effectsToApply);
    }

    private void ApplyAbsoluteDamageReductionEffect(Unit activator, Unit opponent, 
        List<(Unit, IEffect)> effectsToApply)
    {
        ApplyEffects<AbsoluteDamageReductionEffect>(activator, opponent, effectsToApply);
    }

    private void ApplyPercentageDamageReductionEffect(Unit activator, Unit opponent, 
        List<(Unit, IEffect)> effectsToApply)
    {
        ApplyEffects<IPercentageDamageReductionEffect>(activator, opponent, effectsToApply);
    }

    private void ApplyFirstAttackPercentageDamageReductionEffect(Unit activator, Unit opponent, 
        List<(Unit, IEffect)> effectsToApply)
    {
        ApplyEffects<FirstAttackPercentageDamageReductionEffect>(activator, opponent, effectsToApply);
    }

    private void ApplyFollowUpPercentageDamageReductionEffect(Unit activator, Unit opponent, 
        List<(Unit, IEffect)> effectsToApply)
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
        _consoleGameView.AnnounceAttackerBonusEffect(combat.Attacker);
        _consoleGameView.AnnounceAttackerPenaltyEffect(combat.Attacker);
        _consoleGameView.AnnounceNeutralizationBonusEffect(combat.Attacker);
        _consoleGameView.AnnounceNeutralizationPenaltyEffect(combat.Attacker);
        _consoleGameView.AnnounceExtraDamage(combat.Attacker);
        _consoleGameView.AnnouncePercentageReductionEffect(combat.Attacker);
        _consoleGameView.AnnounceAbsoluteDamageReduction(combat.Attacker);
    }
    private void AnnounceDefenderSkills(Combat combat)
    {
        _consoleGameView.AnnounceDefenderBonusEffect(combat.Defender);
        _consoleGameView.AnnounceDefenderPenaltyEffect(combat.Defender);
        _consoleGameView.AnnounceNeutralizationBonusEffect(combat.Defender);
        _consoleGameView.AnnounceNeutralizationPenaltyEffect(combat.Defender);
        _consoleGameView.AnnounceExtraDamage(combat.Defender);
        _consoleGameView.AnnouncePercentageReductionEffect(combat.Defender);
        _consoleGameView.AnnounceAbsoluteDamageReduction(combat.Defender);
    }
}