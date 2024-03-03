using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Social.Sport.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Sport.Infrastructure.Configurations
{
    public class UserConfiguration : BaseConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Username).IsRequired();
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ProfilePic);
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.salt).IsRequired(false);
            builder.Property(x => x.Role);
            builder.Property(x => x.DOB).IsRequired();
            builder.Property(x => x.phoneNumber).HasMaxLength(10);
            builder.Property(x => x.TeamId);
            builder.Property(x => x.isActive).HasConversion<string>();

            builder.HasMany(x => x.Teams)
                .WithMany(x => x.Users);

            base.Configure(builder);
        }
    }
}
