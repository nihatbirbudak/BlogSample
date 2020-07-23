
using BlogSample.WebUI.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSample.WebUI.CustomHandler
{
    public class RolesAuthorizationHandler :
        AuthorizationHandler<RolesAuthorizationRequirement>, IAuthorizationHandler
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            RolesAuthorizationRequirement requirement)
        {

            if (context.User == null || !context.User.Identity.IsAuthenticated)
            {
                context.Fail();
                return Task.CompletedTask;
            }
            var validRole = false;

            if (requirement.AllowedRoles == null ||
               requirement.AllowedRoles.Any() == false)
            {
                validRole = true;
            }
            else
            {
                var claims = context.User.Claims;
                var userDTO = BloggerConvert.BloggerJsonDeSerializeUserDTO(claims.FirstOrDefault(z => z.Type == "UserDTO").Value);
                var roles = requirement.AllowedRoles;

                if (roles.Contains(userDTO.roleDTO.Name))
                {
                    validRole = true;
                }
            }
            if (validRole)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;

        }
    }
}
