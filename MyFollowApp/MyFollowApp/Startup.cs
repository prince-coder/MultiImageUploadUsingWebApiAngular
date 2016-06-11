using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyFollowApp.Startup))]
namespace MyFollowApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
