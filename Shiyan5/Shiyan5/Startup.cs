using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shiyan5.Startup))]
namespace Shiyan5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
