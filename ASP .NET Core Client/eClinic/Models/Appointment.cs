using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eClinic.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }
        [ConcurrencyCheck]
        public string DoctorPesel { get; set; }
        [ConcurrencyCheck]
        public string PatientPesel { get; set; }
        [ConcurrencyCheck]
        public int DiseaseID { get; set; }
        [ConcurrencyCheck]
        public DateTime AppointmentDate { get; set;}
        [ConcurrencyCheck]
        public bool AppointmentCompleted { get; set; }
    }
}