using ItemRazorV1Real.Models;
using ItemRazorV1Real.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace ItemRazorV1Real.Pages.LogIn
{
    public class LogInPageModel : PageModel
    {
        private UserService _userService;
        public static User LoggedInUser { get; set; } = null;
       
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty,DataType(DataType.Password)]
        public string Password { get; set; }
        public string Message { get; set; }

        public LogInPageModel(UserService userService)
        {
            _userService = userService;
        }


        public async Task<IActionResult> OnPost()
        {

            List<User> users = _userService.Users;
            foreach (User user in users)
            {

                if (UserName == user.UserName)
                {
                    var passwordHasher = new PasswordHasher<string>();
                    if (passwordHasher.VerifyHashedPassword(null, user.Password, Password) == PasswordVerificationResult.Success)

                    {
                        LoggedInUser = user;

                        var claims = new List<Claim> { new Claim(ClaimTypes.Name, UserName) };
                        if (UserName == "admin") claims.Add(new Claim(ClaimTypes.Role, "admin"));

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                        return RedirectToPage("/Item/GetAllItems");
                    }

                }

            }

            Message = "Invalid attempt";
            return Page();
        }
    }
}
