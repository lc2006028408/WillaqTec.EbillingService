using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WillaqTec.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPersonService _personService;
        public LoginController(IUserService userService, IPersonService personService)
        {
            _userService = userService;
            _personService = personService;
        }

        public IActionResult Index()
        {

            //if (!HttpContext.User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("Index", "Login");
            //}
            //else
            //{
            //    return View();
            //}

            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                ViewBag.Data = false;
                return View();
            }
            else
            {
                if(HttpContext.Session.GetInt32("UserId") == 0)
                {
                    ViewBag.Data = false;
                    return View();
                }
                else
                {
                    ViewBag.Data = true;
                    return RedirectToAction("Index", "Home");

                }
            }
        }

        public async Task<IActionResult> Login(string userName, string password)
        {
            var user = await _userService.ValidateAsync(userName, password);
            var person = await _personService.GetByIdAsync(user.PersonId);
            if (user != null)
            {
                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, "anet@test.com"),
                };
                
                var grandmaIdentity =
                new ClaimsIdentity(userClaims, "User Identity");
                
                var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                await HttpContext.SignInAsync(userPrincipal);
                HttpContext.Session.SetString("userFullName", $"{person.FatherLastName} {person.MotherLastName}, {person.Name}");
                ViewData["UserFullName"] = $"{person.FatherLastName} {person.MotherLastName}, {person.Name}";
                HttpContext.Session.SetInt32("userId", user.UserId);
                return RedirectToAction("Index", "Home");
            }
            
            return View(user);
        }

        [Authorize]
        public  IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

    }
}
