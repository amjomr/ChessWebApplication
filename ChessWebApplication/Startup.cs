using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChessWebApplication.Startup))]
namespace ChessWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
