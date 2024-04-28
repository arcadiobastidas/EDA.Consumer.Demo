using EDA.Consumer.Demo.Application.Common.Interfaces;
using EDA.Consumer.Demo.Infrastructure.Common.Persistence;
using Microsoft.Extensions.Logging;

namespace EDA.Consumer.Demo.Infrastructure.Checks.Persistence;

public class CheckRepository : ICheckRepository
{
    private readonly EdaDemoDbContext _context;
    private readonly ILogger<CheckRepository> _logger;
    
    public CheckRepository(EdaDemoDbContext context, ILogger<CheckRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public Task GenerateCheckAsync(Guid id)
    {
        var check = _context.Checks.Find(id);
        check!.Generate();
        return Task.CompletedTask;
    }
  
}