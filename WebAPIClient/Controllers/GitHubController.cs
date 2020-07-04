using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPIClient.Models;

namespace WebAPIClient.Controllers
{
    [Route("api/git")]
    public class GitHubController : Controller
    {
        private static readonly HttpClient client = new HttpClient();
       
        [HttpGet]
        [Route("repositories")]
        public async Task<IEnumerable<Repository>> ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));            
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = await client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            var repositories = await JsonSerializer.DeserializeAsync<IEnumerable<Repository>>(streamTask);

            return repositories;
        }
    }
}
