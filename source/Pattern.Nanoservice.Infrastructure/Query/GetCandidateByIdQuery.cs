using MediatR;
using Microsoft.EntityFrameworkCore;
using Pattern.Nanoservice.Domain;
using Pattern.Nanoservice.Infrastructure.Context;
using System.Threading;
using System.Threading.Tasks;

namespace Pattern.Nanoservice.Infrastructure.Query
{
    public class GetCandidateByIdQuery : IRequest<Candidate>
    {
        public int Id { get; set; }
        public class GetCandidateByIdQueryHandler : IRequestHandler<GetCandidateByIdQuery, Candidate>
        {
            private readonly CandidateContext candidateContext;

            public GetCandidateByIdQueryHandler(CandidateContext candidateContext)
            {
                this.candidateContext = candidateContext;
            }
            public async Task<Candidate> Handle(GetCandidateByIdQuery query, CancellationToken cancellationToken)
            {
                return await this.candidateContext.Candidates.FirstOrDefaultAsync(x => x.Id == query.Id);
            }
        }
    }
}
