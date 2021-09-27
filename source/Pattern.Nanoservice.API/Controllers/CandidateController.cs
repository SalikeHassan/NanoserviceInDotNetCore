using Microsoft.AspNetCore.Mvc;
using Pattern.Nanoservice.API.Client;
using Pattern.Nanoservice.Contract.Dtos.Request;
using Pattern.Nanoservice.Domain;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace Pattern.Nanoservice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly CandidateHttpClient candidateHttp;

        public CandidateController(CandidateHttpClient candidateHttp)
        {
            this.candidateHttp = candidateHttp;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Candidate), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var response = await this.candidateHttp.GetCandidateById(id.ToString());

            if (response == null)
            {
                return this.NoContent();
            }

            return this.Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        public async Task<IActionResult> Create([FromBody] CandidateRequest candidateRequest)
        {
            var response = await this.candidateHttp.CreateCandidate(candidateRequest);

            if (response == null)
            {
                return this.NoContent();
            }

            return this.Ok(response);
        }
    }
}
