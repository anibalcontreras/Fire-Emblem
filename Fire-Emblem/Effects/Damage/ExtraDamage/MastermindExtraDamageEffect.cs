using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.ExtraDamage;

public class MastermindExtraDamageEffect : IExtraDamageEffect
{
    private readonly double _xPercentage = 0.8;
    private readonly double _yPercentage = 0.8;
    private EffectTarget _target { get; }
    
    public MastermindExtraDamageEffect(EffectTarget target)
    {
        _target = target;
    }

    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = GetTargetUnit(activator, opponent);
        int unitTotalBonus = CalculateUnitTotalBonus(targetUnit);
        int opponentTotalPenalty = CalculateOpponentTotalPenalty(opponent);
        int extraDamage = CalculateExtraDamage(unitTotalBonus, opponentTotalPenalty);
        ApplyExtraDamage(targetUnit, extraDamage);
        AddEffectToTargetUnit(targetUnit);
    }

    private Unit GetTargetUnit(Unit activator, Unit opponent)
    {
        return _target == EffectTarget.Unit ? activator : opponent;
    }

    private int CalculateUnitTotalBonus(Unit unit)
    {
        return unit.AtkBonus + unit.SpdBonus + unit.DefBonus + unit.ResBonus
               - unit.AtkBonusNeutralization - unit.SpdBonusNeutralization
               - unit.DefBonusNeutralization - unit.ResBonusNeutralization;
        
    }

    private int CalculateOpponentTotalPenalty(Unit opponent)
    {
        return opponent.AtkPenalty + opponent.SpdPenalty + opponent.DefPenalty + opponent.ResPenalty
               - opponent.AtkPenaltyNeutralization - opponent.SpdPenaltyNeutralization
               - opponent.DefPenaltyNeutralization - opponent.ResPenaltyNeutralization;
    }

    private int CalculateExtraDamage(int unitTotalBonus, int opponentTotalPenalty)
    {
        int x = (int)(unitTotalBonus * _xPercentage);
        int y = (int)(opponentTotalPenalty * _yPercentage);
        return x + y;
    }

    private void ApplyExtraDamage(Unit targetUnit, int extraDamage)
    {
        targetUnit.ApplyExtraDamageEffect(extraDamage);
    }

    private void AddEffectToTargetUnit(Unit targetUnit)
    {
        EffectCollection targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}