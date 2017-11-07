using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhysicianDirectory.Startup))]
namespace PhysicianDirectory
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
