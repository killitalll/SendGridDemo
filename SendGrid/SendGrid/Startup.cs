using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SendGrid.Startup))]
namespace SendGrid
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
