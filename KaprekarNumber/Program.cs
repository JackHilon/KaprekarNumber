using System;
using System.Collections.Generic;

namespace KaprekarNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int b = 10;
            Console.Write("Enter the number (p): ");
            int p = EnterNumber();
            Console.Write("Enter the base (b)..: ");
            b = EnterNumber();


            string str;
            int number = 0;
            while (true)
            {
                StartMessage();

                str = Console.ReadLine();
                switch (str)
                {
                    case "0":
                        break;
                    case "1":
                        Console.Write("Enter new value of (p): ");
                        p = EnterNumber();
                        continue;
                    case "2":
                        Console.Write("Enter new value of (b): ");
                        b = EnterNumber();
                        continue;
                    case "3":
                        Console.Write("Enter your number: ");
                        number = EnterNumber();
                        PrintTest2(number, p, b);
                        continue;
                    case "4":
                        PartFour(b);
                        continue;
                    default:
                        continue;
                }
                break;
            }
        }
        private static void PartFour(int b)
        {
            Console.Write("Enter The limit of your list: ");
            int nLimit = EnterNumber();
            Console.Write("Enter The limit of your (p).: ");
            int pLimit = EnterNumber();
            var list1 = MakeList1(nLimit, pLimit, b);
            Console.WriteLine($"List of Kaprekar numbers ({pLimit}, {nLimit})");
            PrintList(list1);
        }
        private static void PrintList(List<int> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(" ");
        }

        private static List<int> MakeList1(int nLimit, int pLimit, int b)
        {
            var res = new List<int>();
            for (int p = 1; p <= pLimit; p++)
            {
                for (int n = 0; n <=nLimit; n++)
                {
                    if (TestKaprekar(n, p, b) == true)
                        res.Add(n);
                }
            }
            
            var res1 = UniqueList(res);
            var res2 = BubbleSort(res1);
            return res2;
        }
        private static List<int> BubbleSort(List<int> myList)
        {
            var list = CopyList(myList);
            for (int i = 0; i < list.Count; i++)
            {
                for (int k = 1; k < list.Count; k++)
                {
                    if (list[k] < list[k - 1])
                    {
                        Swap(list, k, k - 1);
                    }
                }
            }
            return list;
        }
        private static List<int> UniqueList(List<int> myList)
        {
            var list = CopyList(myList);
            for (int i = 0; i < list.Count; i++)
            {
                for (int k = 0; k < list.Count; k++)
                {
                    if (k == i)
                        continue;
                    if (list[i] == list[k])
                    {
                        list.RemoveAt(k);
                        k = k - 1;
                    }
                }
            }
            return list;
        }
        private static void Swap(List<int> list, int a, int b)
        {
            int temp = list[a];
            list[a] = list[b];
            list[b] = temp;
        }
        private static void PrintTest2(int number, int p, int b)
        {
            if (TestKaprekar(number, p, b) == true)
                Console.WriteLine($"The number ({number}) is a Kaprekar number.");
            else Console.WriteLine($"The number ({ number}) is not a Kaprekar number!!!!");
        }
        private static bool TestKaprekar(int number, int p, int b)
        {
            int beta = BetaCaculation(number, p, b);
            int alpha = AlphaCalculation(number, p, b, beta);
            int karekar = alpha + beta;
            if (number == karekar)
                return true;
            else
                return false;
        }
        private static int AlphaCalculation(int n, int p, int b, int beta)
        {
            int first = n * n - beta;
            int second = (int)Math.Pow(b, p);
            int result = first / second;
            return result;
        }
        private static int BetaCaculation(int n, int p, int b)
        {
            int result = (n * n) % ((int)Math.Pow(b, p));
            return result;
        }
        private static int EnterNumber()
        {
            int a = 0;
            try
            {
                a = int.Parse(Console.ReadLine());
                if (a < 1 || a > 10000)
                        throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message +": Enter number [1 , 10000]");
                return EnterNumber();
            }
            return a;
        }
        private static List<int> CopyList(List<int> myList)
        {
            var list = new List<int>();
            for (int i = 0; i < myList.Count; i++)
            {
                list.Add(myList[i]);
            }
            return list;
        }
        private static void StartMessage()
        {
            Console.WriteLine("(0)....................Exit");
            Console.WriteLine("(1)....................Change (p)");
            Console.WriteLine("(2)....................Change (b)");
            Console.WriteLine("(3)....................Enter a number to test");
            Console.WriteLine("(4)....................Show list of Kaprekar numbers (pLimit, nLimit)");
        }
    }
}
