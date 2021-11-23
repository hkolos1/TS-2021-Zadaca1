using System;
using System.Linq;
using System.Diagnostics;

namespace Zadaca1
{

    class AlgoritamSelectionSort
    {
        static void Swap(ref int a, ref int b)
        {
            var t = a;
            a = b;
            b = t;
        }
        public static void SelectionSort(ref int[] input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                var min = i;

                for (var j = i + 1; j < input.Length; j++)
                {
                    if (input[min] > input[j])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    var temp = input[min];
                    input[min] = input[i];
                    input[i] = temp;
                }
            }

        }
    }

    class AlgoritamShellSort
    {
        public static void ShellSort(ref int[] array)
        {
            // Udaljenost između elemenata koji se porede
            var d = array.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < array.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        var temp = array[j - d];
                        array[j - d] = array[j];
                        array[j] = temp;
                        j = j - d;
                    }
                }
                d = d / 2;
            }
        }
        
    }
    class AlgoritamBubbleSort
    {

        public static void BubbleSort(ref int[] niz)
        {
            int velicina;
            //Opadajući ispis niza
            int temp;
            for (int i = 0; i < niz.Length; i++)
            {
                for (int j = i + 1; j < niz.Length; j++)
                {
                    if (niz[i] < niz[j])
                    {
                        temp = niz[i];
                        niz[i] = niz[j];
                        niz[j] = temp;
                    }
                }
            }
        }
        static void Trade(int []arr)
        {
            
            int j = 1;
            int temp = arr[j];
            arr[j] = arr[j + 1];
            arr[j + 1] = temp;
        }

    }
    class AlgoritamInsertionSort
    {
        public static void InsertionSort(ref int[] input)
        {

            for (int i = 0; i < input.Count(); i++)
            {
                var item = input[i];
                var currentIndex = i;

                while (currentIndex > 0 && input[currentIndex - 1] > item)
                {
                    input[currentIndex] = input[currentIndex - 1];
                    currentIndex--;
                }

                input[currentIndex] = item;
            }
        }
    }

    class AlgoritamCombSort
    {
        static int getNextGap(int gap)
        {
            gap = (gap * 10) / 13;
            if (gap < 1)
                return 1;
            return gap;
        }

        public static void CombSort(ref int[] input)
        {
            int n = input.Length;
            int gap = n;
            bool swapped = true;

            while (gap != 1 || swapped == true)
            {
                gap = getNextGap(gap);
                swapped = false;

                for (int i = 0; i < n - gap; i++)
                {
                    if (input[i] > input[i + gap])
                    {
                        int temp = input[i];
                        input[i] = input[i + gap];
                        input[i + gap] = temp;

                        swapped = true;
                    }
                }
            }
        }
    }


    class AlgoritamCocktailSort
    {
        public static void CocktailSort(ref int[] input)
        {
            bool swapped = true;
            int start = 0;
            int end = input.Length;

            while (swapped == true)
            {
                swapped = false;

                for (int i = start; i < end - 1; ++i)
                {
                    if (input[i] > input[i + 1])
                    {
                        int temp = input[i];
                        input[i] = input[i + 1];
                        input[i + 1] = temp;
                        swapped = true;
                    }
                }

                if (swapped == false)
                    break;

                swapped = false;

                end = end - 1;

                for (int i = end - 1; i >= start; i--)
                {
                    if (input[i] > input[i + 1])
                    {
                        int temp = input[i];
                        input[i] = input[i + 1];
                        input[i + 1] = temp;
                        swapped = true;
                    }
                }

                start = start + 1;
            }

        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {

            int odabirVel = 0;

            Console.Write("Odaberite zeljenu veličinu niza :\n");
            Console.Write("1 - 10\n");
            Console.Write("2 - 100\n");
            Console.Write("3 - 1000\n");
            Console.Write("4 - vlastiti unos\n");
            Console.Write("\n");

            odabirVel = Convert.ToInt32(Console.ReadLine());

            int vel = 0;

            switch (odabirVel)
            {
                case 1:
                    vel = 10;
                    break;

                case 2:
                    vel = 100;
                    break;

                case 3:
                    vel = 1000;
                    break;

                case 4:
                    Console.Write("\nUnesite broj elemenata niza:");
                    vel = Convert.ToInt32(Console.ReadLine());
                    break;

                default:
                    Console.WriteLine("Pogrešan unos");
                    return;

            }

            int Min = 0;
            int Max = 1000;
            int[] test2 = new int[vel];

            Random randNum = new Random();
            for (int i = 0; i < test2.Length; i++)
            {
                test2[i] = randNum.Next(Min, Max);
            }

            Console.Write("\nOdaberite zeljeni algoritam:\n");
            Console.Write("1 - SelectionSort\n");
            Console.Write("2 - ShellSort\n");
            Console.Write("3 - BubbleSort\n");
            Console.Write("4 - InsertionSort\n");
            Console.Write("5 - CombSort\n");
            Console.Write("6 - CocktailSort\n");
            Console.Write("\n");

            int odabir = Convert.ToInt32(Console.ReadLine());
            Stopwatch vrijeme = new Stopwatch();

            switch (odabir)
            {
                case 1:

                    Console.WriteLine("\nOdabrali ste SelectionSort\n");
                    vrijeme.Start();
                    AlgoritamSelectionSort.SelectionSort(ref test2);
                    Console.WriteLine("Sortiran niz glasi: {0}", string.Join(",", test2));
                    vrijeme.Stop();
                    Console.WriteLine("\nVrijeme potrebno za izvršenje algoritma {0} ms \n", vrijeme.Elapsed);

                    break;

                case 2:

                    Console.WriteLine("\nOdabrali ste ShellSort\n");
                    vrijeme.Start();
                    AlgoritamShellSort.ShellSort(ref test2);
                    Console.WriteLine("Sortiran niz glasi: {0}", string.Join(",", test2));
                    vrijeme.Stop();
                    Console.WriteLine("\nVrijeme potrebno za izvršenje algoritma {0} ms \n", vrijeme.Elapsed);

                    break;

                case 3:
                    Console.WriteLine("\nOdabrali ste BubbleSort\n");
                    vrijeme.Start();
                    AlgoritamBubbleSort.BubbleSort(ref test2);
                    Console.WriteLine("Sortiran niz glasi: {0}", string.Join(",", test2));
                    vrijeme.Stop();
                    Console.WriteLine("\nVrijeme potrebno za izvršenje algoritma {0} ms \n", vrijeme.Elapsed);

                    break;

                case 4:
                    Console.WriteLine("\nOdabrali ste InsertionSort\n");
                    vrijeme.Start();
                    AlgoritamInsertionSort.InsertionSort(ref test2);
                    Console.WriteLine("Sortiran niz glasi: {0}", string.Join(",", test2));
                    vrijeme.Stop();
                    Console.WriteLine("\nVrijeme potrebno za izvršenje algoritma {0} ms \n", vrijeme.Elapsed);

                    break;

                case 5:
                    Console.WriteLine("\nOdabrali ste CombSort\n");
                    vrijeme.Start();
                    AlgoritamCombSort.CombSort(ref test2);
                    Console.WriteLine("Sortiran niz glasi: {0}", string.Join(",", test2));
                    vrijeme.Stop();
                    Console.WriteLine("\nVrijeme potrebno za izvršenje algoritma {0} ms \n", vrijeme.Elapsed);

                    break;

                case 6:
                    Console.WriteLine("\nOdabrali ste CocktailSort\n");
                    vrijeme.Start();
                    AlgoritamCocktailSort.CocktailSort(ref test2);
                    Console.WriteLine("Sortiran niz glasi: {0}", string.Join(",", test2));
                    vrijeme.Stop();
                    Console.WriteLine("\nVrijeme potrebno za izvršenje algoritma {0} ms \n", vrijeme.Elapsed);

                    break;

                default:
                    Console.WriteLine("Pogrešan unos");
                    return;

            }
        }
    }
}
