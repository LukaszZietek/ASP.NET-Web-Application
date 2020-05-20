using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRUDOProject.Startup))]
namespace CRUDOProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
