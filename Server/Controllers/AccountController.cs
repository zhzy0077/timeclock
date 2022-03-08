using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Controllers;

[Route("[controller]")]
[ApiController]
public class AccountController
{
    private readonly TimeClockContext _context;

    public AccountController(TimeClockContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IAsyncEnumerable<Account> GetAccounts()
    {
        return _context.Accounts!.AsAsyncEnumerable();
    }

    [HttpPost]
    public async Task<Account> Insert([FromForm] string name)
    {
        var account = new Account(name);
        _context.Accounts!.Add(account);
        await _context.SaveChangesAsync().ConfigureAwait(false);

        return account;
    }
    
    
    [HttpPost("delete")]
    public async Task<Account> Delete([FromForm] string name)
    {
        var account = await _context.Accounts!.Where(account => account.Name.Equals(name)).FirstAsync();
        _context.Remove(account);
        await _context.SaveChangesAsync().ConfigureAwait(false);

        return account;
    }
    
}