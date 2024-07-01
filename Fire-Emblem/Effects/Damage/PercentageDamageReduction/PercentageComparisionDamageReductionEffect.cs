using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.PercentageDamageReduction
{
    public class PercentageComparisionDamageReductionEffect : IPercentageDamageReductionEffect
    {
        private readonly EffectTarget _target;
        private readonly double _maxPercentage = 0.4;
        private readonly StatType _firstStat;
        private readonly StatType _secondStat;
        
        public PercentageComparisionDamageReductionEffect(StatType firstStat, StatType secondStat, EffectTarget target)
        {
            _target = target;
            _firstStat = firstStat;
            _secondStat = secondStat;
        }
        
        public void ApplyEffect(Unit activator, Unit opponent)
        {
            Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
            double percentageReduction = CalculatePercentageReduction(targetUnit, opponent);
            targetUnit.ApplyPercentageDamageReduction(percentageReduction);
            EffectCollection targetUnitEffects = targetUnit.Effects;
            targetUnitEffects.AddEffect(this);
        }

        private double CalculatePercentageReduction(Unit targetUnit, Unit opponent)
        {
            double firstStatValue = GetFirstStatValue(targetUnit);
            double secondStatValue = GetSecondStatValue(opponent);
            double statDifference = CalculateStatDifference(firstStatValue, secondStatValue);
            return CalculateFinalPercentageReduction(statDifference);
        }

        private double GetFirstStatValue(Unit targetUnit)
        {
            return targetUnit.GetCurrentStat(_firstStat);
        }

        private double GetSecondStatValue(Unit opponent)
        {
            return opponent.GetCurrentStat(_secondStat);
        }

        private double CalculateStatDifference(double firstStatValue, double secondStatValue)
        {
            return firstStatValue - secondStatValue;
        }

        private double CalculateFinalPercentageReduction(double statDifference)
        {
            double percentageReduction = statDifference * 0.04;

            if (percentageReduction > _maxPercentage)
                percentageReduction = _maxPercentage;
            else if (percentageReduction < 0)
                percentageReduction = 0;
            return percentageReduction;
        }
    }
}