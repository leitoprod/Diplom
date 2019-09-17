using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Импортируем из txt данные в dataGridView
            string s;
            int i = 0;
            StreamReader f = new StreamReader(@"C:\Users\Admin\source\repos\NS\NS\database.txt");
            while ((s = f.ReadLine()) != null)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = i.ToString();
                dataGridView1.Rows[i].Cells[1].Value = s.ToString();
                i++;
            }
            f.Close();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            int kolVoStrok = i;   //запоминаем количество строк импортированных из txt

            //Находим Xmin
            i = 0;
            double xmin = double.Parse(dataGridView1.Rows[0].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture);
            while (i < kolVoStrok)
            {
                if (xmin > double.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture))
                {
                    xmin = double.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                }
                i++;
            }
            textBox1.Text = xmin.ToString();


            //Находим Xmax
            i = 0;
            double xmax = double.Parse(dataGridView1.Rows[0].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture);
            while (i<kolVoStrok)
            {
                if(xmax < double.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture))
                {
                    xmax = double.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                }
                i++;
            }
            textBox2.Text = xmax.ToString();

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            double v = 0.7;
            double u = 0.05 ;
            double a = 0.1;
            double h0 = 0;
            double W = 0.5;
            double b = 0.1;
            double h1, h2, h3, h4, h5, h6, h7, h8, h9, h10,hi;
            double s1, s2, s3, s4, s5, s6, s7, s8, s9, s10;
            double si = 0;
            int i = 6;
            double yres;


            double maxMinusMin = double.Parse(textBox2.Text)-double.Parse(textBox1.Text);
            s1 = (v * ((double.Parse(dataGridView1.Rows[5].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture))-double.Parse(textBox1.Text))/maxMinusMin) + (u * (double.Parse(dataGridView1.Rows[4].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture))) + a;
            hi = s1;
            while (i < 15)
            {
                si  = (v * ((double.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture)) - double.Parse(textBox1.Text)) / maxMinusMin) + (u * hi) + a;
                h1 = si;
                i++;



            }
            yres = W * si + b;
            yres = yres * maxMinusMin + double.Parse(textBox1.Text);






            textBox3.Text = yres.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
        }
    }
}
