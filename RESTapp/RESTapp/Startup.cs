using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RESTapp.Startup))]
namespace RESTapp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
