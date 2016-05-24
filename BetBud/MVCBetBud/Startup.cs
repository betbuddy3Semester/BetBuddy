using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCBetBud.Startup))]
namespace MVCBetBud
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
