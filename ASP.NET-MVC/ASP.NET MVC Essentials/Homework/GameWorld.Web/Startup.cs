using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameWorld.Web.Startup))]
namespace GameWorld.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
