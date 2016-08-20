using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExPhO.Startup))]
namespace ExPhO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
