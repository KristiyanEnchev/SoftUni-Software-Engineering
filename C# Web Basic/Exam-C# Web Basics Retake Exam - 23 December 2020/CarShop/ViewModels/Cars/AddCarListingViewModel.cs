namespace CarShop.ViewModels.Cars
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstrants.Car;

    public class AddCarListingViewModel
    {
        [StringLength(ModelMaxLength, MinimumLength = ModelMinLength, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Model { get; init; }

        public int Year { get; init; }

        [StringLength(UrlMaxLength, MinimumLength = 0, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Image { get; init; }

        [RegularExpression(PlateNumberRegex, ErrorMessage = "{0} is not valid, mustbe in format 'AA4567BB'")]
        public string PlateNumber { get; init; }
    }
}
