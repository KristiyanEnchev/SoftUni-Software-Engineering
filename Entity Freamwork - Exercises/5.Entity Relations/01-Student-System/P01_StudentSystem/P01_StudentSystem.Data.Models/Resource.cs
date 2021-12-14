using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P01_StudentSystem.Data.Models.Enumeration;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public ResourceType ResourceType { get; set; }

        [Required]
        [Column(TypeName="varchar(2048)")]
        public string Url { get; set; }
    }
}
