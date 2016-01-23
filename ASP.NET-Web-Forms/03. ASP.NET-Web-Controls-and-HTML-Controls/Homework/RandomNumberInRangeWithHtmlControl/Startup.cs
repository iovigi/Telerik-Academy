using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RandomNumberInRangeWithHtmlControl.Startup))]
namespace RandomNumberInRangeWithHtmlControl
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
