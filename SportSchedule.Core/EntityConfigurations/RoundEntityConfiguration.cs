using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSchedule.Core.Models;

namespace SportSchedule.Core.EntityConfigurations
{
    public class RoundEntityConfiguration : IEntityTypeConfiguration<Round>
    {
        public void Configure(EntityTypeBuilder<Round> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Games).WithOne(x => x.Round);
            builder.Property(x => x.Number).IsRequired();
        }
    }
}
