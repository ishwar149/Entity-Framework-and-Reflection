using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AsianStoreUI.Startup))]
namespace AsianStoreUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
