using GripDigital.Test.Authentication.Interfaces;

namespace GripDigital.Test.Authentication
{
    public class PasswordProvider : IPasswordProvider
    {
        public string GetPasswordHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool ValidatePassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}