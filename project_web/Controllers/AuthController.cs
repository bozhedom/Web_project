using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using project_web.Enums;
using project_web.Objects;
using System.Security.Claims;

namespace project_web.Controllers
{
    public class AuthController : Controller
    {
        [HttpPost]
        [Route("auth/login")]
        public async Task<AuthInfo> Login([FromBody] AuthInput input)
            {
            if (input.Login == "test" && input.Password == "admin")
            {
                await SetCookies(input.Login, RoleType.Admin);
                return AuthInfo.Success(RoleType.Admin);
            }

            return AuthInfo.Fail();
        }

        [HttpGet]
        [Route("auth/logout")]
        public async Task<AuthInfo> Logout()
        {
            await RemoveCookies();
            return AuthInfo.Fail();
        }

        [HttpGet]
        [Route("auth/getInfo")]
        public AuthInfo GetInfo()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                string role = User.FindFirstValue(ClaimsIdentity.DefaultRoleClaimType);
                RoleType roleType = Role.FromString(role);
                return AuthInfo.Success(roleType);
            }

            return AuthInfo.Fail();
        }

        #region private
        private async Task SetCookies(string login, RoleType role)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, role.ToString())
                };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await AuthenticationHttpContextExtensions.SignInAsync(HttpContext, new ClaimsPrincipal(id));
        }

        private async Task RemoveCookies()
        {
            await AuthenticationHttpContextExtensions.SignOutAsync(HttpContext);
        }
        #endregion
    }
}