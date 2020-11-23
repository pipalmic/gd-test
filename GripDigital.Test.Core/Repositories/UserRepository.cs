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
            // Heslo123 => $2a$11$HWQw111.v374W9yovMxItO2sx.o3/gdKq4Ho4s6UYnuZEAuHmj7Q6
            new User(1, "testUser1", "$2a$11$HWQw111.v374W9yovMxItO2sx.o3/gdKq4Ho4s6UYnuZEAuHmj7Q6"),
            new User(2, "testUser2", "$2a$11$HWQw111.v374W9yovMxItO2sx.o3/gdKq4Ho4s6UYnuZEAuHmj7Q6"),
            new User(3, "testUser3", "$2a$11$HWQw111.v374W9yovMxItO2sx.o3/gdKq4Ho4s6UYnuZEAuHmj7Q6"),
            new User(4, "testUser4", "$2a$11$HWQw111.v374W9yovMxItO2sx.o3/gdKq4Ho4s6UYnuZEAuHmj7Q6"),
            new User(5, "testUser5", "$2a$11$HWQw111.v374W9yovMxItO2sx.o3/gdKq4Ho4s6UYnuZEAuHmj7Q6")
        }; 
        
        public Task<User?> GetByUserName(string userName)
        {
            var user = Users.FirstOrDefault(o => o.UserName == userName);
            return Task.FromResult(user);
        }
    }
}