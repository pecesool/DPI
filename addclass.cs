using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace DPI
{
    public partial class addclass : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=pecesool;password=1234;database=dpi");
        //подключение бд
        public addclass()
        {
            InitializeComponent();
            Animator.Start();//объявлении анимации
        }
        //объявление перменных
        int par;
        string lit, tip, clas;
        int eb = 0;
        int[] ids = new int[10000];
        int k = 0, vkk = 0;
        int kolklas;
        int errror;
        private void pictureBox2_Click(object sender, EventArgs e)
        {//переход в меню
            menu s = new menu();
            s.Show();
            this.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {//увеличение прогресбара в соответствии выбора пользователя
            if (radioButton1.Checked == true) { progressBar1.Value += 34; par = 7; } else { progressBar1.Value -= 34; }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {//увеличение прогресбара в соответствии выбора пользователя
            if (radioButton2.Checked == true) { progressBar1.Value += 34; par = 8; } else { progressBar1.Value -= 34; }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {//увеличение прогресбара в соответствии выбора пользователя
            if (radioButton7.Checked == true) { textBox1.Text = ""; progressBar1.Value += 34; lit = "A"; } else { progressBar1.Value -= 34; }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {//увеличение прогресбара в соответствии выбора пользователя
            if (radioButton8.Checked == true) { textBox1.Text = ""; progressBar1.Value += 34; lit = "B"; } else { progressBar1.Value -= 34; }
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {//увеличение прогресбара в соответствии выбора пользователя
            if (radioButton9.Checked == true) { textBox1.Text = ""; progressBar1.Value += 34; lit = "C"; } else { progressBar1.Value -= 34; }
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {//увеличение прогресбара в соответствии выбора пользователя
            if (radioButton10.Checked == true) { textBox1.Text = ""; progressBar1.Value += 34; lit = "D"; } else { progressBar1.Value -= 34; }
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {//увеличение прогресбара в соответствии выбора пользователя
            if (radioButton11.Checked == true) { textBox1.Text = ""; progressBar1.Value += 34; lit = "E"; } else { progressBar1.Value -= 34; }
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {//увеличение прогресбара в соответствии выбора пользователя
            if (radioButton12.Checked == true) { textBox1.Text = ""; progressBar1.Value += 34; lit = "F"; } else { progressBar1.Value -= 34; }
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {//увеличение прогресбара в соответствии выбора пользователя
            if (radioButton13.Checked == true) { progressBar1.Value += 32; tip = "Русский"; } else { progressBar1.Value -= 32; }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {//увеличение програес бара в соответсвии с выбором пользователя
            string gg;
            gg = textBox1.Text;
            if (0 < gg.Length && gg.Length < 2)
            {
                lit = textBox1.Text; radioButton7.Checked = false; radioButton8.Checked = false; radioButton9.Checked = false;
                radioButton10.Checked = false; radioButton11.Checked = false; radioButton12.Checked = false; progressBar1.Value += 34;
            }
            if (gg.Length == 0) { progressBar1.Value -= 34; }
            radioButton7.Checked = false; radioButton8.Checked = false; radioButton9.Checked = false; radioButton10.Checked = false; radioButton11.Checked = false; radioButton12.Checked = false;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        Classes.FUNC func = new Classes.FUNC();
        private void button1_Click(object sender, EventArgs e)
        {
            //проверка на правильность ввода информации
            clas = par + lit;
            errror = 0;
            try {int b= Convert.ToInt32(textBox1.Text);  }
            catch {MessageBox.Show("Поле литеры класса не может быть числовым!");errror++; }
            string pas = textBox1.Text;
            if (pas.Length > 1) { errror++; MessageBox.Show("Поле литеры класса не дожно быть больше одного!"); }
            if (pas[0] >= 'A' && pas[0] <= 'z') { }else
            { errror++; MessageBox.Show("Поле литеры класса дожно состоять из латинских букв!"); }
            if (errror == 0)
            {
                if (progressBar1.Value == 100)
                {//сохронение данных в базу данных

                    conn.Open();

                    MySqlCommand command = new MySqlCommand("INSERT INTO `класс` (`Класс`, `Тип класса`) VALUES (@clas, @tip)", conn);
                    command.Parameters.AddWithValue("@clas", clas);
                    command.Parameters.AddWithValue("@tip", tip);
                    if (command.ExecuteNonQuery() == 1) { MessageBox.Show("Класс сохранен!"); }
                        radioButton7.Checked = false; radioButton8.Checked = false; radioButton9.Checked = false; radioButton10.Checked = false; radioButton11.Checked = false; radioButton12.Checked = false;
                    radioButton1.Checked = false; radioButton2.Checked = false;
                    radioButton13.Checked = false; radioButton14.Checked = false; textBox1.Text = "";
                    conn.Close();
                }
                else { MessageBox.Show("заполните все поля!"); }
            }
            else
            {
                //очистка текстбоксов
                //if (errror >0) { MessageBox.Show("данный класс уже существует, введите другой!"); }
                radioButton7.Checked = false; radioButton8.Checked = false; radioButton9.Checked = false; radioButton10.Checked = false; radioButton11.Checked = false; radioButton12.Checked = false;
                radioButton1.Checked = false; radioButton2.Checked = false;
                radioButton13.Checked = false; radioButton14.Checked = false; textBox1.Text = "";
            }

            comboBox1.Items.Clear();
            //выборка данных из бд
            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `класс`");
            DataTable dt1 = func.getData(command1);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string tmp = Convert.ToString(dt1.Rows[i]["Класс"]);
                comboBox1.Items.Add(tmp);
            }
            kolklas = dt1.Rows.Count;
            label15.Text = "Всего классов : " + kolklas.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {//подгрузка данных из бд

            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `класс`");
            DataTable dt = func.getData(command1);
            string b;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (comboBox1.Text == dt.Rows[i]["Класс"].ToString()) { b = dt.Rows[i]["Тип класса"].ToString(); label14.Text = "Язык обучения : " + b; }
                    }
            kolklas = dt.Rows.Count;
            label15.Text = "Всего классов : " + kolklas.ToString();
            //информация о классе
            MySqlCommand command = new MySqlCommand("SELECT * FROM `класс` WHERE `Класс` = @uL");
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = comboBox1.Text;
            DataTable table = func.getData(command);
            int idcl = Convert.ToInt32(table.Rows[0]["ID класса"]);
            //информация об учениках

            MySqlCommand command3 = new MySqlCommand("SELECT * FROM `ученики` WHERE `ID класса` = @uL");
            command3.Parameters.Add("@uL", MySqlDbType.Int32).Value = idcl;
            DataTable table1 = func.getData(command3); label10.Text = "Общее количество детей: " + table1.Rows.Count.ToString();
            for (int i = 0; i < table1.Rows.Count; i++)
            {
                ids[k] = Convert.ToInt32(table1.Rows[i]["IDученика"]);
                k++;
            }
            //информация об учениках

            MySqlCommand command4 = new MySqlCommand("SELECT * FROM `ученики` WHERE `ID класса` = @uL AND `Пол` = 'женский'");
            command4.Parameters.Add("@uL", MySqlDbType.Int32).Value = idcl;
            DataTable table2 = func.getData(command4); label12.Text = "Девочек: " + table2.Rows.Count.ToString();
            //информация об учениках

            MySqlCommand command5 = new MySqlCommand("SELECT * FROM `ученики` WHERE `ID класса` = @uL  AND `Пол` = 'мужской'");
            command5.Parameters.Add("@uL", MySqlDbType.Int32).Value = idcl;
            DataTable table3 = func.getData(command5); label11.Text = "Мальчиков: " + table3.Rows.Count.ToString();
            //информация об медкарте
            MySqlCommand command6 = new MySqlCommand("SELECT * FROM `медкартаа` WHERE `ВКК` = @uL");
            command6.Parameters.Add("@uL", MySqlDbType.VarChar).Value = "есть";
            DataTable table4 = func.getData(command6); vkk = 0;
                eb = 0;
            for (int i = 0; i < table4.Rows.Count; i++)
            {              
                if (ids[eb] == Convert.ToInt32(table4.Rows[i]["ID ученика"]))
                {
                    vkk=vkk+1;eb=eb+1;                                               
                }                
            }
             label13.Text = "Детей с освобождением от физкультуры : " + vkk.ToString();      
            
            
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {//увеличение данных прогрессбара в соответствии с выбором пользователя
            if (radioButton14.Checked == true) { progressBar1.Value += 32; tip = "Казахский"; } else { progressBar1.Value -= 32; }
        }

        private void addclass_Load(object sender, EventArgs e)
        {
            //подгрузка данных из бд с откртием форсы
            toolTip1.SetToolTip(this.pictureBox2, "Закрыть окно");
            MySqlCommand command = new MySqlCommand("SELECT * FROM `класс`");
            DataTable dt = func.getData(command);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string tmp = Convert.ToString(dt.Rows[i]["Класс"]);
                comboBox1.Items.Add(tmp);
            }
            kolklas = dt.Rows.Count;
            label15.Text = "Всего классов : " + kolklas.ToString();
        }
    }
}
