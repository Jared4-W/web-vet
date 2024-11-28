using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Examen1_JaredChavez.Startup))]
namespace Examen1_JaredChavez
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
