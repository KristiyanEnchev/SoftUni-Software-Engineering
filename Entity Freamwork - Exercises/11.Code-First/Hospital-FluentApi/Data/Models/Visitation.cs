using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_HospitalDatabase.Data.Models
{
    public class Visitation
    {
        [Key]
        public int VisitationId { get; set; }

        public DateTime Date { get; set; }

        public string Comments { get; set; }


        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }


        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
