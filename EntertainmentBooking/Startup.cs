using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EntertainmentBooking.Startup))]
namespace EntertainmentBooking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
