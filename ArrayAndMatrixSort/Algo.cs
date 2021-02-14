using System;

namespace ArrayAndMatrixSort
{
    static class Algo
    {
        public enum Axis
        {
            OX = 0,
            OY = 1,
            OZ = 2
        }
        public static void InitialArray(ref int[] arr, int arrSize = 10, int defaultvalue = 0, bool isRandom = true, int MinRandNumber = 1, int MaxRandNumber = 999)
        {
            if (arr == null)
            {
                throw new Exception("arr is null");
            }
            if (MinRandNumber > MaxRandNumber)
            {
                throw new Exception("Min rand number can't be bigger than Max rand nuber");
            }
            arrSize = ((arrSize < 1) ? 1 : ((arrSize > int.MaxValue) ? 1 : arrSize));
            arr = new int[arrSize];
            if (isRandom)
            {
                Random rand = new Random();
                for (int i = 0; i < arr.Length; i++)
                    arr[i] = rand.Next(MinRandNumber, MaxRandNumber);
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                    arr[i] = defaultvalue;
            }
        }
        public static void InitialArray(ref int[,,] arr, int arrSize = 10, int defaultvalue = 0, bool isRandom = true, int MinRandNumber = 1, int MaxRandNumber = 999)
        {
            if (arr == null)
            {
                throw new Exception("arr is null");
            }
            if (MinRandNumber > MaxRandNumber)
            {
                throw new Exception("Min rand number can't be bigger than Max rand nuber");
            }
            arrSize = ((arrSize < 1) ? 1 : ((arrSize > int.MaxValue) ? 1 : arrSize));
            arr = new int[arrSize, arrSize, arrSize];
            if (isRandom)
            {
                Random rand = new Random();
                for (int x = 0; x < arr.GetLength(0); x++)
                    for (int y = 0; y < arr.GetLength(1); y++)
                        for (int z = 0; z < arr.GetLength(2); z++)
                            arr[x, y, z] = rand.Next(MinRandNumber, MaxRandNumber);
            }
            else
            {
                for (int x = 0; x < arr.GetLength(0); x++)
                    for (int y = 0; y < arr.GetLength(1); y++)
                        for (int z = 0; z < arr.GetLength(2); z++)
                            arr[x, y, z] = defaultvalue;
            }
        }

        public static void ReverseArray(ref int[] arr)
        {
            for (int i = 0; i < arr.Length / 2; i++)
                Swap(ref arr[i], ref arr[arr.Length - i - 1]);
        }

        internal delegate void arrSort(ref int[] array);
        internal delegate void arrSort3(ref int[,,] array);

        internal static void SortAndPrint(ref int[] array, arrSort Sortfn)
        {
            FnInvoke(ref array, Sortfn);
            Print(array);
        }
        internal static void SortAndPrint(ref int[,,] array, arrSort3 Sortfn)
        {
            FnInvoke(ref array, Sortfn);
            Print(array);
        }

        internal static void FnInvoke(ref int[] array, arrSort Sortfn)
        {
            Console.WriteLine("\n" + Sortfn.Method.Name);
            Sortfn(ref array);
        }
        internal static void FnInvoke(ref int[,,] array, arrSort3 Sortfn)
        {
            Console.WriteLine("\n" + Sortfn.Method.Name);
            Sortfn(ref array);
        }

        internal static void Print(int[] arr, int? sizeOut = null)
        {
            Console.Write("\n[");
            sizeOut ??= arr.Length;
            sizeOut = (sizeOut < 0) ? 0 : ((sizeOut > arr.Length) ? arr.Length : sizeOut);
            for (int i = 0; i < sizeOut; i++)
                Console.Write(arr[i] + " ");

            Console.Write("]\n");
        }
        internal static void Print(int[,,] arr)
        {
            Console.Write("\n[");
            for (int x = 0; x < arr.GetLength(0); x++)
            {
                Console.Write("\n[");
                for (int y = 0; y < arr.GetLength(1); y++)
                {
                    Console.Write("[");
                    for (int z = 0; z < arr.GetLength(2); z++)
                        Console.Write(arr[x, y, z] + " ");
                    Console.Write("]");
                }
                Console.Write("]");
            }
            Console.Write("\n]");
        }

        #region Fn support for Sorts
        internal static int[] ConvertTo1d(int[,,] arr, Axis AxisToGet, int x = 0, int y = 0, int z = 0)
        {
            int[] temp = new int[arr.GetLength(0)]; //arr is cube index's equals by size x=y=z;
            switch (AxisToGet)
            {
                case Axis.OX:
                    for (x = 0; x < arr.GetLength(0); x++)
                        temp[x] = arr[x, y, z];
                    break;
                case Axis.OY:
                    for (y = 0; y < arr.GetLength(1); y++)
                        temp[y] = arr[x, y, z];
                    break;
                case Axis.OZ:
                    for (z = 0; z < arr.GetLength(2); z++)
                        temp[z] = arr[x, y, z];
                    break;
            }

            return temp;
        }
        internal static void Write3dFrom1d(ref int[,,] arr, int[] buffer, Axis AxisToChange, int x = 0, int y = 0, int z = 0)
        {
            switch (AxisToChange)
            {
                case Axis.OX:
                    for (x = 0; x < arr.GetLength(0); x++)
                        arr[x, y, z] = buffer[x];
                    break;
                case Axis.OY:
                    for (y = 0; y < arr.GetLength(1); y++)
                        arr[x, y, z] = buffer[y];
                    break;
                case Axis.OZ:
                    for (z = 0; z < arr.GetLength(2); z++)
                        arr[x, y, z] = buffer[z];
                    break;
            }
        }
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
        #endregion

        #region sorts
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
