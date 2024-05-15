// using Fire_Emblem.Units;
//
// namespace Fire_Emblem.Effects.Damage.AbsoluteDamageReduction;
//
// public class AbsolutePercentageDamageReductionEffect : IEffect, IAbsoluteDamageReductionEffect
// {
//     private readonly double _percentage;
//     
//     private EffectTarget Target { get; }
//     
//     public AbsolutePercentageDamageReductionEffect(double percentage, EffectTarget target)
//     {
//         _percentage = percentage;
//         Target = target;
//     }
//     
//     public void ApplyEffect(Unit activator, Unit opponent)
//     {
//         Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
//         int reductionAmount = (int)(targetUnit.CurrentHP * _percentage);
//         targetUnit.ApplyAbsoluteDamageReductionEffect(reductionAmount);
//         targetUnit.AddActiveEffect(this);
//     }
// }