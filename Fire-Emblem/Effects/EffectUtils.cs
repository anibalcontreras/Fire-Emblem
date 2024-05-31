using Fire_Emblem.Effects.AlterBaseStat;
using Fire_Emblem.Effects.Neutralization;

namespace Fire_Emblem.Effects;

public static class EffectUtils
{
    public static bool IsFirstOrderEffect(ConditionalEffect effect)
    {
        return effect.Effect is AlterBaseStatEffect
               || effect.Effect is IBonusEffect
               || effect.Effect is FirstAttackBonusEffect
               || effect.Effect is IPenaltyEffect
               || effect.Effect is FirstAttackPenaltyEffect
               || effect.Effect is NeutralizationBonusEffect
               || effect.Effect is NeutralizationPenaltyEffect;
    }
}
