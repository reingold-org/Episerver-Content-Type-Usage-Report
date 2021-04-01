using System.Web.Mvc;
using System.Web.Routing;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;

namespace Reingold.Episerver.Reports.ContentTypeUsage
{
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    [InitializableModule]
    public class ContentTypeUsageReportInitialization : IInitializableModule
    {
        private static bool initialized;

        public void Initialize(InitializationEngine context)
        {
            if (initialized || context.HostType != HostType.WebApplication)
            {
                return;
            }

            RouteTable.Routes.MapRoute("Reingold Content Type Usage Report",
                "modules/reingold/reports/contenttypeusage/{action}", 
                new
                { 
                    controller = "ContentTypeUsageReport", 
                    action = "Index" 
                });

            initialized = true;
        }

        public void Uninitialize(InitializationEngine context)
        {

        }
    }
}