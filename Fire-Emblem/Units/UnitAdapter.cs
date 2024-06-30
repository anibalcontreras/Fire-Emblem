using Fire_Emblem_GUI;
using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Units;

public class UnitAdapter : IUnit
{
    private readonly Unit _unit;

    public UnitAdapter(Unit unit)
    {
        _unit = unit;
    }

    public string Name => _unit.Name;
    public string Weapon => _unit.Weapon.Name;
    public int Hp => _unit.CurrentHP;
    public int Atk => _unit.GetCurrentStat(StatType.Atk);
    public int Spd => _unit.GetCurrentStat(StatType.Spd);
    public int Def => _unit.GetCurrentStat(StatType.Def);
    public int Res => _unit.GetCurrentStat(StatType.Res);
    public string[] Skills => _unit.Skills.Items.Select(s => s.Name).ToArray();
}