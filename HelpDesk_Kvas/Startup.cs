using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelpDesk_Kvas.Startup))]
namespace HelpDesk_Kvas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
