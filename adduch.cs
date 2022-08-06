using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using MySql.Data.MySqlClient;

namespace DPI
{
    public partial class adduch : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=pecesool;password=1234;database=dpi");
        public adduch()
        {
            InitializeComponent();
        }
        string im, fam, ot, pol, vkk, prot;
       

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {//увеличение прогресс бара в соответствии набранных значений
            if (radioButton1.Checked == true) { progressBar1.Value += 10; pol = "мужской"; } else { progressBar1.Value -= 10; }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {//увеличение прогресс бара в соответствии набранных значений
            if (radioButton2.Checked == true) { progressBar1.Value += 10; pol = "женский"; } else { progressBar1.Value -= 10; }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {//увеличение прогресс бара в соответствии набранных значений
            if (radioButton4.Checked == true) { egoldsGoogleTextBox7.Visible = true; } else { egoldsGoogleTextBox7.Visible = false; }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {//увеличение прогресс бара в соответствии набранных значений
            egoldsGoogleTextBox7.Text = "";
            if (radioButton3.Checked == true) { progressBar1.Value += 20; vkk = "нет"; prot = "нет"; } else { progressBar1.Value -= 20; }
        }

        int b = 0;
        private void egoldsGoogleTextBox1_TextChanged(object sender, EventArgs e)
        {//увеличение прогресс бара в соответствии набранных значений
            im = egoldsGoogleTextBox1.Text;
            string gg;
            gg = egoldsGoogleTextBox1.Text;
            
            if (b == 0)
            {
                if (gg.Length == 1) { progressBar1.Value += 10;b=1; }
            }
            if (gg.Length == 0) { progressBar1.Value -= 10; b = 0; }
        }
        int b1;
        private void egoldsGoogleTextBox2_TextChanged(object sender, EventArgs e)
        {//увеличение прогресс бара в соответствии набранных значений
            fam = egoldsGoogleTextBox2.Text;
            string gg;
            gg = egoldsGoogleTextBox2.Text;

            if (b1 == 0)
            {
                if (gg.Length == 1) { progressBar1.Value += 10; b1 = 1; }
            }
            if (gg.Length == 0) { progressBar1.Value -= 10; b1 = 0; }
        }

        int b2;
        private void egoldsGoogleTextBox3_TextChanged(object sender, EventArgs e)
        {//увеличение прогресс бара в соответствии набранных значений
            ot = egoldsGoogleTextBox3.Text;
            string gg;
            gg = egoldsGoogleTextBox3.Text;
            if (b2 == 0)
            {
                if (gg.Length == 1) { progressBar1.Value += 10; b2 = 1; }
            }
            if (gg.Length == 0) { progressBar1.Value -= 10; b2 = 0; }
        }
        int b3;
        private void egoldsGoogleTextBox4_TextChanged(object sender, EventArgs e)
        {//увеличение прогресс бара в соответствии набранных значений
            if (egoldsGoogleTextBox4.Text != "") {  }
            string gg;
            gg = egoldsGoogleTextBox4.Text;

            if (b3 == 0)
            {
                if (gg.Length == 1) { progressBar1.Value += 10; b3 = 1; }
            }
            if (gg.Length == 0) { progressBar1.Value -= 10; b3 = 0; }
        }

        int b4;
        private void egoldsGoogleTextBox5_TextChanged(object sender, EventArgs e)
        {//увеличение прогресс бара в соответствии набранных значений
            if (egoldsGoogleTextBox5.Text != "") {  }
            string gg;
            gg = egoldsGoogleTextBox5.Text;

            if (b4 == 0)
            {
                if (gg.Length == 1) { progressBar1.Value += 10; b4 = 1; }
            }
            if (gg.Length == 0) { progressBar1.Value -= 10; b4 = 0; }
        }

        int b5;
        private void egoldsGoogleTextBox6_TextChanged(object sender, EventArgs e)
        {//увеличение прогресс бара в соответствии набранных значений
            if (egoldsGoogleTextBox6.Text != "") {}
            string gg;
            gg = egoldsGoogleTextBox6.Text;

            if (b5 == 0)
            {
                if (gg.Length == 1) { progressBar1.Value += 10; b5 = 1; }
            }
            if (gg.Length == 0) { progressBar1.Value -= 10; b5 = 0; }
        }

        int b6;
        private void egoldsGoogleTextBox7_TextChanged(object sender, EventArgs e)
        {//увеличение прогресс бара в соответствии набранных значений
            prot = egoldsGoogleTextBox7.Text;
            string gg;
            gg = egoldsGoogleTextBox7.Text;

            if (b6 == 0)
            {
                if (gg.Length == 1) { progressBar1.Value += 20; b6 = 1; }
            }
            if (gg.Length == 0) { progressBar1.Value -= 20; b6 = 0; }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {//увеличение прогресс бара в соответствии набранных значений
            menu s = new menu();
            s.Show();
            this.Hide();
        }

        private void egoldsGoogleTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void egoldsGoogleTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        int dr, rost, ves, idcl, indeks;
        int error = 0, iduch;
        private void adduch_Load(object sender, EventArgs e)
        {//при появлении формы подгрузка данных из бд
            toolTip1.SetToolTip(this.pictureBox2, "Закрыть окно");
            MySqlCommand command = new MySqlCommand( "SELECT * FROM `класс`");
            DataTable dt = func.getData(command);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string tmp = Convert.ToString(dt.Rows[i]["Класс"]);
                comboBox1.Items.Add(tmp);
            }

        }
        Classes.FUNC func = new Classes.FUNC();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {//подгрузка данных из бд и фиксирование выбранного элемента
            MySqlCommand command = new MySqlCommand("SELECT * FROM `класс` WHERE `Класс` = @uL");
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = comboBox1.Text;
            DataTable table = func.getData(command);
            idcl = Convert.ToInt32(table.Rows[0]["ID класса"]);
            if (comboBox1.Text!="")
            {
                progressBar1.Value += 10;
            }
            else { progressBar1.Value -= 10; }

        }

        private void button1_Click(object sender, EventArgs e)
        {//проверка правильности введенных данных
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

            if (egoldsGoogleTextBox7.Text != "")
            {
                if (prot[0] >= 'А' && prot[0] <= 'я') { }
                else
                { error++; MessageBox.Show("Поле противопоказаний ученика дожно состоять из букв кирилицы!"); }
            }
            if (egoldsGoogleTextBox5.Text != "")
            {
                try { rost = Convert.ToInt32(egoldsGoogleTextBox5.Text); }
                catch { MessageBox.Show("Поле роста ученика не может быть текстовым!"); error++; }
            }
            if (egoldsGoogleTextBox6.Text != "")
            {try { ves = Convert.ToInt32(egoldsGoogleTextBox6.Text); }
            catch { MessageBox.Show("Поле веса ученика не может быть текстовым!"); error++; }

            }
            

            MySqlCommand command2 = new MySqlCommand("SELECT * FROM `ученики`");
            DataTable dt = func.getData(command2);

            error = 0;
                 
                    iduch = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
            {//сохранение данных из таблицы в переменные
                if (im == Convert.ToString(dt.Rows[i]["Имя"]) && fam == Convert.ToString(dt.Rows[i]["Фамилия"])
                        && ot == Convert.ToString(dt.Rows[i]["Отчество"]) && dr == Convert.ToInt32(dt.Rows[i]["Год рождения"])
                        && pol == Convert.ToString(dt.Rows[i]["Пол"]) && idcl == Convert.ToInt32(dt.Rows[i]["ID класса"]))
                        { error = error += 1; }
                    }
                
            
            if (progressBar1.Value == 100 && error == 0)
            {// при нулевых ошибках сохранение данных в бд
                indeks = rost - 100;
                conn.Open();
                MySqlCommand command = new MySqlCommand("INSERT INTO `ученики` (`Фамилия`, `Имя`, `Отчество`, `Год рождения`, `Пол`, `ID класса`) VALUES (@fam, @im, @ot, @dr,@pol,@idcl)", conn);

                command.Parameters.AddWithValue("@iduch", iduch);
                command.Parameters.AddWithValue("@fam", fam);
                command.Parameters.AddWithValue("@im", im);
                command.Parameters.AddWithValue("@ot", ot);
                command.Parameters.AddWithValue("@dr", dr);
                command.Parameters.AddWithValue("@pol", pol);
                command.Parameters.AddWithValue("@idcl", idcl);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Ученик сохранен!");
                    egoldsGoogleTextBox4.Text = "";
                    egoldsGoogleTextBox3.Text = "";
                    egoldsGoogleTextBox2.Text = "";
                    egoldsGoogleTextBox1.Text = "";
                    comboBox1.Text = "";
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                }
                conn.Close();

                conn.Open();
                MySqlCommand command1 = new MySqlCommand("INSERT INTO `медкартаа` ( `ID ученика`, `Рост`, `Вес`, `ВКК`, `Противопоказания`, `Индекс массы тела`) VALUES ( @iduch, @rost, @ves, @vkk, @prot,@indeks)", conn);

                command1.Parameters.AddWithValue("@iduch", iduch);
                command1.Parameters.AddWithValue("@rost", rost);
                command1.Parameters.AddWithValue("@ves", ves);
                command1.Parameters.AddWithValue("@vkk", vkk);
                command1.Parameters.AddWithValue("@prot", prot);
                command1.Parameters.AddWithValue("@indeks", indeks);
                if (command1.ExecuteNonQuery() == 1)
                {
                    egoldsGoogleTextBox5.Text = "";
                    egoldsGoogleTextBox6.Text = "";
                    egoldsGoogleTextBox7.Text = "";
                    egoldsGoogleTextBox1.Text = "";
                    radioButton4.Checked = false;
                    radioButton3.Checked = false;
                }
                conn.Close();
            }
            else { MessageBox.Show("Ученик не сохранен!"); }
        }
    }
}
