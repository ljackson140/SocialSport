using Social.Sport.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Social.Sport.Infrastructure.Configurations
{
    public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedBy);
            builder.Property(x => x.UpdatedBy);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.UpdatedDate);
        }
    }
}
