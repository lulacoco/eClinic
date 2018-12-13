using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eClinic.Models
{
    public class Patient
    {
        [Key]
        public string PatientPesel { get; set; }
        [ConcurrencyCheck]
        public int Age { get; set; }
        [ConcurrencyCheck]
        public string FirstName { get; set; }
        [ConcurrencyCheck]
        public string LastName { get; set; }
    }
}
