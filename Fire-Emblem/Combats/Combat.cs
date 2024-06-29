using Fire_Emblem.Units;

namespace Fire_Emblem;

public class Combat
{
    public Unit Attacker { get; }
    public Unit Defender { get;  }
    
    public Combat(Unit attacker, Unit defender)
    {
        Attacker = attacker;
        Defender = defender;
    }
    
}
