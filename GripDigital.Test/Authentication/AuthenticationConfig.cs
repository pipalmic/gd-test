using System.Diagnostics.CodeAnalysis;

namespace GripDigital.Test.Authentication
{
    [ExcludeFromCodeCoverage]
    public class AuthenticationConfig
    {
        public string Key { get; set; } = string.Empty;

        public string Audience { get; set; } = string.Empty;

        public string Issuer { get; set; } = string.Empty;
    }
}