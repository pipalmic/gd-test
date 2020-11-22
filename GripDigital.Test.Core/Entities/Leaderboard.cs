namespace GripDigital.Test.Core.Entities
{
    public class Leaderboard
    {
        public Leaderboard(int id, GameType gameType)
        {
            Id = id;
            GameType = gameType;
        }
        
        public int Id { get; private set; }   
        
        public GameType GameType { get; private set; }
    }
}