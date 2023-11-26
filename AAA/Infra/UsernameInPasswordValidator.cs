using Microsoft.AspNetCore.Identity;

namespace AAA.Infra
{
    public class UsernameInPasswordValidator : IPasswordValidator<IdentityUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<IdentityUser> manager, IdentityUser user, string? password)
        {
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
