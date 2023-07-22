using InnoloftWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnoloftWebAPI.DataAccess.Configuration;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int");
        builder.Property(x => x.UserId).HasColumnName("UserId").HasColumnType("int");
        builder.Property(x => x.EventName).HasColumnName("EventName").HasColumnType("nvarchar(250)");
        builder.Property(x => x.Title).HasColumnName("Title").HasColumnType("nvarchar(250)");
        builder.Property(x => x.Description).HasColumnName("Description").HasColumnType("nvarchar(250)");
        builder.Property(x => x.TimeZoneId).HasColumnName("TimeZoneId").HasColumnType("nvarchar(250)");
    }
}
