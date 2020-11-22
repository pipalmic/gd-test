namespace GripDigital.Test.Core.Entities
{
    public class Player
    {
        public Player(int userId, int matchId, int score)
        {
            UserId = userId;
            MatchId = matchId;
            Score = score;
        }
        
        public int UserId { get; private set; }
        
        public int MatchId { get; private set; }
        
        public int Score { get; private set; }
    }
}