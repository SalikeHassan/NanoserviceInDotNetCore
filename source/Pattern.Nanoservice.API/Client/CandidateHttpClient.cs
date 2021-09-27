using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pattern.Nanoservice.Contract.Dtos.Request;
using Pattern.Nanoservice.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Nanoservice.API.Client
{
    public class CandidateHttpClient
    {
        private readonly HttpClient httpClient;

        public CandidateHttpClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Candidate> GetCandidateById(string id)
        {
            using (HttpResponseMessage responseMessage = await this.httpClient.GetAsync("GetCandidateById"))
            {
                using (HttpContent content = responseMessage.Content)
                {
                    string data = await content.ReadAsStringAsync();
                    if (data != null)
                    {
                        return JsonConvert.DeserializeObject<Candidate>(data);
                    }

                    return null;
                }
            }
        }

        public async Task<int?> CreateCandidate(CandidateRequest candidateRequest)
        {
            var json = JsonConvert.SerializeObject(candidateRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpResponseMessage responseMessage = await this.httpClient.PostAsync("CreateCandidate", data))
            {
                using (HttpContent content = responseMessage.Content)
                {
                    string responseData = await content.ReadAsStringAsync();
                    if (data != null)
                    {
                        return JsonConvert.DeserializeObject<int>(responseData);
                    }

                    return null;
                }
            }
        }
    }
}
