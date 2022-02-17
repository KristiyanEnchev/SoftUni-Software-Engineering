namespace IRunes.ViewModels.Tracks
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.Track;
    public class CreateTrackViewModel
    {
        public string Id { get; set; }

        [StringLength(TrackNameMaxLength, MinimumLength = TrackNameMinLength, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [StringLength(UrlMaxLength, MinimumLength = 0, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Link { get; set; }
    }
}
