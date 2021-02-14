using System;

namespace ArrayAndMatrixSort
{
    class Question2
    {
        private void Part_A_sort(ref int[] array)
        {

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
            #endregion
        }
    }
}
