using SharedTrip.Data;
using System.Linq;

namespace SharedTrip.Services
{

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext data;

        public UserService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public bool IsInThisTrip(string userId, string tripId)
        {
            if (this.data.UserTrips.Any(t => t.UserId == userId && tripId == t.TripId))
            {
                return true;
            }

            return false;
        }
    }
}
