using System;
using System.Linq;

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
        public static void InitialArray(ref int[,] arr, int arrSize = 10, int defaultvalue = 0, bool isRandom = true, int MinRandNumber = 1, int MaxRandNumber = 999)
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
            arr = new int[arrSize, arrSize];
            if (isRandom)
            {
                Random rand = new Random();
                for (int x = 0; x < arr.GetLength((int)Axis.OX); x++)
                    for (int y = 0; y < arr.GetLength((int)Axis.OY); y++)
                        arr[x, y] = rand.Next(MinRandNumber, MaxRandNumber);
            }
            else
            {
                for (int x = 0; x < arr.GetLength(0); x++)
                    for (int y = 0; y < arr.GetLength(1); y++)
                        arr[x, y] = defaultvalue;
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
                for (int x = 0; x < arr.GetLength((int)Axis.OX); x++)
                    for (int y = 0; y < arr.GetLength((int)Axis.OY); y++)
                        for (int z = 0; z < arr.GetLength((int)Axis.OZ); z++)
                            arr[x, y, z] = rand.Next(MinRandNumber, MaxRandNumber);
            }
            else
            {
                for (int x = 0; x < arr.GetLength((int)Axis.OX); x++)
                    for (int y = 0; y < arr.GetLength((int)Axis.OY); y++)
                        for (int z = 0; z < arr.GetLength((int)Axis.OZ); z++)
                            arr[x, y, z] = defaultvalue;
            }
        }

        public static void ReverseArray(ref int[] arr)
        {
            for (int i = 0; i < arr.GetLength((int)Axis.OX) / 2; i++)
                Swap(ref arr[i], ref arr[arr.GetLength((int)Axis.OX) - i - 1]);
        }
        public static void ReverseArray(ref int[,] arr)
        {
            for (int x = 0; x < arr.GetLength((int)Axis.OX) / 2; x++)
                for (int y = 0; y < arr.GetLength((int)Axis.OY) / 2; y++)
                {
                    Swap(ref arr[x,y], ref arr[arr.GetLength((int)Axis.OX) - x - 1, arr.GetLength((int)Axis.OY) - y-1]);
                }
        }

        internal delegate void arrSort1d(ref int[] array);
        internal delegate void arrSort2d(ref int[,] array);
        internal delegate void arrSort3d(ref int[,,] array);

        internal static void SortAndPrint(ref int[] array, arrSort1d Sortfn)
        {
            FnInvoke(ref array, Sortfn);
            Print(array);
        }
        internal static void SortAndPrint(ref int[,] array, arrSort2d Sortfn)
        {
            FnInvoke(ref array, Sortfn);
            Print(array);
        }
        internal static void SortAndPrint(ref int[,,] array, arrSort3d Sortfn)
        {
            FnInvoke(ref array, Sortfn);
            Print(array);
        }

        internal static void FnInvoke(ref int[] array, arrSort1d Sortfn)
        {
            Console.WriteLine("\n" + Sortfn.Method.Name);
            Sortfn(ref array);
        }
        internal static void FnInvoke(ref int[,] array, arrSort2d Sortfn)
        {
            Console.WriteLine("\n" + Sortfn.Method.Name);
            Sortfn(ref array);
        }
        internal static void FnInvoke(ref int[,,] array, arrSort3d Sortfn)
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
        internal static void Print(int[,] arr)
        {
            Console.Write("\n[");
            for (int x = 0; x < arr.GetLength((int)Axis.OX); x++)
            {
                Console.Write("\n[");
                for (int y = 0; y < arr.GetLength((int)Axis.OY); y++)
                    Console.Write(arr[x, y] + " ");
                Console.Write("]");
            }
            Console.Write("\n]");
        }
        internal static void Print(int[,,] arr)
        {
            Console.Write("\n[");
            for (int x = 0; x < arr.GetLength((int)Axis.OX); x++)
            {
                Console.Write("\n[");
                for (int y = 0; y < arr.GetLength((int)Axis.OY); y++)
                {
                    Console.Write("[");
                    for (int z = 0; z < arr.GetLength((int)Axis.OZ); z++)
                        Console.Write(arr[x, y, z] + " ");
                    Console.Write("]");
                }
                Console.Write("]");
            }
            Console.Write("\n]");
        }

        #region Fn support for Sorts
       
        internal static int[] ConvertTo1d(int[,] arr)
        {
            return arr.Cast<int>().ToArray();
        }
       
        internal static void ConvertTo2d(ref int[,] arr, int[] array_1d)
        {
            for (int x = 0; x < array_1d.Length; x++)
            {
                arr[x % arr.GetLength((int)Algo.Axis.OX), (int)Math.Floor((decimal)x / arr.GetLength((int)Algo.Axis.OX))] = array_1d[x];
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
            array = QuickSort(array, 0, array.GetLength((int)Axis.OX) - 1);
        }
        public static void BubbleSort(ref int[] arr)
        {
            for (int i = 0; i < arr.GetLength((int)Axis.OX); i++)
                for (int j = i + 1; j < arr.GetLength((int)Axis.OX); j++)
                    if (arr[i] > arr[j])
                        Swap(ref arr[i], ref arr[j]);

        }
        #endregion
    }
}
