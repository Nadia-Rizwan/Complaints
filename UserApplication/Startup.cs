using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UserApplication.Startup))]
namespace UserApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
