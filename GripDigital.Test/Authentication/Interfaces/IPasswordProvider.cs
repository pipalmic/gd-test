namespace GripDigital.Test.Authentication.Interfaces
{
    public interface IPasswordProvider
    {
        string GetPasswordHash(string password);

        bool ValidatePassword(string password, string hash);
    }
}