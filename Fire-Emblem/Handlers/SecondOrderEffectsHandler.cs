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
        return new List<Type>
        {
            typeof(IExtraDamageEffect),
            typeof(FirstAttackExtraDamageEffect),
            typeof(AbsoluteDamageReductionEffect),
            typeof(IPercentageDamageReductionEffect),
            typeof(FirstAttackPercentageDamageReductionEffect),
            typeof(FollowUpPercentageDamageReductionEffect),
            typeof(IHealingEffect),
            typeof(CounterattackDenialEffect),
            typeof(CounterattackDenialDenialEffect),
            typeof(DamageBeforeCombatEffect),
            typeof(FollowUpGuaranteeEffect)
        };
    }
}
