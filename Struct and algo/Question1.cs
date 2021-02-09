using System;

namespace Struct_and_algo
{
    class Question1
    {

        private void Part_A_sort(ref int[] array)
        {
            int[] temp = (int[])array.Clone();
            int middleIndex = temp.Length / 2;

            int outidx = 0;
            for (int i = 0; i < middleIndex; i++)
            {
                array[i] = temp[outidx++];
                array[temp.Length - 1 - i] = temp[outidx++];
            }
            array[middleIndex] = temp[^1];
        }
        private void Part_B_sort(ref int[] array)
        {
            int[] temp = (int[])array.Clone();
            int middleIndex = temp.Length / 2;
            int outidx = 0;
            for (int i = 0; i < middleIndex; i++)
            {
                array[outidx++] = temp[i];
                array[outidx++] = temp[temp.Length - 1 - i];
            }
            array[^1] = temp[middleIndex];
        }

        private void Part_C_sort(ref int[] array)
        {
            int[] temp = (int[])array.Clone();
            int doubleSize = array.Length * 2;
            array = new int[doubleSize];
            for (int i = 0; i < doubleSize; i++)
            {
                int idiv2 = (int)Math.Floor(i / 2D);
                array[i++] = temp[idiv2];
                array[i] = temp[temp.Length -1 - idiv2];
            }
        }
        


        public void Init()
        {
            Console.WriteLine("\n**************\t" + this.GetType().Name);

            const int arrSize = 8;
            int[] array = new int[arrSize];
            Algo.InitialArray(ref array, arrSize: arrSize, isRandom: true);

            int[] SortedArray = (int[])array.Clone();
            Algo.SortAndPrint(ref SortedArray, Algo.QuickSort);

            #region Part A
            int[] Part_A_CenterMax_arr = (int[])SortedArray.Clone();
            Algo.SortAndPrint(ref Part_A_CenterMax_arr, Part_A_sort);

            int[] Part_A_CenterMin_arr = (int[])SortedArray.Clone();
            Algo.ReverseArray(ref Part_A_CenterMin_arr);
            Algo.SortAndPrint(ref Part_A_CenterMin_arr, Part_A_sort);
            #endregion

            #region Part B
            int[] Part_B_arr = (int[])SortedArray.Clone();
            Algo.SortAndPrint(ref Part_B_arr, Part_B_sort);
            #endregion

            #region Part C
            int[] Part_C_arr = (int[])SortedArray.Clone();
            Algo.SortAndPrint(ref Part_C_arr, Part_C_sort);
            #endregion
        }
    }
}
