namespace Andreys.Services.Contracts
{
    public interface IPasswordHasher
    {
        string GeneratePassword(string password);
    }
}
