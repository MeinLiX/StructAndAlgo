using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ArrayAndMatrixSort
{
    class Question3
    {
        private void MinAndMaxOfArr3_log(ref int[,,] array)
        {
            int min = array[0, 0, 0];
            int max = array[0, 0, 0];
            foreach (int item in array)
            {
                min = item < min ? item : min;
                max = item > max ? item : max;
            }
            Console.WriteLine($"Min value: {min}");
            Console.WriteLine($"Min value: {max}");
        }

        private void Sort_OX_OY_OZ_Arr3(ref int[,,] array)
        {
            foreach (var ax in Enum.GetValues(typeof(Algo.Axis)))
                for (int z = 0; z < array.GetLength(2); z++)
                    for (int y = 0; y < array.GetLength(1); y++)
                        for (int x = 0; x < array.GetLength(0); x++)
                        {
                            int[] temp_arr = Algo.ConvertTo1d(array, (Algo.Axis)ax, x, y, z);
                            Algo.QuickSort(ref temp_arr);
                            Algo.Write3dFrom1d(ref array, temp_arr, (Algo.Axis)ax, x, y, z);

                            if ((Algo.Axis)ax == Algo.Axis.OX)
                                x = array.GetLength(0) - 1;
                            else if ((Algo.Axis)ax == Algo.Axis.OY)
                                y = array.GetLength(1) - 1;
                            else if ((Algo.Axis)ax == Algo.Axis.OZ)
                                y = array.GetLength(2) - 1;
                        }
        }

        public void Init()
        {
            Console.WriteLine("\n**************\t" + this.GetType().Name);
            const int arrSize = 6;
            int[,,] array = new int[arrSize, arrSize, arrSize];
            Algo.InitialArray(ref array, arrSize: arrSize);

            Algo.FnInvoke(ref array, MinAndMaxOfArr3_log);

            int[,,] Sorted3dArray = (int[,,])array.Clone();
            Algo.SortAndPrint(ref Sorted3dArray, Sort_OX_OY_OZ_Arr3);
        }
    }
}
