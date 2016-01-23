using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RandomNumberInRangeWithHtmlControl
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void button_Click(object sender, EventArgs e)
        {
            int downBoundry = int.MinValue;
            int upBoundry = int.MaxValue;

            var downBoundryControl = (HtmlInputText)this.FindControl("firstRange");
            if (!int.TryParse(downBoundryControl.Value, out downBoundry))
            {
                downBoundry = int.MinValue;
            }

            var upBoundryControl = (HtmlInputText)this.FindControl("secondRange");
            if (!int.TryParse(upBoundryControl.Value, out upBoundry))
            {
                upBoundry = int.MaxValue;
            }


            Random rand = new Random();

           var control  = (HtmlGenericControl)this.FindControl("randomNumberContainer");
            control.InnerText = rand.Next(downBoundry, upBoundry).ToString();
        }
    }
}