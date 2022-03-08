namespace Server.Models;

public class Entry
{
    public long? Id { get; set; }
    public EntryType Type { get; set; }
    public DateTimeOffset DateTime { get; set; }
    public string Account { get; set; }
    public string? Description { get; set; }

    private const string DateTimePattern = "yyyy/MM/dd HH:mm:ss";

    public Entry(EntryType type, DateTimeOffset dateTime, string account)
    {
        Type = type;
        DateTime = dateTime;
        Account = account;
    }

    public Entry(EntryType type, DateTimeOffset dateTime, string account, string? description)
    {
        Type = type;
        DateTime = dateTime;
        Account = account;
        Description = description;
    }

    public override string ToString()
    {
        return $"{Type.ToFriendlyString()} {DateTime.ToString(DateTimePattern)} {Account}  {Description ?? ""}";
    }
}