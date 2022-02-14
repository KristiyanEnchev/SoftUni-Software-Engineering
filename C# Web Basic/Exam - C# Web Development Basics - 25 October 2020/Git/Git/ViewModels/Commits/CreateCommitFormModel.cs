namespace Git.ViewModels.Commits
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.Commit;

    public class CreateCommitFormModel
    {
        public string Id { get; init; }

        [StringLength(CommitDescriptionMaxLength, MinimumLength = CommitDescriptionMinLength, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Description { get; init; }
    }
}
