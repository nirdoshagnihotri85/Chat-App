using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LetsChat.Startup))]
namespace LetsChat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
