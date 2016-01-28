using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserRegister
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                return;
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            this.Page.Validate();
        }

        protected void CustomValidatorAccept_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = CheckBoxAccept.Checked;
        }

        protected void Index_Changed(object sender, EventArgs e)
        {
            CheckBoxListMaleCars.Visible = false;
            CheckBoxListFemaleCoffee.Visible = false;

            if (RadioButtonSex.SelectedValue == "Male")
            {
                CheckBoxListMaleCars.Visible = true;
            }
            else if (RadioButtonSex.SelectedValue == "Female")
            {
                CheckBoxListFemaleCoffee.Visible = true;
            }
        }
    }
}