using Fire_Emblem.Effects;
using Fire_Emblem.Effects.CounterattackDenial;
using Fire_Emblem.Effects.Damage.AbsoluteDamageReduction;
using Fire_Emblem.Effects.Damage.DamageOutOfCombat;
using Fire_Emblem.Effects.Damage.ExtraDamage;
using Fire_Emblem.Effects.Damage.PercentageDamageReduction;
using Fire_Emblem.Effects.FollowUp;
using Fire_Emblem.Effects.Healing;
using Fire_Emblem.Units;

namespace Fire_Emblem.Handlers;
public class SecondOrderEffectsHandler : EffectsHandler
{
    public SecondOrderEffectsHandler(Unit activator, Unit opponent) : base(activator, opponent) { }

    protected override bool ShouldProcessEffect(ConditionalEffect conditionalEffect)
    {
        return !EffectUtils.IsFirstOrderEffect(conditionalEffect);
    }

    protected override IEnumerable<Type> GetEffectTypesInOrder()
    {
        // TODO: Esta lista es clave
        return new List<Type>
        {
            typeof(IExtraDamageEffect),
            typeof(FirstAttackExtraDamageEffect),
            typeof(IAbsoluteDamageReductionEffect),
            typeof(IPercentageDamageReductionEffect),
            typeof(IFirstAttackPercentageDamageReductionEffect),
            typeof(IFollowUpPercentageDamageReductionEffect),
            typeof(IHealingEffect),
            typeof(CounterattackDenialEffect),
            typeof(CounterattackDenialDenialEffect),
            typeof(FollowUpGuaranteeEffect),
            typeof(DenialFollowUpEffect),
            typeof(DenialFollowUpGuaranteeEffect),
            typeof(DenialOfDenialFollowUpEffect),
            typeof(IDamageBeforeCombatEffect),
        };
    }
}
