using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute("AMKOConfig", typeof(AMKO.Startup))]
namespace AMKO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
