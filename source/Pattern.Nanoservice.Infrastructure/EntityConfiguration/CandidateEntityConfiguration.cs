using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pattern.Nanoservice.Domain;

namespace Pattern.Nanoservice.Infrastructure.EntityConfiguration
{
    public class CandidateEntityConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(50);

            builder.ToTable("Candidate", "candidate");
        }
    }
}
