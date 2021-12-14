using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_HospitalDatabase.Data.Models
{
    public class Visitation
    {
        [Key]
        public int VisitationId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(250)]
        public string Comments { get; set; }


        [ForeignKey(nameof(Doctor))]
        public int? DoctorId { get; set; }
        [Required]
        public Doctor Doctor { get; set; }


        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        [Required]
        public Patient Patient { get; set; }
    }
}
