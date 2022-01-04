using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Utils
{
    public static class ListUtils
    {

        public static char GetMostCommonValue(List<char> charList)
        {
            char result = char.MinValue;
            if (charList.Any())
            {
                result = charList.GroupBy(x => x)
                    .Select(x => new { num = x, count = x.Count() })
                    .OrderByDescending(g => g.count)
                    .Select(g => g.num).First().Key;
            }

            return result;
        }
    }
}
