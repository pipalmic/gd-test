using GripDigital.Test.Core.Entities.Interfaces;

namespace GripDigital.Test.Core.Entities
{
    public class User : IId
    {
        public User(int id, string userName, string passwordHash)
        {
            Id = id;
            UserName = userName;
            PasswordHash = passwordHash;
        }
        
        public int Id { get; private set; }
        
        public string UserName { get; private set; }
        
        public string PasswordHash { get; private set; }
    }
}