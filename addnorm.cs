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
    public partial class addnorm : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=pecesool;password=1234;database=dpi");
        //подключение к бд
        public addnorm()
        {
            InitializeComponent();
            
        }
        

        Classes.FUNC func = new Classes.FUNC();
        private void addnorm_Load(object sender, EventArgs e)//при открытии формы подгрузка данных из БД
        {
            comboBox1.Items.Clear();
            comboBox3.Items.Clear();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `класс`");
            DataTable dt = func.getData(command);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string tmp = Convert.ToString(dt.Rows[i]["Класс"]);
                comboBox1.Items.Add(tmp);
            }
            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `норматив`");
            DataTable dt1 = func.getData(command1);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string tmp = Convert.ToString(dt1.Rows[i]["Название норматива"]);
                comboBox2.Items.Add(tmp);
            }
          
            toolTip1.SetToolTip(this.pictureBox2, "Закрыть окно"); 
        }
        private void pictureBox2_Click(object sender, EventArgs e)//переход в меню
        {
            menu s = new menu();
            s.Show();
            this.Hide();
        }
        int idnorm;
        string fam, im;
        private void button1_Click(object sender, EventArgs e)
        {
            
            dataGridView1.Refresh();
            dataGridView1.DataSource = null;
                    
                    
            if (comboBox2.Text == "Бег 30 метров")//определение номера выбранного норматива
            {
                      idnorm = 1;
                       
                    
                }
            if (comboBox2.Text == "Прыжок в длину с места")
            {
                   idnorm = 2;
            }
            if (comboBox2.Text == "Бросок набивного мяча 2кг")
            {
              
                   idnorm = 3;

            }
            if (comboBox2.Text == "Челночный бег 3*10м")
            {
                   idnorm = 4;
                
            }
            dataGridView1.Rows[0].Cells[2].Value = idnorm;//сохранение результатов таблицы в переменные
            dataGridView1.Rows[0].Cells[1].Value = im;
                    dataGridView1.Rows[0].Cells[0].Value = fam;
            dataGridView1.Visible = true;
            dataGridView1.Refresh();
            MessageBox.Show("Введите результат выполнения норматива в таблицу.");

        }
        
       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();//подгрузка данных из БД в соответствии с выбранными значениями
            MySqlCommand command = new MySqlCommand("SELECT * FROM `класс` WHERE `Класс` = @uL");
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = comboBox1.Text;
            DataTable table = func.getData(command);
            int idcl = Convert.ToInt32(table.Rows[0]["ID класса"]);


            MySqlCommand command3 = new MySqlCommand("SELECT * FROM `ученики` WHERE `ID класса` = @uL");
            command3.Parameters.Add("@uL", MySqlDbType.Int32).Value = idcl;
            DataTable dt1 = func.getData(command3);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string tmp = Convert.ToString(Convert.ToString(dt1.Rows[i]["Фамилия"]) + " " + Convert.ToString(dt1.Rows[i]["Имя"]));
                comboBox3.Items.Add(tmp);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
         
          
         
                string ress="";
            // проверка на правильность ввода данных
            try { ress = dataGridView1.Rows[0].Cells[3].Value.ToString(); } catch { MessageBox.Show("заполните поле"); }
            try {float res1 = Convert.ToSingle(ress); } catch { MessageBox.Show("В таблицу можно ввести только целые числа или дробные через запятую "); dataGridView1.Rows[0].Cells[3].Value = ""; }
            ress = dataGridView1.Rows[0].Cells[3].Value.ToString();
            if (ress != "")
            {
                float res = Convert.ToSingle(ress);
                bool isM = false;
                string lvl = "Низкий";
                MySqlCommand command3 = new MySqlCommand("SELECT * FROM `ученики`WHERE `IDученика` = @uL");
                command3.Parameters.Add("@uL", MySqlDbType.Int32).Value = iduch;
                DataTable dt1 = func.getData(command3);
                if (dt1.Rows[0]["Пол"].ToString() == "мужской")
                {
                    isM = true;
                }
                if (isM)
                {//перевод числовых данных в статистичекие
                    switch (comboBox2.SelectedIndex)
                    {
                        case 1:
                            if (res >= 5.7)
                            {
                                lvl = "Низкий";
                            }
                            else if (res >= 4.8)
                            {
                                lvl = "Средний";
                            }
                            else
                            {
                                lvl = "Высокий";
                            }
                            break;
                        case 2:
                            if (res <= 364)
                            {
                                lvl = "Низкий";
                            }
                            else if (res <= 493)
                            {
                                lvl = "Средний";
                            }
                            else
                            {
                                lvl = "Высокий";
                            }
                            break;
                        case 3:
                            if (res <= 161)
                            {
                                lvl = "Низкий";
                            }
                            else if (res <= 186)
                            {
                                lvl = "Средний";
                            }
                            else
                            {
                                lvl = "Высокий";
                            }
                            break;
                        case 4:
                            if (res >= 9.2)
                            {
                                lvl = "Низкий";
                            }
                            else if (res >= 8.3)
                            {
                                lvl = "Средний";
                            }
                            else
                            {
                                lvl = "Высокий";
                            }
                            break;
                    }
                }
                else
                {
                    switch (comboBox2.SelectedIndex)
                    {
                        case 1:
                            if (res >= 6.0)
                            {
                                lvl = "Низкий";
                            }
                            else if (res >= 5.3)
                            {
                                lvl = "Средний";
                            }
                            else
                            {
                                lvl = "Высокий";
                            }
                            break;
                        case 2:
                            if (res <= 346)
                            {
                                lvl = "Низкий";
                            }
                            else if (res <= 471)
                            {
                                lvl = "Средний";
                            }
                            else
                            {
                                lvl = "Высокий";
                            }
                            break;
                        case 3:
                            if (res <= 145)
                            {
                                lvl = "Низкий";
                            }
                            else if (res <= 162)
                            {
                                lvl = "Средний";
                            }
                            else
                            {
                                lvl = "Высокий";
                            }
                            break;
                        case 4:
                            if (res >= 10)
                            {
                                lvl = "Низкий";
                            }
                            else if (res >= 9.1)
                            {
                                lvl = "Средний";
                            }
                            else
                            {
                                lvl = "Высокий";
                            }
                            break;
                    }
                }

                string date;
                date = dateTimePicker1.Text;
                conn.Open();//отправка данных на сервер
                MySqlCommand command = new MySqlCommand("INSERT INTO `сдачанормативовв` (`ID ученика`, `Дата сдачи`, `ID норматива`, `Результат`, `Итог`) VALUES (@iduch, @date,@idn,@ress,@lvl)", conn);
                command.Parameters.AddWithValue("@iduch", iduch);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@idn", idnorm);
                command.Parameters.AddWithValue("@ress", ress);
                command.Parameters.AddWithValue("@lvl", lvl);
                if (command.ExecuteNonQuery() == 1) { MessageBox.Show("Результат сохранен!"); }
                conn.Close();
            }

            
          
        }
        
        int iduch;
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {//подгрузка данных из бд в соответствии с выбранными значениями
            MySqlCommand command3 = new MySqlCommand("SELECT * FROM `ученики`");
            DataTable dt1 = func.getData(command3);
            for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        string b = dt1.Rows[i]["Фамилия"].ToString() +" "+ dt1.Rows[i]["Имя"].ToString();
                        if (comboBox3.Text == b)
                        {
                            im= dt1.Rows[i]["Имя"].ToString();
                            fam = dt1.Rows[i]["Фамилия"].ToString();
                            iduch = Convert.ToInt32(dt1.Rows[i]["IDученика"]);
                        }
                    
            }

            
        }
            
        
    }
    
}

