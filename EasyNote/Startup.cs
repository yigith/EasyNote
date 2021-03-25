using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EasyNote.Startup))]
namespace EasyNote
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
