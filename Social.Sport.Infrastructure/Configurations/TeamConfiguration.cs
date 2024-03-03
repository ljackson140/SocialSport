using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Social.Sport.Core.Entities;


namespace Social.Sport.Infrastructure.Configurations
{
    public class TeamConfiguration : BaseConfiguration<Team>
    {
        public override void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(x => x.TeamName).IsRequired();
            builder.Property(x => x.TeamDescription).IsRequired();
            builder.Property(x => x.TeamCaptain).IsRequired();
            builder.Property(x => x.TeamMax).HasMaxLength(100);

            builder.HasMany(x => x.Users)
               .WithMany(x => x.Teams);

            base.Configure(builder);
        }
    }
}
