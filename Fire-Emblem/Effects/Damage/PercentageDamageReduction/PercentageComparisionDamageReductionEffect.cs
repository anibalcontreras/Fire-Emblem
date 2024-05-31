using Fire_Emblem.Combats.Stats;
using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Effects.Damage.PercentageDamageReduction
{
    public class PercentageComparisionDamageReductionEffect : IPercentageDamageReductionEffect
    {
        private readonly EffectTarget Target;
        private readonly double _maxPercentage = 0.4;
        private readonly StatType _firstStat;
        private readonly StatType _secondStat;
        
        public PercentageComparisionDamageReductionEffect(StatType firstStat, StatType secondStat, EffectTarget target)
        {
            Target = target;
            _firstStat = firstStat;
            _secondStat = secondStat;
        }
        
        public void ApplyEffect(Unit activator, Unit opponent)
        {
            Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
            double firstStatValue = targetUnit.GetCurrentStat(_firstStat);
            double secondStatValue = opponent.GetCurrentStat(_secondStat);
            double statDifference = firstStatValue - secondStatValue;
            double percentageReduction = statDifference * 0.04;
            if (percentageReduction > _maxPercentage)
                percentageReduction = _maxPercentage;
            else if (percentageReduction < 0)
                percentageReduction = 0;
            targetUnit.ApplyPercentageDamageReductionEffect(percentageReduction);
            targetUnit.AddActiveEffect(this);
        }
    }
}