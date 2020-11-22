using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GripDigital.Test.Core.Entities;
using GripDigital.Test.Core.Repositories.Interfaces;

namespace GripDigital.Test.Core.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private static readonly List<Match> Matches = new List<Match>
        {
            new Match(1, "First match", MatchStatus.Finished, GameType.TypeA, new List<Player>
            {
                new Player(1, 1, 250),
                new Player(2, 1, 320)
            }),
            new Match(2, "Second match", MatchStatus.InProgress, GameType.TypeA, new List<Player>
            {
                new Player(1, 2, 130),
                new Player(3, 2, 100),
                new Player(4, 2, 90)
            }),
            new Match(3, "Third match", MatchStatus.Created, GameType.TypeC, new List<Player>
            {
                new Player(3, 3, 0)
            })
        };
        
        public Task<IEnumerable<Match>> GetActive()
        {
            return Task.FromResult(Matches
                .Where(o => new [] {MatchStatus.Created, MatchStatus.InProgress}.Contains(o.Status))
            );
        }
    }
}