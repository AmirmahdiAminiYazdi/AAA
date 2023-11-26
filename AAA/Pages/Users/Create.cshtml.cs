using AAA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace AAA.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly UserManager<customIdentityUser> _userManager;

        public CreateModel(UserManager<customIdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        [EmailAddress]
        public string Email { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid) 
            {
                customIdentityUser user = new()
                {
                    UserName = UserName,
                    Email = Email,
                    FirstName = FirstName,
                    LastName = LastName,

                };
                IdentityResult result = await _userManager.CreateAsync(user,Password);
                if (result.Succeeded)
                {
                    return RedirectToPage("ListUser");
                }
                foreach(var item  in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return Page();
        }
    }
}
