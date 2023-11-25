using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace AAA.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(UserManager<IdentityUser>userManager)
        {
            _userManager = userManager;
        }
        //[BindProperty]
        //public string Name { get; set; }
        //[BindProperty]
        //public string Family { get; set; }
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
                IdentityUser user = new()
                {
                    UserName = UserName,
                    Email = Email
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
