// using Fire_Emblem.UnitManagment;
//
// namespace Fire_Emblem.Effect;
//
// public class BonusEffectToBoth : IEffect
// {
//     private IEffect _effectForInitiator;
//     private IEffect _effectForOpponent;
//
//     public ApplyEffectToBoth(IEffect effectForInitiator, IEffect effectForOpponent)
//     {
//         _effectForInitiator = effectForInitiator;
//         _effectForOpponent = effectForOpponent;
//     }
//
//     public void ApplyEffect(GameView view, Unit initiator, Unit opponent)
//     {
//         _effectForInitiator.ApplyEffect(view, initiator);
//         _effectForOpponent.ApplyEffect(view, opponent);
//     }
//
//     public void RevertEffect(GameView view, Unit initiator, Unit opponent)
//     {
//         _effectForInitiator.RevertEffect(view, initiator);
//         _effectForOpponent.RevertEffect(view, opponent);
//     }
//
//     public IEffect Clone()
//     {
//         return new BonusEffectToBoth(_effectForInitiator.Clone(), _effectForOpponent.Clone());
//     }
// }