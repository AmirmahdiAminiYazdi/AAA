using AAA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace AAA.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly UserManager<customIdentityUser> _userManager;

        public EditModel(UserManager<customIdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [BindProperty]
        public string Id { get; set; }
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string? Password { get; set; }
        [BindProperty]
        [EmailAddress]
        public string Email { get; set; }
        public async Task OnGet(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserName = user.UserName;
            Email = user.Email;


        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(Id);
                user.FirstName = FirstName;
                user.LastName = LastName;
                user.UserName = UserName;
                user.Email = Email;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded && !string.IsNullOrEmpty(Password))
                {
                   await _userManager.RemovePasswordAsync(user);
                    result = await _userManager.AddPasswordAsync(user, Password);
                }
                if (result.Succeeded)
                {
                    return RedirectToPage("ListUser");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

            }
            return Page();
        }
    }
}
