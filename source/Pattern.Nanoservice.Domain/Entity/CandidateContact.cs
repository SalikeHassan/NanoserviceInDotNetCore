using Pattern.Nanoservice.Domain.BaseEntity;

namespace Pattern.Nanoservice.Domain
{
    public class CandidateContact : Entity
    {
        public string Email { get; set; }

        public string Mobile { get; set; }

        public int CandidateId { get; set; }

        public virtual Candidate Candidate { get; set; }
    }
}
