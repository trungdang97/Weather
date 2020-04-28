using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Weather.API.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [Authorize]
        [HttpGet]
        [Route("get")]
        public ActionResult<IEnumerable<string>> GetValue()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("simpleget")]
        public ActionResult<IEnumerable<string>> GetValue1()
        {
            return new string[] { "value1" };
        }

        // GET api/values/5
        [HttpGet]
        [Route("auth")]
        public async Task<ActionResult<DiscoveryResponse>> Get()
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:8589");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
            }
            return disco;
        }

        [HttpGet]
        [Route("login")]
        public async Task<ActionResult<TokenResponse>> Login()
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:8589");
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,

                ClientId = "client",
                ClientSecret = "secret",
                Scope = "api1"
            });
            return tokenResponse;
        }
    }
}
