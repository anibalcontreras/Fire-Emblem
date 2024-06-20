using Fire_Emblem.Effects;
using Fire_Emblem.Effects.Damage.DamageOutOfCombat;
using Fire_Emblem.Effects.Healing;
using Fire_Emblem.Units;

namespace Fire_Emblem.Handlers;

public class AfterCombatEffectsHandler : EffectsHandler
{
    public AfterCombatEffectsHandler(Unit activator, Unit opponent) : base(activator, opponent) { }
    
    protected override bool ShouldProcessEffect(ConditionalEffect conditionalEffect)
    {
        return EffectUtils.IsAfterCombatEffect(conditionalEffect);
    }
    
    protected override IEnumerable<Type> GetEffectTypesInOrder()
    {
        return new List<Type>
        {
            typeof(DamageAfterCombatEffect),
            typeof(AfterCombatAbsoluteHealingEffect)
        };
    }
}
