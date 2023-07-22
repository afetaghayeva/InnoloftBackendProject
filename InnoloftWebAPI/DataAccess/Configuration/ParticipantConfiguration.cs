using InnoloftWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnoloftWebAPI.DataAccess.Configuration;

public class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
{
    public void Configure(EntityTypeBuilder<Participant> builder)
    {
        builder.ToTable("Participants");

        builder.HasKey(e => e.Id);
        builder.HasOne(e => e.Event).WithMany(e => e.Participants);
    }
}
