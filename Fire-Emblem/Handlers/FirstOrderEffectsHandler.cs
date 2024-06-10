using Fire_Emblem.Effects;
using Fire_Emblem.Effects.AlterBaseStat;
using Fire_Emblem.Effects.CounterattackDenial;
using Fire_Emblem.Effects.Neutralization;
using Fire_Emblem.Units;

namespace Fire_Emblem.Handlers;
public class FirstOrderEffectsHandler : EffectsHandler
{
    public FirstOrderEffectsHandler(Unit activator, Unit opponent) : base(activator, opponent) { }

    protected override bool ShouldProcessEffect(ConditionalEffect conditionalEffect)
    {
        return EffectUtils.IsFirstOrderEffect(conditionalEffect);
    }

    protected override IEnumerable<Type> GetEffectTypesInOrder()
    {
        return new List<Type>
        {
            typeof(AlterBaseStatEffect),
            typeof(IBonusEffect),
            typeof(FirstAttackBonusEffect),
            typeof(IPenaltyEffect),
            typeof(FirstAttackPenaltyEffect),
            typeof(NeutralizationBonusEffect),
            typeof(NeutralizationPenaltyEffect),
        };
    }
}