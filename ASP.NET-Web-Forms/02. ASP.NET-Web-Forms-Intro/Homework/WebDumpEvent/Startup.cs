using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebDumpEvent.Startup))]
namespace WebDumpEvent
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
