using InnofoltDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InnofoltDataAccess;

public class InnofoltDbContext:DbContext
{
    public InnofoltDbContext(DbContextOptions<InnofoltDbContext> options):base(options)
    {
        
    }

    public DbSet<Event> Events { get; set; }
}
