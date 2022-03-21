using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace course_project 
{
    public partial class Input : Form
    {
        public static int n;
        public DataGridView dataGridView;
        public DataGridView dataGridView1;
        public static List<Edges> _edges;
        public Input()
        {
            InitializeComponent();
        }

        private void Input_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            n = int.Parse(textBox1.Text);
            //Создаем датагрейд
            dataGridView = new DataGridView();
          
            dataGridView.Location = new Point(100, 50);
            dataGridView.Height = 300;
            dataGridView.Width = 300;
            Controls.Add(dataGridView);
            dataGridView.AllowUserToAddRows = false;
            dataGridView.RowTemplate.Height = 30;
            dataGridView.CellContentClick += new DataGridViewCellEventHandler(dataGridView_CellContentClick);
            dataGridView.Height = 30 * n + dataGridView.ColumnHeadersHeight*2;
            dataGridView.Width = 30 * n + dataGridView.RowHeadersWidth;
            for (int i = 0; i < n; i++)
            {
                dataGridView.Columns.Add(i.ToString(), (i+1).ToString());
                DataGridViewColumn gridViewColumn = dataGridView.Columns[i];
                gridViewColumn.Width = 30;
                dataGridView.Rows.Add();

            }
           
            dataGridView1 = new DataGridView();
            dataGridView1.Location = new Point(460, 50);
            dataGridView1.Height = 300;
            dataGridView1.Width = 300;
            Controls.Add(dataGridView1);
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Height = 30 * n + dataGridView.ColumnHeadersHeight*2;
            dataGridView1.Width = 30 * n + dataGridView.RowHeadersWidth;
            dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView_CellContentClick);
            for (int i = 0; i < n; i++)
            {
                dataGridView1.Columns.Add(i.ToString(), (i+1).ToString());
                DataGridViewColumn gridViewColumn1 = dataGridView1.Columns[i];
                gridViewColumn1.Width = 30;
                dataGridView1.Rows.Add();
            }
        }
        private void datagridview_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = (e.Row.Index+1).ToString();
        }
        private void datagridview1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = (e.Row.Index + 1).ToString();
        }
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Заполняем 2 массива, один для матрицы смежности (Arr) и матрица с весами (ArrWeight)
            int[,] Arr = new int[n, n];
            int[,] ArrWeight = new int[n, n];

            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                for (int j = 0; j < dataGridView.ColumnCount; j++)
                {
                    //Преобразуем значения из ячеек в числа, и пишем в массив

                    if (dataGridView[i, j].Value != null)
                    {
                        Arr[i, j] = Convert.ToInt32(dataGridView.Rows[i].Cells[j].Value);
                    }
                    else
                    {
                        dataGridView.Rows[i].Cells[j].Value = 0.ToString();
                        Arr[i, j] = Convert.ToInt32(dataGridView.Rows[i].Cells[j].Value);
                    }
                }
            }

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    //Преобразуем значения из ячеек в числа, и пишем в массив


                    if (dataGridView1[i, j].Value != null)
                    {
                        ArrWeight[i, j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[j].Value = 0.ToString();
                        ArrWeight[i, j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                    }
                }
            }
            //ЗАполняем массивы класса InputInformation
            InputInformation inputInformation = new InputInformation(n);
            try
            {
                inputInformation.InpArr(Arr);
                inputInformation.InpArrWeight(ArrWeight);
            }
            catch
            {
                MessageBox.Show("Массивы не заполняются");
            }
            _edges = inputInformation.TransfArr(inputInformation.ArrReturn(), inputInformation.ArrWeightReturn());
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Output form1 = new Output();
            form1.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Output form1 = new Output();
            form1.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
