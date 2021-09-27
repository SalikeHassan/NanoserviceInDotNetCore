using Pattern.Nanoservice.Domain.BaseEntity;

namespace Pattern.Nanoservice.Domain
{
    public class CandidateAddress : Entity
    {
        public string CityName { get; set; }

        public string StateName { get; set; }

        public string PinCode { get; set; }

        public int CandidateId { get; set; }

        public virtual Candidate Candidate { get; set; }
    }
}
