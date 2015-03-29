using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Homework9.Startup))]
namespace Homework9
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
