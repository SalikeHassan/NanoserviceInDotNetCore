using System.Collections.Generic;

namespace Pattern.Nanoservice.Contract.Dtos.Response
{
    public class CandidateDetailsResponse
    {
        public CandidateDetailsResponse()
        {
            this.CandidateContactResponses = new List<CandidateContactResponse>();
            this.CandidateSkills = new List<CandidateSkill>();
        }

        public string FirstName { get; set; }

        public string CityName { get; set; }

        public IList<CandidateContactResponse> CandidateContactResponses { get; set; }

        public IList<CandidateSkill> CandidateSkills { get; set; }
    }

    public class CandidateContactResponse
    {
        public string Email { get; set; }
    }

    public class CandidateSkill
    {
        public string SkillName { get; set; }
    }
}
