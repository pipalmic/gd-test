namespace GripDigital.Test.Authentication.Interfaces
{
    public interface ITokenProvider
    {
        string GenerateToken(string userName);
    }
}