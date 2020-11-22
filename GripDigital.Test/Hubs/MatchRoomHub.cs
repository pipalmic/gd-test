using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace GripDigital.Test.Hubs
{
    public class MatchRoomHub : Hub
    {
        public async Task AddToMatch(int matchId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, matchId.ToString());
        }

        public async Task RemoveFromMatch(int matchId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, matchId.ToString());
        }
        
        public async Task Fire(int matchId)
        {
            await Clients.Group(matchId.ToString()).SendAsync("FireFunc");
        }
        
        public async Task Move(int matchId, Vector3 vector)
        {
            await Clients.Group(matchId.ToString()).SendAsync("MoveFunc", vector);
        }
        
        public async Task GetPlayers(int matchId, ushort limit)
        {
            await Clients.Group(matchId.ToString()).SendAsync("GetPlayersFunc", limit);
        }
    }
}