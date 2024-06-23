using Fire_Emblem.Effects;
using Fire_Emblem.Handlers;
using Fire_Emblem.Units;
using Fire_Emblem.Views;

namespace Fire_Emblem.Controllers;

public class SkillController
{
    private readonly ConsoleGameView _consoleGameView;
    private FirstOrderEffectsHandler? _firstOrderEffectsHandler;
    private SecondOrderEffectsHandler? _secondOrderEffectsHandler;

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
        ApplyFirstOrderEffects(activator, opponent);
        ApplySecondOrderEffects(activator, opponent);
    }
    
    private void ApplyFirstOrderEffects(Unit activator, Unit opponent)
    {
        List<(Unit, IEffect)> firstEffectsToApply = new List<(Unit, IEffect)>();
        _firstOrderEffectsHandler = new FirstOrderEffectsHandler(activator, opponent);
        _firstOrderEffectsHandler.CollectConditionMetEffects(firstEffectsToApply);
        _firstOrderEffectsHandler = new FirstOrderEffectsHandler(opponent, activator);
        _firstOrderEffectsHandler.CollectConditionMetEffects(firstEffectsToApply);
        _firstOrderEffectsHandler.ApplyEffectsInOrder(firstEffectsToApply);
    }
    
    private void ApplySecondOrderEffects(Unit activator, Unit opponent)
    {
        List<(Unit, IEffect)> secondEffectsToApply = new List<(Unit, IEffect)>();
        _secondOrderEffectsHandler = new SecondOrderEffectsHandler(activator, opponent);
        _secondOrderEffectsHandler.CollectConditionMetEffects(secondEffectsToApply);
        _secondOrderEffectsHandler = new SecondOrderEffectsHandler(opponent, activator);
        _secondOrderEffectsHandler.CollectConditionMetEffects(secondEffectsToApply);
        _secondOrderEffectsHandler.ApplyEffectsInOrder(secondEffectsToApply);
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
        _consoleGameView.AnnounceHealingEffect(combat.Attacker);
        _consoleGameView.AnnounceCounterattackDenialEffect(combat.Attacker);
        _consoleGameView.AnnounceCounterattackDenialDenialEffect(combat.Attacker);
        _consoleGameView.AnnounceDamageBeforeCombatEffect(combat.Attacker);
        _consoleGameView.AnnounceFollowUpGuarantee(combat.Attacker);
        _consoleGameView.AnnounceDenialFollowUp(combat.Attacker);
        _consoleGameView.AnnounceDenialFollowUpGuaranteed(combat.Attacker);
        _consoleGameView.AnnounceDenialOfDenialFollowUp(combat.Attacker);
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
        _consoleGameView.AnnounceHealingEffect(combat.Defender);
        _consoleGameView.AnnounceCounterattackDenialEffect(combat.Defender);
        _consoleGameView.AnnounceCounterattackDenialDenialEffect(combat.Defender);
        _consoleGameView.AnnounceDamageBeforeCombatEffect(combat.Defender);
        _consoleGameView.AnnounceFollowUpGuarantee(combat.Defender);
        _consoleGameView.AnnounceDenialFollowUp(combat.Defender);
        _consoleGameView.AnnounceDenialFollowUpGuaranteed(combat.Defender);
        _consoleGameView.AnnounceDenialOfDenialFollowUp(combat.Defender);
    }
    
    public void ActivateAfterCombatSkills(Unit attacker, Unit defender)
    {
        ApplyAfterCombatSkills(attacker, defender);
        AnnounceAfterCombatEffects(attacker, defender);
    }

    private void ApplyAfterCombatSkills(Unit activator, Unit opponent)
    {
        List<(Unit, IEffect)> afterCombatEffectsToApply = new List<(Unit, IEffect)>();
        AfterCombatEffectsHandler afterCombatEffectsHandler = new AfterCombatEffectsHandler(activator, opponent);
        afterCombatEffectsHandler.CollectConditionMetEffects(afterCombatEffectsToApply);
        afterCombatEffectsHandler = new AfterCombatEffectsHandler(opponent, activator);
        afterCombatEffectsHandler.CollectConditionMetEffects(afterCombatEffectsToApply);
        afterCombatEffectsHandler.ApplyEffectsInOrder(afterCombatEffectsToApply);
    }
    
    private void AnnounceAfterCombatEffects(Unit attacker, Unit defender)
    {
        AnnounceAttackerAfterCombatSkills(attacker);
        AnnounceDefenderAfterCombatSkills(defender);
    }

    private void AnnounceAttackerAfterCombatSkills(Unit attacker)
    {
        _consoleGameView.AnnounceDamageOutOfCombatEffect(attacker);
    }
    
    private void AnnounceDefenderAfterCombatSkills(Unit defender)
    {
        _consoleGameView.AnnounceDamageOutOfCombatEffect(defender);
    }
}
