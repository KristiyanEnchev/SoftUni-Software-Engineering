namespace IRunes.Services.Services
{
    using IRunes.Data;
    using IRunes.Data.Models;
    using IRunes.Services.Contracts;
    using IRunes.ViewModels.Albums;
    using IRunes.ViewModels.Tracks;
    using System.Collections.Generic;
    using System.Linq;

    public class AlbumsService : BaseService<Album>, IAlbumsService
    {
        private const int DefaultAlbumPrice = 0;

        public AlbumsService(IRunesDbContext data, IValidatorService validator)
            : base(data, validator)
        {
        }

        public List<AllAlbumDetailsViewModel> GetAllAlbums()
        {
            var albums = this
                .GetAll()
                .Select(i => new AllAlbumDetailsViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                })
                .ToList();
            return albums;
        }
        public List<string> CreateAlbum(CreateAlbumViewModel model)
        {
            ICollection<string> errorModel = Validator.ValidateModel(model);

            if (errorModel.Count != 0)
            {
                return errorModel.ToList();
            }

            var album = new Album
            {
                Name = model.Name,
                Cover = model.Cover,
                Price = DefaultAlbumPrice,
            };

            this.Data.Albums.Add(album);

            this.Data.SaveChanges();

            return errorModel.ToList();
        }

        public AlbumDetailsViewModel GetDetails(string albumId)
        {
            var tracks = this.Data.Tracks.Where(x => x.AlbumId == albumId);
            var albumById = this.GetById(albumId);

            var album = new AlbumDetailsViewModel
            {
                Id = albumId,
                Name = albumById.Name,
                Cover = albumById.Cover,
                Tracks = tracks.Select(x => new TracksViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                }).ToList(),
                Price = tracks.Sum(x => x.Price),
            };

            return album;
        }

        public bool IsAlbumExists(string id)
            => this.Data.Albums.Any(a => a.Id == id);

        public Album GetById(string id)
            => this.Data.Albums.FirstOrDefault(u => u.Id == id);

        public IEnumerable<Album> GetAll()
            => this.Data.Albums.ToList();
    }
}
