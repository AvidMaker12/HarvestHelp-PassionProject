using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HarvestHelp_PassionProject.Startup))]
namespace HarvestHelp_PassionProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
