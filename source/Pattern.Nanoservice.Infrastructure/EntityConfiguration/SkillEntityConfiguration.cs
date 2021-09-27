using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pattern.Nanoservice.Domain;


namespace Pattern.Nanoservice.Infrastructure.EntityConfiguration
{
    public class SkillEntityConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.Property(p => p.SkillName).HasColumnType("varchar(100)")
                .IsRequired();

            builder.ToTable("Skills", "candidate");
        }
    }
}
