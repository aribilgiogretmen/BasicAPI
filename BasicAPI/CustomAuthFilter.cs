using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BasicAPI
{
    public class CustomAuthFilter : Attribute, IAuthorizationFilter
    {

        private const string API_KEY = "123456789";

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            if (!context.HttpContext.Request.Headers.TryGetValue("X-API-KEY", out var extractApiKey))
            {

                context.Result = new UnauthorizedObjectResult(new { Message = "Apı key Bulunamadı" });
                return;

            }

            if (!API_KEY.Equals(extractApiKey))
            {

                context.Result = new UnauthorizedObjectResult(new { Message = "Yetkisiz APi Key" });
                return;

            }

        }
    }
}
