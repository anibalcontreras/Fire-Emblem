using Fire_Emblem.Effects.Bonus;
using Fire_Emblem.Handlers;
using Fire_Emblem.Units;
using Fire_Emblem.Views;

namespace Fire_Emblem.Controllers;

public class SkillController
{
    private readonly ConsoleGameView _consoleGameView;
    private readonly FirstOrderEffectsHandler _firstOrderEffectsHandler;
    private readonly SecondOrderEffectsHandler _secondOrderEffectsHandler;

    public SkillController(ConsoleGameView consoleGameView)
    {
        _consoleGameView = consoleGameView;
        _firstOrderEffectsHandler = new FirstOrderEffectsHandler();
        _secondOrderEffectsHandler = new SecondOrderEffectsHandler();
    }

    public void ActivateSkills(Combat combat)
    {
        ApplySkills(combat.Attacker, combat.Defender);
        AnnounceEffects(combat);
    }

    private void ApplySkills(Unit activator, Unit opponent)
    {
        ApplyFirstOrderEffects(activator, opponent);
        ApplySecondOrderEffects(activator, opponent);
    }
    
    private void ApplyFirstOrderEffects(Unit activator, Unit opponent)
    {
        List<(Unit, IEffect)> firstEffectsToApply = new List<(Unit, IEffect)>();
        _firstOrderEffectsHandler.CollectConditionMetEffects(activator, opponent, firstEffectsToApply);
        _firstOrderEffectsHandler.CollectConditionMetEffects(opponent, activator, firstEffectsToApply);
        _firstOrderEffectsHandler.ApplyEffectsInOrder(activator, opponent, firstEffectsToApply);
    }
    
    private void ApplySecondOrderEffects(Unit activator, Unit opponent)
    {
        List<(Unit, IEffect)> secondEffectsToApply = new List<(Unit, IEffect)>();
        _secondOrderEffectsHandler.CollectConditionMetEffects(activator, opponent, secondEffectsToApply);
        _secondOrderEffectsHandler.CollectConditionMetEffects(opponent, activator, secondEffectsToApply);
        _secondOrderEffectsHandler.ApplyEffectsInOrder(activator, opponent, secondEffectsToApply);
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