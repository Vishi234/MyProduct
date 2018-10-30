using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hangfire;
using Hangfire.SqlServer;

[assembly: OwinStartup(typeof(Invent.Startup))]

namespace Invent
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
            .UseSqlServerStorage("DBCONN");
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}
