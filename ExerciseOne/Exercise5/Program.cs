using System;
using System.IO;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name :");
            string name = Console.ReadLine();

            Console.WriteLine("Enter your Student Number :");
            string studentNumber = Console.ReadLine();

            string[] subjects = new string[7];
            string[] levels = new string[7];
            string[] results = new string[7];
            int[] points = new int[7];

            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"Enter Name of Subject {i + 1} :");
                subjects[i] = Console.ReadLine();

                Console.WriteLine($"Enter Level of Subject {i + 1} :");
                levels[i] = Console.ReadLine();

                Console.WriteLine($"Enter Result of Subject {i + 1} :");
                results[i] = Console.ReadLine();
                Console.Clear();
            }

            int TotalPoints = CalculatePoints(results, levels, points);

            DisplayResults(name, studentNumber, subjects, results, levels, points, TotalPoints);
            WriteDetailsToFile(name, studentNumber, subjects, results, levels, points, TotalPoints);

            Console.ReadLine();
        }
        private static void WriteDetailsToFile(
            string name, string studentNum, string[] subjects, string[] results,
            string[] levels, int[] points, int totalPoints)
        {
            StreamWriter SW = new StreamWriter("Results.txt");

            SW.WriteLine($"Name: {name}");
            SW.WriteLine($"Student Number: {studentNum}");

            for (int i = 0; i < results.Length; i++)
            {
                SW.WriteLine($"{subjects[i],10} {levels[i],10} {results[i],10} {points[i],10}");
            }

            SW.WriteLine($"Total Points : {totalPoints}");

            SW.Flush();
            SW.Close();

            Console.WriteLine("Written Successfully to File");
        }
        private static void DisplayResults(
            string name, string studentNum, string[] subjects, string[] results,
            string[] levels, int[] points, int totalPoints)
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Student No.: {studentNum}");

            for (int i = 0; i < results.Length; i++)
            {
                Console.WriteLine($"{subjects[i],10} {levels[i],10} {results[i],10} {points[i],10}");
            }
            Console.WriteLine($"Total Points : {totalPoints}");
        }
        private static int CalculatePoints(string[] data, string[] levels, int[] studentPoints)
        {
            int[] gradeBoundaries = new int[] { 90, 80, 70, 60, 50, 40, 30, 0 };
            int[] higherPoints = new int[] { 100, 88, 77, 66, 56, 46, 37, 0 };
            int[] ordinaryPoints = new int[] { 56, 46, 37, 28, 20, 12, 0, 0 };

            int totalPoints = 0, points = 0, result = 0;

            for (int i = 0; i < data.Length; i++)
            {
                result = Convert.ToInt32(data[i]);

                for (int J = 0; J < gradeBoundaries.Length; J++)
                {
                    if (result >= gradeBoundaries[J])
                    {
                        points = levels[i].ToLower().Equals("h") ? higherPoints[J] : ordinaryPoints[J];
                        break;
                    }
                }
                studentPoints[i] = points;
            }

            Array.Sort(studentPoints);
            Array.Reverse(studentPoints);

            for (int i = 0; i < 6; i++)
            {
                totalPoints += studentPoints[i];
            }
            return totalPoints;
        }
    }
}
