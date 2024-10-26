using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Autosaloon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Automobile> cars= new List<Automobile>(); // список всех Автомобилей(экземпляров класса)


        private void Form1_Load(object sender, EventArgs e)
        {
            SQLiteConnection connection = new SQLiteConnection("Integrated Security = SSPI; Data Source = automobile.db"); 
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"SELECT  Brand,Model,Cost,Amount  FROM Cars";
            using (var rd1 = command.ExecuteReader())
            {

                while (rd1.Read())
                {
                    cars.Add(new Automobile(rd1.GetString(0), rd1.GetString(1),rd1.GetInt32(2),rd1.GetInt32(3)));
                }
            }
            connection.Close();

            dataGridView1.DataSource= cars; // заполняем таблицу данными о всех автомобилях
            for(int i = 0; i < cars.Count; i++) // выводим график стоимость всех автомобилей , где ось Х- модель , а ось У-стоимость
            {
                chart1.Series[0].Points.AddXY(cars[i].Model, cars[i].Cost);
            }

            comboBox1.Items.Add("Toyota"); // добавялем в combobox все марки(для последюущих запросов)
            comboBox1.Items.Add("Nissan");
            comboBox1.Items.Add("Audi");
            comboBox1.Items.Add("BMW");
            comboBox1.Items.Add("Lada");
            comboBox1.Items.Add("Cherry");
            comboBox1.Items.Add("Ford");
            comboBox1.Items.Add("Lotus");

            comboBox1.Items.Add("Отсортировать по стоимсоти(от меньшей к большей)"); // добавялем в combobox придуманные нами сортировки
            comboBox1.Items.Add("Отсортировать по стоимсоти(от большей к меньшей)");
            comboBox1.Items.Add("Отсортировать по колличеству");
            comboBox1.Items.Add("Автомобили стоимость больше 8.000.000 рублей");
            comboBox1.Items.Add("Автомобили, которых в наличии менее 100 единиц");

            
            comboBox2.Hide();
            label3.Hide();
        }

       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //метод который активируется при изменении выбранного элемента combobox
        {
            if(comboBox1.SelectedIndex == 0) // индекс выбранного элемента совпадает с порядком как мы их добавили, отсчет начинается с нуля
            {


                comboBox2.Show();
                
                
                comboBox2.Items.Clear();
                this.chart1.Series[0].Points.Clear(); //отчищаем график чтобы они не наложились друг на друга
                IEnumerable<Automobile> query = cars.Where(n => n.Brand == "Toyota"); // самый обычный запрос который из всего списка машин выберает только те у которых марка Toyota
                
                List<Automobile> temp = query.ToList(); // превращаем рерузбтат опроса в список
                dataGridView1.DataSource = temp; // выводим результат запрос в таблицу , т.к талбица ввыодит только массива и списки
                for (int i = 0;i<temp.Count;i++)
                {
                    chart1.Series[0].Points.AddXY(temp[i].Model, temp[i].Cost); // заполняем график заново
                    comboBox2.Items.Add(temp[i].Model.ToString());
                }
                
            }
            if (comboBox1.SelectedIndex == 1)
            {
                comboBox2.Show();
                
                comboBox2.Items.Clear();
                this.chart1.Series[0].Points.Clear();
                IEnumerable<Automobile> query = cars.Where(n => n.Brand == "Nissan");

                List<Automobile> temp = query.ToList();
                dataGridView1.DataSource = temp;    
                for (int i = 0; i < temp.Count; i++)
                {
                    chart1.Series[0].Points.AddXY(temp[i].Model, temp[i].Cost);
                    comboBox2.Items.Add(temp[i].Model.ToString());
                }
            }
            if (comboBox1.SelectedIndex == 2)
            {
                comboBox2.Show();
            
                comboBox2.Items.Clear();
                this.chart1.Series[0].Points.Clear();
                IEnumerable<Automobile> query = cars.Where(n => n.Brand == "Audi");

                List<Automobile> temp = query.ToList();
                dataGridView1.DataSource = temp; for (int i = 0; i < temp.Count; i++)
                {
                    chart1.Series[0].Points.AddXY(temp[i].Model, temp[i].Cost);
                    comboBox2.Items.Add(temp[i].Model.ToString());
                }
            }
            if (comboBox1.SelectedIndex == 3)
            {
                comboBox2.Show();
             
                comboBox2.Items.Clear();
                this.chart1.Series[0].Points.Clear();
                IEnumerable<Automobile> query = cars.Where(n => n.Brand == "BMW");

                List<Automobile> temp = query.ToList();
                dataGridView1.DataSource = temp; for (int i = 0; i < temp.Count; i++)
                {
                    chart1.Series[0].Points.AddXY(temp[i].Model, temp[i].Cost);
                    comboBox2.Items.Add(temp[i].Model.ToString());
                }
            }
            if (comboBox1.SelectedIndex == 4)
            {
                comboBox2.Show();
             
                comboBox2.Items.Clear();
                this.chart1.Series[0].Points.Clear();
                IEnumerable<Automobile> query = cars.Where(n => n.Brand == "Lada");

                List<Automobile> temp = query.ToList();
                dataGridView1.DataSource = temp; for (int i = 0; i < temp.Count; i++)
                {
                    chart1.Series[0].Points.AddXY(temp[i].Model, temp[i].Cost);
                    comboBox2.Items.Add(temp[i].Model.ToString());
                }
            }
            if (comboBox1.SelectedIndex == 5)
            {
                comboBox2.Show();
                
                comboBox2.Items.Clear();
                this.chart1.Series[0].Points.Clear();
                IEnumerable<Automobile> query = cars.Where(n => n.Brand == "Cherry");

                List<Automobile> temp = query.ToList();
                dataGridView1.DataSource = temp; for (int i = 0; i < temp.Count; i++)
                {
                    chart1.Series[0].Points.AddXY(temp[i].Model, temp[i].Cost);
                    comboBox2.Items.Add(temp[i].Model.ToString());
                }
            }
            if (comboBox1.SelectedIndex == 6)
            {
                comboBox2.Show();
               
                comboBox2.Items.Clear();
                this.chart1.Series[0].Points.Clear();
                IEnumerable<Automobile> query = cars.Where(n => n.Brand == "Ford");

                List<Automobile> temp = query.ToList();
                dataGridView1.DataSource = temp; for (int i = 0; i < temp.Count; i++)
                {
                    chart1.Series[0].Points.AddXY(temp[i].Model, temp[i].Cost);
                    comboBox2.Items.Add(temp[i].Model.ToString());
                }
            }
            if (comboBox1.SelectedIndex == 7)
            {
                comboBox2.Show();
              
                comboBox2.Items.Clear();
                this.chart1.Series[0].Points.Clear();
                IEnumerable<Automobile> query = cars.Where(n => n.Brand == "Lotus");

                List<Automobile> temp = query.ToList();
                dataGridView1.DataSource = temp; for (int i = 0; i < temp.Count; i++)
                {
                    chart1.Series[0].Points.AddXY(temp[i].Model, temp[i].Cost);
                    comboBox2.Items.Add(temp[i].Model.ToString());
                }
            }
            if (comboBox1.SelectedIndex == 8)
            {
                comboBox2.Hide();
                label3.Hide();
                this.chart1.Series[0].Points.Clear();
                IEnumerable<Automobile> query = cars.OrderBy(n => n.Cost); //Вид сортировки идентичен , меняем только параметры OrderBy- сортировка от меньшего к большему int значений

                List<Automobile> temp = query.ToList();
                dataGridView1.DataSource = temp; for (int i = 0; i < temp.Count; i++)
                {
                    chart1.Series[0].Points.AddXY(temp[i].Model, temp[i].Cost);

                }
            }
            if (comboBox1.SelectedIndex == 9)
            {
                comboBox2.Hide();
                label3.Hide();
                this.chart1.Series[0].Points.Clear();
                IEnumerable<Automobile> query = cars.OrderBy(n => n.Cost).Reverse(); //в конце reverse чтобы сортировка была от большего к меньшему

                List<Automobile> temp = query.ToList();
                dataGridView1.DataSource = temp; for (int i = 0; i < temp.Count; i++)
                {
                    chart1.Series[0].Points.AddXY(temp[i].Model, temp[i].Cost);
                }
            }
            if (comboBox1.SelectedIndex == 10)
            {
                comboBox2.Hide();
                label3.Hide();
                this.chart1.Series[0].Points.Clear();
                IEnumerable<Automobile> query = cars.OrderBy(n => n.Amount); // сортировкуа по колличеству

                List<Automobile> temp = query.ToList();
                dataGridView1.DataSource = temp; for (int i = 0; i < temp.Count; i++)
                {
                    chart1.Series[0].Points.AddXY(temp[i].Model, temp[i].Cost);
                }
            }
            if (comboBox1.SelectedIndex == 11)
            {
                comboBox2.Hide();
                label3.Hide();
                this.chart1.Series[0].Points.Clear();
                IEnumerable<Automobile> query = cars.Where(n => n.Cost > 8000000); //где стоимость выше 8.000.000

                List<Automobile> temp = query.ToList();
                dataGridView1.DataSource = temp; for (int i = 0; i < temp.Count; i++)
                {
                    chart1.Series[0].Points.AddXY(temp[i].Model, temp[i].Cost);
                }
            }
            if (comboBox1.SelectedIndex == 12)
            {
                comboBox2.Hide();
                label3.Hide();
                this.chart1.Series[0].Points.Clear();
                IEnumerable<Automobile> query = cars.Where(n => n.Amount < 100); //колличество меньше 100

                List<Automobile> temp = query.ToList();
                dataGridView1.DataSource = temp; for (int i = 0; i < temp.Count; i++)
                {
                    chart1.Series[0].Points.AddXY(temp[i].Model, temp[i].Cost);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<Automobile> query=cars.Where(n=>n.Model==comboBox2.Text);
            List<Automobile> temp = query.ToList();
            label3.Text= comboBox2.Text + " " + " Стоимость:" +' ' + temp[0].Cost;
            label3.Show();
        }
    }
}
