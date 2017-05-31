using Microsoft.Owin;
using Owin;
using SuperChat;

[assembly: OwinStartup(typeof(Startup))]

namespace SuperChat
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
