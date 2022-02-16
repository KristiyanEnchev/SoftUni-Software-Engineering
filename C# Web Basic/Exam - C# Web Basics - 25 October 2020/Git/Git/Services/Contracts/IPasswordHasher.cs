namespace Git.Services.Contracts
{
    public interface IPasswordHasher
    {
        string GeneratePassword(string password);
    }
}
