namespace MUSACA.Services.Contracts
{
    public interface IPasswordHasher
    {
        string GeneratePassword(string password);
    }
}
