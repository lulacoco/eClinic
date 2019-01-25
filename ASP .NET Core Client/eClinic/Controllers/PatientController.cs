using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using eClinic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eClinic.Controllers
{
    [Authorize(Roles="patient")]
    public class PatientController : Controller
    {
        protected ApplicationDbContext mContext;
        protected UserManager<ApplicationUser> mUserManager;
        protected SignInManager<ApplicationUser> mSignInManager;
        protected RoleManager<IdentityRole> mRoleManager;
        public PatientController(
            ApplicationDbContext applicationDbContext,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            mContext = applicationDbContext;
            mUserManager = userManager;
            mSignInManager = signInManager;
            mRoleManager = roleManager;
        }

        public IActionResult Index()
        { 
            return View();
        }

        public IActionResult About()
        {
            return View("Index");
        }

        public IActionResult Visit()
        {
            //GetAppointments();
            GetTheBestDoctor();
            return View();
        }

        public List<Appointment> GetThisWeekAppointments(Doctor doc)
        {
            //Get nearest Sunday
            var nextSunday = DateTime.Now.AddDays(DayOfWeek.Sunday - DateTime.Now.DayOfWeek).Date;

            List<Appointment> appointments = null;

            //Get Appointments with time bigger than 'now'
            //and smaller than next nearest sunday (the clinic is close on Sundays)
            var allAppointments = mContext.Appointment
                .Where(t => t.AppointmentDate > DateTime.Now
                && t.AppointmentDate < nextSunday
                && t.DoctorPesel == doc.DoctorPesel); 
            return appointments;
        }

        public Doctor GetTheBestDoctor()
        {
            Doctor theBestDoctor = null;

            var today = DateTime.Today;
            var firstDayOfMonth = new DateTime(today.Year, today.Month, 1);

            //getAppointments returns a pair of doctor and appointment
            //both are connected with the doctor that has the most visits
            //it is just a one tuple
            var getAppointments = mContext.Doctor
                .Join(mContext.Appointment,
                d => d.DoctorPesel,
                a => a.DoctorPesel,
                (d, a) => new { Doctor = d, Appointment = a })
                .GroupBy(a => a.Doctor.DoctorPesel)
                .OrderByDescending(a => a.Count())
                .FirstOrDefault();
            
            var doctorPesel = getAppointments.Key;
            var size = getAppointments.Count();

            var doctorName = getAppointments.FirstOrDefault().Doctor.FirstName;

            return theBestDoctor;
        }
        
    }
}