namespace SharedTrip.Services
{
    public interface IUserService
    {
        public bool IsInThisTrip(string userId, string tripId);
    }
}
