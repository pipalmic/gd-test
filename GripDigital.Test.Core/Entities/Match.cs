using System.Collections.Generic;

namespace GripDigital.Test.Core.Entities
{
    public class Match
    {
        public Match(int id, string name, MatchStatus status, GameType gameType, List<Player> players)
        {
            Id = id;
            Name = name;
            Status = status;
            GameType = gameType;
            Players = players;
        }
        
        public int Id { get; private set; }
        
        public string Name { get; private set; }
        
        public MatchStatus Status { get; private set; }
        
        public GameType GameType { get; private set; }
        
        public List<Player> Players { get; set; }
    }
}