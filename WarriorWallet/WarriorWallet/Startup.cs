using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WarriorWallet.Startup))]
namespace WarriorWallet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
