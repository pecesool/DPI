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
    public partial class registr : Form
    {

        MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=pecesool;password=1234;database=dpi");
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
           
            im = egoldsGoogleTextBox1.Text;

            if (b == 0)
            {
                if (im.Length == 1) { progressBar1.Value += 15; b = 1; }
            }
            if (im.Length == 0) { progressBar1.Value -= 15; b = 0; }
        }
        int b1;
        private void egoldsGoogleTextBox2_TextChanged(object sender, EventArgs e)
        {
            
            fam = egoldsGoogleTextBox2.Text;

            if (b1 == 0)
            {
                if (fam.Length == 1) { progressBar1.Value += 15; b1 = 1; }
            }
            if (fam.Length == 0) { progressBar1.Value -= 15; b1 = 0; }
        }
        int b2;
        private void egoldsGoogleTextBox3_TextChanged(object sender, EventArgs e)
        {
            
            ot = egoldsGoogleTextBox3.Text;

            if (b2 == 0)
            {
                if (ot.Length == 1) { progressBar1.Value += 15; b2 = 1; }
            }
            if (ot.Length == 0) { progressBar1.Value -= 15; b2 = 0; }
        }
        int b3;
        private void egoldsGoogleTextBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dr = Convert.ToInt32(egoldsGoogleTextBox4.Text);
                string gg;
                gg = egoldsGoogleTextBox4.Text;

                if (b3 == 0)
                {
                    if (gg.Length == 1) { progressBar1.Value += 15; b3 = 1; }
                }
                if (gg.Length == 0) { progressBar1.Value -= 15; b3 = 0; }
            }
            catch
            {
                MessageBox.Show("В поле года рождения можно вводить только числовые значения");

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) { progressBar1.Value += 10; pol = "мужской"; } else { progressBar1.Value -= 10; pol = "женский"; }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true) { progressBar1.Value += 10; pol = "женский"; } else { progressBar1.Value -= 10; pol = "мужской"; }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        int dr, error;
        string im, fam, ot ,log, pol;
        int b0;
        private void egoldsGoogleTextBox5_TextChanged(object sender, EventArgs e)
        {
            
            log = egoldsGoogleTextBox5.Text;

            if (b0 == 0)
            {
                if (log.Length == 1) { progressBar1.Value += 15; b0 = 1; }
            }
            if (log.Length == 0) { progressBar1.Value -= 15; b0 = 0; }
        }
        int pa=0, pa1, pa2, pa3;

        private void egoldsGoogleTextBox6_Click(object sender, EventArgs e)
        {

        }

        private void egoldsGoogleTextBox5_Click(object sender, EventArgs e)
        {

        }

        private void egoldsGoogleTextBox1_Click(object sender, EventArgs e)
        {

        }

        int s =1, s1=1, s2=1, s3=1;
        int p;
        int respas=0;string pas;
        private void egoldsGoogleTextBox6_TextChanged(object sender, EventArgs e)
        {
               
            pas = egoldsGoogleTextBox6.Text;
            
            //проверка длины пароля
            if (pa == 0)
            {
                if (pas.Length < 7) { progressBar1.Value += 0; } else { progressBar1.Value += 4;respas += 4; p += 4; ; pa = 1;s = 0; }
            }
            if (s == 0)
            {
                if (pas.Length < 8) { progressBar1.Value -= 4; respas -= 4; s = 1;pa = 0; }
            }
            //проверка наличия латинских букв
            if (pa1 == 0)
            {
                for (int i = 0; i < pas.Length; i++) { if (pas[i] >= 'A' && pas[i] <= 'z') { progressBar1.Value += 4;respas += 4; p += 4; pa1 = 1; s1 = 0; break; } else { progressBar1.Value += 0; } }
            }
            if (s1 == 0)
            {
                bool ch = true;
                for (int i = 0; i < pas.Length; i++) { if (pas[i] >= 'A' && pas[i] <= 'z') { ch = true; break; } else { ch = false; } }
                if(ch==false){ progressBar1.Value -= 4;respas -= 4; s1 = 1;pa1 = 0; } 
            }

            //проверка наличия цифр
            if (pa2 == 0)
            {
                for (int i = 0; i < pas.Length; i++) { if (pas[i] >= '0' && pas[i] <= '9') { progressBar1.Value += 3;respas += 3; p+=3 ; pa2 = 1;s2 = 0; break; } else { progressBar1.Value += 0; } }
            }
            if (s2 == 0)
            {
                bool ch=true;
                for (int i = 0; i < pas.Length; i++)
                {
                    if (pas[i] >= '0' && pas[i] <= '9') { ch = true; break; } else { ch = false; }
                }
                    if (ch == false)
                    {
                        progressBar1.Value -= 3;respas -= 3; s2 = 1; pa2 = 0;
                    }                
            }
            //проверка наличия символов
            if (pa3 == 0)
            {
                for (int i = 0; i < pas.Length; i++) { if (pas[i] >= '!' && pas[i] <= '/') { progressBar1.Value += 4;respas += 4; p += 4;pa3 = 1; s3 = 0; break; } else { progressBar1.Value += 0; } }
            }
            if (s3 == 0)
            {
                bool ch =true;
                for (int i = 0; i < pas.Length; i++) { if (pas[i] >= '!' && pas[i] <= '/') { ch = true; break; } else { ch = false; } }
                if (ch == false) { progressBar1.Value -= 4;respas -= 4; s3 = 1; pa3 = 0; }
            }
            if (pas == "") { progressBar1.Value = 0;respas = 0; pa = 0;pa1 = 0;pa2 = 0;pa3 = 0; }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form1 s = new Form1();
            s.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            error = 0;
            if (egoldsGoogleTextBox4.Text != "")
            {
                try { dr = Convert.ToInt32(egoldsGoogleTextBox4.Text); }
                catch { MessageBox.Show("Поле года рождения не может быть текстовым!"); error++; }
                string b = egoldsGoogleTextBox4.Text;
                if (b.Length != 4) { error++; MessageBox.Show("Поле года рождения должно состоять из четырех цифр!"); }
            }
            else { MessageBox.Show("Не оставляйте поле ввода года рождения пустым!"); error++; }

            if (egoldsGoogleTextBox1.Text != "")
            {
                if (im[0] >= 'А' && im[0] <= 'я') { }
                else
                { error++; MessageBox.Show("Поле имени пользователя дожно состоять из букв кирилицы!"); }
            }
            else { MessageBox.Show("Не оставляйте поле ввода имени пользователя пустым!"); error++; }
            if (egoldsGoogleTextBox5.Text != "")
            {
                if (log[0] >= 'A' && log[0] <= 'z') { }
                else
                { error++; MessageBox.Show("Поле логина пользователя дожно состоять из латинских букв!"); }
            }
            else { MessageBox.Show("Не оставляйте поле ввода логина пользователя пустым!"); error++; }

            if (egoldsGoogleTextBox2.Text != "")
            {
                if (fam[0] >= 'А' && fam[0] <= 'я') { }
                else
                { error++; MessageBox.Show("Поле фамилия пользователя дожно состоять из букв кирилицы!"); }
            }
            else { MessageBox.Show("Не оставляйте поле ввода фамилии пользователя пустым!"); error++; }
            if (egoldsGoogleTextBox3.Text != "")
            {
                if (ot[0] >= 'А' && ot[0] <= 'я') { }
                else
                { error++; MessageBox.Show("Поле отчества пользователя дожно состоять из букв кирилицы!"); }
            }
            else { MessageBox.Show("Не оставляйте поле ввода отчества пользователя пустым!"); error++; }
            if (egoldsGoogleTextBox6.Text != "")
            {
                if (respas == 15) { }
                else
                { error++; MessageBox.Show("Надежный пароль должен состоять не менее чем из 8 символов и должен содержать латинские буквы, цифры и знаки"); }
            }
            else { MessageBox.Show("Не оставляйте поле ввода пароля пустым!"); error++; }
            if (progressBar1.Value == 100 && error == 0) 
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`Login`, `Password`, `Имя`, `Фамилия`, `Отчество`, `Год рождения`,`Пол`) VALUES (@log, @pas, @im, @fam,@ot,@dr,@pol)", conn);

                
                command.Parameters.AddWithValue("@fam", fam);
                command.Parameters.AddWithValue("@im", im);
                command.Parameters.AddWithValue("@ot", ot);
                command.Parameters.AddWithValue("@dr", dr);
                command.Parameters.AddWithValue("@pol", pol);
                command.Parameters.AddWithValue("@log", log);
                command.Parameters.AddWithValue("@pas", pas);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Ученик сохранен!");
                    Form1 s = new Form1();
                    s.Show();
                    this.Hide();
                }
                conn.Close();
            }
        }
    }
}
