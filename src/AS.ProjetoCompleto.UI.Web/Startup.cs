using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AS.ProjetoCompleto.UI.Web.Startup))]
namespace AS.ProjetoCompleto.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
