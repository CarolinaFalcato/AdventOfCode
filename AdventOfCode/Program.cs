using AdventOfCode.Utils;
using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> fileList = FileUtils.GetListFromFile("./Resources/input.txt");

            long powerConsumption = Calculator.GetPowerConsumption(fileList);
            Console.WriteLine("Power consumption: {0}", powerConsumption);

            long lifeSupportRating = Calculator.GetLifeSupportRating(fileList);
            Console.WriteLine("Life support rating: {0}", lifeSupportRating);
        }
    }
}
