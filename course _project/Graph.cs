using System.Collections.Generic;

namespace course_project 
{
        public struct Edges
        {
            public int u { get; set; }
            public int v { get; set; }
            public int w { get; set; }
        }
        class Graph
        {
            
            private List<Edges> edgesList;
            private Edges edg;
            public int number_of_edges;
            private int edge_number;
            private int inf = 1000000;
            List<Edges> Edges_sort;
            private int start_number;
            public  List<int> distance; 
        public Graph(int edge_number_, int _start_number)
        {
            edgesList = new List<Edges>() { };
            Edges_sort = new List<Edges>() { };
            edg = new Edges();
            edge_number = edge_number_;
            start_number = _start_number;
            distance = new List<int>() { };

        }
            //Сортировка
           public List<Edges> bellman_ford(int number_of_edges, int starts_number, int edge_number, List<Edges> edges)
            {
                Edges edges1 = new Edges() ;
                int[] arr = new int[inf / 1000];
                for (int i = 0; i < number_of_edges; i++)
                {
                    arr[i] = inf;
                }
                arr[starts_number-1] = 0;
                List<int> N = new List<int>() { };
                List<int> M = new List<int>() { };
                List<int> weight = new List<int>() { };
                for (int i = 0; i < number_of_edges - 1; i++)
                {

                    for (int j = 0; j < edge_number; j++)
                    {
                        if (arr[edges[j].u] > arr[edges[j].v] + edges[j].w)
                        {

                            arr[edges[j].u] = edges[j].w + arr[edges[j].v];
                            N.Add(edges[j].v);
                            M.Add(edges[j].u);
                            weight.Add(edges[j].w);
                        }
                            
                    }
                }
                for (int i = 0; i < N.Count; i++)
                    {
                    edges1.u = N[i];
                    edges1.v = M[i];
                    edges1.w = weight[i];
                    Edges_sort.Add(edges1);

                    }
                 for (int i = 0; i < number_of_edges; i++)
                    {
                    distance.Add(arr[i]);
                    }
                    return Edges_sort;
                }
        }
}
