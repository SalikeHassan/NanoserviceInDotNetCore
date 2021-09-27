﻿using Pattern.Nanoservice.Domain.BaseEntity;
using System.Collections.Generic;

namespace Pattern.Nanoservice.Domain
{
    public class Candidate : Entity
    {
        public Candidate()
        {
            this.CandidateContacts = new HashSet<CandidateContact>();
            this.CandidateSkillXrefs = new HashSet<CandidateSkillXref>();
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<CandidateContact> CandidateContacts { get; set; }

        public virtual CandidateAddress CandidateAddress { get; set; }

        public virtual ICollection<CandidateSkillXref> CandidateSkillXrefs { get; set; }
    }
}
