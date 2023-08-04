using Login_Register_Page.Models;
using Login_Register_Page.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

public class RegisterController : Controller
{
    private AuthDbContext db;
    private readonly UserManager<IdentityUser> userManager;
    private readonly SignInManager<IdentityUser> signInManager;

    public RegisterController(AuthDbContext db, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        this.db = db;
        this.userManager = userManager;
        this.signInManager = signInManager;
    }


    
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    //[BindProperty]
    //public Register RModel { get; set; }
    

    [HttpPost]
    [ActionName("Register")]

    public async Task<IActionResult> OnPostAsync(Register RModel)

    {

        
        if (ModelState.IsValid)
         {
            var user = new IdentityUser
            {
                UserName = RModel.Email,
                Email = RModel.Email
            };

            var result = await userManager.CreateAsync(user, RModel.Password);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
                return RedirectToAction("Index","Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
 
        return View(RModel);
    }
}

