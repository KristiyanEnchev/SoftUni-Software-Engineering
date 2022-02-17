namespace IRunes.Services.Contracts
{
    using IRunes.Data.Models;
    using IRunes.ViewModels.Albums;
    using System.Collections.Generic;

    public interface IAlbumsService
    {
        List<AllAlbumDetailsViewModel> GetAllAlbums();
        AlbumDetailsViewModel GetDetails(string albumId);
        List<string> CreateAlbum(CreateAlbumViewModel model);
        Album GetById(string id);
    }
}
