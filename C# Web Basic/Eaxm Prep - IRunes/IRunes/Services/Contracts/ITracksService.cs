namespace IRunes.Services.Contracts
{
    using IRunes.Data.Models;
    using IRunes.ViewModels.Tracks;
    using System.Collections.Generic;

    public interface ITracksService
    {
        List<string> CreateTrack(CreateTrackViewModel model, string albumId);
        List<TracksViewModel> GetTracksInAlbum(string albumId);
        TrackDetailsViewModel GetDetails(string trackId, string albumid);
        Track GetById(string id);
        IEnumerable<Track> GetAllByAlbumId(string albumId);
    }
}
