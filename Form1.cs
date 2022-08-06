using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Animator.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.label2, "Выход");

        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void yt_Button1_Click_1(object sender, EventArgs e)
        {
            menu s = new menu();
            s.Show();
            this.Hide();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void yt_Button2_Click(object sender, EventArgs e)
        {
            registr s = new registr();
            s.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
