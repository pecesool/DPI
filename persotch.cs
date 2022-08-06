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
    public partial class persotch : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=pecesool;password=1234;database=dpi");
        Classes.FUNC func = new Classes.FUNC();
        int id, godr;
        string kl, im, fam, klas;
        string medres, vkk, prot;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            richTextBox18.Text = label8.Text + "\n\n" + label5.Text + "\n\n" + label3.Text + "\n\n" + label1.Text + "\n\n" + richTextBox17.Text + "\n\n" + richTextBox5.Text + "\n" + obyasbeg + "\n\n" + richTextBox3.Text + "\n" + obyaspr + "\n\n" + richTextBox4.Text + "\n" + obyasmet + "\n\n" + "   РЕКОМЕНДАЦИИ" + "\n\n" + richTextBox1.Text;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK) printDocument1.Print();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox18.Text, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(100, 100));
        }

        string obyasbeg, obyaspr, obyasmet;
        int ves, index, rost;
        private void label7_Click(object sender, EventArgs e)
        {
            richTextBox7.Visible = false; richTextBox6.Visible = false; richTextBox2.Visible = false;
            richTextBox10.Visible = false; richTextBox9.Visible = false; richTextBox8.Visible = false;
            richTextBox13.Visible = false; richTextBox12.Visible = false; richTextBox11.Visible = false;
            menu s = new menu();
            s.Show();
            this.Hide();
        }
        private void db() {
            conn.Open();
            string query = "SELECT * FROM `сдачанормативовв`";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        public persotch(int i, string cl)
        {
            InitializeComponent();
            db();
            id = i;
            kl = cl;
        }

        private void persotch_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.label7, "Закрыть окно");
            toolTip2.SetToolTip(this.pictureBox1, "Печать");
            label3.Text = label3.Text + kl;
            MySqlCommand command = new MySqlCommand("SELECT * FROM `ученики`");
            DataTable uchenik = func.getData(command);
            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `медкартаа`");
            DataTable med = func.getData(command1);
            MySqlCommand command2 = new MySqlCommand("SELECT * FROM `сдачанормативовв`");
            DataTable normative = func.getData(command2);
            for (int i = 0; i < uchenik.Rows.Count; i++)
            {
                if (id == Convert.ToInt32(uchenik.Rows[i]["IDученика"]))
                {
                    im = uchenik.Rows[i]["Имя"].ToString(); fam = uchenik.Rows[i]["Фамилия"].ToString(); godr = Convert.ToInt32(uchenik.Rows[i]["Год рождения"]);
                    label5.Text = label5.Text + im; label8.Text = label8.Text + fam; label1.Text = label1.Text + godr.ToString();
                }                
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridView1.DataSource;
                bs.Filter = "[ID ученика]=" + id;
                dataGridView1.DataSource = bs;
            }
            int count;
            count = normative.Rows.Count;
            for (int i = 0; i < med.Rows.Count; i++)
            {
                if (id == Convert.ToInt32(med.Rows[i]["ID ученика"]))
                {
                    ves = Convert.ToInt32(med.Rows[i]["Вес"]);
                    index = Convert.ToInt32(med.Rows[i]["Индекс массы тела"]);
                    rost = Convert.ToInt32(med.Rows[i]["Рост"]);
                    if (index + 5 < ves) { medres = "Выше"; }
                    if (index - 10 > ves) { medres = "Ниже"; }
                    if (index - 10 < ves && ves < index + 5) { medres = "Норма"; }
                    vkk = med.Rows[i]["ВКК"].ToString();
                    prot = med.Rows[i]["Противопоказания"].ToString();
                }
            }
            if (vkk == "нет") { richTextBox17.Text = "Ученик посещает уроки физической культуры\n\nПротивопоказаний нет"; }
            if (vkk == "есть") { richTextBox17.Text = "Ученик освобожден от уроков физической культуры\n\nПротивопоказание: " + prot; }
            if (medres == "Выше") { richTextBox17.Text = richTextBox17.Text + "\n\n" + "Вес ученика:" + ves + "кг" + "\n\n" + "Рост ученика:" + rost + "см" + "\n\nИндекс массы тела превышает норму"; }
            if (medres == "Норма") { richTextBox17.Text = richTextBox17.Text + "\n\n" + "Вес ученика:" + ves + "кг" + "\n\n" + "Рост ученика:" + rost + "см" + "\n\nИндекс массы тела соответствует норме"; }
            if (medres == "Ниже") { richTextBox17.Text = richTextBox17.Text + "\n\n" + "Вес ученика:" + ves + "кг" + "\n\n" + "Рост ученика:" + rost + "см" + "\n\nИндекс массы тела ниже нормы"; }


            int[] norm = new int[count];
            string[] res = new string[count];
            for (int i = 0; i < count; i++)
            {
                if (id == Convert.ToInt32(normative.Rows[i]["ID ученика"]))
                {
                    norm[i] = Convert.ToInt32(normative.Rows[i]["ID норматива"]); res[i] = normative.Rows[i]["Итог"].ToString();
                    if (norm[i] == 2)
                    {
                        switch (res[i])
                        {
                            case "Высокий": richTextBox7.Visible = true; obyaspr = richTextBox7.Text; richTextBox14.SendToBack(); break;
                            case "Средний": richTextBox6.Visible = true; obyaspr = richTextBox6.Text; richTextBox14.SendToBack(); break;
                            case "Низкий": richTextBox2.Visible = true; obyaspr = richTextBox2.Text; richTextBox14.SendToBack(); break;
                            default: richTextBox14.BringToFront(); obyaspr = richTextBox14.Text; break;
                        }
                    }
                    if (norm[i] == 3)
                    {
                        switch (res[i])
                        {
                            case "Высокий": richTextBox10.Visible = true; obyasmet = richTextBox10.Text; richTextBox15.SendToBack(); break;
                            case "Средний": richTextBox9.Visible = true; obyasmet = richTextBox9.Text; richTextBox15.SendToBack(); break;
                            case "Низкий": richTextBox8.Visible = true; obyasmet = richTextBox8.Text; richTextBox15.SendToBack(); break;
                            default: richTextBox15.BringToFront(); obyasmet = richTextBox15.Text; break;
                        }
                    }
                    if (norm[i] == 1)
                    {
                        switch (res[i])
                        {
                            case "Высокий": richTextBox13.Visible = true; obyasbeg = richTextBox13.Text; richTextBox16.SendToBack(); break;
                            case "Средний": richTextBox12.Visible = true; obyasbeg = richTextBox12.Text; richTextBox16.SendToBack(); break;
                            case "Низкий": richTextBox11.Visible = true; obyasbeg = richTextBox11.Text; richTextBox16.SendToBack(); break;
                            default: richTextBox16.BringToFront(); obyasbeg = richTextBox16.Text; break;
                        }
                    }
                }
            }
            if (richTextBox13.Visible == true) { richTextBox1.Text = richTextBox1.Text + "Бег 30 метров. Челночный бег 3х10 метров. \n\nОчень сильные мышцы ног необходимы для бега на короткие дистанции. Хороший результат в беге на короткие дистанции часто является показателем хорошо развитой взрывной силы. Этот аспект является толчком к самореализации в таких видах спорта, как легкая атлетика, футбол и баскетбол.\n\n\n\n\n"; }
            if (richTextBox12.Visible == true || richTextBox11.Visible == true)
            {
                richTextBox1.Text = richTextBox1.Text + "Бег 30 метров. Челночный бег 3х10 метров. \n\n Бег на короткие дистанции предполагает анаэробное дыхание, поэтому выносливость практически не нужна. Имеет значение общая физическая подготовка. Скорость бега зависит от частоты и длины ваших шагов. Для бега на короткие дистанции очень важно иметь очень сильные мышцы ног. " +
"Поэтому одна из основных составляющих тренировки спринтера силовые и барьерные упражнения. Многие упражнения на силовые блоки выполняются с лишним весом. К ним относятся: кратковременное максимальное ускорение с «тележкой», ускорение с замедлением (тренажер замедляет бег спортсмена с помощью фитнес-ленты), «брейки» и выпады с легкой штангой. Прыжки создают в спринтере взрывную силу, что крайне необходимо, поэтому прыжковые упражнения должны быть еще одним компонентом тренировки. " +
"\nЧтобы улучшить свои результаты в беге на короткие дистанции, важно научиться правильной технике бега. Правильная техника бега не только улучшит ваши результаты, но и защитит вас от нежелательных травм.\n\n Техника бега на короткие дистанции.\n1) бег должен быть ритмичным и свободным с небольшим наклоном корпуса вперед.\n2) при отталкивании нога должна быть полностью выпрямлена.\n3) после завершения отталкивания нога расслабленно сгибается в колене и выносится бедром вперед.\n" +
"4) нога касается дорожки носком и на протяжении всей фазы опоры стопа не падает на пятку.\n5) ступни ставятся по прямой линии.\n8) нельзя закидывать ноги далеко вперед.\n9) во время бега руки согнуты в локтях(руки помогают сохранять равновесие и поддерживать или изменять темп движения).\n\n\n\n\n";
            }
            if (richTextBox10.Visible == true) { richTextBox1.Text = richTextBox1.Text + "Метание набивного мяча двумя руками из-за головы сидя. \n\nПри метании набивного мяча двумя руками из-за головы задействуются несколько групп мышц (мышцы рук и плечевого пояса, а также мышцы пресса и спины), поэтому хорошие результаты в этом упражнении часто являются показателем сильного атакующего удара в боксе или волейболе.\n\n\n\n\n"; }
            if (richTextBox9.Visible == true || richTextBox8.Visible == true) { richTextBox1.Text = richTextBox1.Text + "Метание набивного мяча двумя руками из-за головы сидя. \n\nПри метании набивного мяча двумя руками из-за головы задействуются несколько групп мышц (мышцы рук и плечевого пояса, а также мышцы пресса и спины), поэтому хорошие результаты в этом упражнении часто являются показателем сильного атакующего удара в боксе или волейболе. Соответственно, для улучшения результатов норматива, стоит развивать эти группы мышц в тренажерном зале или домашних условиях.\nЧтобы улучшить свои результаты броска набивного мяча из-за головы, важно научиться правильной технике. Правильная техника броска не только улучшит ваши результаты, но и защитит вас от нежелательных травм.\n\nТехника броска набивного мяча двумя руками из-за головы сидя делится на две фазы.\n1. Фаза перед броском.\nИспытуемый сидит на линии, ноги врозь, держа мяч перед собой.\n2. Фаза броска.\nИспытуемый сидит на линии, ноги врозь, держа мяч перед собой. Поднимая мяч вверх, сгибает руки в локтевых суставах и опускает мяч за голову, и резким движением бросает мяч вперед и вверх.\n\n\n\n\n"; }
            if (richTextBox7.Visible == true) { richTextBox1.Text = richTextBox1.Text + "Прыжки в длину с места \n\nПоскольку прыжки развивают взрывную силу ног, их часто включают в комплексную тренировку спортсменов, например, по легкой атлетике, баскетболу, боксу. Хороший результат при выполнении прыжков в длину с места станет толчком к самореализации в этих видах спорта.\n\n\n\n\n"; }
            if (richTextBox6.Visible == true || richTextBox2.Visible == true) { richTextBox1.Text = richTextBox1.Text + "Прыжки в длину с места \n\nТак как прыжки развивают взрывную силу ног, их часто включают в комплексную тренировку спортсменов, например, в легкой атлетике, баскетболе боксе и т.д. Во время выполнения прыжковых упражнений задействуется несколько групп мышц (четырехглавые мышцы бедра, ягодичные мышцы, мышцы спины, а также стопы и голени). Соответственно, стоит развивать эти группы мышц в тренажерном зале или домашних условиях. Одним из наиболее эффективных методов развития взрывной силы является методика Юрия Витальевича Верхошанского (профессора, доктора педагогических наук) «Ударный метод». Ударный метод разработан Ю.В. Верхошанского на тренировке сборной СССР по легкой атлетике в конце 60-х - начале 70-х годов. В основе этой техники лежат различные виды прыжков: глубокие прыжки (это прыжок с определенной высоты), прыжки через преграды, прыжки через скамейку, упражнения с отягощениями.\n\nЧтобы улучшить свои результаты в прыжках в длину с места, важно научиться правильной технике бега. Правильная техника прыжка не только улучшит ваши результаты, но и защитит вас от нежелательных травм.\n\nТехника прыжка в длину с места делится на три фазы.\n1. Фаза перед отталкиванием.\nне допускается переступать линию оттока или касаться ее, а также отталкиваться от предварительного прыжка;\n2. Фаза отталкивания.\nНемного отведите руки назад и согните ноги в коленных и тазобедренных суставах. Сделайте резкий выпад руками вперед и резко оторвитесь от земли.\n3. Фаза полета и приземления.\nиспытуемый полностью вытягивается, затем подтягивает ноги к груди, при этом руки отводятся назад. После чего прыгун выпрямляет ноги в коленях. В момент касания ногами земли, руки активно выводятся вперед, одновременно сгибая ноги в коленных суставах.\n\n\n\n\n"; }


        }
    }
}
