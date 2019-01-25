using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eClinic.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [ForeignKey("Doctor")]
        public string DoctorPesel { get; set; }
        public Doctor Doctor { get; set; }

        [ForeignKey("Patient")]
        public string PatientPesel { get; set; }
        public Patient Patient { get; set; }

        [ForeignKey("Diseases")]
        public int DiseaseId { get; set; }
        public Diseases Diseases { get; set; }

        public DateTime AppointmentDate { get; set; }
        public bool AppointmentCompleted { get; set; }

    }
}
