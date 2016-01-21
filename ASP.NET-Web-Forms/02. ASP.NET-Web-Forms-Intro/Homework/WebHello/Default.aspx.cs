using System;
using System.Reflection;
using System.Web.UI;

namespace WebHello
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Hello, ASP.NET<br />");
            Response.Write(Assembly.GetExecutingAssembly().Location);
        }
    }
}