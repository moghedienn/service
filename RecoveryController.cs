using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service;

[ApiController]
[Route("api/recoveries")]
public class RecoveryController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public RecoveryController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterRecovery(Recovery recovery)
    {
        _dbContext.Recoveries.Add(recovery);
        await _dbContext.SaveChangesAsync();

        return Ok();
    }
    [HttpGet("period")]
    public async Task<IActionResult> GetRecoveriesByPeriod(DateTime startDate, DateTime endDate)
    {
        var recoveries = await _dbContext.Recoveries
            .Where(r => r.Timestamp >= startDate && r.Timestamp <= endDate)
            .ToListAsync();

        return Ok(recoveries);
    }

    [HttpPost("status")]
    public async Task<IActionResult> UpdateRecoveryStatus(int id, string newStatus)
    {
        var recovery = await _dbContext.Recoveries.FindAsync(id);
        if (recovery == null)
            return NotFound();

        recovery.Status = newStatus;
        await _dbContext.SaveChangesAsync();

        return Ok(recovery);
    }
}