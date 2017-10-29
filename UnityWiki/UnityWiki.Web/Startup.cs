using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UnityWiki.Web.Startup))]
namespace UnityWiki.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
