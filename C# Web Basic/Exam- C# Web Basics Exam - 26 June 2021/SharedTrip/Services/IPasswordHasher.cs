namespace SharedTrip.Services
{
    public interface IPasswordHasher
    {
        string GeneratePassword(string password);
    }
}
