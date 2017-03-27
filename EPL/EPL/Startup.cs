using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EPL.Startup))]
namespace EPL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
