using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eClinic.Models
{
    public class Diseases
    {
        [Key]
        public int DiseaseId { get; set; }
        public string DiseaseName { get; set; }
        public string DiseaseType { get; set; }
        public string Orders { get; set; }
    }
}
