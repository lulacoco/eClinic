﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eClinic.Models
{
    public class PatientLogin
    {
        [Key]
        public int LoginId { get; set; }
        [BindProperty]
        public string Username { get; set; }
        public string Email { get; set; }
        [BindProperty]
        public string Pass { get; set; }
        public string PatientPesel { get; set; }
    }
}
