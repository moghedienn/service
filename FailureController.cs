using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service;

[ApiController]
[Route("api/failures")]
public class FailureController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public FailureController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterFailure(Failure failure)
    {
        _dbContext.Failures.Add(failure);
        await _dbContext.SaveChangesAsync();

        return Ok();
    }
    [HttpGet("period")]
    public async Task<IActionResult> GetFailuresByPeriod(DateTime startDate, DateTime endDate)
    {
        var failures = await _dbContext.Failures
            .Where(f => f.Timestamp >= startDate && f.Timestamp <= endDate)
            .ToListAsync();

        return Ok(failures);
    }

    [HttpPost("status")]
    public async Task<IActionResult> UpdateFailureStatus(int id, string newStatus)
    {
        var failure = await _dbContext.Failures.FindAsync(id);
        if (failure == null)
            return NotFound();

        failure.Status = newStatus;
        await _dbContext.SaveChangesAsync();

        return Ok(failure);
    }
}

