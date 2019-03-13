using System;
using System.Linq;

namespace QuickSort
{
    public class Program
    {
        public static void Main()
        {
        }   

        public static void GenerateArray(int[] array) //Генерация массива
        {
            var rnd = new Random();

            for (int i = 0; i < array.Length; i++)
                array[i] = rnd.Next(0, 20);

            return;
        }

        static void Swap<T>(ref T leftElement, ref T rightElement) //Перестановка элементов
        {
            T temp;
            temp = leftElement;
            leftElement = rightElement;
            rightElement = temp;
        }

        public static void QuickSort(int[] array, int start, int end) //Сортировка
        {
            if ((end == start) | (array.Length == 0))
                return;
            var pivot = array[end];
            var i = start;
            for (int j = start; j <= end - 1; j++)
                if (array[j] <= pivot)
                {
                    Swap(ref array[i], ref array[j]);
                    i++;
                }

            Swap(ref array[i], ref array[end]);
            if (i > start) QuickSort(array, start, i - 1);
            if (i < end) QuickSort(array, i + 1, end);
        }

        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }


    }
}
