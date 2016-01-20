using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFormDemoAplication.Startup))]
namespace WebFormDemoAplication
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
