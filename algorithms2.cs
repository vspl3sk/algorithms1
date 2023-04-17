using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication22
{
    class PyramidSorting
    {
        //добавление элемента к пирамиде
        static int add2pyramid(double[] arr, int i, int N)
        {
            int imax;
            double buf;
            if ((2 * i + 2) < N)
            {
                if (arr[2 * i + 1] < arr[2 * i + 2]) imax = 2 * i + 2;
                else imax = 2 * i + 1;
            }
            else imax = 2 * i + 1;
            if (imax >= N) return i;
            if (arr[i] < arr[imax])
            {
                buf = arr[i];
                arr[i] = arr[imax];
                arr[imax] = buf;
                if (imax < N / 2) i = imax;
            }
            return i;
        }
        public static void sorting(double[] arr, int len)
        {
            //шаг 1: постройка пирамиды
            for (int i = len / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = add2pyramid(arr, i, len);
                if (prev_i != i) ++i;
            }

            //шаг 2: сортировка
            double buf;
            for (int k = len - 1; k > 0; --k)
            {
                buf = arr[0];
                arr[0] = arr[k];
                arr[k] = buf;
                int i = 0, prev_i = -1;
                while (i != prev_i)
                {
                    prev_i = i;
                    i = add2pyramid(arr, i, k);
                }
                foreach (double x in arr)
                {
                    System.Console.Write(x + " ");
                }
                Console.WriteLine();
            }
        }
    }
    class Test
    {
        static void Main(string[] args)
        {
            double[] arr = new double[5];

            //заполнение массив случайными числами
            Random rd = new Random();
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = rd.Next(1, 50);
            }
            System.Console.WriteLine("Множество перед пирамидальной сортировкой:");
            foreach (double x in arr)
            {
                System.Console.Write(x + " ");
            }
            Console.WriteLine();
            PyramidSorting.sorting(arr, arr.Length);
            System.Console.WriteLine("\n Множество после пирамидальной сортировки:");
            foreach (double x in arr)
            {
                System.Console.Write(x + " ");
            }
            System.Console.WriteLine("\n нажмите <Enter> для выхода");
            System.Console.ReadLine();
        }
    }
}