﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pattern.Nanoservice.Domain;

namespace Pattern.Nanoservice.Infrastructure.EntityConfiguration
{
    public class CandidateContactConfiguration : IEntityTypeConfiguration<CandidateContact>
    {
        public void Configure(EntityTypeBuilder<CandidateContact> builder)
        {
            builder.Property(x => x.Email).HasMaxLength(300)
                .IsRequired();

            builder.Property(x => x.Mobile).HasMaxLength(30)
                .IsRequired();

            builder.HasOne(x => x.Candidate)
           .WithMany(x => x.CandidateContacts)
           .HasForeignKey(x => x.CandidateId)
           .OnDelete(DeleteBehavior.ClientSetNull)
           .HasConstraintName("Candidate_FK_CandidateContact_CandidateId");

            builder.ToTable("CandidateContacts", "candidate");
        }
    }
}
