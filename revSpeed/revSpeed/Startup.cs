using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(revSpeed.Startup))]
namespace revSpeed
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
