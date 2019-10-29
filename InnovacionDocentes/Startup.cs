using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InnovacionDocentes.Startup))]
namespace InnovacionDocentes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
