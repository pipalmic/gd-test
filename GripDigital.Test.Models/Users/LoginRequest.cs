using System.Diagnostics.CodeAnalysis;

namespace GripDigital.Test.Models.Users
{
    [ExcludeFromCodeCoverage]
    public class LoginRequest
    {
        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}