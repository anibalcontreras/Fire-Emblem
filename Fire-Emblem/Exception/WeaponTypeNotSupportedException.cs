namespace Fire_Emblem.Exception;

public class WeaponTypeNotSupportedException : ApplicationException
{
    private static readonly string _defaultMessage = "Weapon type not supported.";
    
    public WeaponTypeNotSupportedException() : base(_defaultMessage) {}
}
