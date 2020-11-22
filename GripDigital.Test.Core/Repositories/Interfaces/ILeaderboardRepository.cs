using System.Threading.Tasks;
using GripDigital.Test.Core.Entities;

namespace GripDigital.Test.Core.Repositories.Interfaces
{
    public interface ILeaderboardRepository
    {
        Task<Leaderboard> GetByGameType(GameType gameType);
    }
}