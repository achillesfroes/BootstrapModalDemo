using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ModalDemo.Startup))]
namespace ModalDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
