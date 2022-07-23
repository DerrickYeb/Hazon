using Core.Application.Repositories;

namespace Core.Application.Abstractions.Services.General
{
    public interface IAuditService : IScopedService
    {
        // Task<IResult<IEnumerable<AuditResponse>>> GetUserTrailsAsync(Guid userId);
    }
}