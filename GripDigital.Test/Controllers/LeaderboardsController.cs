using System.Threading.Tasks;
using GripDigital.Test.Core.Entities;
using GripDigital.Test.Core.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GripDigital.Test.Controllers
{
    [ApiController]
    [Authorize]
    [Route("leaderboards")]
    public class LeaderboardsController : Controller
    {
        private readonly ILeaderboardRepository _leaderboardRepository;

        public LeaderboardsController(ILeaderboardRepository leaderboardRepository)
        {
            _leaderboardRepository = leaderboardRepository;
        }

        [HttpGet("{gameType}")]
        public async Task<IActionResult> GetLeaderboard(GameType gameType)
        {
            var leaderboard = await _leaderboardRepository.GetByGameType(gameType);
            return Ok(leaderboard);
        }
    }
}