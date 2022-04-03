using Microsoft.EntityFrameworkCore;
using MySpot.Application.Abstractions;
using MySpot.Application.DTO;
using MySpot.Application.Queries;

namespace MySpot.Infrastructure.DAL.Handlers;

internal sealed class GetUsersHandler : IQueryHandler<GetUsers, IEnumerable<UserDto>>
{
    private readonly MySpotDbContext _dbContext;

    public GetUsersHandler(MySpotDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<IEnumerable<UserDto>> HandleAsync(GetUsers query)
        => await _dbContext.Users
            .AsNoTracking()
            .Select(x => x.AsDto())
            .ToListAsync();
}