using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Utils
{
    public static class FileUtils
    {

        public static List<string> GetListFromFile(string filePath)
        {
            List<string> result = null;
            if (File.Exists(filePath))
            {
                var file = File.ReadAllLines(filePath); // ReadAllLines opens and closes the file
                result = new(file);
            }
            return result;
        }
    }
}
