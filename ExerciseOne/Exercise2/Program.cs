using System;
using System.IO;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\S00213943\Downloads\results.txt";

            try
            {
                string[] fileContents = File.ReadAllLines(filePath);

                int TotalPoints = 0, Points = 0, Result = 0;

                foreach (string line in fileContents)
                {

                    {
                        Result = Convert.ToInt32(line);

                        if (Result >= 90)
                            Points = 100;
                        else if (Result >= 80)
                            Points = 88;
                        else if (Result >= 70)
                            Points = 77;
                        else if (Result >= 60)
                            Points = 66;
                        else if (Result >= 50)
                            Points = 56;
                        else if (Result >= 40)
                            Points = 46;
                        else if (Result >= 30)
                            Points = 37;
                        else
                            Points = 0;

                        TotalPoints += Points;
                    }
                }
                    File.AppendAllText(filePath, Environment.NewLine + "Total Points: " + TotalPoints.ToString());
                }
            

            catch (IOException io)
            {
                Console.WriteLine(io.Message);
            }
        }
    }
}
