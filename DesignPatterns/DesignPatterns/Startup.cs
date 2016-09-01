using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DesignPatterns.Startup))]
namespace DesignPatterns
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
