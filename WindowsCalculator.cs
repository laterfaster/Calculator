using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using exp6lib;

namespace exp6app
{
    public partial class WindowsCalculator : Form
    {
        public WindowsCalculator()
        {
            InitializeComponent();
        }

        private void WindowsCalculator_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label1.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label1.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label1.Text += "8";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            label1.Text += "9";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label1.Text += "00";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            label1.Text += "0";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            label1.Text += ".";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            label1.Text = label1.Text.Substring(0, label1.Text.Length - 1);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            label1.Text += " + ";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            label1.Text += " - ";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            label1.Text += " * ";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            label1.Text += " / ";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            label1.Text += " ( ";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            label1.Text += " ) ";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            char[] charSeparators = new char[] { ' ' };
            string[] target = label1.Text.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            if (Calculator.Check(target))
                label1.Text = Calculator.ResultOf(target).ToString();
            else label1.Text = "非法输入";
            if(Calculator.wrong)
                label1.Text = "非法输入";

        }
    }
}
