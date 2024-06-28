using Fire_Emblem.Effects;
using Fire_Emblem.Handlers;
using Fire_Emblem.Units;
using Fire_Emblem.Views;

namespace Fire_Emblem.Controllers;

public class SkillController
{
    private readonly IView _view;
    private FirstOrderEffectsHandler? _firstOrderEffectsHandler;
    private SecondOrderEffectsHandler? _secondOrderEffectsHandler;

    public SkillController(IView view)
    {
        _view = view;
    }

    public void ActivateSkills(Combat combat)
    {
        ApplySkills(combat.Attacker, combat.Defender);
        AnnounceEffects(combat);
        AnnounceBeforeCombatEffects(combat);
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
        _view.AnnounceAttackerBonusEffect(combat.Attacker);
        _view.AnnounceAttackerPenaltyEffect(combat.Attacker);
        _view.AnnounceNeutralizationBonusEffect(combat.Attacker);
        _view.AnnounceNeutralizationPenaltyEffect(combat.Attacker);
        _view.AnnounceExtraDamage(combat.Attacker);
        _view.AnnouncePercentageReductionEffect(combat.Attacker);
        _view.AnnounceAbsoluteDamageReduction(combat.Attacker);
        _view.AnnounceHealingEffect(combat.Attacker);
        _view.AnnounceCounterattackDenialEffect(combat.Attacker);
        _view.AnnounceCounterattackDenialDenialEffect(combat.Attacker);
        _view.AnnounceFollowUpGuarantee(combat.Attacker);
        _view.AnnounceDenialFollowUp(combat.Attacker);
        _view.AnnounceDenialOfDenialFollowUp(combat.Attacker);
        _view.AnnounceDenialFollowUpGuaranteed(combat.Attacker);
    }

    private void AnnounceDefenderSkills(Combat combat)
    {
        _view.AnnounceDefenderBonusEffect(combat.Defender);
        _view.AnnounceDefenderPenaltyEffect(combat.Defender);
        _view.AnnounceNeutralizationBonusEffect(combat.Defender);
        _view.AnnounceNeutralizationPenaltyEffect(combat.Defender);
        _view.AnnounceExtraDamage(combat.Defender);
        _view.AnnouncePercentageReductionEffect(combat.Defender);
        _view.AnnounceAbsoluteDamageReduction(combat.Defender);
        _view.AnnounceHealingEffect(combat.Defender);
        _view.AnnounceCounterattackDenialEffect(combat.Defender);
        _view.AnnounceCounterattackDenialDenialEffect(combat.Defender);
        _view.AnnounceFollowUpGuarantee(combat.Defender);
        _view.AnnounceDenialFollowUp(combat.Defender);
        _view.AnnounceDenialOfDenialFollowUp(combat.Defender);
        _view.AnnounceDenialFollowUpGuaranteed(combat.Defender);
    }
    
    private void AnnounceBeforeCombatEffects(Combat combat)
    {
        AnnounceAttackerBeforeCombatSkills(combat.Attacker);
        AnnounceDefenderBeforeCombatSkills(combat.Defender);
    }
    
    private void AnnounceAttackerBeforeCombatSkills(Unit attacker)
    {
        _view.AnnounceDamageBeforeCombatEffect(attacker);
    }
    
    private void AnnounceDefenderBeforeCombatSkills(Unit defender)
    {
        _view.AnnounceDamageBeforeCombatEffect(defender);
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
        _view.AnnounceDamageOutOfCombatEffect(attacker);
    }
    
    private void AnnounceDefenderAfterCombatSkills(Unit defender)
    {
        _view.AnnounceDamageOutOfCombatEffect(defender);
    }
}
