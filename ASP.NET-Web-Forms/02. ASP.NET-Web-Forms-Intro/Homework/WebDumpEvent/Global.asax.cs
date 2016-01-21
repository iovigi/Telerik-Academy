using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebDumpEvent
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Response.Write("Application_Start </br>");
        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            Response.Write("Application_BeginRequest </br>");
        }

        void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            Response.Write("Application_AuthenticateRequest </br>");
        }

        void Session_Start(object sender, EventArgs e)
        {
            Response.Write("Session_Start </br>");
        }

        void Application_EndRequest(object sender, EventArgs e)
        {
            Response.Write("Application_EndRequest </br>");
        }

        void Session_End(object sender, EventArgs e)
        {
            Response.Write("Session_End </br>");
        }

        void Application_End(object sender, EventArgs e)
        {
            Response.Write("Application_End </br>");
        }

        void Application_Error(Object sender, EventArgs e)
        {
            Response.Write("Application_Error </br>");
        }
    }
}