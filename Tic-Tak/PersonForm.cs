using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tic_Tak
{
    public partial class PersonForm : Form
    {
        GameController controller = new GameController(true);
        Button[] buttons = new Button[9];
        public PersonForm()
        {
            InitializeComponent();
        }

        private void PersonForm_Load(object sender, EventArgs e)
        {
            buttons[0] = button1; buttons[1] = button2; buttons[2] = button3;
            buttons[3] = button4; buttons[4] = button5; buttons[5] = button6;
            buttons[6] = button7; buttons[7] = button8; buttons[8] = button9;

            for (int i =0; i < buttons.Length; i++)
            {
                buttons[i].Text ="";
            }
            label1.Text = "Ходит первый игрок";

        }

        private void click(int butIndex)
        {

            if (controller.getFirst())
            {
                buttons[butIndex].Text = "X";
            }
            else
            {
                buttons[butIndex].Text = "0";
            }
            controller.setMatrix(butIndex + 1);

            if (controller.check())
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Enabled = false;
                }
                label1.Text = controller.getWinnerName();
            }
            else
            {
                controller.changeFirst();
                label1.Text = controller.getName();
            }
            buttons[butIndex].Enabled = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            click(0);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            click(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            click(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            click(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            click(4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            click(5);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            click(6);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            click(7);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            click(8);
        }
    }
}
