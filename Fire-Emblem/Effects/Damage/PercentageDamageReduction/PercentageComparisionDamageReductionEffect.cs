using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.PercentageDamageReduction
{
    public class PercentageComparisionDamageReductionEffect : IEffect, IPercentageDamageReductionEffect
    {
        private readonly EffectTarget Target;
        private readonly double _maxPercentage = 0.4;
        private readonly StatType _stat1;
        private readonly StatType _stat2;
        
        public PercentageComparisionDamageReductionEffect(StatType stat1, StatType stat2, EffectTarget target)
        {
            Target = target;
            _stat1 = stat1;
            _stat2 = stat2;
        }
        
        public void ApplyEffect(Unit activator, Unit opponent)
        {
            Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
            
            double stat1Value = GetStatValue(targetUnit, _stat1);
            double stat2Value = GetStatValue(opponent, _stat2);
            double statDifference = stat1Value - stat2Value;
            double percentageReduction = statDifference * 0.04;
            
            if (percentageReduction > _maxPercentage)
            {
                percentageReduction = _maxPercentage;
            }
            else if (percentageReduction < 0)
            {
                percentageReduction = 0;
            }
            
            targetUnit.ApplyPercentageDamageReductionEffect(percentageReduction);
            targetUnit.AddActiveEffect(this);
        }

        private double GetStatValue(Unit unit, StatType statType)
        {
            switch (statType)
            {
                case StatType.Res:
                    return unit.CurrentRes;
                case StatType.Spd:
                    return unit.CurrentSpd;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}