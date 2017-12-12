using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConsertoPraVoce.Startup))]
namespace ConsertoPraVoce
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
