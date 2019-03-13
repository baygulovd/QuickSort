using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickSort;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        /*
         *  Сортировка массива из трёх элементов. 
         *  После сортировки второй элемент больше первого, третий больше второго
        */
        public void TestMethod1()
        {
            int[] array = new int[3];
            Program.GenerateArray(array);
            Program.QuickSort(array);

            for (int i = 0; i < array.Length - 1; i++)
            {
                Assert.IsFalse(array[i] > array[i + 1]);
            }
        }

        [TestMethod]
        /*
         *  Сортировка массива из 100 одинаковых числе работает корректно
         */
        public void TestMethod2()
        {
            int[] arrayBefore = new int[100];
            for (int i = 0; i < arrayBefore.Length; i++)
            {
                arrayBefore[i] = 10;
            }
            int[] arrayAfter = arrayBefore;
            Program.QuickSort(arrayAfter);

            Assert.IsTrue(arrayAfter.SequenceEqual(arrayBefore));
        }

        [TestMethod]
        /*
         *  Сортировка массива из 1000 случайных элементов.
         *  Проверить что 10 случайных пар элементов массива после сортировки упорядочены
         *  (из пары больший тот, чей индекс больше)
         */
        public void TestMethod3()
        {
            int[] array = new int[1000];
            Program.GenerateArray(array);
            Program.QuickSort(array);
            var rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                int firstIndex = rnd.Next(array.Length);
                int secondIndex = rnd.Next(array.Length);
                int a = array[firstIndex]; 
                int b = array[secondIndex];

                if (firstIndex == secondIndex)
                    i--; //Добавляем еще одну итерацию, т.к. по факту это не пара
                else if (firstIndex > secondIndex)
                    Assert.IsTrue(a > b);
                else if (firstIndex < secondIndex)
                    Assert.IsTrue(a < b);
            }
        }

        [TestMethod]
        // Сортировка пустого массива работает корректно
        public void TestMethod4()
        {
            int[] array = new int[0];
            Program.GenerateArray(array);
            Program.QuickSort(array);

            Assert.IsTrue(array.Length == 0);
        }

        [TestMethod]
        public void TestMethod5()
        {
            int[] array = new int[1500000000];
            Program.GenerateArray(array);
            Program.QuickSort(array);

            for (int i = 0; i < array.Length - 1; i++)
            {
                Assert.IsFalse(array[i] > array[i + 1]);
            }
        }
    }
}
