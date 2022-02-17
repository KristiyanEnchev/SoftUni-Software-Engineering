namespace IRunes.ViewModels.Albums
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.Album;
    public class CreateAlbumViewModel
    {

        [StringLength(AlbumNameMaxLength, MinimumLength = AlbumNameMinLength, ErrorMessage = "Name {0} is wrong, shuold be betwean {1} and {2} long")]
        public string Name { get; set; }

        [MaxLength(UrlMaxLength, ErrorMessage = "Too long Url")]
        public string Cover { get; set; }
    }
}
