using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Pattern.Nanoservice.Contract.Dtos.Request;
using Pattern.Nanoservice.Infrastructure.Query;
using Pattern.Nanoservice.Service.Command;

namespace Pattern.Nanoservice.FunctionApp
{
    public class CandidateFunction
    {
        private readonly IMediator mediator;

        public CandidateFunction(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [FunctionName("GetCandidateById")]
        public async Task<IActionResult> GetCandidateById([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
            HttpRequest req, ILogger log)
        {
            int id;
            var requestQryString = req.Query["id"];

            if (int.TryParse(requestQryString, out id))
            {
                var response = await this.mediator.Send(new GetCandidateByIdQuery() { Id = id });

                if (response == null)
                {
                    return new NoContentResult();
                }

                return new OkObjectResult(response);
            }
            else
            {
                return new BadRequestErrorMessageResult("Invalid input");
            }
        }

        [FunctionName("CreateCandidate")]
        public async Task<IActionResult> CreateCandidate([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
            HttpRequestMessage req, ILogger log)
        {
            var requestBody = await req.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(requestBody) || string.IsNullOrWhiteSpace(requestBody))
            {
                return new BadRequestErrorMessageResult("Invalid input");
            }

            var candidateRequest = JsonConvert.DeserializeObject<CandidateRequest>(requestBody);
            var response = await this.mediator.Send(new CreateCandidateAndContactCommand() { candidateRequest = candidateRequest });

            if (response == 0)
            {
                return new NoContentResult();
            }

            return new OkObjectResult(response);
        }
    }
}

