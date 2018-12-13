using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eClinic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eClinic.Controllers
{
    public class LoginController : Controller
    {
        protected ApplicationDbContext mContext;
        protected UserManager<ApplicationUser> mUserManager;
        protected SignInManager<ApplicationUser> mSignInManager;

        public LoginController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            mContext = context;
            mUserManager = userManager;
            mSignInManager = signInManager;
        }
        public IActionResult Index(string returnUrl="")
        {
            mContext.Database.EnsureCreated();
            //mContext.Doctor.Add(new Doctor
            //{
            //    FirstName = "Pantelo",
            //    LastName = "Pamelo",
            //    DoctorPesel = 98038272924
            //});
            //mContext.SaveChanges();
            var model = new DoctorLogin { ReturnUrl = returnUrl };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Sign(
            DoctorLogin doctorLogin, 
            string lPatient, 
            string lDoctor, 
            string rPatient, 
            string rDoctor)
        {
            if (ModelState.IsValid)
            {
                //Register for Patients or Doctors
                if(!string.IsNullOrEmpty(rPatient) || !string.IsNullOrEmpty(rDoctor))
                {   
                    var result = await mUserManager.CreateAsync(new ApplicationUser
                    {
                        UserName = doctorLogin.Username,
                        Email = doctorLogin.Email,
                    }, doctorLogin.Pass);
                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(lPatient))
                            return Content("Register succeded! Welcome patient, " + doctorLogin.Username, "text/html");
                        else if (!string.IsNullOrEmpty(lDoctor))
                            return Content("Register succeded! Welcome doctor, " + doctorLogin.Username, "text/html");
                    }
                    return Content("Register failed! Error type: " + result.Errors.First<IdentityError>().Description, "text/html");

                }
                //Login for Patients or Doctors
                else if(!string.IsNullOrEmpty(lPatient) || !string.IsNullOrEmpty(lDoctor))
                {
                    await mSignInManager.PasswordSignInAsync(doctorLogin.Username, doctorLogin.Pass, true, false);
                    if (!string.IsNullOrEmpty(lPatient))
                        return Content("Login succeded! Welcome patient, " + doctorLogin.Username, "text/html");
                    else if (!string.IsNullOrEmpty(lDoctor))
                        return Content("Login succeded! Welcome doctor, " + doctorLogin.Username, "text/html");
                }
            }
            return View(doctorLogin);
        }
        
        [Authorize]
        [Route("/haker")]
        public IActionResult PrivateArea()
        {
            return Content($"This is an area for logged users. Welcome {HttpContext.User.Identity.Name}", "text/html");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await mSignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}