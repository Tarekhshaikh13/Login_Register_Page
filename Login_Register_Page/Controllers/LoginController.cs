using Login_Register_Page.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Login_Register_Page.Controllers
{
    public class LoginController : Controller
    {
        private SignInManager<IdentityUser> _signInManager;
        public LoginController(SignInManager<IdentityUser> signInManager)
        {
            this._signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Login")]
        public async Task<IActionResult> OnPostAsync(Login Lmodel, string returnurl = null)
        {
            if(ModelState.IsValid)
            {
               var result = await _signInManager.PasswordSignInAsync(Lmodel.Email, Lmodel.Password,Lmodel.RememberMe,false);
                if(result.Succeeded)
                {
                    if(returnurl== null || returnurl == "")
                    {
                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        return View(returnurl);
                    }

                }
                ModelState.AddModelError("", "Invalid Credentials");

            }
            return View();
          
        }
        public async Task<IActionResult> Signout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");    

        }
    }
}
