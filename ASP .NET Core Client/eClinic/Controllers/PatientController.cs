using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eClinic.Controllers
{
    [Authorize(Roles="patient")]
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View("Index");
        }

        public IActionResult Contact()
        {
            return View("Index");
        }
    }
}