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
    public partial class choose : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=pecesool;password=1234;database=dpi");
        public choose()
        {
            InitializeComponent();
        }
        Classes.FUNC func = new Classes.FUNC();
        private void choose_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.label7, "Закрыть окно");
            MySqlCommand command = new MySqlCommand("SELECT * FROM `класс`");
            DataTable dt = func.getData(command);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string tmp = Convert.ToString(dt.Rows[i]["Класс"]);
                comboBox1.Items.Add(tmp);
            }
        }
        private void label7_Click(object sender, EventArgs e)
        {
            menu s = new menu();
            s.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                persotch s = new persotch(ids[comboBox2.SelectedIndex], comboBox1.Text);
                s.Show();
                this.Hide();
            }
        }
        int[] ids = new int[10000];
        int k = 0;
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            k = 0;
            comboBox2.Items.Clear();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `класс` WHERE `Класс` = @uL");
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = comboBox1.Text;
            DataTable table = func.getData(command);
            int idcl = Convert.ToInt32(table.Rows[0]["ID класса"]);
            MySqlCommand command3 = new MySqlCommand("SELECT * FROM `ученики` WHERE `ID класса` = @uL");
            command3.Parameters.Add("@uL", MySqlDbType.Int32).Value = idcl;
            DataTable dt1 = func.getData(command3);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                ids[k] = Convert.ToInt32(dt1.Rows[i]["IDученика"]);
                k++;
                string tmp = Convert.ToString(Convert.ToString(dt1.Rows[i]["Фамилия"]) + " " + Convert.ToString(dt1.Rows[i]["Имя"]));
                comboBox2.Items.Add(tmp);
            }
        }
    }
}
