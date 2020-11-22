using System.Diagnostics.CodeAnalysis;

namespace GripDigital.Test.Models.Users
{
    [ExcludeFromCodeCoverage]
    public class LoginResponse
    {
        private LoginResponse(bool isSuccessful, string? token = null)
        {
            IsSuccessful = isSuccessful;
            Token = token;
        }
        
        public bool IsSuccessful { get; }
        
        public string? Token { get; }

        public static LoginResponse Unauthorized()
        {
            return new LoginResponse(false);
        }

        public static LoginResponse Authorized(string token)
        {
            return new LoginResponse(true, token);
        }
    }
}