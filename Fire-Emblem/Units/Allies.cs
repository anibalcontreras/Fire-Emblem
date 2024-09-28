namespace Fire_Emblem.Units;

public class Allies
{
    private readonly List<Unit> _allies = new();
    public IEnumerable<Unit> Items => _allies.AsReadOnly();
    
    public void AddAlly(Unit ally)
        => _allies.Add(ally);
    
    public void RemoveAllAlies()
        => _allies.Clear();
}