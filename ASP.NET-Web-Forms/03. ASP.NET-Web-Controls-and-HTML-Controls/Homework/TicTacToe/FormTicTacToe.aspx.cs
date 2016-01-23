using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicTacToe
{
    public partial class FormTicTacToe : System.Web.UI.Page
    {
        private readonly string playerMark = "X";
        private readonly string computerMark = "O";

        private static sbyte[,] martix;

        private bool isFinish = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                return;
            }

            martix = new sbyte[3, 3];
        }

        protected void topLeft_Click(object sender, EventArgs e)
        {
            if (topLeft.Text != " " || isFinish)
            {
                return;
            }

            topLeft.Text = playerMark;
            ProcessGame(0, 0);
        }

        protected void topMiddle_Click(object sender, EventArgs e)
        {
            if (topMiddle.Text != " " || isFinish)
            {
                return;
            }

            topMiddle.Text = playerMark;
            ProcessGame(0, 1);
        }

        protected void topRight_Click(object sender, EventArgs e)
        {
            if (topRight.Text != " " || isFinish)
            {
                return;
            }

            topRight.Text = playerMark;
            ProcessGame(0, 2);
        }

        protected void middleLeft_Click(object sender, EventArgs e)
        {
            if (middleLeft.Text != " " || isFinish)
            {
                return;
            }

            middleLeft.Text = playerMark;
            ProcessGame(1, 0);
        }

        protected void middleMiddle_Click(object sender, EventArgs e)
        {
            if (middleMiddle.Text != " " || isFinish)
            {
                return;
            }

            middleMiddle.Text = playerMark;
            ProcessGame(1, 1);
        }

        protected void middleRight_Click(object sender, EventArgs e)
        {
            if (middleRight.Text != " " || isFinish)
            {
                return;
            }

            middleRight.Text = playerMark;
            ProcessGame(1, 2);
        }

        protected void bottomLeft_Click(object sender, EventArgs e)
        {
            if (bottomLeft.Text != " " || isFinish)
            {
                return;
            }

            bottomLeft.Text = playerMark;
            ProcessGame(2, 0);
        }

        protected void bottomMiddle_Click(object sender, EventArgs e)
        {
            if (bottomMiddle.Text != " " || isFinish)
            {
                return;
            }

            bottomMiddle.Text = playerMark;
            ProcessGame(2, 1);
        }

        protected void bottomRight_Click(object sender, EventArgs e)
        {
            if (bottomRight.Text != " " || isFinish)
            {
                return;
            }

            bottomRight.Text = playerMark;
            ProcessGame(2, 2);
        }

        private void ProcessGame(int row, int column)
        {
            martix[row, column] = 1;

            if (CheckWin(1))
            {
                isFinish = true;
                result.Text = "Player win";

                return;
            }

            if (CheckIsSpaceFinish())
            {
                isFinish = true;

                return;
            }

            ComputerMakeMove();

            if (CheckWin(-1))
            {
                isFinish = true;

                result.Text = "Computer win";
            }

            if (CheckIsSpaceFinish())
            {
                isFinish = true;

                return;
            }
        }

        private bool CheckWin(sbyte number)
        {
            if (martix[0, 0] == number && martix[0, 1] == number && martix[0, 2] == number)
            {
                return true;
            }

            if (martix[0, 0] == number && martix[1, 1] == number && martix[2, 2] == number)
            {
                return true;
            }

            if (martix[0, 0] == number && martix[1, 0] == number && martix[2, 0] == number)
            {
                return true;
            }

            if (martix[0, 1] == number && martix[1, 1] == number && martix[2, 1] == number)
            {
                return true;
            }

            if (martix[0, 2] == number && martix[1, 2] == number && martix[2, 2] == number)
            {
                return true;
            }

            if (martix[0, 2] == number && martix[1, 1] == number && martix[2, 0] == number)
            {
                return true;
            }

            if (martix[1, 0] == number && martix[1, 1] == number && martix[1, 2] == number)
            {
                return true;
            }

            if (martix[2, 0] == number && martix[2, 1] == number && martix[2, 2] == number)
            {
                return true;
            }

            return false;
        }

        private void ComputerMakeMove()
        {
            if (martix[0, 0] == 0)
            {
                topLeft.Text = computerMark;
                martix[0, 0] = -1;

                return;
            }

            if (martix[0, 1] == 0)
            {
                topMiddle.Text = computerMark;
                martix[0, 1] = -1;

                return;
            }

            if (martix[0, 2] == 0)
            {
                topRight.Text = computerMark;
                martix[0, 2] = -1;

                return;
            }

            if (martix[1, 0] == 0)
            {
                middleLeft.Text = computerMark;
                martix[1, 0] = -1;

                return;
            }

            if (martix[1, 1] == 0)
            {
                middleMiddle.Text = computerMark;
                martix[1, 1] = -1;

                return;
            }

            if (martix[1, 2] == 0)
            {
                middleRight.Text = computerMark;
                martix[1, 2] = -1;

                return;
            }

            if (martix[2, 0] == 0)
            {
                bottomLeft.Text = computerMark;
                martix[2, 0] = -1;

                return;
            }

            if (martix[2, 1] == 0)
            {
                bottomMiddle.Text = computerMark;
                martix[2, 1] = -1;

                return;
            }

            if (martix[2, 2] == 0)
            {
                bottomRight.Text = computerMark;
                martix[2, 2] = -1;

                return;
            }
        }

        private bool CheckIsSpaceFinish()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (martix[i, j] == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}