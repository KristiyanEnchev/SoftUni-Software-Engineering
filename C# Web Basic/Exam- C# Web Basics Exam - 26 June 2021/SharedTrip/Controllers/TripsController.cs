namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using MyWebServer.Results;
    using SharedTrip.Data;
    using SharedTrip.Data.Models;
    using SharedTrip.Models.Trips;
    using SharedTrip.Services;
    using System;
    using System.Globalization;
    using System.Linq;

    public class TripsController : Controller
    {
        private readonly IUserService users;
        private readonly IValidator validator;
        private readonly ApplicationDbContext data;

        public TripsController(IUserService users, IValidator validator, ApplicationDbContext data)
        {
            this.users = users;
            this.validator = validator;
            this.data = data;
        }

        [Authorize]
        public HttpResponse All()
        {
            var tripsQuery = this.data
                .Trips
                .AsQueryable();

            var trips = tripsQuery
                .Select(t => new TripListingViewModel
                {
                    TripId = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    Seats = t.Seat,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                })
                .ToList();

            return View(trips);
        }


        [Authorize]
        public HttpResponse Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddTripFormModel model)
        {
            var modelErrors = this.validator.ValidateTrip(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                ImagePath = model.ImagePath,
                DepartureTime = DateTime.Parse(model.DepartureTime, CultureInfo.InvariantCulture),
                Description = model.Description,
                Seat = model.Seats,
            };

            data.Trips.Add(trip);
            data.UserTrips.Add(new UserTrip 
            {
                UserId = this.User.Id,
                TripId = trip.Id,
            });

            data.SaveChanges();

            return Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            var tripDetails = this.data
                .Trips
                .Where(i => i.Id == tripId)
                .Select(i => new TripDetailsModel
                {
                    TripId = i.Id,
                    StartPoint = i.StartPoint,
                    EndPoint = i.EndPoint,
                    Description = i.Description,
                    ImagePath= i.ImagePath,
                    Seats = i.Seat,
                    DepartureTime = i.DepartureTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture)
                })
                .FirstOrDefault();


            if (tripDetails == null)
            {
                return NotFound();
            }

            return View(tripDetails);
        }

        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            var trip = this.data
                .Trips
                .FirstOrDefault(x => x.Id == tripId);

            if (trip == null)
            {
                return Error("Trip was not found! Try again");
            }

            if (trip.Seat == 0)
            {
                return Error("There are no more free seats for this trip!");
            }

            if (users.IsInThisTrip(this.User.Id, tripId))
            {
                return Redirect($"/Trips/Details?tripId={tripId}");
            }

            this.data.UserTrips.Add(new UserTrip
            {
                TripId = tripId,
                UserId = this.User.Id,
            });

            this.data.SaveChanges();

            trip.Seat -= 1;

            this.data.SaveChanges();

            return Redirect("/Trips/All");
        }


    }
}
