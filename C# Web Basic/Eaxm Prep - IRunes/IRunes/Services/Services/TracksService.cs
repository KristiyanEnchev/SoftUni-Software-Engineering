namespace IRunes.Services.Services
{
    using IRunes.Data;
    using IRunes.Data.Models;
    using IRunes.Services.Contracts;
    using IRunes.ViewModels.Tracks;
    using System.Collections.Generic;
    using System.Linq;

    public class TracksService : BaseService<Track>, ITracksService
    {
        public TracksService(IRunesDbContext data, IValidatorService validator)
            : base(data, validator)
        {
        }

        public List<TracksViewModel> GetTracksInAlbum(string albumId) 
        {
            var tracks = this.GetAllByAlbumId(albumId)
                .Select(x => new TracksViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                }).ToList();

            return tracks;
        }

        public TrackDetailsViewModel GetDetails(string trackId, string albumid) 
        {
            var track = this.GetById(trackId);

            var model = new TrackDetailsViewModel
            {
                Name = track.Name,
                Link = track.Link,
                Price = track.Price,
                AlbumId = albumid
            };

            return model;

        }

        public List<string> CreateTrack(CreateTrackViewModel model, string albumId)
        {
            ICollection<string> errorModel = this.Validator.ValidateModel(model);

            if (errorModel == null || errorModel.Count != 0) 
            {
                return errorModel.ToList();
            }

            var album = this.Data.Albums.FirstOrDefault(x => x.Id == albumId);

            var track = new Track
            {
                Name = model.Name,
                Price = model.Price,
                Link = model.Link,
                Album = album,
                AlbumId = albumId,
            };

            album.Tracks.Add(track);

            this.Data.Tracks.Add(track);

            this.Data.SaveChanges();

            return errorModel.ToList();
        }

        public Track GetById(string id)
            => this.Data.Tracks.FirstOrDefault(t => t.Id == id);

        public IEnumerable<Track> GetAllByAlbumId(string albumId)
            => this.Data.Tracks
                .Where(t => t.AlbumId == albumId)
                .ToList();
    }
}
