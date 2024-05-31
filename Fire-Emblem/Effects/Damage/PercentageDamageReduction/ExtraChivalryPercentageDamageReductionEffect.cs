using Fire_Emblem.Effects.Bonus;
using Fire_Emblem.Effects.Damage.PercentageDamageReduction;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.ExtraChivalryPercentageDamageReduction
{
    public class ExtraChivalryPercentageDamageReductionEffect : IEffect, IPercentageDamageReductionEffect
    {
        private readonly double _percentage;
        private readonly EffectTarget _target;
        
        public ExtraChivalryPercentageDamageReductionEffect(double percentage, EffectTarget target)
        {
            _percentage = percentage;
            _target = target;
        }
        
        public void ApplyEffect(Unit activator, Unit opponent)
        {
            Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
            double opponentHpFraction = (double)opponent.CurrentHP / opponent.BaseHp;
            double truncatedHpFraction = Math.Truncate(opponentHpFraction * 100) / 100;
            double damageReductionPercentage = truncatedHpFraction * 0.5;
            double truncatedDamageReductionPercentage = Math.Truncate(damageReductionPercentage * 100) / 100;
            targetUnit.ApplyPercentageDamageReduction(truncatedDamageReductionPercentage);
            targetUnit.AddActiveEffect(this);
        }
    }
}