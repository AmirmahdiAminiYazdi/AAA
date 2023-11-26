using Microsoft.AspNetCore.Identity;

namespace AAA.Models
{
    public class customIdentityUser : IdentityUser 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
