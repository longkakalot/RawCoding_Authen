using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EP1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secrect()
        {
            return View();
        }

        public IActionResult Authenticate()
        {
            //tạo userClaim
            var grandmaClaim = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Long"),
                new Claim(ClaimTypes.Email, "long@gmail.com"),
                new Claim("Grandma says", "long@gmail.com")
            };
            var licenseClaim = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Long nc"),
                new Claim("Grandma says", "long@gmail.com")
            };

            //tạo user Identidy
            var grandIdentity = new ClaimsIdentity(grandmaClaim, "Grandma Identity");
            var licenseIdentity = new ClaimsIdentity(licenseClaim, "Pikapu");

            var userPrincipal = new ClaimsPrincipal(new[] {grandIdentity, licenseIdentity });

            HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index");
        }
    }
}
