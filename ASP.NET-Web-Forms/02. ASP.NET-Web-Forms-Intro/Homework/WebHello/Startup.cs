using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebHello.Startup))]
namespace WebHello
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
