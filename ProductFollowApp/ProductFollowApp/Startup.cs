using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductFollowApp.Startup))]
namespace ProductFollowApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
