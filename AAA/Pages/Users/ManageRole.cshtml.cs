
using AAA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AAA.Pages.Users
{
    public class ManageRoleModel : PageModel
    {
        private readonly UserManager<customIdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        [BindProperty]
        public List<string> Roles { get; set; }
        [BindProperty]
        public string Id { get; set; }
        public customIdentityUser CurentUser { get; set; }
        public List<IdentityRole> AllRoles { get; set; }
        public List<string> UserRoles { get; set; }
        public ManageRoleModel(UserManager<customIdentityUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task OnGet(string id)
        {
            CurentUser = await _userManager.FindByIdAsync(id);

            UserRoles = (await _userManager.GetRolesAsync(CurentUser)).ToList();
            AllRoles = _roleManager.Roles.ToList();
            
        }
        public async Task<IActionResult> OnPostAsync()
        {
            CurentUser = await _userManager.FindByIdAsync(Id);
            AllRoles = _roleManager.Roles.ToList();

            foreach (var item in AllRoles)
            {
                if (Roles.Contains(item.Name))
                {
                    if (!(await _userManager.IsInRoleAsync(CurentUser, item.Name)))
                    {
                        await _userManager.AddToRoleAsync(CurentUser, item.Name);
                    }
                }
                else
                {
                    if (await _userManager.IsInRoleAsync(CurentUser, item.Name))
                    {
                        await _userManager.RemoveFromRoleAsync(CurentUser, item.Name);
                    }
                }
            }
            return RedirectToPage("ListUser");

        }
    }
}
