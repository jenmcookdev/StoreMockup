using uStoreMvc.Models;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System;

namespace uStoreMvc
{
    // Note: For instructions on enabling IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=301868
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Application["launchTimestamp"] = DateTime.Now;
        }//Application_Start()

        protected void Application_Error()
        {
            //Comment out when coding in order to view errors & debug.  
            //Uncomment when ready to deploy

            //Response.Redirect("/error.html");
            Response.Redirect("~/Content/images/error.png");

        }//Application_Error()
    }//class
}//namespace
