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
    }
}
