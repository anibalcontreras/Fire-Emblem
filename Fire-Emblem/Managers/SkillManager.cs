using Fire_Emblem.Effects;
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
        ApplySkills(combat.Attacker, combat.Defender, combat);
        AnnounceEffects(combat);
    }
    
    private void ApplySkills(Unit activator, Unit opponent, Combat combat)
    {
        List<(Unit, IEffect)> effectsToApply = new List<(Unit, IEffect)>();
        CollectElegibleEffectsFromActiveUnit(activator, opponent, combat, effectsToApply);
        CollectElegibleEffectsFromOpponentUnit(activator, opponent, combat, effectsToApply);
        ApplyBonusEffects(activator, opponent, effectsToApply);
        ApplyFirstAttackBonusEffects(activator, opponent, effectsToApply);
        ApplyPenaltyBonus(activator, opponent, effectsToApply);
        ApplyFirstAttackPenaltyBonus(activator, opponent, effectsToApply);
        ApplyNeutralizationBonusEffect(activator, opponent, effectsToApply);
        ApplyNeutralizationPenaltyBonus(activator, opponent, effectsToApply);
    }
    private static void CollectElegibleEffectsFromActiveUnit(Unit activator, Unit opponent, Combat combat,
        List<(Unit, IEffect)> effectsToApply)
    {
        foreach (var skill in activator.Skills)
        {
            if (skill.Condition.IsConditionMet(combat, activator, opponent))
            {
                foreach (var effect in skill.Effect)
                {
                    effectsToApply.Add((activator, effect));
                }
            }
        }
    }
    private static void CollectElegibleEffectsFromOpponentUnit(Unit activator, Unit opponent, 
        Combat combat, List<(Unit, IEffect)> effectsToApply)
    {
        foreach (var skill in opponent.Skills)
        {
            if (skill.Condition.IsConditionMet(combat, opponent, activator))
            {
                foreach (var effect in skill.Effect)
                {
                    effectsToApply.Add((opponent, effect));
                }
            }
        }
    }
    private static void ApplyBonusEffects(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        foreach (var (unit, effect) in effectsToApply.Where(e => e.Item2 is IBonusEffect))
        {
            effect.ApplyEffect(unit, unit == activator ? opponent : activator);
        }
    }
        
    private static void ApplyFirstAttackBonusEffects(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        foreach (var (unit, effect) in effectsToApply.Where(e => e.Item2 is FirstAttackBonusEffect))
        {
            effect.ApplyEffect(unit, unit == activator ? opponent : activator);
        }
    }
    
    private static void ApplyPenaltyBonus(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        foreach (var (unit, effect) in effectsToApply.Where(e => e.Item2 is PenaltyEffect))
        {
            effect.ApplyEffect(unit, unit == activator ? opponent : activator);
        }
    }
    
    private static void ApplyFirstAttackPenaltyBonus(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        foreach (var (unit, effect) in effectsToApply.Where(e => e.Item2 is FirstAttackPenaltyEffect))
        {
            effect.ApplyEffect(unit, unit == activator ? opponent : activator);
        }
    }
    
    private static void ApplyNeutralizationBonusEffect(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        foreach (var (unit, effect) in effectsToApply.Where(e => e.Item2 is NeutralizationBonusEffect))
        {
            effect.ApplyEffect(unit, unit == activator ? opponent : activator);
        }
    }
    private static void ApplyNeutralizationPenaltyBonus(Unit activator, Unit opponent, List<(Unit, IEffect)> effectsToApply)
    {
        foreach (var (unit, effect) in effectsToApply.Where(e => e.Item2 is NeutralizationPenaltyEffect))
        {
            effect.ApplyEffect(unit, unit == activator ? opponent : activator);
        }
    }
    
    private void AnnounceEffects(Combat combat)
    {
        _gameView.AnnounceAttackerBonusStat(combat.Attacker);
        _gameView.AnnounceAttackerPenaltyStat(combat.Attacker);
        _gameView.AnnounceNeutralizationBonusEffect(combat.Attacker);
        _gameView.AnnounceNeutralizationPenaltyEffect(combat.Attacker);
        _gameView.AnnounceDefenderBonusEffects(combat.Defender);
        _gameView.AnnounceDefenderPenaltyEffects(combat.Defender);
        _gameView.AnnounceNeutralizationBonusEffect(combat.Defender);
        _gameView.AnnounceNeutralizationPenaltyEffect(combat.Defender);
    }
}