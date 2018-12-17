using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Contacts.Web.Startup))]
namespace Contacts.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
