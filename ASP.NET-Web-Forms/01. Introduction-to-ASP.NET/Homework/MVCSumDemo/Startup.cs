using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCSumDemo.Startup))]
namespace MVCSumDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
