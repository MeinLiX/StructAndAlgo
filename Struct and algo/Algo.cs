using System;

namespace Struct_and_algo
{
    static class Algo
    {
        public static void InitialArray(ref int[] arr, int arrSize = 10, int defaultvalue = 0, bool isRandom = true,int MinRandNumber=1, int MaxRandNumber=999)
        {
            if (arr == null)
            {
                throw new Exception("arr is null");
            }
            arrSize = ((arrSize < 1) ? 1 : ((arrSize > int.MaxValue) ? 1 : arrSize));
            arr = new int[arrSize];
            if (isRandom)
            {
                Random rand = new Random();
                for (int i = 0; i < arr.Length; i++)
                    arr[i] = rand.Next(1, 999);
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                    arr[i] = defaultvalue;
            }
        }
        public static void ReverseArray(ref int[] arr)
        {
            for (int i = 0; i < arr.Length / 2; i++)
                Swap(ref arr[i], ref arr[arr.Length - i - 1]);
        }

        internal delegate void arrSort(ref int[] array);

        internal static void SortAndPrint(ref int[] array, arrSort Sortfn)
        {
            Console.WriteLine("\n" + Sortfn.Method.Name);
            Sortfn(ref array);
            Print(array);
        }

        internal static void Print(int[] arr, int? sizeOut = null)
        {
            Console.Write("\n[");
            sizeOut ??= arr.Length;
            sizeOut = ((sizeOut < 0) ? 0 : ((sizeOut > arr.Length) ? arr.Length : sizeOut));
            for (int i = 0; i < sizeOut; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.Write("]\n");
        }

        #region Fn support for Sorts
        internal static void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }
        private static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
                if (array[i] < array[maxIndex])
                    Swap(ref array[++pivot], ref array[i]);

            Swap(ref array[++pivot], ref array[maxIndex]);
            return pivot;
        }
        private static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex <= maxIndex)
            {
                var pivotIndex = Partition(array, minIndex, maxIndex);
                QuickSort(array, minIndex, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, maxIndex);
            }
            return array;
        }
        #endregion

        #region sorts
        public static void QuickSort(ref int[] array)
        {
            array = QuickSort(array, 0, array.Length - 1);
        }

        public static void BubbleSort(ref int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                for (int j = i + 1; j < arr.Length; j++)
                    if (arr[i] > arr[j])
                        Swap(ref arr[i], ref arr[j]);

        }
        #endregion
    }
}
