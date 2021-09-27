using MediatR;
using Pattern.Nanoservice.Contract.Dtos.Request;
using Pattern.Nanoservice.Domain;
using Pattern.Nanoservice.Infrastructure.Context;
using System.Threading;
using System.Threading.Tasks;

namespace Pattern.Nanoservice.Service.Command
{
    public class CreateCandidateAndContactCommand : IRequest<int>
    {
        public CandidateRequest candidateRequest { get; set; }

        public class CreateCandidateAndContactCommandHandler : IRequestHandler<CreateCandidateAndContactCommand, int>
        {
            private readonly CandidateContext candidateContext;

            public CreateCandidateAndContactCommandHandler(CandidateContext candidateContext)
            {
                this.candidateContext = candidateContext;
            }
            public async Task<int> Handle(CreateCandidateAndContactCommand command, CancellationToken cancellationToken)
            {
                var candidate = new Candidate()
                {
                    FirstName = command.candidateRequest.FirstName,
                    LastName = command.candidateRequest.LastName,
                    CandidateAddress = new CandidateAddress() { CityName = command.candidateRequest.CityName, StateName = command.candidateRequest.StateName, PinCode = command.candidateRequest.PinCode },
                };

                foreach (var item in command.candidateRequest.CandidateContactRequests)
                {
                    candidate.CandidateContacts.Add(new CandidateContact() { Email = item.Email, Mobile = item.Mobile });
                }

                foreach (var item in command.candidateRequest.SkillId)
                {
                    candidate.CandidateSkillXrefs.Add(new CandidateSkillXref() { SkillId = item });
                }

                this.candidateContext.Candidates.Add(candidate);

                return await this.candidateContext.SaveChangesAsync();
            }
        }
    }
}
