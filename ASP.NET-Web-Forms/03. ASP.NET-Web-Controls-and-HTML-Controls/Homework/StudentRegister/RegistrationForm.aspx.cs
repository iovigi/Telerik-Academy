using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentRegister
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            var title = "<h1>Student Detail:</h2>";
            var fullname = "<p>Fullname:" + firstName.Text + " " + lastName.Text + "</p>";
            var facultyNumber = "<p>facultyNumber:" + this.facultyNumber.Text + "</p>";
            var university = "<p>university:" + this.listUniversities.SelectedValue + "</p>";
            var specialty = "<p>specialty :" + this.listOfSpeciality.SelectedValue + "</p>";
            var courses = "<p>courses :" + 
                string.Join(",", this.courses.Items.Cast<ListItem>().Where(x => x.Selected).Select(x => x.Value)) 
                + "</p>";

            this.registerContainer.Controls.Add(new LiteralControl(title));
            this.registerContainer.Controls.Add(new LiteralControl(fullname));
            this.registerContainer.Controls.Add(new LiteralControl(facultyNumber));
            this.registerContainer.Controls.Add(new LiteralControl(university));
            this.registerContainer.Controls.Add(new LiteralControl(specialty));
            this.registerContainer.Controls.Add(new LiteralControl(courses));
        }
    }
}