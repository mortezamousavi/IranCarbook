using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Irancarbook.Startup))]
namespace Irancarbook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
