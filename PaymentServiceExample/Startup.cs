using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PaymentServiceExample.Startup))]
namespace PaymentServiceExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
