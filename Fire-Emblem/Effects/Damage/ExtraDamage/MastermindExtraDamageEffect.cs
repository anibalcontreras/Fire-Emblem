using Fire_Emblem.Stats;
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
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;

        int unitTotalBonus = targetUnit.AtkBonus + targetUnit.SpdBonus + targetUnit.DefBonus + targetUnit.ResBonus -
                             targetUnit.AtkBonusNeutralization - targetUnit.SpdBonusNeutralization -
                             targetUnit.DefBonusNeutralization - targetUnit.ResBonusNeutralization;
        int opponentTotalPenalty = opponent.AtkPenalty + opponent.SpdPenalty + opponent.DefPenalty + opponent.ResPenalty -
                                   opponent.AtkPenaltyNeutralization - opponent.SpdPenaltyNeutralization -
                                   opponent.DefPenaltyNeutralization - opponent.ResPenaltyNeutralization;
        int x = (int)(unitTotalBonus * _xPercentage);
        int y = (int)(opponentTotalPenalty * _yPercentage);
        int extraDamage = x + y;
        targetUnit.ApplyExtraDamageEffect(extraDamage);
        targetUnit.AddActiveEffect(this);
    }
}