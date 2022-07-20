using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using tawsel.models;

namespace tawsel.Helpers
{
    public class RequestsFilter : Attribute, IAsyncActionFilter
    {
        string Permission;
        string Controller;
        tawseel Context;
        public RequestsFilter(string action, string controller)
        {
            Permission = action;
            Controller = controller;
            Context = new tawseel();
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var token = getToken(context);
            var role = GetRole(token);

            var requestIsAuthorized = Context.PremissionRoleControllers.
                Any(r => r.page.name == Controller && r.permission.Name == Permission && r.role.Name == role);

            if (requestIsAuthorized)
            {
                await next();
            }

            context.HttpContext.Response.StatusCode = 401;
        }

        string getToken(ActionExecutingContext context)
        {
            return context.HttpContext.Request.Headers["Authorization"][0].Split(" ")[1];


             
        }


        string GetRole(string token)
        {
            string secret = "StrONGKAutHENTICATIONKEy";
            var key = Encoding.ASCII.GetBytes(secret);
            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            var claimsPrinciple = handler.ValidateToken(token, validations, out var tokenSecure);
            var role = claimsPrinciple.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            return role.ElementAt(0);
        }
    }
}
