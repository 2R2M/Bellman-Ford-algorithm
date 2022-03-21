using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace course_project 
{
    public partial class Output : Form
    {
        public DataGridView dataGridView;
        public List<Edges> _edges;

        public Output()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawGr(sender, new PaintEventArgs(this.CreateGraphics(), new Rectangle()));
        }

        public void DrawGr(object sender, PaintEventArgs e)
        {
            DrawGraph drawGraph = new DrawGraph(300, 300, 400, 300);
            Input input = new Input();
            int n = Input.n;
            InputInformation inputInformation = new InputInformation();
        
            _edges = Input._edges;
            List<Edges> edgesL = new List<Edges>() { };
            List<PointF> pointFs = new List<PointF>() { };
            for (int i = 0; i < _edges.Count; i++)
            {
                drawGraph.CreatePoint(_edges[i]);
            }
            Dictionary<int, PointF> DpointF = DrawGraph.DictPoint;
            edgesL = DrawGraph.edg;
            for (int i = 0; i < edgesL.Count; i++)
            {
                drawGraph.DrawEdge(edgesL[i], DpointF, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DrawGrSort(sender, new PaintEventArgs(this.CreateGraphics(), new Rectangle()));
        }


        public void DrawGrSort(object sender, PaintEventArgs e)
        {
            DrawGraph.DictPoint.Clear();
            DrawGraph.edg.Clear();
            DrawGraph drawGraph = new DrawGraph(300, 300, 700, 300);
            Input input = new Input();
            int n = Input.n;
            _edges = Input._edges;
            int start_number = int.Parse(textBox1.Text);
            Graph graph = new Graph(_edges.Count, start_number);
            List<Edges> edgSort = graph.bellman_ford(n, start_number, _edges.Count, _edges);
            for (int i = 0; i < edgSort.Count; i++)
            {
                drawGraph.CreatePoint(edgSort[i]);
            }
            Dictionary<int, PointF> DpointF = DrawGraph.DictPoint;
            List<Edges> edgesL = new List<Edges>() { };
            edgesL = DrawGraph.edg;
            for (int i = 0; i < edgesL.Count; i++)
            {
                drawGraph.DrawEdge(edgesL[i], DpointF, e);
            }
          
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
