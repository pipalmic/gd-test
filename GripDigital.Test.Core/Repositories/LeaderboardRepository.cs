using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GripDigital.Test.Core.Entities;
using GripDigital.Test.Core.Exceptions;
using GripDigital.Test.Core.Repositories.Interfaces;

namespace GripDigital.Test.Core.Repositories
{
    public class LeaderboardRepository : ILeaderboardRepository
    {
        private readonly List<Leaderboard> _leaderboards = new List<Leaderboard>
        {
            new Leaderboard(1, GameType.TypeA),
            new Leaderboard(2, GameType.TypeB),
            new Leaderboard(3, GameType.TypeC)
        };
        
        public Task<Leaderboard> GetByGameType(GameType gameType)
        {
            var leaderboard = _leaderboards.FirstOrDefault(o => o.GameType == gameType);
            if(leaderboard == null)
                throw new NotFoundException($"Leaderboard for the game type {gameType} was not found!");
            return Task.FromResult(leaderboard);
        }
    }
}