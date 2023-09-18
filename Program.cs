/*
    CST8359 - Lab1
    Author       : Liam Chatland
    Student #    : 041000031
    Last Modified: 2023-09-17
    Professor    : Amir Afrasiabi Rad
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;


namespace Lab1
{
    class Program
    {
        private static void Main(string[] args)
        {
            IList<string> words = new List<string>();
            bool cont = true;
            while (cont)
            {
                Console.WriteLine("1: Import words from File");
                Console.WriteLine("2: Bubble sort words");
                Console.WriteLine("3: LINQ/Lambda sort words");
                Console.WriteLine("4: Count the distinct words");
                Console.WriteLine("5: Take the first 50 words");
                Console.WriteLine("6: Reverse print the words");
                Console.WriteLine("7: Get and display words that end with ‘a’ and display the count");
                Console.WriteLine("8: Get and display words that include ‘m’ and display the count");
                Console.WriteLine("9: Get and display words that are less than 4 characters long and include the letter ‘I’, and display the count");
                Console.WriteLine("x: Exit");
                Console.Write("\r\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        string fileName = "Words.txt";
                        string path = Path.Combine(Environment.CurrentDirectory, fileName);
                        words = File.ReadAllLines(path).ToList();
                        Console.WriteLine("The number of words is " + words.Count);
                        break;
                    case "2":
                        bubbleSort(words);
                        break;
                    case "3":
                        lambdaSort(words);
                        break;
                    case "4":
                        countDistinctWords(words);
                        break;
                    case "5":
                        firstFiftyWords(words);
                        break;
                    case "6":
                        reverse(words);
                        break;
                    case "7":
                        endWithA(words);
                        break;
                    case "8":
                        includeM(words);
                        break;
                    case "9":
                        lessThenFourAndincludeI(words); 
                        break;
                    case "x":
                        cont = false;
                        break;
                    default:
                        Console.WriteLine("Please enter valid input"+"\n\n");
                        continue;
                }
            }
        }

        public static IList<string> bubbleSort(IList<string> words)
        {
            string[] temp = words.ToArray();
            bool swapped = true;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < words.Count() - 1 && swapped; i++)
            {
                swapped = false;
                for (int j = 0; j < words.Count() - i - 1; j++)
                {
                    if (string.Compare(temp[j], temp[j + 1]) >= 0)
                    {
                        string tempString = temp[j];
                        temp[j] = temp[j + 1];
                        temp[j + 1] = tempString;
                        swapped = true;
                    }
                }
            }
            stopWatch.Stop();
            TimeSpan t = stopWatch.Elapsed;
            Console.WriteLine("Time elapsed: " + t.Milliseconds + "ms\n\n");
            return temp;
        }

        public static void lambdaSort(IList<string> words)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();


            var _Results = from elements in words
                           orderby elements.ToString()
                           select elements;

            stopWatch.Stop();
            TimeSpan t = stopWatch.Elapsed;
            Console.WriteLine("Time elapsed: " + t.Milliseconds + "ms\n\n");
        }

        public static void countDistinctWords(IList<string> words)
        {
            var results = (from element in words
                            select element).Distinct().Count();

            Console.WriteLine("The number of distinct words is: " + results + "\n\n");
        }

        public static void firstFiftyWords(IList<string> words)
        {
            var results = (from element in words
                            select element).Take(50);

            foreach (string value in results)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine("\n");
        }

        public static void reverse(IList<string> words)
        {
            var results = (Enumerable.Reverse(words));

            foreach (string value in results)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine("\n");
        }

        public static void endWithA(IList<string> words)
        {
            var results = (from elements in words
                            where elements.EndsWith("a")
                            select elements);

            foreach (string value in results)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine("Number of words that end with 'a': " + results.Count() + "\n\n");
        }


        public static void includeM(IList<string> words)
        {
            var results = (from elements in words
                            where elements.Contains("m")
                            select elements);

            foreach (string value in results)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine("Number of words that Include 'M': " + results.Count() + "\n\n");
        }


        public static void lessThenFourAndincludeI(IList<string> words)
        {
            var results = (from elements in words
                            where elements.Length< 4 && elements.Contains("I")
                            select elements);

            foreach (string value in results)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine("Number of words that are less then 4 and Include 'I': " + results.Count() + "\n\n");
        }
    }
}