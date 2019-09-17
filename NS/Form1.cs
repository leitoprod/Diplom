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
            //Импортируем из txt данные в dataGridView1
            string s;
            int i = 0;
            StreamReader f = new StreamReader(@"..\..\database.txt");
            while ((s = f.ReadLine()) != null)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = i.ToString();
                dataGridView1.Rows[i].Cells[1].Value = s.ToString();
                i++;
            }
            f.Close();
            int kolVoStrok = i-3;   //запоминаем количество строк импортированных из txt
            int x = 0;
            while (x<10) //создаем и импортируем данные о первых 10 днях в datagridView2
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[x].Cells[0].Value = x.ToString();
                dataGridView2.Rows[x].Cells[1].Value = dataGridView1.Rows[x].Cells[1].Value;
                dataGridView2.Rows[x].Cells[2].Value = 0;
                x++;
            }
            StreamReader k = new StreamReader(@"..\..\koff.txt"); //импортируем данные о коэффициентах из файла
            textBox4.Text = k.ReadLine();
            textBox5.Text = k.ReadLine();
            textBox7.Text = k.ReadLine();
            textBox8.Text = k.ReadLine();
            k.Close();

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

            double a = 0.1;
          
            textBox6.Text = a.ToString();
           
            textBox9.Text = 10.ToString(); //Для корректной работы некоторых функций в некоторых полях должны стоять данные числа
            textBox12.Text = 0.ToString();
            textBox14.Text = 100.ToString();
            textBox13.Text = 100.ToString();
            i = 0;
            while (i < 1000) //добовялем пустые строки
            {
                i++;
                dataGridView2.Rows.Add();
            }
        }

       
        private void button1_Click(object sender, EventArgs e) //кнопка Работаем
        {

            double v = double.Parse(textBox4.Text); //импорт информации из textBox в переменные
            double u = double.Parse(textBox5.Text);
            double a = double.Parse(textBox6.Text);
            double W = double.Parse(textBox7.Text);
            double b = double.Parse(textBox8.Text);
            int x = int.Parse(textBox9.Text);
            x = x - 10;
            double h0 = 0;
            double h1, h2, h3, h4, h5, h6, h7, h8, h9, h10;
            double s1, s2, s3, s4, s5, s6, s7, s8, s9, s10;
            double b1, b2, b3, b4, b5, b6, b7, b8, b9;
            double bo,bh;
            double y;
            double deltaW, deltaBy, deltaV, deltaU, deltaBh;


            double maxMinusMin = double.Parse(textBox2.Text) - double.Parse(textBox1.Text);   //Максимум минус Минимум для функции нормализации

            s1 = (v * (double.Parse(dataGridView1.Rows[x].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture) - double.Parse(textBox1.Text)) / maxMinusMin) + (u * h0) + a;
            h1 = Math.Tanh(s1);
            //Находим s1...s10, h1..h10
            s2 = (v * (double.Parse(dataGridView1.Rows[x+1].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture) - double.Parse(textBox1.Text)) / maxMinusMin) + (u * h1) + a;
            h2 = Math.Tanh(s2);

            s3 = (v * (double.Parse(dataGridView1.Rows[x+2].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture) - double.Parse(textBox1.Text)) / maxMinusMin) + (u * h2) + a;
            h3 = Math.Tanh(s3);

            s4 = (v * (double.Parse(dataGridView1.Rows[x+3].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture) - double.Parse(textBox1.Text)) / maxMinusMin) + (u * h3) + a;
            h4 = Math.Tanh(s4);

            s5 = (v * (double.Parse(dataGridView1.Rows[x+4].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture) - double.Parse(textBox1.Text)) / maxMinusMin) + (u * h4) + a;
            h5 = Math.Tanh(s5);

            s6 = (v * (double.Parse(dataGridView1.Rows[x+5].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture) - double.Parse(textBox1.Text)) / maxMinusMin) + (u * h5) + a;
            h6 = Math.Tanh(s6);

            s7 = (v * (double.Parse(dataGridView1.Rows[x+6].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture) - double.Parse(textBox1.Text)) / maxMinusMin) + (u * h6) + a;
            h7 = Math.Tanh(s7);

            s8 = (v * (double.Parse(dataGridView1.Rows[x+7].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture) - double.Parse(textBox1.Text)) / maxMinusMin) + (u * h7) + a;
            h8 = Math.Tanh(s8);

            s9 = (v * (double.Parse(dataGridView1.Rows[x + 8].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture) - double.Parse(textBox1.Text)) / maxMinusMin) + (u * h8) + a;
            h9 = Math.Tanh(s9);

            s10 = (v * (double.Parse(dataGridView1.Rows[x + 9].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture) - double.Parse(textBox1.Text)) / maxMinusMin) + (u * h9) + a;
            h10 = Math.Tanh(s10);

            y = W * h10 + b; 


            ////////////////////  ОБРАТНЫЙ ПРОХОД  /////////////////////////
            if (dataGridView1.Rows[x + 10].Cells[1].Value == null) return; //условие проверяющее что мы не дошли до конца дней
            bo = y - ((double.Parse(dataGridView1.Rows[x + 10].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture) - double.Parse(textBox1.Text)) / maxMinusMin);
            bo = y - ((double.Parse(dataGridView1.Rows[x + 10].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture) - double.Parse(textBox1.Text)) / maxMinusMin);
            bh = W * bo*(((0.5*(Math.Cosh(2*y)+1))- 0.5 * (Math.Sinh(2 * y) + 1))/ (0.5 * (Math.Cosh(2 * y) + 1))); 

            b9 = u * bh * (((0.5 * (Math.Cosh(2 * s9) + 1)) - 0.5 * (Math.Sinh(2 * s9) + 1)) / (0.5 * (Math.Cosh(2 * s9) + 1))); 
            b8 = u * b9 * (((0.5 * (Math.Cosh(2 * s8) + 1)) - 0.5 * (Math.Sinh(2 * s8) + 1)) / (0.5 * (Math.Cosh(2 * s8) + 1)));
            b7 = u * b8 * (((0.5 * (Math.Cosh(2 * s7) + 1)) - 0.5 * (Math.Sinh(2 * s7) + 1)) / (0.5 * (Math.Cosh(2 * s7) + 1)));
            b6 = u * b7 * (((0.5 * (Math.Cosh(2 * s6) + 1)) - 0.5 * (Math.Sinh(2 * s6) + 1)) / (0.5 * (Math.Cosh(2 * s6) + 1)));
            b5 = u * b6 * (((0.5 * (Math.Cosh(2 * s5) + 1)) - 0.5 * (Math.Sinh(2 * s5) + 1)) / (0.5 * (Math.Cosh(2 * s5) + 1)));
            b4 = u * b5 * (((0.5 * (Math.Cosh(2 * s4) + 1)) - 0.5 * (Math.Sinh(2 * s4) + 1)) / (0.5 * (Math.Cosh(2 * s4) + 1))); 
            b3 = u * b4 * (((0.5 * (Math.Cosh(2 * s3) + 1)) - 0.5 * (Math.Sinh(2 * s3) + 1)) / (0.5 * (Math.Cosh(2 * s3) + 1)));
            b2 = u * b3 * (((0.5 * (Math.Cosh(2 * s2) + 1)) - 0.5 * (Math.Sinh(2 * s2) + 1)) / (0.5 * (Math.Cosh(2 * s2) + 1)));
            b1 = u * b2 * (((0.5 * (Math.Cosh(2 * s1) + 1)) - 0.5 * (Math.Sinh(2 * s1) + 1)) / (0.5 * (Math.Cosh(2 * s1) + 1)));

            ///////////////////Изменения весов /////////////
            
            deltaW = bo * h10; 
            deltaBy = bo; 
            deltaV = b1 * ((double.Parse(dataGridView1.Rows[x].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture) - double.Parse(textBox1.Text)) / maxMinusMin) + b2 * ((double.Parse(dataGridView1.Rows[x + 1].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture) - double.Parse(textBox1.Text)) / maxMinusMin) + b3 * ((double.Parse(dataGridView1.Rows[x + 2].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture) - double.Parse(textBox1.Text)) / maxMinusMin) + b4 * ((double.Parse(dataGridView1.Rows[x + 3].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture) - double.Parse(textBox1.Text)) / maxMinusMin) + b5 * ((double.Parse(dataGridView1.Rows[x + 4].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture) - double.Parse(textBox1.Text)) / maxMinusMin) + b6 * ((double.Parse(dataGridView1.Rows[x + 5].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture) - double.Parse(textBox1.Text)) / maxMinusMin) + b7 * ((double.Parse(dataGridView1.Rows[x + 6].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture) - double.Parse(textBox1.Text)) / maxMinusMin) + b8 * ((double.Parse(dataGridView1.Rows[x + 7].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture) - double.Parse(textBox1.Text)) / maxMinusMin) + b9 * ((double.Parse(dataGridView1.Rows[x + 8].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture) - double.Parse(textBox1.Text)) / maxMinusMin) + bh * ((double.Parse(dataGridView1.Rows[x + 9].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture) - double.Parse(textBox1.Text)) / maxMinusMin);
            deltaU = b1 * h0 + b2 * h1 + b3 * h2 + b4 * h3 + b5 * h4 + b6 * h5 + b7 * h6 + b8 * h7 + b9 * h8 + bh * h9;
            deltaBh = b1 + b2 + b3 + b4 + b5 + b6 + b7 + b8 + b9 + bh;

            //////////////////////результат и выход////////////////////////
            
            x = x + 10;
            y = y * maxMinusMin + double.Parse(textBox1.Text);
            bo = y - double.Parse(dataGridView1.Rows[x].Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture);
            dataGridView2.Rows[x].Cells[0].Value = x;
            dataGridView2.Rows[x].Cells[1].Value = y;


            if (Math.Abs(bo) < 0.01 ) //условие изменяющее цвет ячейки в зависимости от размера ошибки
            {
                dataGridView2.Rows[x].Cells[2].Value = bo;
                dataGridView2.Rows[x].Cells[2].Style.BackColor = System.Drawing.Color.LightGreen;
            }
            if (Math.Abs(bo) > 0.01 && Math.Abs(bo) < 0.1) //условие изменяющее цвет ячейки в зависимости от размера ошибки
            {
                dataGridView2.Rows[x].Cells[2].Value = bo;
                dataGridView2.Rows[x].Cells[2].Style.BackColor = System.Drawing.Color.Yellow;
            }
            if (Math.Abs(bo) > 0.1&& Math.Abs(bo) < 1) //условие изменяющее цвет ячейки в зависимости от размера ошибки
            {
                dataGridView2.Rows[x].Cells[2].Value = bo;
                dataGridView2.Rows[x].Cells[2].Style.BackColor = System.Drawing.Color.Orange;
            }
            if (Math.Abs(bo) > 1) //условие изменяющее цвет ячейки в зависимости от размера ошибки
            {
                dataGridView2.Rows[x].Cells[2].Value = bo;
                dataGridView2.Rows[x].Cells[2].Style.BackColor = System.Drawing.Color.Tomato;
            }


            textBox3.Text = y.ToString();//Результат записываем в поле результат
            x=x+1;
            v = v - deltaV/4; //изменяем веса
            u = u - deltaU /4;
            W = W - deltaW / 4;
            b = b - deltaBh / 4;
            textBox4.Text = v.ToString(); //записываем изменение весов в textBox 
            textBox5.Text = u.ToString();
            textBox6.Text = a.ToString();
            textBox7.Text = W.ToString();
            textBox8.Text = b.ToString();
            textBox9.Text = x.ToString();
        }

        private void button2_Click(object sender, EventArgs e) //Проходим 100 дней
        {
            int i = 0;
            while (i<100)
                {
                button1_Click(sender, e);
                i++;
            }
        }

        private void button3_Click(object sender, EventArgs e) //функция вычисления общей ошибки
        {
            int i = 10;
            double error = 0;
            int x = 0;
            while(i!=1000)
            {
                error = Math.Abs(double.Parse(dataGridView2.Rows[i].Cells[2].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture))+error;
                i++;
                x++;
            }
            i = i - 10;
            error = error / x;
            textBox10.Text = error.ToString();
        }

        private void button4_Click(object sender, EventArgs e) //функция вычисления ошибки за последние 50 значений
        {
            int i = int.Parse(textBox9.Text);
            i = i - 50;
            int x = 0;
            double error = 0;
            while (i!=1000)
            {
                error = Math.Abs(double.Parse(dataGridView2.Rows[i].Cells[2].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture)) + error;
                i++;
                x++;
            }
            
            error = error / x;
            textBox11.Text = error.ToString();
        }

        private void button5_Click(object sender, EventArgs e)  //работаем до конца
        {
            int i = 0;
            while (i < 1000)
            {
                button1_Click(sender, e);
                i++;
            }
        }

        private void button6_Click(object sender, EventArgs e)      //функция одной эпохи (считает одну эпоху и проверяет соостветсвие лучших коэффциаетов и значений, если текущий проход лучше изменяет лучшие) 
        {
            int i = 0;
            double exiterror=double.Parse(textBox14.Text);
            textBox9.Text = 10.ToString();
            double errorallnow = double.Parse(textBox13.Text);
            double errorall=0;
            
                
                textBox9.Text = 10.ToString();
                button5_Click(sender, e);
                int o = int.Parse(textBox9.Text);
                o = o - 50;
                int x = 0;
                double error = 0;
                while (o != 1000)
                {
                    error = Math.Abs(double.Parse(dataGridView2.Rows[o].Cells[2].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture)) + error;
                    o++;
                    x++;
                }

                error = error / x;
                if (error < exiterror)
                {
                    exiterror = error;
                    textBox16.Text = textBox4.Text;
                    textBox15.Text = textBox5.Text;
                    textBox18.Text = textBox7.Text;
                    textBox17.Text = textBox8.Text;

                }
                i++;
                o = 10;
                x = 0;
                while (o != 327)
                {
                    errorall = Math.Abs(double.Parse(dataGridView2.Rows[o].Cells[2].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture)) + errorall;
                    o++;
                    x++;
                }
                errorall = errorall /x;
                if (errorall < errorallnow) { errorallnow = errorall; textBox13.Text = errorallnow.ToString(); }
            
            i = 0;
            i = int.Parse(textBox12.Text.ToString());
            i++;
            textBox12.Text = i.ToString();
            button3_Click(sender, e);
            button4_Click(sender, e);            
            textBox14.Text = exiterror.ToString();
        }

        private void button7_Click(object sender, EventArgs e)      //запись коэффициентов в файл
        {
            StreamWriter k = new StreamWriter(@"..\..\koff.txt");
            k.Write(textBox4.Text);
            k.Write('\n');
            k.Write(textBox5.Text);
            k.Write('\n');
            k.Write(textBox7.Text);
            k.Write('\n');
            k.Write(textBox8.Text);
            k.Write('\n');


            k.Close();
        }

        private void button8_Click(object sender, EventArgs e)      //1000 эпох (вызывает расчет одной эпохи 1000 раз)
        {
            int i = 0;
            textBox9.Text = 10.ToString();

            progressBar1.Minimum = 0; // по умолчанию
            progressBar1.Maximum = 1000; //по умолчанию
            progressBar1.Value = 0; //по умолчанию
            progressBar1.Step = 1; //по умолчанию
            
            while (i < 1000)
            {
                
                button6_Click(sender, e);
                progressBar1.PerformStep(); //вызываем этот метод для увеличения шкалы progressBar
                i++;

            }
            button3_Click(sender, e);
            button4_Click(sender, e);
        }

        private void button9_Click(object sender, EventArgs e) //запись лучших коэффциантов в файл
        {
            StreamWriter k = new StreamWriter(@"..\..\bestkoff.txt");
            k.Write(textBox16.Text);
            k.Write('\n');
            k.Write(textBox15.Text);
            k.Write('\n');
            k.Write(textBox18.Text);
            k.Write('\n');
            k.Write(textBox17.Text);
            k.Write('\n');
            k.Close();
        }
    }
}


