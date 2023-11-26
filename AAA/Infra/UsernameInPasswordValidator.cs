using AAA.Models;
using Microsoft.AspNetCore.Identity;

namespace AAA.Infra
{
    public class UsernameInPasswordValidator : IPasswordValidator<customIdentityUser>
    {
        private readonly List<string> blackList = new()
        {
            "database",".netframework","redis"
        };
        public Task<IdentityResult> ValidateAsync(UserManager<customIdentityUser> manager, customIdentityUser user, string? password)
        {
            foreach (var item in blackList) 
            { 
                if(password.Contains(item))
                          return Task.FromResult(IdentityResult.Failed(new IdentityError
                          {
                              Code = "password is in black list",
                              Description = "You can not use this password, because it's in black list",
                          }));
            }
            if (password.Contains(user.UserName,StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "UsernameInPassword",
                    Description = "You can not use your username in Password",
                }));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
}
