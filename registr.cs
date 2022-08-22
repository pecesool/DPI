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
    public partial class registr : Form
    {
        public registr()
        {
            InitializeComponent();
        }

        private void registr_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.label1, "Закрыть окно");
            toolTip2.SetToolTip(this.egoldsGoogleTextBox6, "Логин должен быть уникальным и содержать только латинские буквы.\nПароль должен содержать как минимум 8 символов, 1 букву, 1 цифру и 1 знак.");
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        int b;
        private void egoldsGoogleTextBox1_TextChanged(object sender, EventArgs e)
        {
            string gg;
            gg = egoldsGoogleTextBox1.Text;

            if (b == 0)
            {
                if (gg.Length == 1) { progressBar1.Value += 15; b = 1; }
            }
            if (gg.Length == 0) { progressBar1.Value -= 15; b = 0; }
        }
        int b1;
        private void egoldsGoogleTextBox2_TextChanged(object sender, EventArgs e)
        {
            string gg;
            gg = egoldsGoogleTextBox2.Text;

            if (b1 == 0)
            {
                if (gg.Length == 1) { progressBar1.Value += 15; b1 = 1; }
            }
            if (gg.Length == 0) { progressBar1.Value -= 15; b1 = 0; }
        }
        int b2;
        private void egoldsGoogleTextBox3_TextChanged(object sender, EventArgs e)
        {
            string gg;
            gg = egoldsGoogleTextBox3.Text;

            if (b2 == 0)
            {
                if (gg.Length == 1) { progressBar1.Value += 15; b2 = 1; }
            }
            if (gg.Length == 0) { progressBar1.Value -= 15; b2 = 0; }
        }
        int b3;
        private void egoldsGoogleTextBox4_TextChanged(object sender, EventArgs e)
        {
            string gg;
            gg = egoldsGoogleTextBox4.Text;

            if (b3 == 0)
            {
                if (gg.Length == 1) { progressBar1.Value += 15; b3 = 1; }
            }
            if (gg.Length == 0) { progressBar1.Value -= 15; b3 = 0; }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) { progressBar1.Value += 10; } else { progressBar1.Value -= 10; }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true) { progressBar1.Value += 10;  } else { progressBar1.Value -= 10; }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        int dr, error;
        string im, fam, ot ;
        int b0;
        private void egoldsGoogleTextBox5_TextChanged(object sender, EventArgs e)
        {
            string gg;
            gg = egoldsGoogleTextBox5.Text;

            if (b0 == 0)
            {
                if (gg.Length == 1) { progressBar1.Value += 15; b0 = 1; }
            }
            if (gg.Length == 0) { progressBar1.Value -= 15; b0 = 0; }
        }
        int pa, pa1, pa2, pa3;

        private void egoldsGoogleTextBox6_Click(object sender, EventArgs e)
        {

        }

        int s =1, s1=1, s2=1, s3=1;
        int p;
        private void egoldsGoogleTextBox6_TextChanged(object sender, EventArgs e)
        {
            
            string pas = egoldsGoogleTextBox6.Text;
            //проверка длины пароля
            if (pa == 0)
            {
                if (pas.Length < 7) { progressBar1.Value += 0; } else { progressBar1.Value += 4;p += 4; ; pa = 1;s = 0; }
            }
            if (s == 0)
            {
                if (pas.Length < 8) { progressBar1.Value -= 4; s = 1;pa = 0; }
            }
            //проверка наличия латинских букв
            if (pa1 == 0)
            {
                for (int i = 0; i < pas.Length; i++) { if (pas[i] >= 'A' && pas[i] <= 'z') { progressBar1.Value += 4;p += 4; pa1 = 1;s1 = 0; break; } }
            }
            if (s1 == 0)
            {
                for (int i = 0; i < pas.Length; i++) { if (pas[i] >= 'A' && pas[i] <= 'z') { } else { progressBar1.Value -= 4; s1 = 1;pa1 = 0; break; } }
            }

            //проверка наличия цифр
            if (pa2 == 0)
            {
                for (int i = 0; i < pas.Length; i++) { if (pas[i] >= '0' && pas[i] <= '9') { progressBar1.Value += 3;p+=3 ; pa2 = 1;s2 = 0; break; } }
            }
            if (s2 == 0)
            {
                bool ch=false;
                for (int i = 0; i < pas.Length; i++)
                {
                    if (pas[i] >= '0' && pas[i] <= '9') { ch = true; } break;
                }
                    if (ch == false)
                    {
                        progressBar1.Value -= 3; s2 = 1; pa2 = 0;
                    }                
            }
            //проверка наличия символов
            if (pa3 == 0)
            {
                for (int i = 0; i < pas.Length; i++) { if (pas[i] >= '!' && pas[i] <= '/') { progressBar1.Value += 4; p += 4;pa3 = 1; s3 = 0; break; } }
            }
            if (s3 == 0)
            {
                for (int i = 0; i < pas.Length; i++) { if (pas[i] >= '!' && pas[i] <= '/') { } else { progressBar1.Value -= 4;s3 = 1;pa3 = 0; } }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form1 s = new Form1();
            s.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (egoldsGoogleTextBox4.Text != "")
            {
                try { dr = Convert.ToInt32(egoldsGoogleTextBox4.Text); }
                catch { MessageBox.Show("Поле года рождения не может быть текстовым!"); error++; }
                string b = egoldsGoogleTextBox4.Text;
                if (b.Length != 4) { error++; MessageBox.Show("Поле года рождения должно состоять из четырех цифр!"); }
            }

            if (egoldsGoogleTextBox1.Text != "")
            {
                if (im[0] >= 'А' && im[0] <= 'я') { }
                else
                { error++; MessageBox.Show("Поле имени ученика дожно состоять из букв кирилицы!"); }
            }

            if (egoldsGoogleTextBox2.Text != "")
            {
                if (fam[0] >= 'А' && fam[0] <= 'я') { }
                else
                { error++; MessageBox.Show("Поле фамилия ученика дожно состоять из букв кирилицы!"); }
            }

            if (egoldsGoogleTextBox3.Text != "")
            {
                if (ot[0] >= 'А' && ot[0] <= 'я') { }
                else
                { error++; MessageBox.Show("Поле отчества ученика дожно состоять из букв кирилицы!"); }
            }


        }
    }
}
