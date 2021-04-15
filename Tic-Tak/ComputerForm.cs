using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tic_Tak
{
    public partial class ComputerForm : Form
    {
        GameController controller;
        GameLogic logic;
        Button[] buttons = new Button[9];
        int[] freeValues = new int[9];
        Random rand = new Random();
        bool game = true;
        int value, level;
        public ComputerForm()
        {
            InitializeComponent();
        }

        private void ComputerForm_Load(object sender, EventArgs e)
        {
            value = rand.Next(0,2);

            buttons[0] = button1; buttons[1] = button2; buttons[2] = button3;
            buttons[3] = button4; buttons[4] = button5; buttons[5] = button6;
            buttons[6] = button7; buttons[7] = button8; buttons[8] = button9;

            for (int i = 0; i < buttons.Length; i++)
            {
                freeValues[i] = i;
                buttons[i].Text = "";
            }
            label1.Text = value.ToString();
            
            if (value == 0)
            {
                controller = new GameController(true);
                logic = new GameLogic(controller.getMatrix(), 1);
            }
            else
            {
                controller = new GameController(false);
                logic = new GameLogic(controller.getMatrix(), 1);
            }
        }

        private int [] changeArr(int var)
        {
            int[] mass = new int[freeValues.Length-1];
            int c = 0;

            for (int i = 0; i < freeValues.Length; i++)
            {
                if (freeValues[i] != var)
                {
                    mass[c] = freeValues[i];
                    c++;
                }
            }
            return mass;
        }
        
        private void computerStep()
        {
            label2.Text = level.ToString();
            if (level == 0)
            {
                int var =-1;
                if (freeValues.Length>0) var = freeValues[rand.Next(0, freeValues.Length)];
                freeValues = changeArr(var);
                click(true, var);
            } else
            {
                //computerLogic
                int[] m = logic.step(level);
                if (m[0] == -1 && m[1] == -1)
                {
                    int var = -1;
                    if (freeValues.Length > 0) var = freeValues[rand.Next(0, freeValues.Length)];
                    freeValues = changeArr(var);
                    click(true, var);
                }
                else
                {
                    int var = m[0] * 3 + m[1];
                    if (var == 0)
                    {
                        var = 0;
                    }
                    if (freeValues.Length > 0) freeValues = changeArr(var);
                    click(true, -1, m[0], m[1]);
                }

            }
        }

        private void click(bool comp = false, int butIndex = -1, int y =-1, int x = -1 )
        {
            Console.WriteLine(x + " " + y);
            if (butIndex >= 0) controller.setMatrix(butIndex + 1);
            else
            {
                controller.setMatrix(-1, y, x);
                butIndex = y * 3 + x;
            }
            controller.changeFirst();
            label1.Text = controller.getName();
            if (controller.getFirst())
            {
                buttons[butIndex].Text = "0";
            }
            else
            {
                buttons[butIndex].Text = "X";
            }
            if (controller.check())
            {
                game = false;
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Enabled = false;
                }
                label1.Text = controller.getWinnerName();
            }
            else
            {
                if (!comp && freeValues.Length > 0) freeValues = changeArr(butIndex);
                if (freeValues.Length == 0)
                {
                    game = false;
                    label1.Text = "Ничья";
                }
                
                if (comp) return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(button1.Text == "X" || button1.Text == "0")) { 
                click(false, 0);
                if (game )computerStep();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!(button2.Text == "X" || button2.Text == "0"))
            {
                click(false, 1);
                if (game) computerStep();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!(button3.Text == "X" || button3.Text == "0"))
            {
                click(false, 2);
                if (game) computerStep();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!(button4.Text == "X" || button4.Text == "0"))
            {
                click(false, 3);
                if (game) computerStep();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!(button5.Text == "X" || button5.Text == "0"))
            {
                click(false, 4);
                if (game) computerStep();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!(button6.Text == "X" || button6.Text == "0"))
            {
                click(false, 5);
                if (game) computerStep();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!(button7.Text == "X" || button7.Text == "0"))
            {
                click(false, 6);
                if (game) computerStep();
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (!(button8.Text == "X" || button8.Text == "0"))
            {
                click(false, 7);
                if (game) computerStep();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!(button9.Text == "X" || button9.Text == "0"))
            {
                click(false, 8);
                if (game) computerStep();
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            level = Int32.Parse(comboBox1.SelectedItem.ToString());
            if (value == 1) computerStep();
        }
    }
}
