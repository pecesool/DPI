using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DPI
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=pecesool;password=1234;database=dpi");
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
        Classes.FUNC func = new Classes.FUNC();
        private void yt_Button1_Click_1(object sender, EventArgs e)
        {
            string log = egoldsGoogleTextBox1.Text;
            string pas = egoldsGoogleTextBox2.Text;
            MySqlCommand command2 = new MySqlCommand("SELECT * FROM `users`");
            DataTable users = func.getData(command2);
            bool d =true;
            for (int i = 0; i < users.Rows.Count; i++)
            {
                if (log == users.Rows[i]["Login"].ToString() && pas== users.Rows[i]["Password"].ToString())
                {
                    d = true;
                   menu s = new menu();
                s.Show();
                Hide();
                    break;
                }
                else { d= false; }
                
            }
            if (d == false) 
            {
                MessageBox.Show("Неправильный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                egoldsGoogleTextBox1.Text = "";
                egoldsGoogleTextBox2.Text = "";
            }
            
            
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
