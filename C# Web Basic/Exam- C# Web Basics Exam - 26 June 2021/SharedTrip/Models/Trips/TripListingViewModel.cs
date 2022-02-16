namespace SharedTrip.Models.Trips
{
    using System;
    public class TripListingViewModel
    {
        public string TripId { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public string DepartureTime { get; set; }
        public int Seats { get; set; }
    }
}
