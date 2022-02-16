namespace Git.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static DataConstants.Commit;

    public class Commit
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(Creator))]
        public string CreatorId { get; set; }
        public User Creator { get; set; }


        [ForeignKey(nameof(Repository))]
        public string RepositoryId { get; set; }
        public Repository Repository { get; set; }
    }
}