namespace Git.ViewModels.Repository
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.Repository;
    public class CreateRepositoryViewModel
    {
        [StringLength(RepositoryNameMaxLength, MinimumLength = RepositoryNameMinLength, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Name { get; set;}
        public string RepositoryType { get; set; }
    }
}
