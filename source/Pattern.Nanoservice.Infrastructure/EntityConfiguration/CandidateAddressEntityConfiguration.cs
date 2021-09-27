using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pattern.Nanoservice.Domain;

namespace Pattern.Nanoservice.Infrastructure.EntityConfiguration
{
    public class CandidateAddressEntityConfiguration : IEntityTypeConfiguration<CandidateAddress>
    {
        public void Configure(EntityTypeBuilder<CandidateAddress> builder)
        {
            builder.Property(p => p.CityName).HasColumnType("varchar(100)");
            builder.Property(p => p.StateName).HasColumnType("varchar(100)");
            builder.Property(p => p.PinCode).HasColumnType("varchar(10)")
                .IsRequired();

            builder.HasOne(o => o.Candidate)
                .WithOne(o => o.CandidateAddress)
                .HasForeignKey<CandidateAddress>(x => x.CandidateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Candidate_FK_CandidateAddress_CandidateID");

            builder.ToTable("CandidateAddress", "candidate");

        }
    }
}
