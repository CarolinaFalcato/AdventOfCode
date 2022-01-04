using AdventOfCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public static class Calculator
    {
        public static long GetPowerConsumption(List<string> fileList)
        {
            long result = 0;
            long gammaRate = 0;
            long epsilonRate = 0;
            if (fileList.Any())
            {
                string gammaRateBin = string.Empty;
                string epsilonRateBin = string.Empty;
                int rowLength = fileList[0].Length;
                for (int i = 0; i < rowLength; i++)
                {
                    var columnList = fileList.Select(row => row[i]).ToList();
                    var max = ListUtils.GetMostCommonValue(columnList);
                    gammaRateBin += max;
                    epsilonRateBin += max == '0' ? '1' : '0';
                }

                gammaRate = Convert.ToInt32(gammaRateBin, 2);
                epsilonRate = Convert.ToInt32(epsilonRateBin, 2);
                Console.WriteLine("Gamma rate: {0}\nEpsilon rate: {1}", gammaRate, epsilonRate);

                result = gammaRate * epsilonRate;
            }

            return result;
        }

        public static List<string> GetGeneratorRatingList(List<string> valuesList, char value, int pos)
        {
            List<string> result = null;
            if (valuesList.Any())
                result = valuesList.Where(x => x[pos] == value).ToList();

            return result;
        }

        public static long GetLifeSupportRating(List<string> fileList)
        {
            long result = 0;
            long oxygenRating = 0;
            long co2Rating = 0;
            if (fileList.Any())
            {
                List<string> oxygenRatingList = fileList;
                List<string> co2RatingList = fileList;
                List<char> columnList = null;
                char max = char.MinValue;
                int rowLength = fileList[0].Length;
                for (int i = 0; i < rowLength; i++)
                {
                    if(oxygenRatingList.Count > 1)
                    {
                        columnList = oxygenRatingList.Select(row => row[i]).ToList();
                        if (columnList.Count == 2 && columnList[0] != columnList[1])
                            max = '1';
                        else
                            max = ListUtils.GetMostCommonValue(columnList);
                        oxygenRatingList = GetGeneratorRatingList(oxygenRatingList, max, i);
                    }

                    if (co2RatingList.Count > 1)
                    {
                        columnList = co2RatingList.Select(row => row[i]).ToList();
                        if (columnList.Count == 2 && columnList[0] != columnList[1])
                            max = '1';
                        else
                            max = ListUtils.GetMostCommonValue(columnList);
                        co2RatingList = GetGeneratorRatingList(co2RatingList, max == '0' ? '1' : '0', i);
                    }
                }

                oxygenRating = oxygenRatingList.Count == 1 ? Convert.ToInt32(oxygenRatingList[0], 2) : 0;
                co2Rating = co2RatingList.Count == 1 ? Convert.ToInt32(co2RatingList[0], 2) : 0;
                Console.WriteLine("Oxygen rating rate: {0}\nCO2 rating: {1}", oxygenRating, co2Rating);

                result = oxygenRating * co2Rating;
            }

            return result;
        }
    }
}
