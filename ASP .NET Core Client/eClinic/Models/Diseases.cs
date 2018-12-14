using Microsoft.AspNetCore.Mvc;
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
        public int DiseaseID { get; set; }
        [ConcurrencyCheck]
        public string DiseaseName { get; set; }
        [ConcurrencyCheck]
        public string DiseaseType { get; set; }
        [ConcurrencyCheck]
        public string Orders { get; set; }
    }
}