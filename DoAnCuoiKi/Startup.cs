using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoAnCuoiKi.Startup))]
namespace DoAnCuoiKi
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
