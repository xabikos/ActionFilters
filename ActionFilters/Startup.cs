using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ActionFilters.Startup))]
namespace ActionFilters
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
