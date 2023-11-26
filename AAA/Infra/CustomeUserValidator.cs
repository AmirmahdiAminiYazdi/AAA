using Microsoft.AspNetCore.Identity;

namespace AAA.Infra
{
    public class CustomeUserValidator : IUserValidator<IdentityUser>
    {
        private readonly string organizationEmail = "Microsoft.com";
        public Task<IdentityResult> ValidateAsync(UserManager<IdentityUser> manager, IdentityUser user)
        {
            if (!user.Email.EndsWith(organizationEmail,StringComparison.OrdinalIgnoreCase)) 
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "Invalid Email",
                    Description = "You should use your organization Email",
                }));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
}
