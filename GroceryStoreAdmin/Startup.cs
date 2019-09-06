using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GroceryStoreAdmin.Startup))]
namespace GroceryStoreAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
