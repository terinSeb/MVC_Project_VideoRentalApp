using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyAppWithLatestAuth.Startup))]
namespace VidlyAppWithLatestAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
