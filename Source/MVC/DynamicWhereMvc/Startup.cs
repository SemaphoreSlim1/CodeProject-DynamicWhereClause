using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DynamicWhereMvc.Startup))]
namespace DynamicWhereMvc
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {}
    }
}