using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineHospitalSystem.Startup))]
namespace OnlineHospitalSystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
