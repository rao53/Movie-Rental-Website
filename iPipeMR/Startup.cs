using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(iPipeMR.Startup))]
namespace iPipeMR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
