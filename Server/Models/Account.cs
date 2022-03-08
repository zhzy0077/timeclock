namespace Server.Models;

public class Account
{
    public long Id { get; set; }
    public string Name { get; set; }

    public Account(string name)
    {
        Name = name;
    }
}