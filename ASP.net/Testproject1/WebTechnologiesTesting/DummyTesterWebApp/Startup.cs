using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DummyTesterWebApp.Startup))]
namespace DummyTesterWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
