using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eClinic.Models
{
    public partial class Doctor
    {
        [Key]
        public Int64 DoctorPesel { get; set; }
        [ConcurrencyCheck]
        public int Age { get; set; }
        [ConcurrencyCheck]
        public string FirstName { get; set; }
        [ConcurrencyCheck]
        public string LastName { get; set; }
        [ConcurrencyCheck]
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
