using System;
using System.IO;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\S00213943\Downloads\results.txt";
            string[] fileContents = File.ReadAllLines(filePath);

            int Totalpoints = CalculatePoints(fileContents);

            Console.WriteLine($"The total points are {Totalpoints}");

            Console.ReadLine();

        }

        private static int CalculatePoints(string[] data)
        {
            int[] gradeBoundaries = new int[8] { 90, 80, 70, 60, 50, 40, 30, 0 };
            int[] higherPoints = new int[8] { 100, 88, 77, 66, 56, 46, 37, 0 };

            int totalPoints = 0, points = 0, result = 0;

            for (int i = 0; i < data.Length; i++)
            {
                result = Convert.ToInt32(data[i]);

                for (int J = 0; J < gradeBoundaries.Length; J++)
                {
                    if (result >= gradeBoundaries[J])
                    {
                        points = higherPoints[J];
                        break;
                    }
                }
                totalPoints += points;
            }
            return totalPoints;
        }
    }
}
