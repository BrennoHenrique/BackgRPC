using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace BackgRPC.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class UserAuthorizationAttribute : Attribute, IAuthorizeData, IAsyncAuthorizationFilter
    {
        public string Policy { get; set; }
        public string Roles { get; set; }
        public string AuthenticationSchemes { get; set; }

        public UserAuthorizationAttribute()
        {
            AuthenticationSchemes = "UserAuthorization";
        }

        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            throw new NotImplementedException();
        }
    }
}