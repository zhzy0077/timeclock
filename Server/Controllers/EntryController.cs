using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class EntryController : ControllerBase
{
    private readonly TimeClockContext _context;

    public EntryController(TimeClockContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<string> GetEntries()
    {
        var entries = await _context.Entries!.ToListAsync();
        return entries
            .Select(entry => entry.ToString())
            .Aggregate(string.Empty, (left, right) => $"{left}\n{right}");
    }

    [HttpPost]
    public async Task<Entry> Insert([FromForm] string account, [FromForm] string? description)
    {
        var lastEntry = await _context.Entries!.OrderByDescending(e => e.Id).AsNoTracking().FirstOrDefaultAsync().ConfigureAwait(false);
        if (lastEntry != null)
        {
            lastEntry.Id = null;
            lastEntry.Type = EntryType.Out;
            lastEntry.DateTime = DateTimeOffset.Now;
            _context.Entries!.Add(lastEntry);
        }

        var entry = new Entry(EntryType.In, DateTimeOffset.Now, account, description);
        _context.Entries!.Add(entry);
        await _context.SaveChangesAsync().ConfigureAwait(false);

        return entry;
    }
}