using MediatR;
using Microsoft.EntityFrameworkCore;
using Pattern.Nanoservice.Domain;
using Pattern.Nanoservice.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pattern.Nanoservice.Infrastructure.Query
{
    public class GetCandidateContactsByIdQuery : IRequest<IEnumerable<CandidateContact>>
    {
        public int CandidateId { get; set; }

        public class GetCandidateContactsByIdQueryHandler : IRequestHandler<GetCandidateContactsByIdQuery, IEnumerable<CandidateContact>>
        {
            private readonly CandidateContext candidateContext;

            public GetCandidateContactsByIdQueryHandler(CandidateContext candidateContext)
            {
                this.candidateContext = candidateContext;
            }
            public async Task<IEnumerable<CandidateContact>> Handle(GetCandidateContactsByIdQuery query, CancellationToken cancellationToken)
            {
                return await this.candidateContext.CandidateContacts.Include(x => x.Candidate).Where(x => x.CandidateId == query.CandidateId).ToListAsync();
            }
        }
    }
}
