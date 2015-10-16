using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JM.Examples.MVC.Startup))]
namespace JM.Examples.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
