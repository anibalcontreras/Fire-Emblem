using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects
{
    public class PerceptiveEffect : IEffect, IBonusEffect
    {
        private readonly int _baseSpdIncrease = 12;
        private readonly int _spdIncrementFactor = 4;

        public StatType StatType => StatType.Spd;
        public int? Amount { get; private set; }
        public EffectTarget Target { get; private set; }

        public PerceptiveEffect(EffectTarget target)
        {
            Target = target;
        }

        public void ApplyEffect(Unit activator, Unit opponent)
        {
            Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;

            // Calcular el bono base de velocidad
            int spdBonus = _baseSpdIncrease;

            // Calcular el bono adicional basado en la velocidad sin bonos/penalizaciones
            int baseSpd = targetUnit.GetBaseStat(StatType.Spd);
            int additionalBonus = baseSpd / _spdIncrementFactor;

            // Sumar ambos bonos para obtener el total
            spdBonus += additionalBonus;

            // Aplicar el bono de velocidad al objetivo
            targetUnit.ApplyStatBonusEffect(StatType.Spd, spdBonus);
            targetUnit.AddActiveEffect(this);

            // Guardar el monto para referencia futura
            Amount = spdBonus;
        }
    }
}