using InnoloftWebAPI.DataAccess.Configuration;
using InnoloftWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace InnofoltDataAccess;

public class InnofoltDbContext:DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Participant> Participants { get; set; }

    public InnofoltDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EventConfiguration());
        modelBuilder.ApplyConfiguration(new ParticipantConfiguration());
    }
}
