using Microsoft.EntityFrameworkCore;
using NetRes.Infrastructure.Models;

namespace NetRes.Infrastructure;

public class NetResDbContext : DbContext
{
    public NetResDbContext(DbContextOptions<NetResDbContext> options)
        : base(options) { }

    public DbSet<TestEntityDbModel> TestEntities { get; set; }
}
