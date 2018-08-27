using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApiDemo.Startup))]
namespace WebApiDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
