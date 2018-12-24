using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
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
        protected RoleManager<IdentityRole> mRoleManager;

        public LoginController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            mContext = context;
            mUserManager = userManager;
            mSignInManager = signInManager;
            mRoleManager = roleManager;
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
                    ApplicationUser user = new ApplicationUser();
                    user.Email = doctorLogin.RegisterEmail;
                    user.UserName = doctorLogin.RegisterUsername;

                    var result = await mUserManager.CreateAsync(user, doctorLogin.RegisterPass);
                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(rPatient))
                        {
                            bool roleExist = await mRoleManager.RoleExistsAsync("patient");
                            if (!roleExist)
                            {
                                var role = new IdentityRole();
                                role.Name = "patient";
                                await mRoleManager.CreateAsync(role);
                            }
                            var res = await mUserManager.AddToRoleAsync(user, "patient");
                            return View("Succeeded");
                        }
                        else if (!string.IsNullOrEmpty(rDoctor))
                        {
                            bool roleExist = await mRoleManager.RoleExistsAsync("doctor");
                            if (!roleExist)
                            {
                                var role = new IdentityRole();
                                role.Name = "doctor";
                                await mRoleManager.CreateAsync(role);
                            }
                            var res = await mUserManager.AddToRoleAsync(user, "doctor");
                            return View("Succeeded");
                        }
                    }
                    return Content("Register failed! Error type: " + result.Errors.First<IdentityError>().Description, "text/html");

                }
                //Login for Patients or Doctors
                else if(!string.IsNullOrEmpty(lPatient) || !string.IsNullOrEmpty(lDoctor))
                {
                    var x = await mSignInManager.PasswordSignInAsync(doctorLogin.LoginUsername, doctorLogin.LoginPass, true, false);
                    await CheckRole(lPatient, lDoctor);        
                }
            }
            return View(doctorLogin);
        }

        public async Task<IActionResult> CheckRole (string lPatient, string lDoctor)
        {
            if (!string.IsNullOrEmpty(lPatient) && User.IsInRole("patient"))
                return RedirectToAction("Index", "Patient");
            else if (!string.IsNullOrEmpty(lDoctor) && User.IsInRole("doctor"))
                return RedirectToAction("Index", "Doctor");
            else return Content($"Something went wrong!", "text/html");
            
        }
        
        [Authorize]
        [Route("/haker")]
        public IActionResult PrivateArea()
        {
            return Content($"This is an area for logged users. Welcome {HttpContext.User.Identity.Name}", "text/html");
        }
        
        public async Task<IActionResult> Logout()
        {
            await mSignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}