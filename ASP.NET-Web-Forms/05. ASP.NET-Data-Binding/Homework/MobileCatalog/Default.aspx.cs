using System;
using System.Collections.Generic;
using System.Text;

namespace MobileCatalog
{
    public partial class Default : System.Web.UI.Page
    {
        private List<Producer> producers = new List<Producer>
        {
            new Producer() { Name="BMW", Models=new List<string> (){ "320", "520", "525" } },
            new Producer() { Name="Mercedes", Models=new List<string> (){ "A", "B", "C" } },
            new Producer() { Name="Audi", Models=new List<string> (){ "A6", "80", "A6" } }
        };

        private List<string> extras = new List<string>()
        {
            "USB, audio/video, IN/AUX" ,
            "MP3"
        };

        private List<string> typeOfEngine = new List<string>()
        {
            "Diesel",
            "Petrol",
            "Electrical",
            "Hybrid"
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }

            this.DropDownListProducers.DataSource = this.producers;
            this.DropDownListProducers.DataBind();

            this.DropDownListModel.DataSource = this.producers[0].Models;
            this.DropDownListModel.DataBind();

            this.CheckBoxListExtras.DataSource = this.extras;
            this.CheckBoxListExtras.DataBind();

            this.RadioButtonListEngine.DataSource = this.typeOfEngine;
            this.RadioButtonListEngine.DataBind();
            this.RadioButtonListEngine.SelectedIndex = 0;
        }

        protected void DropDownListProducers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedProducer = this.producers[this.DropDownListProducers.SelectedIndex];
            this.DropDownListModel.DataSource = selectedProducer.Models;
            this.DropDownListModel.DataBind();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder();
            string producer = this.DropDownListProducers.SelectedValue;
            result.AppendLine(
                "Producer: <b>" + Server.HtmlEncode(producer) + "</b><br/>");
            string model = this.DropDownListModel.SelectedValue;
            result.AppendLine(
                "Model: <b>" + Server.HtmlEncode(model) + "</b><br/>");
            for (int i = 0; i < CheckBoxListExtras.Items.Count; i++)
            {
                if (CheckBoxListExtras.Items[i].Selected)
                {
                    string extra = CheckBoxListExtras.Items[i].Text;
                    result.AppendLine(
                        "Extra: <b>" + Server.HtmlEncode(extra) + "</b><br/>");
                }
            }
            string engine = RadioButtonListEngine.SelectedItem.Text;
            result.AppendLine(
                "Engine: <b>" + Server.HtmlEncode(engine) + "</b><br/>");

            this.Result.Visible = true;
            this.Result.Text = result.ToString();
        }
    }
}