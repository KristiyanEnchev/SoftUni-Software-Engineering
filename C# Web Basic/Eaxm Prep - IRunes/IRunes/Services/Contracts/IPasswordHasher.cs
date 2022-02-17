namespace IRunes.Services.Contracts
{
    public interface IPasswordHasher
    {
        string GeneratePassword(string password);
    }
}
