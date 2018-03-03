using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(calu4_t7.Startup))]
namespace calu4_t7
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
