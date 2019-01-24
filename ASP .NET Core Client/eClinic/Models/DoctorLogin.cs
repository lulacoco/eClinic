using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eClinic.Models
{
    public class DoctorLogin
    {
        [Key]
        public int LoginId { get; set; }
        [BindProperty]
        public string LoginUsername { get; set; }
        [BindProperty]
        public string RegisterUsername { get; set; }
        [BindProperty]
        public string LoginEmail { get; set; }
        [BindProperty]
        public string RegisterEmail { get; set; }
        [BindProperty]
        public string LoginPass { get; set; }
        [BindProperty]
        public string RegisterPass { get; set; }
        public Int64 DoctorPesel { get; set; }
        public string ReturnUrl { get; set; }
    }
}
