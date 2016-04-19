using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ajaxprj1.Startup))]
namespace ajaxprj1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
