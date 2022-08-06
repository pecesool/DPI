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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
            Animator.Start();
        }

        private void menu_Load(object sender, EventArgs e)
        {
            egoldsCard1.TextDescrition = "DPI - это автоматизированная система диагностики физических показателей учащихся, для объективного отбора учащихся на спортивные секции.\n\n";
            toolTip1.SetToolTip(this.pictureBox2, "ВЫХОД");
        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {
            if (yt_Button1.Text == "<<")
            {

                label5.Width = 50;
                label2.Width = 50;
                yt_Button1.Text = ">>";
                button1.Visible = false;
                egoldsCard1.Visible = false;
                egoldsCard2.Visible = false;
                comboBox1.Visible = false;
                comboBox2.Visible = false;
                button6.Visible = false;
                label4.Visible = false;
                label8.Visible = false;
                yt_Button1.Location = new System.Drawing.Point(49, -4);
            }
            else
            {
                label5.Width = 195;
                label2.Width = 197;
                yt_Button1.Text = "<<";
                comboBox1.Visible = true;
                egoldsCard1.Visible = true;
                egoldsCard2.Visible = true;
                label8.Visible = true;
                button1.Visible = true;
                comboBox2.Visible = true;
                button6.Visible = true;
                label4.Visible = true;
                yt_Button1.Location = new System.Drawing.Point(195, -4);
                label3.Visible = false;
                label6.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            yt_Button1.Text = ">>";
            label3.Visible = true;
            label6.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
            label5.Width = 52;
            label2.Width = 50;

            button1.Visible = false;
            egoldsCard1.Visible = false;
            egoldsCard2.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            button6.Visible = false;
            label4.Visible = false;
            label8.Visible = false;
            yt_Button1.Location = new System.Drawing.Point(49, -4);
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == " Добавить класс") { addclass s = new addclass(); s.Show(); this.Hide(); }
            if (comboBox1.Text == " Добавить ученика") { adduch s = new adduch(); s.Show(); this.Hide(); }
            if (comboBox1.Text == " Сдача нормативов") { addnorm s = new addnorm(); s.Show(); this.Hide(); }
        }


        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == " Персональный отчет") { choose s = new choose(); s.Show(); this.Hide(); }
            if (comboBox2.Text == " Отчeт для класса") { clotch s = new clotch(); s.Show(); this.Hide(); }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            navigate s = new navigate();
            s.Show();
            this.Hide();
        }
    }
}
