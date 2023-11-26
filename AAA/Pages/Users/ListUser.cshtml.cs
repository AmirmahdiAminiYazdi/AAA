using AAA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AAA.Pages.Users
{
    public class ListUserModel : PageModel
    {
        private readonly UserManager<customIdentityUser> _userManager;
        public IEnumerable<customIdentityUser> Users { get; set; } = Enumerable.Empty<customIdentityUser>();
        public ListUserModel(UserManager<customIdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public void OnGet()
        {
            Users = _userManager.Users.ToList();
        }
        public async Task<IActionResult> OnPostAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if( user is not null )
            {
                await _userManager.DeleteAsync(user);
            }

            return RedirectToPage();
        }
    }
}
