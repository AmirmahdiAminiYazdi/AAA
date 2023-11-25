using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AAA.Pages.Users
{
    public class ListUserModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        public IEnumerable<IdentityUser> Users { get; set; } = Enumerable.Empty<IdentityUser>();
        public ListUserModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public void OnGet()
        {
            Users = _userManager.Users.ToList();
        }
    }
}
