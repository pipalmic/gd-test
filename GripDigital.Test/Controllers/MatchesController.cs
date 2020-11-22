using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using GripDigital.Test.Core.Entities;
using GripDigital.Test.Core.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Client;

namespace GripDigital.Test.Controllers
{
    [ApiController]
    [Authorize]
    [Route("matches")]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchRepository _matchRepository;

        public MatchesController(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Match>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetActive()
        {
            var matches = await _matchRepository.GetActive();
            return Ok(matches);
        }

        // I don't feel this is right, I would expect connection handling on the FE side instead
        [HttpPost("{matchId}/join")]
        [ProducesResponseType(typeof(HubConnection), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetConnection(int matchId)
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/match/room")
                .Build();

            await hubConnection.StartAsync();
            await hubConnection.InvokeAsync("AddToMatch", matchId);
            
            return Ok(hubConnection);
        }
    }
}