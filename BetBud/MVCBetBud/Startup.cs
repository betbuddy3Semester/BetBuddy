using Microsoft.Owin;
using MVCBetBud;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

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