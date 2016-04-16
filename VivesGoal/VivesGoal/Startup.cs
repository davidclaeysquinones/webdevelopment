using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VivesGoal.Startup))]
namespace VivesGoal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
