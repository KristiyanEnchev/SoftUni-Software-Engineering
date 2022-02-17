namespace SMS.Contracts.Services
{
    public interface IPasswordHasher
    {
        string GeneratePassword(string password);
    }
}
