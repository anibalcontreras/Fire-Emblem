using Fire_Emblem.Exceptions;
using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Effect.Neutralization;

public class NeutralizeBonusEffect : IEffect, INeutralizationEffect
{
    public void MarkNeutralization(GameView view, Unit activator, Unit opponent)
    {
        throw new BonusNeutralizationException("The bonus of the rival will be neutralized");
    }
 
    public void RevertNeutralization(GameView view, Unit activator, Unit opponent)
    {
        
    }
    
    public void ApplyEffect(GameView view, Unit activator, Unit opponent)
    {
        MarkNeutralization(view, activator, opponent);
        // view.AnnounceBonusNeutralization("Stat", opponent.Name);
    }
    
    public void RevertEffect(GameView view, Unit activator, Unit opponent)
    {
        RevertNeutralization(view, activator, opponent);
    }

    public IEffect Clone()
    {
        return new NeutralizeBonusEffect();
    }
}