using eClinic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            var result = mContext.Doctor.SingleOrDefault(b => b.DoctorPesel == 80128462129);
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
    }
}
