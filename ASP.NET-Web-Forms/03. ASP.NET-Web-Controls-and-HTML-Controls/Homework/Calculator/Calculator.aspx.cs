using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calculator
{
    public partial class Calculator : System.Web.UI.Page
    {
        private static Operation operation = Operation.None;
        private static double prevNumber;

        protected void DigitPress(object sender, EventArgs e)
        {
            var button = (Button)sender;

            input.Text += button.Text;
        }

        protected void OperationPress(object sender, EventArgs e)
        {
            var button = (Button)sender;

            switch (button.Text)
            {
                case "+":
                    {
                        operation = Operation.Sum;
                    }
                    break;
                case "-":
                    {
                        operation = Operation.Substract;
                    }
                    break;
                case "X":
                    {
                        operation = Operation.Multiply;
                    }
                    break;
                case "/":
                    {
                        operation = Operation.Divede;
                    }
                    break;
                case "sqrt":
                    {
                        double currentNumber = 0;
                        if (!double.TryParse(input.Text, out currentNumber))
                        {
                            input.Text = "";

                            return;
                        }

                        if (currentNumber < 1)
                        {
                            input.Text = "";

                            return;
                        }

                        input.Text = Math.Sqrt((double)currentNumber).ToString();
                    }
                    return;
            }

            if (!double.TryParse(input.Text, out prevNumber))
            {
                prevNumber = 0;
            }

            input.Text = "";
        }

        protected void ClearClick(object sender, EventArgs e)
        {
            operation = Operation.None;
            prevNumber = 0;
            input.Text = "";
        }

        protected void result_Click(object sender, EventArgs e)
        {
            if (operation == Operation.None)
            {
                return;
            }

            double currentNumber = 0;
            if (!double.TryParse(input.Text, out currentNumber))
            {
                input.Text = "";

                return;
            }

            if (operation == Operation.Sum)
            {
                input.Text = (currentNumber + prevNumber).ToString();

                return;
            }

            if (operation == Operation.Substract)
            {
                input.Text = (currentNumber - prevNumber).ToString();

                return;
            }

            if (operation == Operation.Multiply)
            {
                input.Text = (currentNumber * prevNumber).ToString();

                return;
            }

            if (operation == Operation.Divede)
            {
                if (currentNumber == 0 || prevNumber == 0)
                {
                    input.Text = "";

                    return;
                }

                input.Text = (currentNumber / prevNumber).ToString();

                return;
            }
        }
    }

    public enum Operation
    {
        None,
        Sum,
        Substract,
        Multiply,
        Sqrt,
        Divede
    }
}