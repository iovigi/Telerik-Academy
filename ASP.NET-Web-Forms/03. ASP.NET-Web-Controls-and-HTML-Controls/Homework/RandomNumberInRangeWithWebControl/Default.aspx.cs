using System;

namespace RandomNumberInRangeWithWebControl
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GenerateRandomNumber_Click(object sender, EventArgs e)
        {
            int downBoundry = int.MinValue;
            int upBoundry = int.MaxValue;

            if (!int.TryParse(firstRange.Text, out downBoundry))
            {
                downBoundry = int.MinValue;
            }

            if (!int.TryParse(secondRange.Text, out upBoundry))
            {
                upBoundry = int.MaxValue;
            }

            Random rand = new Random();

            randomNumberContainer.Text = rand.Next(downBoundry, upBoundry).ToString();
        }
    }
}