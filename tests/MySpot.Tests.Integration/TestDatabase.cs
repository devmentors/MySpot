using System;
using Microsoft.EntityFrameworkCore;
using MySpot.Infrastructure.DAL;

namespace MySpot.Tests.Integration;

internal sealed class TestDatabase : IDisposable
{
    public MySpotDbContext Context { get; }

    public TestDatabase()
    {
        var options = new OptionsProvider().Get<PostgresOptions>("postgres");
        Context = new MySpotDbContext(new DbContextOptionsBuilder<MySpotDbContext>().UseNpgsql(options.ConnectionString).Options);
    }

    public void Dispose()
    {
        Context.Database.EnsureDeleted();
        Context.Dispose();
    }
}