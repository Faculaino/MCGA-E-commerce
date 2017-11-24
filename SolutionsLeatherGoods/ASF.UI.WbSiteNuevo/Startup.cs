using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASF.UI.WbSiteNuevo.Startup))]
namespace ASF.UI.WbSiteNuevo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
