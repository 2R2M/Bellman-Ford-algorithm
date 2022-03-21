using System.Collections.Generic;

namespace course_project
{
    class InputInformation
    {

        private int[,] Arr;
        private int[,] ArrWeight;
        private Edges t;
        private List<Edges> LEdges;

        public InputInformation() { }

        public InputInformation(int n)
        {
            Arr = new int[n, n];
            ArrWeight = new int[n, n];
            t = new Edges();
            LEdges = new List<Edges>() { };

        }
        //Заполнение массивов
        public void InpArr(int[,] arr)
        {

            Arr = arr;
        }
        public void InpArrWeight(int[,] arr)
        {

            ArrWeight = arr;
        }
        //Возвращение 
        public int[,] ArrReturn()
        {
            return Arr;
        }
        public int[,] ArrWeightReturn()
        {
            return ArrWeight;
        }

        //Преобразование в список структур, нужно для сортировки 
        public  List<Edges> TransfArr(int[,] A, int[,] B)
        {
            t = new Edges();
            LEdges = new List<Edges>() { };
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    if (A[i, j] != 0)
                    {
                 
                        t.u = j;
                        t.v = i;
                        t.w = B[i, j];
                        LEdges.Add(t);

                    }
                    else
                    {
                        t.u = j;
                        t.v = i;
                        t.w = 0;
                        LEdges.Add(t);
                       
                    }
                }
            }
            return LEdges;


        }

    }

}
    
