using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GripDigital.Test.Core.Entities;
using GripDigital.Test.Core.Repositories.Interfaces;

namespace GripDigital.Test.Core.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> Users = new List<User>
        {
            new User(1, "testUser1", ""),
            new User(2, "testUser2", ""),
            new User(3, "testUser3", ""),
            new User(4, "testUser4", ""),
            new User(5, "testUser5", "")
        }; 
        
        public Task<User?> GetByUserName(string userName)
        {
            var user = Users.FirstOrDefault(o => o.UserName == userName);
            return Task.FromResult(user);
        }
    }
}