using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("1.Сортировка выбором\n2.Рекурсия\n3.Быстрая сортировка\n4.Хеш Таблица\n5.Алгоритм Дейкстра\n6.Динамическое программирование на примере последовательности Фибоначи\n7.Жадные Алгоритмы(На примере размена монет)");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch(a)
            {
                case 1:
                    
                        Console.WriteLine("Ведите количество чисел для сортировки.");
                        int N = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите числа для сортировки:");
                        int[] arr = new int[N];
                        for (int i = 0; i < arr.Length; i++)
                        {
                        arr[i] = Convert.ToInt32(Console.ReadLine());
                        }
                        Sort(arr);
                        Console.WriteLine("Отсортированный массив:");
                        for (int i = 0; i < arr.Length; i++)
                        {
                            Console.WriteLine(arr[i]);
                        }
                        Console.ReadLine();                    
                    break;
                case 2:
                    Console.WriteLine("Ведите количество чисел для обратного вывода.");
                    int n = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("Рекурсия");
                    Countdown(n);                
                    Console.ReadLine();
                    break;
                case 3:
                    CountElements(0);
                    break;
                case 4:
                    HashT();
                    break;
                case 5:
                    int[,] graph =  {
                         { 0, 6, 0, 0, 0, 0, 0, 9, 0 },
                         { 6, 0, 9, 0, 0, 0, 0, 11, 0 },
                         { 0, 9, 0, 5, 0, 6, 0, 0, 2 },
                         { 0, 0, 5, 0, 9, 16, 0, 0, 0 },
                         { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                         { 0, 0, 6, 0, 10, 0, 2, 0, 0 },
                         { 0, 0, 0, 16, 0, 2, 0, 1, 6 },
                         { 9, 11, 0, 0, 0, 0, 1, 0, 5 },
                         { 0, 0, 2, 0, 0, 0, 6, 5, 0 }
                            };               
                  
                    Dijkstra.DijkstraAlgo(graph, 0, 9);
                    Console.ReadKey();
                    break;
                        case 6:
                    Console.WriteLine("Ведите количество чисел.");

                    int q = Convert.ToInt32(Console.ReadLine());       
                    
                    int[] arr2 = new int[q];
                    for (int i = 0; i < arr2.Length; i++)
                    {
                        for (int y = 0; y <= q; ++y)
                        {
                            arr2[i] = y;
                        }                        
                    }
                    DinamicFibonachi(arr2);
                    break;
                case 7:
                    Console.WriteLine("Введите сумму которую хотите разменять:");
                    double origAmount = Convert.ToDouble(Console.ReadLine());
                    double toChange = origAmount;
                    double remainAmount = 0.0;
                    int[] coins = new int[4];
                    MakeChange(origAmount, remainAmount, coins);

                    Console.WriteLine("Лучше способ размена " +
                    toChange + " в рублях: ");
                    ShowChange(coins);
                    Console.ReadKey();
                    break;
            }
        }

        public static void DinamicFibonachi(int[] arr)
        {
            
            arr[0] = arr[1] = 1;
            for(int i = 3; i < arr.Length; ++i)
            {
                arr[i] = arr[i - 1] + arr[i - 2];
            }
            for (int i = 0; i < arr.Length; ++i)
            {
                Console.WriteLine(arr[i]);
            }
                
        }


        public static void HashT()
        {
            Hashtable hashtable = new Hashtable();            
            try
            {
                hashtable.Add("Mersedes", "G63");
                hashtable.Add("Audi", "A5");
                hashtable.Add("BMW", "M6");
                hashtable.Add("VW", "Polo");
                //hashtable.Add("VW", "Polo");
                foreach (DictionaryEntry de in hashtable)
                {
                    Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            //ICollection collection = hashtable.Keys;
            ////Console.WriteLine();
            //foreach (string a in collection)
            //{
            //    Console.WriteLine("Key = {0}", a);
            //}

            //ICollection collection2 = hashtable.Values;
            //Console.WriteLine();
            //foreach (string s in collection2)
            //{
            //    Console.WriteLine("Values = {0}", s);
            //}

        }
        public static void MakeChange(double origAmount, double
                            remainAmount, int[] coins)
        {
            if ((origAmount % 50) < origAmount)
            {
                coins[3] = (int)(origAmount / 50);
                remainAmount = origAmount % 50;
                origAmount = remainAmount;
            }
            if ((origAmount % 10) < origAmount)
            {
                coins[2] = (int)(origAmount / 10);
                remainAmount = origAmount % 10;
                origAmount = remainAmount;
            }
            if ((origAmount % 5) < origAmount)
            {
                coins[1] = (int)(origAmount / 5);
                remainAmount = origAmount % 5;
                origAmount = remainAmount;
            }
            if ((origAmount % 1) < origAmount)
            {
                coins[0] = (int)(origAmount / 1);
                remainAmount = origAmount % 1;
            }
        }
        static void ShowChange(int[] arr)
        {
            if (arr[3] > 0)
                Console.WriteLine("Количество 50 рублевых банкнот: " +
                arr[3]);
            if (arr[2] > 0)
                Console.WriteLine("Количество 10 рублевых монет: " + arr[2]);
            if (arr[1] > 0)
                Console.WriteLine("Количество 5 рублевых монет: " + arr[1]);
            if (arr[0] > 0)
                Console.WriteLine("Количество 1 рублевых монет: " + arr[0]);
        }
        static int[] Sort(int[] arr)
        {

            for (int i = 0; i < arr.Length - 1; i++)
            {                
                int min = i;//переменная для хранения мин элемента
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])//проверка на то, что след элемент меньше предыдущего
                    {
                        min = j;
                    }
                }             
                //перезапись в новый массив 
                int temp = arr[min];
                arr[min] = arr[i];
                arr[i] = temp;
            }
            return arr;
        }        

        
        static int Countdown(int i)
        {            
            Console.WriteLine(i);
            if(i <= 0)
            {
                return 0;
            }
            else
            {
                Countdown(i - 1);
            }
            return 0;
        }
        static int Sum(int [] arr)
        {
            int total = 0;
            for(int i = 0; i < arr.Length; ++i)
            {
                total += arr[i];
            }
            Console.WriteLine($"Сумма:{total}");
            return 0;
        }
        static void HashTable()
        {
            Hashtable hashtable = new Hashtable();
            
        }
        static int CountElements(int temp)
        {
            Console.WriteLine("Выбор задачи:\n1.Удвоение значения каждого элемента массива.\n2.Удвоение только первого элемента.\n3.Сумма всех элементов массива.");
            int a = Convert.ToInt32(Console.ReadLine());
            switch (a)
            {
                case 1:
                    Console.WriteLine("Ведите количество чисел для массива.");
                    int С = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите числа:");
                    int[] arr = new int[С];
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] = Convert.ToInt32(Console.ReadLine());
                    }
                    for (int i = 0; i < arr.Length; ++i)
                    {
                        arr[i] = arr[i] * 2;
                    }
                    Console.WriteLine("Удвоение каждого элеемента массива");
                    for (int i = 0; i < arr.Length; ++i)
                    {
                        Console.WriteLine(arr[i]);
                    }
                    break;
                case 2:
                    Console.WriteLine("Ведите количество чисел для массива.");
                    int d = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите числа:");
                    int[] arr2 = new int[d];
                    for (int i = 0; i < arr2.Length; i++)
                    {
                        arr2[i] = Convert.ToInt32(Console.ReadLine());
                    }
                    arr2[0] = arr2[0] * 2;
                    Console.WriteLine("Удвоение первого элеемента массива");
                    for (int i = 0; i < arr2.Length; ++i)
                    {
                        Console.WriteLine(arr2[i]);
                    }
                    break;
                case 3:
                    Console.WriteLine("Ведите количество чисел для массива.");
                    int m = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите числа:");
                    int[] arr5 = new int[m];
                    for (int i = 0; i < arr5.Length; i++)
                    {
                        arr5[i] = Convert.ToInt32(Console.ReadLine());
                    }
                    Sum(arr5);
                    break;                
            }
            return 0;
        }
    }
}
