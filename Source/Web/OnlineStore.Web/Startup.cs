using Microsoft.Owin;
using OnlineStore.Data;
using OnlineStore.Data.Migrations;
using Owin;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(OnlineStore.Web.Startup))]
namespace OnlineStore.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }      
    }
}
