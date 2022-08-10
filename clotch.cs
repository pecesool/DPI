using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;

namespace DPI
{
    public partial class clotch : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=pecesool;password=1234;database=dpi");
        public clotch()
        {
            InitializeComponent();
            dd();
        }
        private void dd() {
            conn.Open();
            string query = "SELECT * FROM `сдачанормативовв`";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
        Classes.FUNC func = new Classes.FUNC();

        int visok = 0, sredn = 0, nizk = 0, vnorm = 0, norm = 0, nnorm = 0, estvkk = 0, nevkk = 0, ves, index;
        string itog, vkk;
        private void clotch_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.label7, "Закрыть окно");
            toolTip2.SetToolTip(this.pictureBox1, "Печать");
            MySqlCommand command = new MySqlCommand("SELECT * FROM `класс`");
            DataTable dt = func.getData(command);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string tmp = Convert.ToString(dt.Rows[i]["Класс"]);
                comboBox2.Items.Add(tmp);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            visok = 0; sredn = 0; nizk = 0; vnorm = 0; norm = 0; nnorm = 0; estvkk = 0; nevkk = 0;
            int[] ids = new int[10000];
            int k = 0;
            //выбор из таблицы класс
            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `класс`");
            DataTable dt = func.getData(command1);
            string b;
            // определение всех данных для выбранного класса
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (comboBox2.Text == dt.Rows[i]["Класс"].ToString()) { b = dt.Rows[i]["Тип класса"].ToString(); label14.Text = "Язык обучения : " + b; }
            }
            //нахлждение айди выбранного класса
            MySqlCommand command = new MySqlCommand("SELECT * FROM `класс` WHERE `Класс` = @uL");
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = comboBox2.Text;
            DataTable table = func.getData(command);
            int idcl = Convert.ToInt32(table.Rows[0]["ID класса"]);
            //выбор данных из таблицы ученик с выбранным айди класса
            MySqlCommand command3 = new MySqlCommand("SELECT * FROM `ученики` WHERE `ID класса` = @uL");
            command3.Parameters.Add("@uL", MySqlDbType.Int32).Value = idcl;
            DataTable table1 = func.getData(command3); label10.Text = "Общее количество детей: " + table1.Rows.Count.ToString();
            //добавление айди учеников в массив
            for (int i = 0; i < table1.Rows.Count; i++)
            {
                ids[k] = Convert.ToInt32(table1.Rows[i]["IDученика"]);
                k++;
            }
            //подсчет данных учеников из выбранного класса
            MySqlCommand command4 = new MySqlCommand("SELECT * FROM `ученики` WHERE `ID класса` = @uL AND `Пол` = 'женский'");
            command4.Parameters.Add("@uL", MySqlDbType.Int32).Value = idcl;
            DataTable table2 = func.getData(command4); label12.Text = "Девочек: " + table2.Rows.Count.ToString();
            MySqlCommand command5 = new MySqlCommand("SELECT * FROM `ученики` WHERE `ID класса` = @uL  AND `Пол` = 'мужской'");
            command5.Parameters.Add("@uL", MySqlDbType.Int32).Value = idcl;
            DataTable table3 = func.getData(command5); label11.Text = "Мальчиков: " + table3.Rows.Count.ToString();
            //цикл для данных массива с данными учеников
            for (int h = 0; h < k; h++)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridView1.DataSource;
                bs.Filter = "[ID ученика]=" + ids[h];
                dataGridView1.DataSource = bs;
                //для выбранных учеников и их айди нахождение в другой таблице их результат выполнения нормативов
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    itog = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    if (itog == "Высокий") { visok++; }
                    if (itog == "Средний") { sredn++; }
                    if (itog == "Низкий") { nizk++; }
                }
                //обнуление фильтра
                BindingSource bs1 = new BindingSource();
                bs1.DataSource = dataGridView1.DataSource;
                bs1.Filter =null;
                dataGridView1.DataSource = bs1;
            }
            int eb=0;
            int l = 0;
            //выбор из таблицы мед карта
            MySqlCommand command9 = new MySqlCommand("SELECT * FROM `медкартаа`");
            DataTable dt3 = func.getData(command9);

            //поиск по базе данных людей с опрделенной мед картой
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                if (ids[eb] == Convert.ToInt32(dt3.Rows[i]["ID ученика"]))
                {
                    eb++;
                    vkk = dt3.Rows[i]["ВКК"].ToString(); l++;
                    if (vkk == "есть") { estvkk++; } else { nevkk++; }
                    ves = Convert.ToInt32(dt3.Rows[i]["Вес"]);
                    index = Convert.ToInt32(dt3.Rows[i]["Индекс массы тела"]);
                    if (index + 5 < ves) { vnorm++; }
                    if (index - 10 > ves) { norm++; }
                    if (index - 10 < ves && ves < index + 5) { nnorm++; }
                }
            }
            //тип графиков
            chart1.Series.Clear();

            chart2.Series.Clear();
            chart3.Series.Clear();
            chart1.Series.Add(new Series("0")
            {
                ChartType = SeriesChartType.Column
            });
            chart2.Series.Add(new Series("0")
            {
                ChartType = SeriesChartType.Column
            });
            chart3.Series.Add(new Series("0")
            {
                ChartType = SeriesChartType.Column
            });

            //добавление данных в графики
            chart2.Series["0"].Points.Add(visok);
            chart2.Series["0"].Points[0].Color = Color.Red;
            chart2.Series["0"].Points[0].AxisLabel = "Высокий";
            chart2.Series["0"].Points[0].Label = visok.ToString();
            //Init data
            chart2.Series["0"].Points.Add(sredn);
            chart2.Series["0"].Points[1].Color = Color.Blue;
            chart2.Series["0"].Points[1].AxisLabel = "Средний";
            chart2.Series["0"].Points[1].Label = sredn.ToString();

            chart2.Series["0"].Points.Add(nizk);
            chart2.Series["0"].Points[2].Color = Color.Green;
            chart2.Series["0"].Points[2].AxisLabel = "Низкий";
            chart2.Series["0"].Points[2].Label = nizk.ToString();


            chart1.Series["0"].Points.Add(estvkk);
            chart1.Series["0"].Points[0].Color = Color.Red;
            chart1.Series["0"].Points[0].AxisLabel = "Освобождены";
            chart1.Series["0"].Points[0].Label = estvkk.ToString();
            //Init data
            chart1.Series["0"].Points.Add(nevkk);
            chart1.Series["0"].Points[1].Color = Color.Blue;
            chart1.Series["0"].Points[1].AxisLabel = "Не освобождены";
            chart1.Series["0"].Points[1].Label = nevkk.ToString();


            chart3.Series["0"].Points.Add(vnorm);
            chart3.Series["0"].Points[0].Color = Color.Red;
            chart3.Series["0"].Points[0].AxisLabel = "Выше нормы";
            chart3.Series["0"].Points[0].Label = vnorm.ToString();
            //Init data
            chart3.Series["0"].Points.Add(norm);
            chart3.Series["0"].Points[1].Color = Color.Blue;
            chart3.Series["0"].Points[1].AxisLabel = "норма";
            chart3.Series["0"].Points[1].Label = norm.ToString();

            chart3.Series["0"].Points.Add(nnorm);
            chart3.Series["0"].Points[2].Color = Color.Green;
            chart3.Series["0"].Points[2].AxisLabel = "Ниже нормы";
            chart3.Series["0"].Points[2].Label = nnorm.ToString();
        }

        private void label7_Click(object sender, EventArgs e)
        {//выход
            menu s = new menu();
            s.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {//вывод на печать печать соответсвующими данными
            richTextBox1.Text = comboBox2.Text + "\n\n" + label14.Text + "\n\n" + label10.Text + "\n\n" + label11.Text + "\n\n" + label12.Text + "\n\n\n" + label5.Text + "\n\n" + "Количество освобожденных от занятий физкультуры: " + estvkk + "\n\nКоличество учеников посещаюхих занятия физической культуры без противопоказаний: " + nevkk + "\n\nКоличество детей с индексом массы тела превышающим норму: " + vnorm + "\n\nКоличество детей с индексом массы тела соответствующему норме: " + norm + "\n\nКоличество детей с индексом массы тела ниже нормы: " + nnorm + "\n\n\nКоличество детей выполнивших нормативы на высокий уровень: " + visok + "\n\n\nКоличество детей выполнивших нормативы на средний уровень: " + sredn + "\n\n\nКоличество детей выполнивших нормативы на низкий уровень: " + nizk;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK) printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {//вывод на печать
            e.Graphics.DrawString(richTextBox1.Text, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(100, 100));
        }
    }
}
