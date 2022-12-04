using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace day_1
{
    class Program
    {
        static void Main(string[] args)
        {

            string filePath = @"D:\advent\day_1\input.txt";
            var inputFile = File.ReadAllLines(filePath);
            var input = new List<string>(inputFile);

            void Part1()
            {
                int elfCalorie = 0;
                int currentCalorie = 0;

                foreach (var line in input)
                {
                    if (line == "")
                    {
                        if (currentCalorie > elfCalorie)
                        { elfCalorie = currentCalorie; }
                        currentCalorie = 0;
                    }
                    else
                    { currentCalorie += Int32.Parse(line); }
                }
                Console.WriteLine(elfCalorie);
            }

            Part1();

            void Part2()
            {
                int[] elfCalorieCount = new int[3];

                int currentCalorie = 0;

                foreach (var line in input)
                {
                    if (line == "")
                    {
                        for (int i = 2; i >= 0; i--)
                        {
                            if (currentCalorie > elfCalorieCount[i])
                            {
                                if (i != 2)
                                { elfCalorieCount[i + 1] = elfCalorieCount[i]; }
                                elfCalorieCount[i] = currentCalorie;
                            }
                        }

                        currentCalorie = 0;
                    }
                    else
                    { currentCalorie += Int32.Parse(line); }
                }

                int totalCalorie = 0;

                foreach (int num in elfCalorieCount)
                { totalCalorie += num; }
                Console.WriteLine(totalCalorie.ToString());
            }


            Part2();
        }
    }
}