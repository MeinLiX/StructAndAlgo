using System;
using System.Linq;

namespace ArrayAndMatrixSort
{
    class Question2
    {
        private void MinAndMaxOfArr2_log(ref int[,] array)
        {
            int min = array[0, 0];
            int max = array[0, 0];
            foreach (int item in array)
            {
                min = item < min ? item : min;
                max = item > max ? item : max;
            }
            Console.WriteLine($"Min value: {min}");
            Console.WriteLine($"Min value: {max}");
        }

        private void Sort_DOWN_RIGHT(ref int[,] array)
        {
            var array_1d = Algo.ConvertTo1d(array);
            Algo.QuickSort(ref array_1d);
            Algo.ConvertTo2d(ref array, array_1d);
        }
        public void Init()
        {
            Console.WriteLine("\n**************\t" + this.GetType().Name);

            const int arrSize = 8;
            int[,] array = new int[arrSize, arrSize];
            Algo.InitialArray(ref array, arrSize: arrSize, isRandom: true);

            Algo.FnInvoke(ref array, MinAndMaxOfArr2_log);


            int[,] SortedArray_DOWN_RIGHT = (int[,])array.Clone();
            Algo.SortAndPrint(ref SortedArray_DOWN_RIGHT, Sort_DOWN_RIGHT);

        }
    }
}
