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
using System.Data.SqlClient;

namespace DPI
{
    public partial class navigate : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=pecesool;password=1234;database=dpi");
        public navigate()
        {
            InitializeComponent();
            dd();
          
        }
        private void dd()
        {
            
            string query = "SELECT * FROM `ученики`";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            menu s = new menu();
            s.Show();
            this.Hide();
        }
        Classes.FUNC func = new Classes.FUNC();
        private void navigate_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.pictureBox2, "Закрыть окно");
            MySqlCommand command = new MySqlCommand("SELECT * FROM `класс`");
            DataTable dt = func.getData(command);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string tmp = Convert.ToString(dt.Rows[i]["Класс"]);
                comboBox1.Items.Add(tmp);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int k = 0;
            string poisk = "";
            if (textBox1.Text != "")
            {
                k++;
                if (k > 1)
                {
                    poisk += " AND ";
                }
                poisk += "[Имя] LIKE'%" + textBox1.Text + "%'";
            }
            if (textBox2.Text != "")
            {
                k++;
                if (k > 1)
                {
                    poisk += " AND ";
                }
                poisk += "[Фамилия] LIKE'%" + textBox2.Text + "%'";
            }
            if (textBox3.Text != "")
            {
                k++;
                if (k > 1)
                {
                    poisk += " AND ";
                }
                poisk += "[Отчество] LIKE'%" + textBox3.Text + "%'";
            }
            if (textBox4.Text != "")
            {
                k++;
                if (k > 1)
                {
                    poisk += " AND ";
                }
                poisk += "[Год рождения]=" + Convert.ToInt32(textBox4.Text);
            }
            if (radioButton2.Checked == true)
            {
                k++;
                if (k > 1)
                {
                    poisk += " AND ";
                }
                poisk += "[Пол] LIKE'%" + radioButton2.Text + "%'";
            }
            if (radioButton1.Checked==true)
            {
                k++;
                if (k > 1)
                {
                    poisk += " AND ";
                }
                poisk += "[Пол] LIKE'%" + radioButton1.Text + "%'";
            }
            if (comboBox1.Text != "")
            {
                k++;
                if (k > 1)
                {
                    poisk += " AND ";
                }
                poisk += "[ID класса]=" + idcl;
            }
            if (k >= 1)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridView1.DataSource;
                bs.Filter = poisk;
                dataGridView1.DataSource = bs;
            }
            else
            {
                if (k == 0)
                {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dataGridView1.DataSource;
                    bs.Filter = "";
                    dataGridView1.DataSource = bs;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = null;
            dataGridView1.DataSource = bs;
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = "";
            comboBox1.Text = "";radioButton1.Checked = false;radioButton2.Checked = false;
        }
        int idcl, kolvo; 
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `класс`");
            DataTable dt = func.getData(command);
            
            for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (comboBox1.Text == Convert.ToString(dt.Rows[i]["Класс"]))
                        {
                          idcl=  Convert.ToInt32(dt.Rows[i]["ID класса"]);
                        }
                    }
        }
        int iduch=0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
            panel3.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `класс`");
             DataTable dt = func.getData(command1);
             kolvo = dt.Rows.Count;
             if (iduch == 0 || fam == "" || im == "" || ot == "" || god == 0 || pol == "" || idkl == 0) { MessageBox.Show("Не оставляйте пустых полей!"); } else
             { if(idkl>kolvo) { MessageBox.Show("Недопустимое значение для поля ID класса"); } else
                 { 

                   try { conn.Open();
                         MySqlCommand command = new MySqlCommand("UPDATE ученики SET `Фамилия` = @login , `Имя` =@name, `Отчество` = @pass, `Год рождения` = @address, `Пол` = @telephone, `ID класса` = @idkl  WHERE IDученика = @iduch;", conn);

                         command.Parameters.Add("@iduch", MySqlDbType.Int32).Value = iduch;
                         command.Parameters.Add("@login", MySqlDbType.VarChar).Value =fam;
                         command.Parameters.Add("@name", MySqlDbType.VarChar).Value = im;
                         command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = ot;
                         command.Parameters.Add("@address", MySqlDbType.Int64).Value =god;
                         command.Parameters.Add("@telephone", MySqlDbType.VarChar).Value = pol;
                         command.Parameters.Add("@idkl", MySqlDbType.Int32).Value = idkl;
                         command.ExecuteNonQuery();
                         MessageBox.Show("Информация об ученике обновлена.");
                         conn.Close();
                        dd();
                    
                    }
                     catch { MessageBox.Show("Введены недопустимые типы данных");dd();}}}



        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            if (iduch == 0)
            {
                MessageBox.Show("Выберите ученика.");
            }
            else
            {
                try
                {
                    conn.Open();
                    MySqlCommand command = new MySqlCommand("DELETE FROM `ученики` WHERE `IDученика` = @id", conn);

                    command.Parameters.Add("@id", MySqlDbType.Int32).Value = iduch;
                    command.ExecuteNonQuery();

                    MessageBox.Show("Ученик был успешно удален.");
                    conn.Close();
                    dd();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }
        string fam, im, ot, pol;

        private void button11_Click(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            int x=0;
            if (radioButton4.Checked == true) { x = 1; }
            if (radioButton3.Checked == true) { x = 0; }
            if (checkBox1.Checked == true) { if (x == 0) { bs.Sort = "Имя ASC"; } else { bs.Sort = "Имя DESC"; } }
            if (checkBox2.Checked == true) { if (x == 0) { bs.Sort = "Фамилия ASC"; } else { bs.Sort = "Фамилия DESC"; } }
            if (checkBox3.Checked == true) { if (x == 0) { bs.Sort = "Отчество ASC"; } else { bs.Sort = "Отчество DESC"; } }
            if (checkBox4.Checked == true) { if (x == 0) { bs.Sort = "Год рождения ASC"; } else { bs.Sort = "Год рождения DESC"; } }
            if (comboBox2.Text=="женский") { bs.Sort = "Пол ASC";   }if(comboBox2.Text == "мужской") { bs.Sort = "Пол DESC"; }
            dataGridView1.DataSource = bs;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel4.Visible = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            comboBox2.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel4.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int k = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[1].Selected = false;
                    for (int j = 0; j <dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                        {
                            if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox5.Text))
                            {
                                dataGridView1.Rows[i].Selected = true;
                                k++;
                                break;//поиск по базе данных
                            }
                        }
                    }
                }
                label10.Text = "Найдено " + k.ToString() + " Совпадений";
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            label10.Text = "";
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
            }
        }

        int idkl, god;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            iduch = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            fam = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            im = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            ot = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            god = Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value);
            pol = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            idkl = Convert.ToInt32(dataGridView1.CurrentRow.Cells[6].Value);
        }
    }
}
