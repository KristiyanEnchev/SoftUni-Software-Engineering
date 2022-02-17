namespace IRunes.ViewModels.Albums
{
    using IRunes.ViewModels.Tracks;
    using System.Collections.Generic;

    public class AlbumDetailsViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Cover { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<TracksViewModel> Tracks { get; set; }
    }
}
