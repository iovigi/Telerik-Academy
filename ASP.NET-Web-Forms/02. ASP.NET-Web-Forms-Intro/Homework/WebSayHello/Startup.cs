using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSayHello.Startup))]
namespace WebSayHello
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
