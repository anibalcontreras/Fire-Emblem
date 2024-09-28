namespace Fire_Emblem;

public class CombatCollection
{
    private readonly List<Combat> _combats;

    public CombatCollection()
    {
        _combats = new List<Combat>();
    }
    
    public List<Combat> GetCombats()
    {
        return new List<Combat>(_combats);
    }
}