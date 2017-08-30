using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NorthWindDB.Startup))]
namespace NorthWindDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
