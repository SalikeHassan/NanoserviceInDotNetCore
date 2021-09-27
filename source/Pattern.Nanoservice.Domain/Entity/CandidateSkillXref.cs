using Pattern.Nanoservice.Domain.BaseEntity;

namespace Pattern.Nanoservice.Domain
{
    public class CandidateSkillXref : Entity
    {
        public int CandidateId { get; set; }
        public int SkillId { get; set; }
        public virtual Candidate Candidate { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
