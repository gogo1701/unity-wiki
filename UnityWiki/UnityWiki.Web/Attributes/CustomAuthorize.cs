using System.Web;
using System.Web.Mvc;

namespace UnityWiki.Web.Attributes
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            string url = HttpUtility.UrlEncode(filterContext.HttpContext.Request.Url.AbsolutePath);

            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("/");
            }
            else
            {
                filterContext.Result = new RedirectResult($"/account/login?ReturnUrl={url}");
            }
        }
    }
}