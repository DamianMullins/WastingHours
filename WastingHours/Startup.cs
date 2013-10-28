using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WastingHours.Startup))]
namespace WastingHours
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
