using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pattern.Nanoservice.Domain;

namespace Pattern.Nanoservice.Infrastructure.EntityConfiguration
{
    public class CandidateSkillXrefEntityConfiguration : IEntityTypeConfiguration<CandidateSkillXref>
    {
        public void Configure(EntityTypeBuilder<CandidateSkillXref> builder)
        {
            builder.HasOne(x => x.Candidate)
                 .WithMany(m => m.CandidateSkillXrefs)
                 .HasForeignKey(f => f.CandidateId)
                 .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.Skill)
                .WithMany(m => m.CandidateSkillXrefs)
                .HasForeignKey(f => f.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.ToTable("CandidateSkillXref", "candidate");
        }
    }
}
