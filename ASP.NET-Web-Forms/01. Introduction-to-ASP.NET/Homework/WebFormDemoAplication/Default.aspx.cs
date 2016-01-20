using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormDemoAplication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonSum_Click(object sender, EventArgs e)
        {
            double x;
            double y;

            if (!double.TryParse(TextBoxNumberX.Text, out x))
            {
                TextBoxResult.Text = "Invalid x";

                return;
            }

            if (!double.TryParse(TextBoxNumberY.Text, out y))
            {
                TextBoxResult.Text = "Invalid y";

                return;
            }

            TextBoxResult.Text = (x + y).ToString();
        }
    }
}