using eClinic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace eClinic.Controllers
{
    public class TestController : Controller
    {
        protected ApplicationDbContext mContext;
        protected UserManager<ApplicationUser> mUserManager;
        protected SignInManager<ApplicationUser> mSignInManager;

        public TestController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            mContext = context;
            mUserManager = userManager;
            mSignInManager = signInManager;
        }
        
        [Route("/con")]
        public async Task<IActionResult> TryConcurrency()
        {
            var result = mContext.Doctor.SingleOrDefault(b => b.DoctorPesel == "80128462129");
            if (result != null)
            {
                result.FirstName = "Andrzeju";
                string x = "Szymon";
                try
                {
                    await mContext.SaveChangesAsync();
                    return Content("Its ok!", "text/html");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    return Content(ex.Message, "text/html");
                }
            }
            return Content("This is null", "text/html");
        }

        [Route("/testerror")]
        public async Task<IActionResult> TryRaiseError()
        {
            var result = await mContext.Patient.AddAsync(new Patient
            {
                PatientPesel = "05928392843",
                FirstName = "Angelina",
                LastName = "Jolie"
            });
            if (result != null)
            {
                try
                {
                    var addPatientLogin = await mContext.PatientLogin.AddAsync(new PatientLogin
                    {
                        Username = "AngelJol",
                        Pass = "secretAngeliPass123!",
                        Email = "angi@gmail.com",
                        PatientPesel = "05928392843"
                    });
                    await mContext.SaveChangesAsync();
                }
                catch(DbUpdateException ex)
                {
                    return Content(ex.InnerException.Message, "text/html");
                }
            }
            return Content("Everything went fine", "text/html");
        }
    }
}
