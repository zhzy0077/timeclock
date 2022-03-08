namespace Server.Models;

public enum EntryType
{
    In,
    Out,
}

public static class EntryTypeExtensions
{
    public static string ToFriendlyString(this EntryType type)
    {
        return type switch
        {
            EntryType.In => "i",
            EntryType.Out => "o",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}